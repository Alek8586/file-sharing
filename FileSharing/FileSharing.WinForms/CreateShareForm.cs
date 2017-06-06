using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSharing.WinForms
{
    public partial class CreateShareForm : Form
    {
        private readonly ServiceClient _client;

        public CreateShareForm()
        {
            InitializeComponent();

            _client = new ServiceClient("http://localhost:53637/api/");
            cbUsers.DataSource = _client.GetUsers();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddShare_Click(object sender, EventArgs e)
        {
            try
            {
                var item = cbUsers.SelectedItem as Model.User;
                if (item != null)
                {
                    _client.CreateShare(AddShare.fileId, item.Id);
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось создать доступ к файлу: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
