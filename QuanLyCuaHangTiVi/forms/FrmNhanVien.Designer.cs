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
            panel1 = new Panel();
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
            CotHinhAnh = new DataGridViewImageColumn();
            TenDangNhap = new DataGridViewTextBoxColumn();
            HoTenNhanVien = new DataGridViewTextBoxColumn();
            MatKhau = new DataGridViewTextBoxColumn();
            QuyenHan = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnhNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachNhanVien).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
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
            panel1.Size = new Size(1690, 233);
            panel1.TabIndex = 1;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(1388, 48);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(112, 34);
            btnChonAnh.TabIndex = 20;
            btnChonAnh.Text = "Chọn Ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // picAnhNhanVien
            // 
            picAnhNhanVien.Location = new Point(1182, 20);
            picAnhNhanVien.Name = "picAnhNhanVien";
            picAnhNhanVien.Size = new Size(150, 207);
            picAnhNhanVien.SizeMode = PictureBoxSizeMode.StretchImage;
            picAnhNhanVien.TabIndex = 19;
            picAnhNhanVien.TabStop = false;
            // 
            // cboQuyenHan
            // 
            cboQuyenHan.FormattingEnabled = true;
            cboQuyenHan.Items.AddRange(new object[] { "Quản Lý", "Nhân Viên ", "Chủ Quán" });
            cboQuyenHan.Location = new Point(868, 29);
            cboQuyenHan.Name = "cboQuyenHan";
            cboQuyenHan.Size = new Size(182, 33);
            cboQuyenHan.TabIndex = 18;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(990, 148);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 34);
            btnThoat.TabIndex = 17;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(850, 148);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(112, 34);
            btnHuyBo.TabIndex = 16;
            btnHuyBo.Text = "Hủy Bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(686, 148);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 15;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(519, 148);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(325, 148);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 34);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(545, 77);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(150, 31);
            txtMatKhau.TabIndex = 11;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(545, 20);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(150, 31);
            txtTenDangNhap.TabIndex = 10;
            txtTenDangNhap.TextChanged += txtDonGiaBan_TextChanged;
            // 
            // txtHoTenNhanVien
            // 
            txtHoTenNhanVien.Location = new Point(184, 53);
            txtHoTenNhanVien.Name = "txtHoTenNhanVien";
            txtHoTenNhanVien.Size = new Size(150, 31);
            txtHoTenNhanVien.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(744, 32);
            label5.Name = "label5";
            label5.Size = new Size(101, 25);
            label5.TabIndex = 6;
            label5.Text = "Quyền Hạn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(434, 83);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 5;
            label4.Text = "Mật Khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(387, 20);
            label3.Name = "label3";
            label3.Size = new Size(134, 25);
            label3.TabIndex = 4;
            label3.Text = "Tên Đăng Nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 57);
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
            btnThem.Location = new Point(134, 148);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvDanhSachNhanVien
            // 
            dgvDanhSachNhanVien.AllowUserToAddRows = false;
            dgvDanhSachNhanVien.AllowUserToDeleteRows = false;
            dgvDanhSachNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachNhanVien.Columns.AddRange(new DataGridViewColumn[] { MaNhanVien, CotHinhAnh, TenDangNhap, HoTenNhanVien, MatKhau, QuyenHan });
            dgvDanhSachNhanVien.Dock = DockStyle.Fill;
            dgvDanhSachNhanVien.Location = new Point(0, 233);
            dgvDanhSachNhanVien.MultiSelect = false;
            dgvDanhSachNhanVien.Name = "dgvDanhSachNhanVien";
            dgvDanhSachNhanVien.RowHeadersWidth = 62;
            dgvDanhSachNhanVien.Size = new Size(1690, 311);
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
            // CotHinhAnh
            // 
            CotHinhAnh.DataPropertyName = "CotHinhAnh";
            CotHinhAnh.HeaderText = "Hình ảnh";
            CotHinhAnh.ImageLayout = DataGridViewImageCellLayout.Zoom;
            CotHinhAnh.MinimumWidth = 8;
            CotHinhAnh.Name = "CotHinhAnh";
            // 
            // TenDangNhap
            // 
            TenDangNhap.DataPropertyName = "TenDangNhap";
            TenDangNhap.HeaderText = "Tên Đăng Nhập";
            TenDangNhap.MinimumWidth = 8;
            TenDangNhap.Name = "TenDangNhap";
            // 
            // HoTenNhanVien
            // 
            HoTenNhanVien.DataPropertyName = "HoTenNhanVien";
            HoTenNhanVien.HeaderText = "Họ Tên";
            HoTenNhanVien.MinimumWidth = 8;
            HoTenNhanVien.Name = "HoTenNhanVien";
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
            // FrmNhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1690, 544);
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
        private DataGridViewTextBoxColumn MaNhanVien;
        private DataGridViewImageColumn CotHinhAnh;
        private DataGridViewTextBoxColumn TenDangNhap;
        private DataGridViewTextBoxColumn HoTenNhanVien;
        private DataGridViewTextBoxColumn MatKhau;
        private DataGridViewTextBoxColumn QuyenHan;
    }
}