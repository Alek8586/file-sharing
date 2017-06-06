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
    public partial class CreateUserForm : Form
    {
        private readonly ServiceClient _client;

        public CreateUserForm()
        {
            InitializeComponent();
            _client = new ServiceClient("http://localhost:53637/api/");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((tbEmail.Text != "") && (tbName.Text != ""))
            {
                _client.CreateUser(tbName.Text, tbEmail.Text);
                this.Close();
            }
            else
                MessageBox.Show("Одно из полей не заполнено", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
