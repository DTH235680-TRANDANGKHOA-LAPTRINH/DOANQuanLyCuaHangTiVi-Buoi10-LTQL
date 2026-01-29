namespace QuanLyCuaHangTiVi.forms
{
    partial class frmQuanLyTiVi
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
            cboHangSanXuat = new ComboBox();
            txtSoLuongTon = new TextBox();
            label8 = new Label();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            dtpNgayNhap = new DateTimePicker();
            txtKhuyenMai = new TextBox();
            txtDonGiaBan = new TextBox();
            txtTenTiVi = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtMaTiVi = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            dgvDanhSachTiVi = new DataGridView();
            MaTiVi = new DataGridViewTextBoxColumn();
            SoLuongTon = new DataGridViewTextBoxColumn();
            TenTiVi = new DataGridViewTextBoxColumn();
            HangSanXuat = new DataGridViewTextBoxColumn();
            NgayNhap = new DataGridViewTextBoxColumn();
            DonGiaBan = new DataGridViewTextBoxColumn();
            KhuyenMai = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachTiVi).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cboHangSanXuat);
            panel1.Controls.Add(txtSoLuongTon);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnHuyBo);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(dtpNgayNhap);
            panel1.Controls.Add(txtKhuyenMai);
            panel1.Controls.Add(txtDonGiaBan);
            panel1.Controls.Add(txtTenTiVi);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtMaTiVi);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1772, 208);
            panel1.TabIndex = 0;
            // 
            // cboHangSanXuat
            // 
            cboHangSanXuat.FormattingEnabled = true;
            cboHangSanXuat.Location = new Point(545, 17);
            cboHangSanXuat.Name = "cboHangSanXuat";
            cboHangSanXuat.Size = new Size(182, 33);
            cboHangSanXuat.TabIndex = 22;
            // 
            // txtSoLuongTon
            // 
            txtSoLuongTon.Location = new Point(1474, 26);
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.Size = new Size(172, 31);
            txtSoLuongTon.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1328, 26);
            label8.Name = "label8";
            label8.Size = new Size(124, 25);
            label8.TabIndex = 20;
            label8.Text = "Số Lượng Tồn";
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
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(545, 57);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(300, 31);
            dtpNgayNhap.TabIndex = 12;
            // 
            // txtKhuyenMai
            // 
            txtKhuyenMai.Location = new Point(1136, 77);
            txtKhuyenMai.Name = "txtKhuyenMai";
            txtKhuyenMai.Size = new Size(150, 31);
            txtKhuyenMai.TabIndex = 11;
            txtKhuyenMai.TextChanged += textBox3_TextChanged;
            // 
            // txtDonGiaBan
            // 
            txtDonGiaBan.Location = new Point(1136, 20);
            txtDonGiaBan.Name = "txtDonGiaBan";
            txtDonGiaBan.Size = new Size(150, 31);
            txtDonGiaBan.TabIndex = 10;
            // 
            // txtTenTiVi
            // 
            txtTenTiVi.Location = new Point(134, 59);
            txtTenTiVi.Name = "txtTenTiVi";
            txtTenTiVi.Size = new Size(150, 31);
            txtTenTiVi.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1026, 83);
            label6.Name = "label6";
            label6.Size = new Size(104, 25);
            label6.TabIndex = 7;
            label6.Text = "Khuyến Mãi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1026, 20);
            label5.Name = "label5";
            label5.Size = new Size(110, 25);
            label5.TabIndex = 6;
            label5.Text = "Đơn Gía Bán";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 59);
            label4.Name = "label4";
            label4.Size = new Size(155, 25);
            label4.TabIndex = 5;
            label4.Text = "Ngày/Tháng/Năm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(387, 20);
            label3.Name = "label3";
            label3.Size = new Size(130, 25);
            label3.TabIndex = 4;
            label3.Text = "Hãng Sản Xuất";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 59);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 3;
            label2.Text = "Tên TiVi";
            // 
            // txtMaTiVi
            // 
            txtMaTiVi.Location = new Point(133, 12);
            txtMaTiVi.Name = "txtMaTiVi";
            txtMaTiVi.Size = new Size(150, 31);
            txtMaTiVi.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 20);
            label1.Name = "label1";
            label1.Size = new Size(70, 25);
            label1.TabIndex = 1;
            label1.Text = "Mã TiVi";
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
            // dgvDanhSachTiVi
            // 
            dgvDanhSachTiVi.AllowUserToAddRows = false;
            dgvDanhSachTiVi.AllowUserToDeleteRows = false;
            dgvDanhSachTiVi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachTiVi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachTiVi.Columns.AddRange(new DataGridViewColumn[] { MaTiVi, SoLuongTon, TenTiVi, HangSanXuat, NgayNhap, DonGiaBan, KhuyenMai });
            dgvDanhSachTiVi.Dock = DockStyle.Fill;
            dgvDanhSachTiVi.Location = new Point(0, 208);
            dgvDanhSachTiVi.MultiSelect = false;
            dgvDanhSachTiVi.Name = "dgvDanhSachTiVi";
            dgvDanhSachTiVi.RowHeadersWidth = 62;
            dgvDanhSachTiVi.Size = new Size(1772, 324);
            dgvDanhSachTiVi.TabIndex = 1;
            dgvDanhSachTiVi.CellContentClick += dataGridView_CellContentClick;
            // 
            // MaTiVi
            // 
            MaTiVi.DataPropertyName = "MaTiVi";
            MaTiVi.HeaderText = "Mã TiVi";
            MaTiVi.MinimumWidth = 8;
            MaTiVi.Name = "MaTiVi";
            // 
            // SoLuongTon
            // 
            SoLuongTon.DataPropertyName = "SoLuongTon";
            SoLuongTon.HeaderText = "Số Lượng Tồn";
            SoLuongTon.MinimumWidth = 8;
            SoLuongTon.Name = "SoLuongTon";
            // 
            // TenTiVi
            // 
            TenTiVi.DataPropertyName = "TenTiVi";
            TenTiVi.HeaderText = "Tên TiVi";
            TenTiVi.MinimumWidth = 8;
            TenTiVi.Name = "TenTiVi";
            // 
            // HangSanXuat
            // 
            HangSanXuat.DataPropertyName = "HangSanXuat";
            HangSanXuat.HeaderText = "Hãng Sản Xuất";
            HangSanXuat.MinimumWidth = 8;
            HangSanXuat.Name = "HangSanXuat";
            // 
            // NgayNhap
            // 
            NgayNhap.DataPropertyName = "NgayNhap";
            NgayNhap.HeaderText = "Ngày Nhập";
            NgayNhap.MinimumWidth = 8;
            NgayNhap.Name = "NgayNhap";
            // 
            // DonGiaBan
            // 
            DonGiaBan.DataPropertyName = "DonGiaBan";
            DonGiaBan.HeaderText = "Đơn Gía Bán";
            DonGiaBan.MinimumWidth = 8;
            DonGiaBan.Name = "DonGiaBan";
            // 
            // KhuyenMai
            // 
            KhuyenMai.DataPropertyName = "KhuyenMai";
            KhuyenMai.HeaderText = "Khuyến Mãi";
            KhuyenMai.MinimumWidth = 8;
            KhuyenMai.Name = "KhuyenMai";
            // 
            // frmQuanLyTiVi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1772, 532);
            Controls.Add(dgvDanhSachTiVi);
            Controls.Add(panel1);
            Name = "frmQuanLyTiVi";
            Text = "Quản Lý TiVi";
            Load += frmQuanLyTiVi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachTiVi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtMaTiVi;
        private Label label1;
        private Button btnThem;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTenTiVi;
        private Label label6;
        private Label label5;
        private DateTimePicker dtpNgayNhap;
        private TextBox txtKhuyenMai;
        private TextBox txtDonGiaBan;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private DataGridView dgvDanhSachTiVi;
        private TextBox txtSoLuongTon;
        private Label label8;
        private ComboBox cboHangSanXuat;
        private DataGridViewTextBoxColumn MaTiVi;
        private DataGridViewTextBoxColumn SoLuongTon;
        private DataGridViewTextBoxColumn TenTiVi;
        private DataGridViewTextBoxColumn HangSanXuat;
        private DataGridViewTextBoxColumn NgayNhap;
        private DataGridViewTextBoxColumn DonGiaBan;
        private DataGridViewTextBoxColumn KhuyenMai;
    }
}