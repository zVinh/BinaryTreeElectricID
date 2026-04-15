namespace BinaryTreeElectricID
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            lblTitle = new Label();
            lblUserIcon = new Label();
            txtUser = new TextBox();
            lblPassIcon = new Label();
            txtPass = new TextBox();
            btnShowPass = new Button();
            btnAdd = new Button();
            btnLogin = new Button();
            separatorDel = new Label();
            btnDelete = new Button();
            separatorSrch = new Label();
            lblSearchIcon = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            separatorAna = new Label();
            btnAnalyze = new Button();
            panelStatus = new Panel();
            lblStatus = new Label();
            panelTree = new Panel();
            panelSidebar.SuspendLayout();
            panelStatus.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(24, 36, 58);
            panelSidebar.Controls.Add(lblTitle);
            panelSidebar.Controls.Add(lblUserIcon);
            panelSidebar.Controls.Add(txtUser);
            panelSidebar.Controls.Add(lblPassIcon);
            panelSidebar.Controls.Add(txtPass);
            panelSidebar.Controls.Add(btnShowPass);
            panelSidebar.Controls.Add(btnAdd);
            panelSidebar.Controls.Add(btnLogin);
            panelSidebar.Controls.Add(separatorDel);
            panelSidebar.Controls.Add(btnDelete);
            panelSidebar.Controls.Add(separatorSrch);
            panelSidebar.Controls.Add(lblSearchIcon);
            panelSidebar.Controls.Add(txtSearch);
            panelSidebar.Controls.Add(btnSearch);
            panelSidebar.Controls.Add(separatorAna);
            panelSidebar.Controls.Add(btnAnalyze);
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(182, 660);
            panelSidebar.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(180, 210, 255);
            lblTitle.Location = new Point(10, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🌳 AVL ID";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserIcon
            // 
            lblUserIcon.Font = new Font("Segoe UI", 8F);
            lblUserIcon.ForeColor = Color.FromArgb(160, 185, 220);
            lblUserIcon.Location = new Point(12, 56);
            lblUserIcon.Name = "lblUserIcon";
            lblUserIcon.Size = new Size(158, 16);
            lblUserIcon.TabIndex = 1;
            lblUserIcon.Text = "👤 Tên đăng nhập";
            // 
            // txtUser
            // 
            txtUser.BackColor = Color.FromArgb(42, 58, 90);
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 9.5F);
            txtUser.ForeColor = Color.White;
            txtUser.Location = new Point(12, 75);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Username / Tên VN";
            txtUser.Size = new Size(158, 24);
            txtUser.TabIndex = 2;
            // 
            // lblPassIcon
            // 
            lblPassIcon.Font = new Font("Segoe UI", 8F);
            lblPassIcon.ForeColor = Color.FromArgb(160, 185, 220);
            lblPassIcon.Location = new Point(12, 112);
            lblPassIcon.Name = "lblPassIcon";
            lblPassIcon.Size = new Size(158, 16);
            lblPassIcon.TabIndex = 3;
            lblPassIcon.Text = "🔒 Mật khẩu";
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.FromArgb(42, 58, 90);
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 9.5F);
            txtPass.ForeColor = Color.White;
            txtPass.Location = new Point(12, 131);
            txtPass.Name = "txtPass";
            txtPass.PlaceholderText = "Password";
            txtPass.Size = new Size(112, 24);
            txtPass.TabIndex = 4;
            txtPass.UseSystemPasswordChar = true;
            // 
            // btnShowPass
            // 
            btnShowPass.BackColor = Color.FromArgb(60, 80, 120);
            btnShowPass.FlatAppearance.BorderColor = Color.FromArgb(80, 100, 150);
            btnShowPass.FlatStyle = FlatStyle.Flat;
            btnShowPass.Font = new Font("Segoe UI", 7F);
            btnShowPass.ForeColor = Color.FromArgb(180, 210, 255);
            btnShowPass.Location = new Point(130, 131);
            btnShowPass.Name = "btnShowPass";
            btnShowPass.Size = new Size(40, 26);
            btnShowPass.TabIndex = 5;
            btnShowPass.Text = "Show";
            btnShowPass.UseVisualStyleBackColor = false;
            btnShowPass.Click += btnShowPass_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(34, 120, 190);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(12, 172);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(72, 30);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "➕ Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(46, 138, 92);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(92, 172);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(78, 30);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "🔑 Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // separatorDel
            // 
            separatorDel.BackColor = Color.FromArgb(50, 70, 100);
            separatorDel.Location = new Point(12, 216);
            separatorDel.Name = "separatorDel";
            separatorDel.Size = new Size(158, 1);
            separatorDel.TabIndex = 8;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(192, 50, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(12, 224);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 30);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "🗑  Xóa tài khoản";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // separatorSrch
            // 
            separatorSrch.BackColor = Color.FromArgb(50, 70, 100);
            separatorSrch.Location = new Point(12, 268);
            separatorSrch.Name = "separatorSrch";
            separatorSrch.Size = new Size(158, 1);
            separatorSrch.TabIndex = 10;
            // 
            // lblSearchIcon
            // 
            lblSearchIcon.Font = new Font("Segoe UI", 7.5F);
            lblSearchIcon.ForeColor = Color.FromArgb(160, 185, 220);
            lblSearchIcon.Location = new Point(12, 276);
            lblSearchIcon.Name = "lblSearchIcon";
            lblSearchIcon.Size = new Size(158, 16);
            lblSearchIcon.TabIndex = 11;
            lblSearchIcon.Text = "🔍 Tìm kiếm & highlight đường đi";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(42, 58, 90);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(12, 295);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên để tìm...";
            txtSearch.Size = new Size(158, 24);
            txtSearch.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(90, 110, 200);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(12, 328);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(158, 30);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "🔍 Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // separatorAna
            // 
            separatorAna.BackColor = Color.FromArgb(50, 70, 100);
            separatorAna.Location = new Point(12, 374);
            separatorAna.Name = "separatorAna";
            separatorAna.Size = new Size(158, 1);
            separatorAna.TabIndex = 14;
            // 
            // btnAnalyze
            // 
            btnAnalyze.BackColor = Color.FromArgb(30, 165, 115);
            btnAnalyze.FlatAppearance.BorderSize = 0;
            btnAnalyze.FlatStyle = FlatStyle.Flat;
            btnAnalyze.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAnalyze.ForeColor = Color.White;
            btnAnalyze.Location = new Point(12, 382);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(158, 30);
            btnAnalyze.TabIndex = 15;
            btnAnalyze.Text = "📊 Phân tích hiệu năng";
            btnAnalyze.UseVisualStyleBackColor = false;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // panelStatus
            // 
            panelStatus.BackColor = Color.FromArgb(240, 244, 250);
            panelStatus.Controls.Add(lblStatus);
            panelStatus.Location = new Point(182, 0);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(1070, 28);
            panelStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 8.5F);
            lblStatus.ForeColor = Color.FromArgb(0, 100, 180);
            lblStatus.Location = new Point(8, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1050, 28);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Chào mừng đến với BinaryTreeElectricID — Hệ thống định danh điện tử AVL";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Click += lblStatus_Click;
            // 
            // panelTree
            // 
            panelTree.AutoScroll = true;
            panelTree.BackColor = Color.FromArgb(245, 248, 255);
            panelTree.Location = new Point(182, 28);
            panelTree.Name = "panelTree";
            panelTree.Size = new Size(1070, 632);
            panelTree.TabIndex = 2;
            panelTree.Paint += panelTree_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 36, 58);
            ClientSize = new Size(1252, 660);
            Controls.Add(panelSidebar);
            Controls.Add(panelStatus);
            Controls.Add(panelTree);
            MinimumSize = new Size(900, 600);
            Name = "Form1";
            Text = "BinaryTreeElectricID — Định danh điện tử AVL";
            Load += Form1_Load;
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelStatus.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel    panelSidebar;
        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblUserIcon;
        private System.Windows.Forms.TextBox  txtUser;
        private System.Windows.Forms.Label    lblPassIcon;
        private System.Windows.Forms.TextBox  txtPass;
        private System.Windows.Forms.Button   btnShowPass;
        private System.Windows.Forms.Button   btnAdd;
        private System.Windows.Forms.Button   btnLogin;
        private System.Windows.Forms.Label    separatorDel;
        private System.Windows.Forms.Button   btnDelete;
        private System.Windows.Forms.Label    separatorSrch;
        private System.Windows.Forms.Label    lblSearchIcon;
        private System.Windows.Forms.TextBox  txtSearch;
        private System.Windows.Forms.Button   btnSearch;
        private System.Windows.Forms.Label    separatorAna;
        private System.Windows.Forms.Button   btnAnalyze;
        private System.Windows.Forms.Panel    panelStatus;
        private System.Windows.Forms.Label    lblStatus;
        private System.Windows.Forms.Panel    panelTree;
    }
}
