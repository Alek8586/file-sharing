namespace FileSharing.WinForms
{
    partial class CreateShareForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.btnAddShare = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbUsers
            // 
            this.cbUsers.DisplayMember = "Name";
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(12, 12);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(156, 21);
            this.cbUsers.TabIndex = 0;
            // 
            // btnAddShare
            // 
            this.btnAddShare.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddShare.Location = new System.Drawing.Point(12, 39);
            this.btnAddShare.Name = "btnAddShare";
            this.btnAddShare.Size = new System.Drawing.Size(75, 23);
            this.btnAddShare.TabIndex = 1;
            this.btnAddShare.Text = "Добавить";
            this.btnAddShare.UseVisualStyleBackColor = true;
            this.btnAddShare.Click += new System.EventHandler(this.btnAddShare_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 39);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CreateShareForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dial;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 74);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddShare);
            this.Controls.Add(this.cbUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateShareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateShareForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Button btnAddShare;
        private System.Windows.Forms.Button btnCancel;
    }
}