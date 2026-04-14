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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietHoaDon));
            dgvDanhSachHD = new DataGridView();
            MaTiVi = new DataGridViewTextBoxColumn();
            TenTiVi = new DataGridViewTextBoxColumn();
            ColKhuyenMai = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            colHinhThucThanhToan = new DataGridViewTextBoxColumn();
            btnThem = new Button();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            dtpNgayLap = new DateTimePicker();
            btnXoa = new Button();
            btnLuu = new Button();
            btnThoat = new Button();
            cboNhanVien = new ComboBox();
            cboTenTiVi = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            txtSoLuong = new TextBox();
            txtDonGia = new TextBox();
            label9 = new Label();
            txtKhuyenMai = new TextBox();
            label1 = new Label();
            txtGhiChu = new TextBox();
            lblTrangThaiTiVi = new Label();
            btnSua = new Button();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label6 = new Label();
            txtTenKhachHang = new TextBox();
            txtCCCD = new TextBox();
            txtDiaChi = new TextBox();
            dtpNgayThangNamSinh = new DateTimePicker();
            txtSDT_KhachHang = new TextBox();
            panelTraGop = new Panel();
            txtKyHanTra = new TextBox();
            label15 = new Label();
            txtLaiSuat = new TextBox();
            txtSoTienConNo = new TextBox();
            txtSoTienTraTruoc = new TextBox();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            rdoTienMat = new RadioButton();
            rdoTraGop = new RadioButton();
            lblTonKho = new Label();
            rdoChuyenKhoan = new RadioButton();
            groupBox1 = new GroupBox();
            btnHuyBo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHD).BeginInit();
            panelTraGop.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDanhSachHD
            // 
            dgvDanhSachHD.AllowUserToAddRows = false;
            dgvDanhSachHD.AllowUserToDeleteRows = false;
            dgvDanhSachHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachHD.Columns.AddRange(new DataGridViewColumn[] { MaTiVi, TenTiVi, ColKhuyenMai, colSoLuong, colDonGia, colThanhTien, colHinhThucThanhToan });
            dgvDanhSachHD.Dock = DockStyle.Fill;
            dgvDanhSachHD.Location = new Point(0, 310);
            dgvDanhSachHD.MultiSelect = false;
            dgvDanhSachHD.Name = "dgvDanhSachHD";
            dgvDanhSachHD.ReadOnly = true;
            dgvDanhSachHD.RowHeadersWidth = 62;
            dgvDanhSachHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachHD.Size = new Size(1754, 213);
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
            // colHinhThucThanhToan
            // 
            colHinhThucThanhToan.DataPropertyName = "HinhThucThanhToan";
            colHinhThucThanhToan.HeaderText = "Hình thức thanh";
            colHinhThucThanhToan.MinimumWidth = 8;
            colHinhThucThanhToan.Name = "colHinhThucThanhToan";
            colHinhThucThanhToan.ReadOnly = true;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Cyan;
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(1483, 52);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(126, 48);
            btnThem.TabIndex = 23;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 65);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 26;
            label2.Text = "Tên tivi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 105);
            label4.Name = "label4";
            label4.Size = new Size(155, 25);
            label4.TabIndex = 28;
            label4.Text = "Ngày lập hóa đơn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 145);
            label5.Name = "label5";
            label5.Size = new Size(98, 25);
            label5.TabIndex = 29;
            label5.Text = "Nhân Viên ";
            // 
            // dtpNgayLap
            // 
            dtpNgayLap.Location = new Point(160, 99);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(238, 31);
            dtpNgayLap.TabIndex = 34;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(1615, 52);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(127, 48);
            btnXoa.TabIndex = 35;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Yellow;
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(1625, 103);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(117, 48);
            btnLuu.TabIndex = 37;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(128, 255, 128);
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(1485, 157);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 48);
            btnThoat.TabIndex = 39;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(160, 139);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(238, 33);
            cboNhanVien.TabIndex = 41;
            // 
            // cboTenTiVi
            // 
            cboTenTiVi.FormattingEnabled = true;
            cboTenTiVi.Location = new Point(158, 57);
            cboTenTiVi.Name = "cboTenTiVi";
            cboTenTiVi.Size = new Size(236, 33);
            cboTenTiVi.TabIndex = 43;
            cboTenTiVi.SelectedIndexChanged += cboTenTiVi_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 185);
            label7.Name = "label7";
            label7.Size = new Size(89, 25);
            label7.TabIndex = 44;
            label7.Text = "Số Lượng";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 265);
            label8.Name = "label8";
            label8.Size = new Size(76, 25);
            label8.TabIndex = 45;
            label8.Text = "Đơn Gía";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(160, 181);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(236, 31);
            txtSoLuong.TabIndex = 46;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(162, 261);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.ReadOnly = true;
            txtDonGia.Size = new Size(236, 31);
            txtDonGia.TabIndex = 47;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 225);
            label9.Name = "label9";
            label9.Size = new Size(104, 25);
            label9.TabIndex = 48;
            label9.Text = "Khuyến Mãi";
            // 
            // txtKhuyenMai
            // 
            txtKhuyenMai.Location = new Point(160, 221);
            txtKhuyenMai.Name = "txtKhuyenMai";
            txtKhuyenMai.ReadOnly = true;
            txtKhuyenMai.Size = new Size(238, 31);
            txtKhuyenMai.TabIndex = 49;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(408, 266);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 50;
            label1.Text = "Ghi Chú";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(488, 263);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(1014, 31);
            txtGhiChu.TabIndex = 51;
            // 
            // lblTrangThaiTiVi
            // 
            lblTrangThaiTiVi.AutoSize = true;
            lblTrangThaiTiVi.Location = new Point(176, 186);
            lblTrangThaiTiVi.Name = "lblTrangThaiTiVi";
            lblTrangThaiTiVi.Size = new Size(0, 25);
            lblTrangThaiTiVi.TabIndex = 53;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Yellow;
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(1483, 106);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(122, 45);
            btnSua.TabIndex = 54;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(455, 103);
            label13.Name = "label13";
            label13.Size = new Size(138, 25);
            label13.TabIndex = 57;
            label13.Text = "Tên Khách Hàng";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(455, 60);
            label12.Name = "label12";
            label12.Size = new Size(122, 25);
            label12.TabIndex = 58;
            label12.Text = "Số Điện Thoại";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(455, 150);
            label11.Name = "label11";
            label11.Size = new Size(93, 25);
            label11.TabIndex = 59;
            label11.Text = "Ngày Sinh";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(455, 194);
            label10.Name = "label10";
            label10.Size = new Size(58, 25);
            label10.TabIndex = 60;
            label10.Text = "CCCD";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(455, 232);
            label6.Name = "label6";
            label6.Size = new Size(68, 25);
            label6.TabIndex = 61;
            label6.Text = "Địa Chỉ";
            // 
            // txtTenKhachHang
            // 
            txtTenKhachHang.Location = new Point(597, 101);
            txtTenKhachHang.Name = "txtTenKhachHang";
            txtTenKhachHang.Size = new Size(236, 31);
            txtTenKhachHang.TabIndex = 62;
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(597, 188);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(236, 31);
            txtCCCD.TabIndex = 63;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(597, 226);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(236, 31);
            txtDiaChi.TabIndex = 64;
            // 
            // dtpNgayThangNamSinh
            // 
            dtpNgayThangNamSinh.Location = new Point(597, 146);
            dtpNgayThangNamSinh.Name = "dtpNgayThangNamSinh";
            dtpNgayThangNamSinh.Size = new Size(236, 31);
            dtpNgayThangNamSinh.TabIndex = 65;
            // 
            // txtSDT_KhachHang
            // 
            txtSDT_KhachHang.Location = new Point(597, 57);
            txtSDT_KhachHang.Name = "txtSDT_KhachHang";
            txtSDT_KhachHang.Size = new Size(236, 31);
            txtSDT_KhachHang.TabIndex = 66;
            txtSDT_KhachHang.TextChanged += txtSDT_KhachHang_TextChanged;
            // 
            // panelTraGop
            // 
            panelTraGop.Controls.Add(txtKyHanTra);
            panelTraGop.Controls.Add(label15);
            panelTraGop.Controls.Add(txtLaiSuat);
            panelTraGop.Controls.Add(txtSoTienConNo);
            panelTraGop.Controls.Add(txtSoTienTraTruoc);
            panelTraGop.Controls.Add(label16);
            panelTraGop.Controls.Add(label17);
            panelTraGop.Controls.Add(label18);
            panelTraGop.Location = new Point(1031, 27);
            panelTraGop.Name = "panelTraGop";
            panelTraGop.Size = new Size(394, 230);
            panelTraGop.TabIndex = 79;
            // 
            // txtKyHanTra
            // 
            txtKyHanTra.Location = new Point(168, 71);
            txtKyHanTra.Name = "txtKyHanTra";
            txtKyHanTra.Size = new Size(182, 31);
            txtKyHanTra.TabIndex = 85;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(20, 72);
            label15.Name = "label15";
            label15.Size = new Size(94, 25);
            label15.TabIndex = 84;
            label15.Text = "Kỳ Hạn Trả";
            // 
            // txtLaiSuat
            // 
            txtLaiSuat.Location = new Point(168, 24);
            txtLaiSuat.Name = "txtLaiSuat";
            txtLaiSuat.Size = new Size(182, 31);
            txtLaiSuat.TabIndex = 83;
            txtLaiSuat.TextChanged += txtLaiSuat_TextChanged;
            // 
            // txtSoTienConNo
            // 
            txtSoTienConNo.Location = new Point(168, 165);
            txtSoTienConNo.Name = "txtSoTienConNo";
            txtSoTienConNo.ReadOnly = true;
            txtSoTienConNo.Size = new Size(182, 31);
            txtSoTienConNo.TabIndex = 82;
            // 
            // txtSoTienTraTruoc
            // 
            txtSoTienTraTruoc.Location = new Point(168, 118);
            txtSoTienTraTruoc.Name = "txtSoTienTraTruoc";
            txtSoTienTraTruoc.Size = new Size(182, 31);
            txtSoTienTraTruoc.TabIndex = 81;
            txtSoTienTraTruoc.TextChanged += txtSoTienTraTruoc_TextChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(20, 166);
            label16.Name = "label16";
            label16.Size = new Size(136, 25);
            label16.TabIndex = 80;
            label16.Text = "Số Tiền Còn Nợ";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(20, 119);
            label17.Name = "label17";
            label17.Size = new Size(145, 25);
            label17.TabIndex = 79;
            label17.Text = "Số Tiền Trả Trước";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(20, 25);
            label18.Name = "label18";
            label18.Size = new Size(73, 25);
            label18.TabIndex = 78;
            label18.Text = "Lãi Suất";
            // 
            // rdoTienMat
            // 
            rdoTienMat.AutoSize = true;
            rdoTienMat.Location = new Point(861, 59);
            rdoTienMat.Name = "rdoTienMat";
            rdoTienMat.Size = new Size(105, 29);
            rdoTienMat.TabIndex = 86;
            rdoTienMat.TabStop = true;
            rdoTienMat.Text = "Tiền Mặt";
            rdoTienMat.UseVisualStyleBackColor = true;
            // 
            // rdoTraGop
            // 
            rdoTraGop.AutoSize = true;
            rdoTraGop.Location = new Point(861, 148);
            rdoTraGop.Name = "rdoTraGop";
            rdoTraGop.Size = new Size(98, 29);
            rdoTraGop.TabIndex = 87;
            rdoTraGop.TabStop = true;
            rdoTraGop.Text = "Trả Góp";
            rdoTraGop.UseVisualStyleBackColor = true;
            rdoTraGop.CheckedChanged += rdoTraGop_CheckedChanged;
            // 
            // lblTonKho
            // 
            lblTonKho.AutoSize = true;
            lblTonKho.Location = new Point(200, 27);
            lblTonKho.Name = "lblTonKho";
            lblTonKho.Size = new Size(153, 25);
            lblTonKho.TabIndex = 88;
            lblTonKho.Text = "số lượng Tồn kho";
            // 
            // rdoChuyenKhoan
            // 
            rdoChuyenKhoan.AutoSize = true;
            rdoChuyenKhoan.Location = new Point(862, 105);
            rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            rdoChuyenKhoan.Size = new Size(162, 29);
            rdoChuyenKhoan.TabIndex = 89;
            rdoChuyenKhoan.TabStop = true;
            rdoChuyenKhoan.Text = "Chuyển Khoảng";
            rdoChuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(224, 224, 224);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(rdoChuyenKhoan);
            groupBox1.Controls.Add(lblTonKho);
            groupBox1.Controls.Add(rdoTraGop);
            groupBox1.Controls.Add(rdoTienMat);
            groupBox1.Controls.Add(panelTraGop);
            groupBox1.Controls.Add(txtSDT_KhachHang);
            groupBox1.Controls.Add(dtpNgayThangNamSinh);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtCCCD);
            groupBox1.Controls.Add(txtTenKhachHang);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(lblTrangThaiTiVi);
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
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(dtpNgayLap);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1754, 310);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Chi Tiết Hóa Đơn";
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.FromArgb(255, 192, 128);
            btnHuyBo.Image = (Image)resources.GetObject("btnHuyBo.Image");
            btnHuyBo.ImageAlign = ContentAlignment.MiddleLeft;
            btnHuyBo.Location = new Point(1625, 160);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(117, 50);
            btnHuyBo.TabIndex = 90;
            btnHuyBo.Text = "Hủy Bỏ";
            btnHuyBo.UseVisualStyleBackColor = false;
            btnHuyBo.Click += btnHuyBo_Click;
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
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHD).EndInit();
            panelTraGop.ResumeLayout(false);
            panelTraGop.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvDanhSachHD;
        private DataGridViewTextBoxColumn MaTiVi;
        private DataGridViewTextBoxColumn TenTiVi;
        private DataGridViewTextBoxColumn ColKhuyenMai;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;
        private DataGridViewTextBoxColumn colHinhThucThanhToan;
        private Button btnThem;
        private Label label2;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpNgayLap;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnThoat;
        private ComboBox cboNhanVien;
        private ComboBox cboTenTiVi;
        private Label label7;
        private Label label8;
        private TextBox txtSoLuong;
        private TextBox txtDonGia;
        private Label label9;
        private TextBox txtKhuyenMai;
        private Label label1;
        private TextBox txtGhiChu;
        private Label lblTrangThaiTiVi;
        private Button btnSua;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label6;
        private TextBox txtTenKhachHang;
        private TextBox txtCCCD;
        private TextBox txtDiaChi;
        private DateTimePicker dtpNgayThangNamSinh;
        private TextBox txtSDT_KhachHang;
        private Panel panelTraGop;
        private TextBox txtKyHanTra;
        private Label label15;
        private TextBox txtLaiSuat;
        private TextBox txtSoTienConNo;
        private TextBox txtSoTienTraTruoc;
        private Label label16;
        private Label label17;
        private Label label18;
        private RadioButton rdoTienMat;
        private RadioButton rdoTraGop;
        private Label lblTonKho;
        private RadioButton rdoChuyenKhoan;
        private GroupBox groupBox1;
        private Button btnHuyBo;
    }
}