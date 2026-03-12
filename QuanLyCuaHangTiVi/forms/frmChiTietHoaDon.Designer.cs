namespace QuanLyCuaHangTiVi.forms
{
    partial class frmChiTietHoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            txtGhiChu = new TextBox();
            label1 = new Label();
            txtKhuyenMai = new TextBox();
            label9 = new Label();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            label8 = new Label();
            label7 = new Label();
            cboTenTiVi = new ComboBox();
            cboNhanVien = new ComboBox();
            cboKhachHang = new ComboBox();
            btnThoat = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            dtpNgayLap = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnThem = new Button();
            dgvDanhSachHD = new DataGridView();
            MaTiVi = new DataGridViewTextBoxColumn();
            TenTiVi = new DataGridViewTextBoxColumn();
            ColKhuyenMai = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHD).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtGhiChu);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtKhuyenMai);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtDonGia);
            groupBox1.Controls.Add(txtSoLuong);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cboTenTiVi);
            groupBox1.Controls.Add(cboNhanVien);
            groupBox1.Controls.Add(cboKhachHang);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(dtpNgayLap);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1754, 274);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Chi Tiết Hóa Đơn";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(1387, 97);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(150, 31);
            txtGhiChu.TabIndex = 51;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1277, 97);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 50;
            label1.Text = "Ghi Chú";
            // 
            // txtKhuyenMai
            // 
            txtKhuyenMai.Location = new Point(1387, 32);
            txtKhuyenMai.Name = "txtKhuyenMai";
            txtKhuyenMai.Size = new Size(150, 31);
            txtKhuyenMai.TabIndex = 49;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1277, 38);
            label9.Name = "label9";
            label9.Size = new Size(104, 25);
            label9.TabIndex = 48;
            label9.Text = "Khuyến Mãi";
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(1087, 86);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.ReadOnly = true;
            txtDonGia.Size = new Size(150, 31);
            txtDonGia.TabIndex = 47;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(1087, 35);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(150, 31);
            txtSoLuong.TabIndex = 46;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(967, 86);
            label8.Name = "label8";
            label8.Size = new Size(76, 25);
            label8.TabIndex = 45;
            label8.Text = "Đơn Gía";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(967, 33);
            label7.Name = "label7";
            label7.Size = new Size(89, 25);
            label7.TabIndex = 44;
            label7.Text = "Số Lượng";
            // 
            // cboTenTiVi
            // 
            cboTenTiVi.FormattingEnabled = true;
            cboTenTiVi.Location = new Point(155, 103);
            cboTenTiVi.Name = "cboTenTiVi";
            cboTenTiVi.Size = new Size(182, 33);
            cboTenTiVi.TabIndex = 43;
            cboTenTiVi.SelectedIndexChanged += cboTenTiVi_SelectedIndexChanged;
            cboTenTiVi.SelectionChangeCommitted += cboTiVi_SelectionChangeCommitted;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(567, 35);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(182, 33);
            cboNhanVien.TabIndex = 41;
            // 
            // cboKhachHang
            // 
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(156, 30);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(182, 33);
            cboKhachHang.TabIndex = 40;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1012, 188);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 34);
            btnThoat.TabIndex = 39;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(708, 188);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 37;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(347, 188);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 34);
            btnXoa.TabIndex = 35;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // dtpNgayLap
            // 
            dtpNgayLap.Location = new Point(567, 97);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(300, 31);
            dtpNgayLap.TabIndex = 34;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(409, 38);
            label5.Name = "label5";
            label5.Size = new Size(98, 25);
            label5.TabIndex = 29;
            label5.Text = "Nhân Viên ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(409, 99);
            label4.Name = "label4";
            label4.Size = new Size(155, 25);
            label4.TabIndex = 28;
            label4.Text = "Ngày lập hóa đơn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 52);
            label3.Name = "label3";
            label3.Size = new Size(107, 25);
            label3.TabIndex = 27;
            label3.Text = "Khách Hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 103);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 26;
            label2.Text = "Tên tivi";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(156, 188);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 23;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvDanhSachHD
            // 
            dgvDanhSachHD.AllowUserToAddRows = false;
            dgvDanhSachHD.AllowUserToDeleteRows = false;
            dgvDanhSachHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachHD.Columns.AddRange(new DataGridViewColumn[] { MaTiVi, TenTiVi, ColKhuyenMai, colSoLuong, colDonGia, colThanhTien });
            dgvDanhSachHD.Dock = DockStyle.Fill;
            dgvDanhSachHD.Location = new Point(0, 274);
            dgvDanhSachHD.MultiSelect = false;
            dgvDanhSachHD.Name = "dgvDanhSachHD";
            dgvDanhSachHD.ReadOnly = true;
            dgvDanhSachHD.RowHeadersWidth = 62;
            dgvDanhSachHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachHD.Size = new Size(1754, 249);
            dgvDanhSachHD.TabIndex = 7;
            // 
            // MaTiVi
            // 
            MaTiVi.DataPropertyName = "MaTiVi";
            MaTiVi.HeaderText = "Mã TiVi";
            MaTiVi.MinimumWidth = 8;
            MaTiVi.Name = "MaTiVi";
            MaTiVi.ReadOnly = true;
            MaTiVi.Resizable = DataGridViewTriState.True;
            // 
            // TenTiVi
            // 
            TenTiVi.DataPropertyName = "TenTiVi";
            TenTiVi.HeaderText = "Tên TiVi";
            TenTiVi.MinimumWidth = 8;
            TenTiVi.Name = "TenTiVi";
            TenTiVi.ReadOnly = true;
            // 
            // ColKhuyenMai
            // 
            ColKhuyenMai.DataPropertyName = "KhuyenMai";
            ColKhuyenMai.HeaderText = "Khuyến Mãi";
            ColKhuyenMai.MinimumWidth = 8;
            ColKhuyenMai.Name = "ColKhuyenMai";
            ColKhuyenMai.ReadOnly = true;
            // 
            // colSoLuong
            // 
            colSoLuong.DataPropertyName = "SoLuongBan";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            colSoLuong.DefaultCellStyle = dataGridViewCellStyle1;
            colSoLuong.HeaderText = "Số Lượng";
            colSoLuong.MinimumWidth = 8;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            // 
            // colDonGia
            // 
            colDonGia.DataPropertyName = "DonGiaBan";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            colDonGia.DefaultCellStyle = dataGridViewCellStyle2;
            colDonGia.HeaderText = "Đơn Gía";
            colDonGia.MinimumWidth = 8;
            colDonGia.Name = "colDonGia";
            colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            colThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            colThanhTien.DefaultCellStyle = dataGridViewCellStyle3;
            colThanhTien.HeaderText = "Thành Tiền";
            colThanhTien.MinimumWidth = 8;
            colThanhTien.Name = "colThanhTien";
            colThanhTien.ReadOnly = true;
            // 
            // frmChiTietHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1754, 523);
            Controls.Add(dgvDanhSachHD);
            Controls.Add(groupBox1);
            Name = "frmChiTietHoaDon";
            Text = "frmChiTietHoaDon";
            Load += frmChiTietHoaDon_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHD).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtKhuyenMai;
        private Label label9;
        private TextBox txtDonGia;
        private TextBox txtSoLuong;
        private Label label8;
        private Label label7;
        private ComboBox cboTenTiVi;
        private ComboBox cboNhanVien;
        private ComboBox cboKhachHang;
        private Button btnThoat;
        private Button btnLuu;
        private Button btnXoa;
        private DateTimePicker dtpNgayLap;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnThem;
        private DataGridView dgvDanhSachHD;
        private TextBox txtGhiChu;
        private Label label1;
        private DataGridViewTextBoxColumn MaTiVi;
        private DataGridViewTextBoxColumn TenTiVi;
        private DataGridViewTextBoxColumn ColKhuyenMai;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;
    }
}