namespace QuanLyCuaHangTiVi.forms
{
    partial class FrmNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNhanVien));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label7 = new Label();
            dtpNgaySinh = new DateTimePicker();
            txtLuong = new TextBox();
            label6 = new Label();
            btnChonAnh = new Button();
            picAnhNhanVien = new PictureBox();
            cboQuyenHan = new ComboBox();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            txtMatKhau = new TextBox();
            txtTenDangNhap = new TextBox();
            txtHoTenNhanVien = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtMaNhanVien = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            dgvDanhSachNhanVien = new DataGridView();
            MaNhanVien = new DataGridViewTextBoxColumn();
            Colngaysinh = new DataGridViewTextBoxColumn();
            HoTenNhanVien = new DataGridViewTextBoxColumn();
            TenDangNhap = new DataGridViewTextBoxColumn();
            MatKhau = new DataGridViewTextBoxColumn();
            QuyenHan = new DataGridViewTextBoxColumn();
            ColLuong = new DataGridViewTextBoxColumn();
            CotHinhAnh = new DataGridViewImageColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnhNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachNhanVien).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 192, 255);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dtpNgaySinh);
            panel1.Controls.Add(txtLuong);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnChonAnh);
            panel1.Controls.Add(picAnhNhanVien);
            panel1.Controls.Add(cboQuyenHan);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnHuyBo);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(txtMatKhau);
            panel1.Controls.Add(txtTenDangNhap);
            panel1.Controls.Add(txtHoTenNhanVien);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtMaNhanVien);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1351, 233);
            panel1.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(287, 123);
            label7.Name = "label7";
            label7.Size = new Size(191, 25);
            label7.TabIndex = 24;
            label7.Text = "Ngày/tháng/năm sinh ";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(502, 123);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(300, 31);
            dtpNgaySinh.TabIndex = 23;
            // 
            // txtLuong
            // 
            txtLuong.Location = new Point(781, 71);
            txtLuong.Name = "txtLuong";
            txtLuong.Size = new Size(182, 31);
            txtLuong.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(707, 80);
            label6.Name = "label6";
            label6.Size = new Size(68, 25);
            label6.TabIndex = 21;
            label6.Text = "Lương ";
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = Color.Gray;
            btnChonAnh.Image = (Image)resources.GetObject("btnChonAnh.Image");
            btnChonAnh.ImageAlign = ContentAlignment.MiddleLeft;
            btnChonAnh.Location = new Point(1176, 28);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(163, 62);
            btnChonAnh.TabIndex = 20;
            btnChonAnh.Text = "Chọn Ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // picAnhNhanVien
            // 
            picAnhNhanVien.Location = new Point(994, 3);
            picAnhNhanVien.Name = "picAnhNhanVien";
            picAnhNhanVien.Size = new Size(150, 207);
            picAnhNhanVien.SizeMode = PictureBoxSizeMode.StretchImage;
            picAnhNhanVien.TabIndex = 19;
            picAnhNhanVien.TabStop = false;
            // 
            // cboQuyenHan
            // 
            cboQuyenHan.FormattingEnabled = true;
            cboQuyenHan.Items.AddRange(new object[] { "Quản Lý", "Nhân Viên Xuất Sắc", "Nhân Viên Trả Góp", "Nhân Viên " });
            cboQuyenHan.Location = new Point(781, 17);
            cboQuyenHan.Name = "cboQuyenHan";
            cboQuyenHan.Size = new Size(182, 33);
            cboQuyenHan.TabIndex = 18;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(255, 192, 192);
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(843, 160);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(126, 67);
            btnThoat.TabIndex = 17;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.FromArgb(128, 255, 255);
            btnHuyBo.Image = (Image)resources.GetObject("btnHuyBo.Image");
            btnHuyBo.ImageAlign = ContentAlignment.MiddleLeft;
            btnHuyBo.Location = new Point(688, 160);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(131, 67);
            btnHuyBo.TabIndex = 16;
            btnHuyBo.Text = "Hủy Bỏ";
            btnHuyBo.UseVisualStyleBackColor = false;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Fuchsia;
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(523, 160);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(141, 67);
            btnLuu.TabIndex = 15;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 255, 128);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(358, 160);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(141, 67);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(191, 160);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(143, 67);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(502, 71);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(150, 31);
            txtMatKhau.TabIndex = 11;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(502, 14);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(150, 31);
            txtTenDangNhap.TabIndex = 10;
            txtTenDangNhap.TextChanged += txtDonGiaBan_TextChanged;
            // 
            // txtHoTenNhanVien
            // 
            txtHoTenNhanVien.Location = new Point(184, 74);
            txtHoTenNhanVien.Name = "txtHoTenNhanVien";
            txtHoTenNhanVien.Size = new Size(150, 31);
            txtHoTenNhanVien.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(674, 20);
            label5.Name = "label5";
            label5.Size = new Size(101, 25);
            label5.TabIndex = 6;
            label5.Text = "Quyền Hạn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(391, 77);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 5;
            label4.Text = "Mật Khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(362, 14);
            label3.Name = "label3";
            label3.Size = new Size(134, 25);
            label3.TabIndex = 4;
            label3.Text = "Tên Đăng Nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 80);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 3;
            label2.Text = "Họ Tên Nhân Viên";
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(184, 12);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(150, 31);
            txtMaNhanVien.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 20);
            label1.Name = "label1";
            label1.Size = new Size(121, 25);
            label1.TabIndex = 1;
            label1.Text = "Mã Nhân viên";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(128, 255, 128);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(23, 157);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(144, 67);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvDanhSachNhanVien
            // 
            dgvDanhSachNhanVien.AllowUserToAddRows = false;
            dgvDanhSachNhanVien.AllowUserToDeleteRows = false;
            dgvDanhSachNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDanhSachNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachNhanVien.Columns.AddRange(new DataGridViewColumn[] { MaNhanVien, Colngaysinh, HoTenNhanVien, TenDangNhap, MatKhau, QuyenHan, ColLuong, CotHinhAnh });
            dgvDanhSachNhanVien.Location = new Point(0, 233);
            dgvDanhSachNhanVien.MultiSelect = false;
            dgvDanhSachNhanVien.Name = "dgvDanhSachNhanVien";
            dgvDanhSachNhanVien.RowHeadersWidth = 62;
            dgvDanhSachNhanVien.Size = new Size(1351, 311);
            dgvDanhSachNhanVien.TabIndex = 2;
            dgvDanhSachNhanVien.CellClick += dgvDanhSachNhanVien_CellClick;
            dgvDanhSachNhanVien.CellFormatting += dgvDanhSachNhanVien_CellFormatting;
            // 
            // MaNhanVien
            // 
            MaNhanVien.DataPropertyName = "MaNhanVien";
            MaNhanVien.HeaderText = "Mã Nhân Viên";
            MaNhanVien.MinimumWidth = 8;
            MaNhanVien.Name = "MaNhanVien";
            // 
            // Colngaysinh
            // 
            Colngaysinh.DataPropertyName = "NgaySinh";
            Colngaysinh.HeaderText = "Ngày Sinh";
            Colngaysinh.MinimumWidth = 8;
            Colngaysinh.Name = "Colngaysinh";
            // 
            // HoTenNhanVien
            // 
            HoTenNhanVien.DataPropertyName = "HoTenNhanVien";
            HoTenNhanVien.HeaderText = "Họ Tên";
            HoTenNhanVien.MinimumWidth = 8;
            HoTenNhanVien.Name = "HoTenNhanVien";
            // 
            // TenDangNhap
            // 
            TenDangNhap.DataPropertyName = "TenDangNhap";
            TenDangNhap.HeaderText = "Tên Đăng Nhập";
            TenDangNhap.MinimumWidth = 8;
            TenDangNhap.Name = "TenDangNhap";
            // 
            // MatKhau
            // 
            MatKhau.DataPropertyName = "MatKhau";
            MatKhau.HeaderText = "Mật Khẩu";
            MatKhau.MinimumWidth = 8;
            MatKhau.Name = "MatKhau";
            // 
            // QuyenHan
            // 
            QuyenHan.DataPropertyName = "QuyenHan";
            QuyenHan.HeaderText = "Quyền Hạn";
            QuyenHan.MinimumWidth = 8;
            QuyenHan.Name = "QuyenHan";
            // 
            // ColLuong
            // 
            ColLuong.DataPropertyName = "Luong";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            ColLuong.DefaultCellStyle = dataGridViewCellStyle1;
            ColLuong.HeaderText = "Lương";
            ColLuong.MinimumWidth = 8;
            ColLuong.Name = "ColLuong";
            // 
            // CotHinhAnh
            // 
            CotHinhAnh.DataPropertyName = "CotHinhAnh";
            CotHinhAnh.HeaderText = "Hình ảnh";
            CotHinhAnh.ImageLayout = DataGridViewImageCellLayout.Zoom;
            CotHinhAnh.MinimumWidth = 8;
            CotHinhAnh.Name = "CotHinhAnh";
            // 
            // FrmNhanVien
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1351, 544);
            Controls.Add(dgvDanhSachNhanVien);
            Controls.Add(panel1);
            Name = "FrmNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhân Viên";
            Load += FrmNhanVien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAnhNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private TextBox txtMatKhau;
        private TextBox txtTenDangNhap;
        private TextBox txtHoTenNhanVien;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtMaNhanVien;
        private Label label1;
        private Button btnThem;
        private DataGridView dgvDanhSachNhanVien;
        private ComboBox cboQuyenHan;
        private Button btnChonAnh;
        private PictureBox picAnhNhanVien;
        private TextBox txtLuong;
        private Label label6;
        private Label label7;
        private DateTimePicker dtpNgaySinh;
        private DataGridViewTextBoxColumn MaNhanVien;
        private DataGridViewTextBoxColumn Colngaysinh;
        private DataGridViewTextBoxColumn HoTenNhanVien;
        private DataGridViewTextBoxColumn TenDangNhap;
        private DataGridViewTextBoxColumn MatKhau;
        private DataGridViewTextBoxColumn QuyenHan;
        private DataGridViewTextBoxColumn ColLuong;
        private DataGridViewImageColumn CotHinhAnh;
    }
}