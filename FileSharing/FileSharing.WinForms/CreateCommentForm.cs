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
    public partial class CreateCommentForm : Form
    {
        private readonly ServiceClient _client;

        public CreateCommentForm()
        {
            InitializeComponent();
            _client = new ServiceClient("http://localhost:53637/api/");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if (rtbComment.Text != "")
            {
                _client.CreateComment(AddComment.fileId, AddComment.userId, rtbComment.Text);
                this.Close();
            }
            else MessageBox.Show("Необходимо написать комментарий к файлу", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
