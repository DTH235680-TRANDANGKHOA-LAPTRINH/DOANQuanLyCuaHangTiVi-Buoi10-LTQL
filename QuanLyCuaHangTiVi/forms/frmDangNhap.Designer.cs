namespace QuanLyCuaHangTiVi.forms
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            btnDangNhap = new Button();
            label1 = new Label();
            txtTenDangNhap = new TextBox();
            groupBox1 = new GroupBox();
            btnHuyBo = new Button();
            txtMatKhau = new TextBox();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.DodgerBlue;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(61, 484);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(185, 66);
            btnDangNhap.TabIndex = 0;
            btnDangNhap.Text = "Đăng nhập ";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(93, 61);
            label1.Name = "label1";
            label1.Size = new Size(314, 55);
            label1.TabIndex = 1;
            label1.Text = "ĐĂNG NHẬP";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BorderStyle = BorderStyle.None;
            txtTenDangNhap.Location = new Point(77, 209);
            txtTenDangNhap.Multiline = true;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(351, 55);
            txtTenDangNhap.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(224, 224, 224);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnDangNhap);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTenDangNhap);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(383, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(508, 606);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Đăng Nhập";
            // 
            // btnHuyBo
            // 
            btnHuyBo.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuyBo.Location = new Point(297, 484);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(185, 66);
            btnHuyBo.TabIndex = 6;
            btnHuyBo.Text = "Hủy bỏ ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BorderStyle = BorderStyle.None;
            txtMatKhau.Location = new Point(77, 350);
            txtMatKhau.Multiline = true;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(347, 48);
            txtMatKhau.TabIndex = 5;
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 298);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 4;
            label3.Text = "Mật khẩu ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 168);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 3;
            label2.Text = "Tên đăng nhập ";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(383, 606);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 606);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDangNhap;
        private Label label1;
        private GroupBox groupBox1;
        private Button btnHuyBo;
        private TextBox textBox2;
        private Label label3;
        private Label label2;
        public TextBox txtTenDangNhap;
        public TextBox txtMatKhau;
        private PictureBox pictureBox1;
    }
}