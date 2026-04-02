namespace QuanLyCuaHangTiVi.forms
{
    partial class frmKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachHang));
            groupBox1 = new GroupBox();
            txtSoDienThoai = new TextBox();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            dtpNgayThangNamSinh = new DateTimePicker();
            txtDiaChi = new TextBox();
            txtCCCD = new TextBox();
            txtTenKhachHang = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtMaKhachHang = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            groupBox2 = new GroupBox();
            dgvDanhSachKhachHang = new DataGridView();
            MaKhachHang = new DataGridViewTextBoxColumn();
            TenKhachHang = new DataGridViewTextBoxColumn();
            SoDienThoai = new DataGridViewTextBoxColumn();
            NgayThangNamSinh = new DataGridViewTextBoxColumn();
            CCCD = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachKhachHang).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSoDienThoai);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(dtpNgayThangNamSinh);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtCCCD);
            groupBox1.Controls.Add(txtTenKhachHang);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaKhachHang);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1747, 274);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(567, 52);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(172, 31);
            txtSoDienThoai.TabIndex = 41;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(128, 255, 128);
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(909, 188);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(125, 63);
            btnThoat.TabIndex = 39;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.FromArgb(255, 192, 128);
            btnHuyBo.Image = (Image)resources.GetObject("btnHuyBo.Image");
            btnHuyBo.ImageAlign = ContentAlignment.MiddleLeft;
            btnHuyBo.Location = new Point(759, 188);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(125, 63);
            btnHuyBo.TabIndex = 38;
            btnHuyBo.Text = "Hủy Bỏ";
            btnHuyBo.UseVisualStyleBackColor = false;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Fuchsia;
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(614, 188);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(125, 63);
            btnLuu.TabIndex = 37;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Yellow;
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(460, 188);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(125, 63);
            btnSua.TabIndex = 36;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(309, 188);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(125, 63);
            btnXoa.TabIndex = 35;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // dtpNgayThangNamSinh
            // 
            dtpNgayThangNamSinh.Location = new Point(567, 97);
            dtpNgayThangNamSinh.Name = "dtpNgayThangNamSinh";
            dtpNgayThangNamSinh.Size = new Size(300, 31);
            dtpNgayThangNamSinh.TabIndex = 34;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(1158, 97);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(150, 31);
            txtDiaChi.TabIndex = 33;
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(1158, 52);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(150, 31);
            txtCCCD.TabIndex = 32;
            // 
            // txtTenKhachHang
            // 
            txtTenKhachHang.Location = new Point(156, 97);
            txtTenKhachHang.Name = "txtTenKhachHang";
            txtTenKhachHang.Size = new Size(150, 31);
            txtTenKhachHang.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1048, 100);
            label6.Name = "label6";
            label6.Size = new Size(68, 25);
            label6.TabIndex = 30;
            label6.Text = "Địa Chỉ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1048, 55);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 29;
            label5.Text = "CCCD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(409, 100);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 28;
            label4.Text = "Ngày Sinh";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(409, 55);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 27;
            label3.Text = "Số Điện Thoại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 100);
            label2.Name = "label2";
            label2.Size = new Size(138, 25);
            label2.TabIndex = 26;
            label2.Text = "Tên Khách Hàng";
            // 
            // txtMaKhachHang
            // 
            txtMaKhachHang.Location = new Point(155, 52);
            txtMaKhachHang.Name = "txtMaKhachHang";
            txtMaKhachHang.Size = new Size(150, 31);
            txtMaKhachHang.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 55);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 24;
            label1.Text = "Mã Khách Hàng";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(128, 255, 255);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(156, 188);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(125, 63);
            btnThem.TabIndex = 23;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDanhSachKhachHang);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 274);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1747, 305);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Khách Hàng";
            // 
            // dgvDanhSachKhachHang
            // 
            dgvDanhSachKhachHang.AllowUserToAddRows = false;
            dgvDanhSachKhachHang.AllowUserToDeleteRows = false;
            dgvDanhSachKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachKhachHang.Columns.AddRange(new DataGridViewColumn[] { MaKhachHang, TenKhachHang, SoDienThoai, NgayThangNamSinh, CCCD, DiaChi });
            dgvDanhSachKhachHang.Dock = DockStyle.Fill;
            dgvDanhSachKhachHang.Location = new Point(3, 27);
            dgvDanhSachKhachHang.MultiSelect = false;
            dgvDanhSachKhachHang.Name = "dgvDanhSachKhachHang";
            dgvDanhSachKhachHang.RowHeadersWidth = 62;
            dgvDanhSachKhachHang.Size = new Size(1741, 275);
            dgvDanhSachKhachHang.TabIndex = 3;
            // 
            // MaKhachHang
            // 
            MaKhachHang.DataPropertyName = "MaKhachHang";
            MaKhachHang.HeaderText = "Mã Khách Hàng";
            MaKhachHang.MinimumWidth = 8;
            MaKhachHang.Name = "MaKhachHang";
            // 
            // TenKhachHang
            // 
            TenKhachHang.DataPropertyName = "TenKhachHang";
            TenKhachHang.HeaderText = "Tên Khách Hàng";
            TenKhachHang.MinimumWidth = 8;
            TenKhachHang.Name = "TenKhachHang";
            // 
            // SoDienThoai
            // 
            SoDienThoai.DataPropertyName = "SoDienThoai";
            SoDienThoai.HeaderText = "Số Điện Thoại";
            SoDienThoai.MinimumWidth = 8;
            SoDienThoai.Name = "SoDienThoai";
            // 
            // NgayThangNamSinh
            // 
            NgayThangNamSinh.DataPropertyName = "NgayThangNamSinh";
            NgayThangNamSinh.HeaderText = "Ngày Sinh";
            NgayThangNamSinh.MinimumWidth = 8;
            NgayThangNamSinh.Name = "NgayThangNamSinh";
            // 
            // CCCD
            // 
            CCCD.DataPropertyName = "CCCD";
            CCCD.HeaderText = "CCCD";
            CCCD.MinimumWidth = 8;
            CCCD.Name = "CCCD";
            // 
            // DiaChi
            // 
            DiaChi.DataPropertyName = "DiaChi";
            DiaChi.HeaderText = "Địa Chỉ";
            DiaChi.MinimumWidth = 8;
            DiaChi.Name = "DiaChi";
            // 
            // frmKhachHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1747, 579);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmKhachHang";
            Text = "Khách Hàng";
            Load += frmKhachHang_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachKhachHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtSoDienThoai;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private DateTimePicker dtpNgayThangNamSinh;
        private TextBox txtDiaChi;
        private TextBox txtCCCD;
        private TextBox txtTenKhachHang;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtMaKhachHang;
        private Label label1;
        private Button btnThem;
        private GroupBox groupBox2;
        private DataGridView dgvDanhSachKhachHang;
        private DataGridViewTextBoxColumn MaKhachHang;
        private DataGridViewTextBoxColumn TenKhachHang;
        private DataGridViewTextBoxColumn SoDienThoai;
        private DataGridViewTextBoxColumn NgayThangNamSinh;
        private DataGridViewTextBoxColumn CCCD;
        private DataGridViewTextBoxColumn DiaChi;
    }
}