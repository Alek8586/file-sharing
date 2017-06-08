namespace FileSharing.WinForms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.lblUserNameLabel = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.tpFilesUser = new System.Windows.Forms.TabPage();
            this.gbComment = new System.Windows.Forms.GroupBox();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.commentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddComment = new System.Windows.Forms.Button();
            this.btnDeleteComment = new System.Windows.Forms.Button();
            this.gbSharedUsers = new System.Windows.Forms.GroupBox();
            this.lbSharedUsers = new System.Windows.Forms.ListBox();
            this.btnAddShare = new System.Windows.Forms.Button();
            this.btnDeleteShare = new System.Windows.Forms.Button();
            this.gpFiles = new System.Windows.Forms.GroupBox();
            this.tpSharedFiles = new System.Windows.Forms.TabPage();
            this.grbCommentSh = new System.Windows.Forms.GroupBox();
            this.dgvCommentSh = new System.Windows.Forms.DataGridView();
            this.btnAddCommentSh = new System.Windows.Forms.Button();
            this.btnDeleteCommentSh = new System.Windows.Forms.Button();
            this.btnDownloadSharedFile = new System.Windows.Forms.Button();
            this.lbFilesShared = new System.Windows.Forms.ListBox();
            this.lblUserShName = new System.Windows.Forms.Label();
            this.lblUserSh = new System.Windows.Forms.Label();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.gbUsers.SuspendLayout();
            this.tpFilesUser.SuspendLayout();
            this.gbComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).BeginInit();
            this.gbSharedUsers.SuspendLayout();
            this.gpFiles.SuspendLayout();
            this.tpSharedFiles.SuspendLayout();
            this.grbCommentSh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommentSh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserNameLabel
            // 
            this.lblUserNameLabel.AutoSize = true;
            this.lblUserNameLabel.Location = new System.Drawing.Point(3, 0);
            this.lblUserNameLabel.Name = "lblUserNameLabel";
            this.lblUserNameLabel.Size = new System.Drawing.Size(129, 13);
            this.lblUserNameLabel.TabIndex = 0;
            this.lblUserNameLabel.Text = "Текущий пользователь:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(138, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(35, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "label1";
            // 
            // lbFiles
            // 
            this.lbFiles.DisplayMember = "Name";
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(6, 19);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(156, 186);
            this.lbFiles.TabIndex = 2;
            this.lbFiles.SelectedValueChanged += new System.EventHandler(this.lbFiles_SelectedValueChanged);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(6, 211);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 3;
            this.btnAddFile.Text = "Добавить";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(87, 211);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFile.TabIndex = 4;
            this.btnDeleteFile.Text = "Удалить";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(6, 240);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(156, 23);
            this.btnDownloadFile.TabIndex = 5;
            this.btnDownloadFile.Text = "Скачать";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpUsers);
            this.tabControl1.Controls.Add(this.tpFilesUser);
            this.tabControl1.Controls.Add(this.tpSharedFiles);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(368, 492);
            this.tabControl1.TabIndex = 7;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.gbUsers);
            this.tpUsers.Location = new System.Drawing.Point(4, 22);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsers.Size = new System.Drawing.Size(360, 466);
            this.tpUsers.TabIndex = 0;
            this.tpUsers.Text = "Пользователи";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.lbUsers);
            this.gbUsers.Controls.Add(this.btnAddUser);
            this.gbUsers.Controls.Add(this.btnDeleteUser);
            this.gbUsers.Controls.Add(this.lblUserInfo);
            this.gbUsers.Location = new System.Drawing.Point(6, 6);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(346, 454);
            this.gbUsers.TabIndex = 10;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "Пользователи";
            // 
            // lbUsers
            // 
            this.lbUsers.DisplayMember = "Name";
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(6, 19);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(334, 342);
            this.lbUsers.TabIndex = 5;
            this.lbUsers.SelectedValueChanged += new System.EventHandler(this.lbUsers_SelectedValueChanged);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(6, 425);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 8;
            this.btnAddUser.Text = "Добавить";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(265, 425);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "Удалить";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUserInfo.Location = new System.Drawing.Point(6, 376);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(49, 34);
            this.lblUserInfo.TabIndex = 6;
            this.lblUserInfo.Text = "Name\r\nEmail";
            // 
            // tpFilesUser
            // 
            this.tpFilesUser.Controls.Add(this.gbComment);
            this.tpFilesUser.Controls.Add(this.gbSharedUsers);
            this.tpFilesUser.Controls.Add(this.gpFiles);
            this.tpFilesUser.Controls.Add(this.lblUserNameLabel);
            this.tpFilesUser.Controls.Add(this.lblUserName);
            this.tpFilesUser.Location = new System.Drawing.Point(4, 22);
            this.tpFilesUser.Name = "tpFilesUser";
            this.tpFilesUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpFilesUser.Size = new System.Drawing.Size(360, 466);
            this.tpFilesUser.TabIndex = 1;
            this.tpFilesUser.Text = "Файлы пользователя";
            this.tpFilesUser.UseVisualStyleBackColor = true;
            // 
            // gbComment
            // 
            this.gbComment.Controls.Add(this.dgvComments);
            this.gbComment.Controls.Add(this.btnAddComment);
            this.gbComment.Controls.Add(this.btnDeleteComment);
            this.gbComment.Location = new System.Drawing.Point(7, 292);
            this.gbComment.Name = "gbComment";
            this.gbComment.Size = new System.Drawing.Size(344, 169);
            this.gbComment.TabIndex = 21;
            this.gbComment.TabStop = false;
            this.gbComment.Text = "Комментарии к файлу";
            // 
            // dgvComments
            // 
            this.dgvComments.AllowUserToAddRows = false;
            this.dgvComments.AllowUserToDeleteRows = false;
            this.dgvComments.AutoGenerateColumns = false;
            this.dgvComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComments.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fileIdDataGridViewTextBoxColumn,
            this.userIdDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn});
            this.dgvComments.DataSource = this.commentBindingSource;
            this.dgvComments.GridColor = System.Drawing.SystemColors.Window;
            this.dgvComments.Location = new System.Drawing.Point(6, 20);
            this.dgvComments.Margin = new System.Windows.Forms.Padding(4);
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.ReadOnly = true;
            this.dgvComments.RowHeadersVisible = false;
            this.dgvComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComments.Size = new System.Drawing.Size(330, 113);
            this.dgvComments.TabIndex = 18;
            // 
            // commentBindingSource
            // 
            this.commentBindingSource.DataSource = typeof(FileSharing.Model.Comment);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(6, 140);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(139, 23);
            this.btnAddComment.TabIndex = 11;
            this.btnAddComment.Text = "Добавить комментраий";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // btnDeleteComment
            // 
            this.btnDeleteComment.Location = new System.Drawing.Point(197, 140);
            this.btnDeleteComment.Name = "btnDeleteComment";
            this.btnDeleteComment.Size = new System.Drawing.Size(139, 23);
            this.btnDeleteComment.TabIndex = 13;
            this.btnDeleteComment.Text = "Удалить комментраий";
            this.btnDeleteComment.UseVisualStyleBackColor = true;
            this.btnDeleteComment.Click += new System.EventHandler(this.btnDeleteComment_Click);
            // 
            // gbSharedUsers
            // 
            this.gbSharedUsers.Controls.Add(this.lbSharedUsers);
            this.gbSharedUsers.Controls.Add(this.btnAddShare);
            this.gbSharedUsers.Controls.Add(this.btnDeleteShare);
            this.gbSharedUsers.Location = new System.Drawing.Point(181, 16);
            this.gbSharedUsers.Name = "gbSharedUsers";
            this.gbSharedUsers.Size = new System.Drawing.Size(170, 270);
            this.gbSharedUsers.TabIndex = 20;
            this.gbSharedUsers.TabStop = false;
            this.gbSharedUsers.Text = "Файл доступен";
            // 
            // lbSharedUsers
            // 
            this.lbSharedUsers.DisplayMember = "Name";
            this.lbSharedUsers.FormattingEnabled = true;
            this.lbSharedUsers.Location = new System.Drawing.Point(6, 19);
            this.lbSharedUsers.Name = "lbSharedUsers";
            this.lbSharedUsers.Size = new System.Drawing.Size(156, 186);
            this.lbSharedUsers.TabIndex = 6;
            // 
            // btnAddShare
            // 
            this.btnAddShare.Location = new System.Drawing.Point(6, 211);
            this.btnAddShare.Name = "btnAddShare";
            this.btnAddShare.Size = new System.Drawing.Size(156, 23);
            this.btnAddShare.TabIndex = 7;
            this.btnAddShare.Text = "Добавить доступ";
            this.btnAddShare.UseVisualStyleBackColor = true;
            this.btnAddShare.Click += new System.EventHandler(this.btnAddShare_Click);
            // 
            // btnDeleteShare
            // 
            this.btnDeleteShare.Location = new System.Drawing.Point(6, 240);
            this.btnDeleteShare.Name = "btnDeleteShare";
            this.btnDeleteShare.Size = new System.Drawing.Size(156, 23);
            this.btnDeleteShare.TabIndex = 10;
            this.btnDeleteShare.Text = "Удалить доступ";
            this.btnDeleteShare.UseVisualStyleBackColor = true;
            this.btnDeleteShare.Click += new System.EventHandler(this.btnDeleteShare_Click);
            // 
            // gpFiles
            // 
            this.gpFiles.Controls.Add(this.lbFiles);
            this.gpFiles.Controls.Add(this.btnAddFile);
            this.gpFiles.Controls.Add(this.btnDeleteFile);
            this.gpFiles.Controls.Add(this.btnDownloadFile);
            this.gpFiles.Location = new System.Drawing.Point(7, 16);
            this.gpFiles.Name = "gpFiles";
            this.gpFiles.Size = new System.Drawing.Size(168, 270);
            this.gpFiles.TabIndex = 19;
            this.gpFiles.TabStop = false;
            this.gpFiles.Text = "Файлы пользователя";
            // 
            // tpSharedFiles
            // 
            this.tpSharedFiles.Controls.Add(this.grbCommentSh);
            this.tpSharedFiles.Controls.Add(this.btnDownloadSharedFile);
            this.tpSharedFiles.Controls.Add(this.lbFilesShared);
            this.tpSharedFiles.Controls.Add(this.lblUserShName);
            this.tpSharedFiles.Controls.Add(this.lblUserSh);
            this.tpSharedFiles.Location = new System.Drawing.Point(4, 22);
            this.tpSharedFiles.Name = "tpSharedFiles";
            this.tpSharedFiles.Size = new System.Drawing.Size(360, 466);
            this.tpSharedFiles.TabIndex = 2;
            this.tpSharedFiles.Text = "Доступные файлы";
            this.tpSharedFiles.UseVisualStyleBackColor = true;
            // 
            // grbCommentSh
            // 
            this.grbCommentSh.Controls.Add(this.dgvCommentSh);
            this.grbCommentSh.Controls.Add(this.btnAddCommentSh);
            this.grbCommentSh.Controls.Add(this.btnDeleteCommentSh);
            this.grbCommentSh.Location = new System.Drawing.Point(6, 289);
            this.grbCommentSh.Name = "grbCommentSh";
            this.grbCommentSh.Size = new System.Drawing.Size(344, 169);
            this.grbCommentSh.TabIndex = 22;
            this.grbCommentSh.TabStop = false;
            this.grbCommentSh.Text = "Комментарии к файлу";
            // 
            // dgvCommentSh
            // 
            this.dgvCommentSh.AllowUserToAddRows = false;
            this.dgvCommentSh.AllowUserToDeleteRows = false;
            this.dgvCommentSh.AutoGenerateColumns = false;
            this.dgvCommentSh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommentSh.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvCommentSh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommentSh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvCommentSh.DataSource = this.commentBindingSource;
            this.dgvCommentSh.GridColor = System.Drawing.SystemColors.Window;
            this.dgvCommentSh.Location = new System.Drawing.Point(6, 20);
            this.dgvCommentSh.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCommentSh.Name = "dgvCommentSh";
            this.dgvCommentSh.ReadOnly = true;
            this.dgvCommentSh.RowHeadersVisible = false;
            this.dgvCommentSh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommentSh.Size = new System.Drawing.Size(330, 113);
            this.dgvCommentSh.TabIndex = 18;
            // 
            // btnAddCommentSh
            // 
            this.btnAddCommentSh.Location = new System.Drawing.Point(6, 140);
            this.btnAddCommentSh.Name = "btnAddCommentSh";
            this.btnAddCommentSh.Size = new System.Drawing.Size(139, 23);
            this.btnAddCommentSh.TabIndex = 11;
            this.btnAddCommentSh.Text = "Добавить комментраий";
            this.btnAddCommentSh.UseVisualStyleBackColor = true;
            this.btnAddCommentSh.Click += new System.EventHandler(this.btnAddCommentSh_Click);
            // 
            // btnDeleteCommentSh
            // 
            this.btnDeleteCommentSh.Location = new System.Drawing.Point(197, 140);
            this.btnDeleteCommentSh.Name = "btnDeleteCommentSh";
            this.btnDeleteCommentSh.Size = new System.Drawing.Size(139, 23);
            this.btnDeleteCommentSh.TabIndex = 13;
            this.btnDeleteCommentSh.Text = "Удалить комментраий";
            this.btnDeleteCommentSh.UseVisualStyleBackColor = true;
            this.btnDeleteCommentSh.Click += new System.EventHandler(this.btnDeleteCommentSh_Click);
            // 
            // btnDownloadSharedFile
            // 
            this.btnDownloadSharedFile.Location = new System.Drawing.Point(6, 260);
            this.btnDownloadSharedFile.Name = "btnDownloadSharedFile";
            this.btnDownloadSharedFile.Size = new System.Drawing.Size(344, 23);
            this.btnDownloadSharedFile.TabIndex = 5;
            this.btnDownloadSharedFile.Text = "Скачать файл";
            this.btnDownloadSharedFile.UseVisualStyleBackColor = true;
            this.btnDownloadSharedFile.Click += new System.EventHandler(this.btnDownloadSharedFile_Click);
            // 
            // lbFilesShared
            // 
            this.lbFilesShared.DisplayMember = "Name";
            this.lbFilesShared.FormattingEnabled = true;
            this.lbFilesShared.Location = new System.Drawing.Point(6, 16);
            this.lbFilesShared.Name = "lbFilesShared";
            this.lbFilesShared.Size = new System.Drawing.Size(344, 238);
            this.lbFilesShared.TabIndex = 2;
            this.lbFilesShared.SelectedValueChanged += new System.EventHandler(this.lbFilesShared_SelectedValueChanged);
            // 
            // lblUserShName
            // 
            this.lblUserShName.AutoSize = true;
            this.lblUserShName.Location = new System.Drawing.Point(138, 0);
            this.lblUserShName.Name = "lblUserShName";
            this.lblUserShName.Size = new System.Drawing.Size(35, 13);
            this.lblUserShName.TabIndex = 1;
            this.lblUserShName.Text = "label2";
            // 
            // lblUserSh
            // 
            this.lblUserSh.AutoSize = true;
            this.lblUserSh.Location = new System.Drawing.Point(3, 0);
            this.lblUserSh.Name = "lblUserSh";
            this.lblUserSh.Size = new System.Drawing.Size(129, 13);
            this.lblUserSh.TabIndex = 0;
            this.lblUserSh.Text = "Текущий пользователь:";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FileSharing.Model.User);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // fileIdDataGridViewTextBoxColumn
            // 
            this.fileIdDataGridViewTextBoxColumn.DataPropertyName = "FileId";
            this.fileIdDataGridViewTextBoxColumn.HeaderText = "FileId";
            this.fileIdDataGridViewTextBoxColumn.Name = "fileIdDataGridViewTextBoxColumn";
            this.fileIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            this.userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            this.userIdDataGridViewTextBoxColumn.FillWeight = 20F;
            this.userIdDataGridViewTextBoxColumn.HeaderText = "Пользователь";
            this.userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            this.userIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Комментарий";
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FileId";
            this.dataGridViewTextBoxColumn2.HeaderText = "FileId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "UserId";
            this.dataGridViewTextBoxColumn3.FillWeight = 20F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Пользователь";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Text";
            this.dataGridViewTextBoxColumn4.HeaderText = "Кмментарий";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 495);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileSharing";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpUsers.ResumeLayout(false);
            this.gbUsers.ResumeLayout(false);
            this.gbUsers.PerformLayout();
            this.tpFilesUser.ResumeLayout(false);
            this.tpFilesUser.PerformLayout();
            this.gbComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).EndInit();
            this.gbSharedUsers.ResumeLayout(false);
            this.gpFiles.ResumeLayout(false);
            this.tpSharedFiles.ResumeLayout(false);
            this.tpSharedFiles.PerformLayout();
            this.grbCommentSh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommentSh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUserNameLabel;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TabPage tpFilesUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.TabPage tpSharedFiles;
        private System.Windows.Forms.Button btnDeleteComment;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.Button btnDeleteShare;
        private System.Windows.Forms.Button btnAddShare;
        private System.Windows.Forms.ListBox lbSharedUsers;
        private System.Windows.Forms.Button btnDownloadSharedFile;
        private System.Windows.Forms.ListBox lbFilesShared;
        private System.Windows.Forms.Label lblUserShName;
        private System.Windows.Forms.Label lblUserSh;
        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.BindingSource commentBindingSource;
        private System.Windows.Forms.GroupBox gbUsers;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.GroupBox gbComment;
        private System.Windows.Forms.GroupBox gbSharedUsers;
        private System.Windows.Forms.GroupBox gpFiles;
        private System.Windows.Forms.GroupBox grbCommentSh;
        private System.Windows.Forms.DataGridView dgvCommentSh;
        private System.Windows.Forms.Button btnAddCommentSh;
        private System.Windows.Forms.Button btnDeleteCommentSh;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}

