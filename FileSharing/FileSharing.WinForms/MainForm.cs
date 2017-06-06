using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FileSharing.Model;
using File = System.IO.File;

namespace FileSharing.WinForms
{
    public partial class MainForm : Form
    {
        private Guid _userId;
        private ServiceClient _client;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileContent = File.ReadAllBytes(dialog.FileName);
                        var file = new Model.File
                        {
                            Name = Path.GetFileName(dialog.FileName),
                            Owner = new User
                            {
                                Id = _userId
                            }
                        };
                        var fileId = _client.CreateFile(file);
                        _client.UploadFileContent(fileId, fileContent);
                        RefreshFileList();
                        MessageBox.Show($"Файл {file.Name} успешно загружен", "Загрузка файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось загрузить файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshFileList()
        {
            lbFiles.DataSource = _client.GetUserFiles();
        }

        private void RefreshUserList()
        {
            try
            {
                lbUsers.DataSource = _client.GetUsers();
            }
            catch
            {
                lbUsers.DataSource = null;
            }
        }

        private void RefreshUsersSharedList()
        {
            var item = lbFiles.SelectedItem as Model.File;
            if (item != null)
            {
                lbSharedUsers.DataSource = _client.GetUsersSharedFile(item.Id);
            }
            else
            {
                lbSharedUsers.DataSource = null;
                lbSharedUsers.DisplayMember = "Name";
            }
        }

        private void RefreshFileSharedList()
        {
            var item = lbUsers.SelectedItem as Model.User;
            if (item != null)
            {
                lbFilesShared.DataSource = _client.GetFilesSharedUser(item.Id);
            }
            else
            {
                lbFilesShared.DataSource = null;
                lbFilesShared.DisplayMember = "Name";
            }
        }

        private void RefreshCommentLis()
        {
            var item = lbFiles.SelectedItem as Model.File;
            if (item != null)
            {
                dgvComments.DataSource = _client.GetComments(item.Id);
            }
            else
            {
                dgvComments.DataSource = null;
            }
        }

        private void RefreshCommentListSh()
        {
            var item = lbFilesShared.SelectedItem as Model.File;
            if (item != null)
            {
                dgvCommentSh.DataSource = _client.GetComments(item.Id);
            }
            else
            {
                dgvCommentSh.DataSource = null;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _client = new ServiceClient("http://localhost:53637/api/");
                RefreshUserList();
                var item = lbUsers.SelectedItem as Model.User;
                if (item != null)
                {
                    _userId = _client.GetUser(item.Id).Id;
                }
                _client = new ServiceClient("http://localhost:53637/api/", _userId);
                RefreshFileList();
                lblUserName.Text = _client.GetUser(_userId).Name;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Произошла ошибка. {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lbFiles.SelectedItem as Model.File;
                if (item != null)
                {
                    _client.DeleteFile(item.Id);
                    RefreshFileList();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lbFiles.SelectedItem as Model.File;
                if (item != null)
                {
                    using (var dialog = new SaveFileDialog())
                    {
                        dialog.FileName = item.Name;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            var content = _client.DownloadFile(item.Id);
                            File.WriteAllBytes(dialog.FileName, content);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось скачать файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            CreateUserForm createUserForm = new CreateUserForm();
            if (createUserForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshUserList();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lbUsers.SelectedItem as Model.User;
                DialogResult result = MessageBox.Show($"Вы уверены что хотите удалить пользователя: {item.Name}",
                    "Удалить?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    if (item != null)
                    {
                        _client.DeleteUser(item.Id);
                        RefreshUserList();
                    }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить пользователя, текст ошибки: {Environment.NewLine}{exception.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var item = lbUsers.SelectedItem as Model.User;
                if (item != null)
                {
                    lblUserInfo.Text = "Name - " + _client.GetUser(item.Id).Name
                        + "\nE-mail - " + _client.GetUser(item.Id).Email;
                    _userId = _client.GetUser(item.Id).Id;
                    _client = new ServiceClient("http://localhost:53637/api/", _userId);
                    RefreshFileList();
                    RefreshUsersSharedList();
                    lblUserName.Text = _client.GetUser(_userId).Name;
                    lblUserShName.Text = lblUserName.Text;
                    RefreshFileSharedList();
                    RefreshCommentLis();
                    RefreshCommentListSh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Произошла ошибка: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbFiles_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshUsersSharedList();
            RefreshCommentLis();
        }

        private void btnDeleteShare_Click(object sender, EventArgs e)
        {
            try
            {
                var file = lbFiles.SelectedItem as Model.File;
                if (file != null)
                {
                    var user = lbSharedUsers.SelectedItem as Model.User;
                    if (user != null)
                    {
                        _client.DeleteShare(_client.GetShareId(file.Id, user.Id));
                        RefreshUsersSharedList();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить доступ к файлу, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddShare_Click(object sender, EventArgs e)
        {
            var file = lbFiles.SelectedItem as Model.File;
            if (file != null)
            {
                AddShare.fileId = file.Id;
                CreateShareForm createShareForm = new CreateShareForm();
                if (createShareForm.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshUsersSharedList();
                }
            }
        }

        private void btnDownloadSharedFile_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lbFilesShared.SelectedItem as Model.File;
                if (item != null)
                {
                    using (var dialog = new SaveFileDialog())
                    {
                        dialog.FileName = item.Name;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            var content = _client.DownloadFile(item.Id);
                            File.WriteAllBytes(dialog.FileName, content);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось скачать файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            var file = lbFiles.SelectedItem as Model.File;
            {
                var user = lbUsers.SelectedItem as Model.User;
                if (file != null && user != null)
                {
                    AddComment.fileId = file.Id;
                    AddComment.userId = user.Id;
                    CreateCommentForm createCommentForm = new CreateCommentForm();
                    if (createCommentForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshCommentLis();
                    }
                }
            }
        }

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            try
            {
                var commentId = (Guid)dgvComments.SelectedRows[0].Cells[0].Value;
                var author = (Guid)dgvComments.SelectedRows[0].Cells[2].Value;
                var user = lbUsers.SelectedItem as Model.User;
                if (_client.GetUser(author).Id == user.Id)
                {
                    _client.DeleteComment((Guid)commentId);
                    RefreshCommentLis();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить комментарий. Текст ошибки: {Environment.NewLine}{exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbFilesShared_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshCommentListSh();
        }

        private void btnDeleteCommentSh_Click(object sender, EventArgs e)
        {
            try
            {
                var commentId = (Guid)dgvCommentSh.SelectedRows[0].Cells[0].Value;
                var author = (Guid)dgvCommentSh.SelectedRows[0].Cells[2].Value;
                var user = lbUsers.SelectedItem as Model.User;
                if (_client.GetUser(author).Id == user.Id)
                {
                    _client.DeleteComment((Guid)commentId);
                    RefreshCommentListSh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить комментарий. Текст ошибки: {Environment.NewLine}{exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCommentSh_Click(object sender, EventArgs e)
        {
            var file = lbFilesShared.SelectedItem as Model.File;
            {
                var user = lbUsers.SelectedItem as Model.User;
                if (file != null && user != null)
                {
                    AddComment.fileId = file.Id;
                    AddComment.userId = user.Id;
                    CreateCommentForm createCommentForm = new CreateCommentForm();
                    if (createCommentForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshCommentListSh();
                    }
                }
            }
        }
    }
}
