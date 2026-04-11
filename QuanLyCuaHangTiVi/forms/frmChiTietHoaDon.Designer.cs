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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietHoaDon));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            lblTonKho = new Label();
            rdoTraGop = new RadioButton();
            rdoTienMat = new RadioButton();
            panelTraGop = new Panel();
            txtKyHanTra = new TextBox();
            label15 = new Label();
            txtLaiSuat = new TextBox();
            txtSoTienConNo = new TextBox();
            txtSoTienTraTruoc = new TextBox();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            lblTrangThaiKhach = new Label();
            txtSDT_KhachHang = new TextBox();
            dtpNgayThangNamSinh = new DateTimePicker();
            txtDiaChi = new TextBox();
            txtCCCD = new TextBox();
            txtTenKhachHang = new TextBox();
            label6 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            btnSua = new Button();
            lblTrangThaiTiVi = new Label();
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
            btnThoat = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            dtpNgayLap = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            btnThem = new Button();
            dgvDanhSachHD = new DataGridView();
            rdoChuyenKhoan = new RadioButton();
            MaTiVi = new DataGridViewTextBoxColumn();
            TenTiVi = new DataGridViewTextBoxColumn();
            ColKhuyenMai = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            colHinhThucThanhToan = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            panelTraGop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHD).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(224, 224, 224);
            groupBox1.Controls.Add(rdoChuyenKhoan);
            groupBox1.Controls.Add(lblTonKho);
            groupBox1.Controls.Add(rdoTraGop);
            groupBox1.Controls.Add(rdoTienMat);
            groupBox1.Controls.Add(panelTraGop);
            groupBox1.Controls.Add(lblTrangThaiKhach);
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
            // lblTonKho
            // 
            lblTonKho.AutoSize = true;
            lblTonKho.Location = new Point(86, 27);
            lblTonKho.Name = "lblTonKho";
            lblTonKho.Size = new Size(153, 25);
            lblTonKho.TabIndex = 88;
            lblTonKho.Text = "số lượng Tồn kho";
            // 
            // rdoTraGop
            // 
            rdoTraGop.AutoSize = true;
            rdoTraGop.Location = new Point(870, 178);
            rdoTraGop.Name = "rdoTraGop";
            rdoTraGop.Size = new Size(98, 29);
            rdoTraGop.TabIndex = 87;
            rdoTraGop.TabStop = true;
            rdoTraGop.Text = "Trả Góp";
            rdoTraGop.UseVisualStyleBackColor = true;
            rdoTraGop.CheckedChanged += rdoTraGop_CheckedChanged;
            // 
            // rdoTienMat
            // 
            rdoTienMat.AutoSize = true;
            rdoTienMat.Location = new Point(863, 59);
            rdoTienMat.Name = "rdoTienMat";
            rdoTienMat.Size = new Size(105, 29);
            rdoTienMat.TabIndex = 86;
            rdoTienMat.TabStop = true;
            rdoTienMat.Text = "Tiền Mặt";
            rdoTienMat.UseVisualStyleBackColor = true;
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
            panelTraGop.Location = new Point(1031, 12);
            panelTraGop.Name = "panelTraGop";
            panelTraGop.Size = new Size(371, 237);
            panelTraGop.TabIndex = 79;
            // 
            // txtKyHanTra
            // 
            txtKyHanTra.Location = new Point(171, 82);
            txtKyHanTra.Name = "txtKyHanTra";
            txtKyHanTra.Size = new Size(182, 31);
            txtKyHanTra.TabIndex = 85;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(23, 83);
            label15.Name = "label15";
            label15.Size = new Size(94, 25);
            label15.TabIndex = 84;
            label15.Text = "Kỳ Hạn Trả";
            // 
            // txtLaiSuat
            // 
            txtLaiSuat.Location = new Point(171, 29);
            txtLaiSuat.Name = "txtLaiSuat";
            txtLaiSuat.Size = new Size(182, 31);
            txtLaiSuat.TabIndex = 83;
            // 
            // txtSoTienConNo
            // 
            txtSoTienConNo.Location = new Point(171, 172);
            txtSoTienConNo.Name = "txtSoTienConNo";
            txtSoTienConNo.ReadOnly = true;
            txtSoTienConNo.Size = new Size(182, 31);
            txtSoTienConNo.TabIndex = 82;
            // 
            // txtSoTienTraTruoc
            // 
            txtSoTienTraTruoc.Location = new Point(171, 135);
            txtSoTienTraTruoc.Name = "txtSoTienTraTruoc";
            txtSoTienTraTruoc.Size = new Size(182, 31);
            txtSoTienTraTruoc.TabIndex = 81;
            txtSoTienTraTruoc.TextChanged += txtSoTienTraTruoc_TextChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(23, 173);
            label16.Name = "label16";
            label16.Size = new Size(136, 25);
            label16.TabIndex = 80;
            label16.Text = "Số Tiền Còn Nợ";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(23, 136);
            label17.Name = "label17";
            label17.Size = new Size(145, 25);
            label17.TabIndex = 79;
            label17.Text = "Số Tiền Trả Trước";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(23, 30);
            label18.Name = "label18";
            label18.Size = new Size(73, 25);
            label18.TabIndex = 78;
            label18.Text = "Lãi Suất";
            // 
            // lblTrangThaiKhach
            // 
            lblTrangThaiKhach.AutoSize = true;
            lblTrangThaiKhach.Location = new Point(448, 9);
            lblTrangThaiKhach.Name = "lblTrangThaiKhach";
            lblTrangThaiKhach.Size = new Size(116, 25);
            lblTrangThaiKhach.TabIndex = 78;
            lblTrangThaiKhach.Text = "Khách Hàng: ";
            // 
            // txtSDT_KhachHang
            // 
            txtSDT_KhachHang.Location = new Point(584, 101);
            txtSDT_KhachHang.Name = "txtSDT_KhachHang";
            txtSDT_KhachHang.Size = new Size(236, 31);
            txtSDT_KhachHang.TabIndex = 66;
            txtSDT_KhachHang.Leave += txtSDT_KhachHang_Leave;
            // 
            // dtpNgayThangNamSinh
            // 
            dtpNgayThangNamSinh.Location = new Point(584, 146);
            dtpNgayThangNamSinh.Name = "dtpNgayThangNamSinh";
            dtpNgayThangNamSinh.Size = new Size(236, 31);
            dtpNgayThangNamSinh.TabIndex = 65;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(584, 225);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(236, 31);
            txtDiaChi.TabIndex = 64;
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(584, 183);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(236, 31);
            txtCCCD.TabIndex = 63;
            // 
            // txtTenKhachHang
            // 
            txtTenKhachHang.Location = new Point(584, 58);
            txtTenKhachHang.Name = "txtTenKhachHang";
            txtTenKhachHang.Size = new Size(236, 31);
            txtTenKhachHang.TabIndex = 62;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(426, 211);
            label6.Name = "label6";
            label6.Size = new Size(68, 25);
            label6.TabIndex = 61;
            label6.Text = "Địa Chỉ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(426, 171);
            label10.Name = "label10";
            label10.Size = new Size(58, 25);
            label10.TabIndex = 60;
            label10.Text = "CCCD";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(426, 147);
            label11.Name = "label11";
            label11.Size = new Size(93, 25);
            label11.TabIndex = 59;
            label11.Text = "Ngày Sinh";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(426, 107);
            label12.Name = "label12";
            label12.Size = new Size(122, 25);
            label12.TabIndex = 58;
            label12.Text = "Số Điện Thoại";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(426, 67);
            label13.Name = "label13";
            label13.Size = new Size(138, 25);
            label13.TabIndex = 57;
            label13.Text = "Tên Khách Hàng";
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
            // lblTrangThaiTiVi
            // 
            lblTrangThaiTiVi.AutoSize = true;
            lblTrangThaiTiVi.Location = new Point(127, 180);
            lblTrangThaiTiVi.Name = "lblTrangThaiTiVi";
            lblTrangThaiTiVi.Size = new Size(0, 25);
            lblTrangThaiTiVi.TabIndex = 53;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(488, 263);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(1014, 31);
            txtGhiChu.TabIndex = 51;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(391, 266);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 50;
            label1.Text = "Ghi Chú";
            // 
            // txtKhuyenMai
            // 
            txtKhuyenMai.Location = new Point(153, 221);
            txtKhuyenMai.Name = "txtKhuyenMai";
            txtKhuyenMai.ReadOnly = true;
            txtKhuyenMai.Size = new Size(238, 31);
            txtKhuyenMai.TabIndex = 49;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(41, 223);
            label9.Name = "label9";
            label9.Size = new Size(104, 25);
            label9.TabIndex = 48;
            label9.Text = "Khuyến Mãi";
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(153, 261);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.ReadOnly = true;
            txtDonGia.Size = new Size(236, 31);
            txtDonGia.TabIndex = 47;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(153, 181);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(236, 31);
            txtSoLuong.TabIndex = 46;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(74, 263);
            label8.Name = "label8";
            label8.Size = new Size(76, 25);
            label8.TabIndex = 45;
            label8.Text = "Đơn Gía";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(50, 183);
            label7.Name = "label7";
            label7.Size = new Size(89, 25);
            label7.TabIndex = 44;
            label7.Text = "Số Lượng";
            // 
            // cboTenTiVi
            // 
            cboTenTiVi.FormattingEnabled = true;
            cboTenTiVi.Location = new Point(153, 57);
            cboTenTiVi.Name = "cboTenTiVi";
            cboTenTiVi.Size = new Size(236, 33);
            cboTenTiVi.TabIndex = 43;
            cboTenTiVi.SelectedIndexChanged += cboTenTiVi_SelectedIndexChanged;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(153, 139);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(238, 33);
            cboNhanVien.TabIndex = 41;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(128, 255, 128);
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(1625, 154);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 48);
            btnThoat.TabIndex = 39;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
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
            // dtpNgayLap
            // 
            dtpNgayLap.Location = new Point(153, 99);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(238, 31);
            dtpNgayLap.TabIndex = 34;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 143);
            label5.Name = "label5";
            label5.Size = new Size(98, 25);
            label5.TabIndex = 29;
            label5.Text = "Nhân Viên ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(-8, 103);
            label4.Name = "label4";
            label4.Size = new Size(155, 25);
            label4.TabIndex = 28;
            label4.Text = "Ngày lập hóa đơn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 63);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 26;
            label2.Text = "Tên tivi";
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
            // rdoChuyenKhoan
            // 
            rdoChuyenKhoan.AutoSize = true;
            rdoChuyenKhoan.Location = new Point(863, 113);
            rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            rdoChuyenKhoan.Size = new Size(162, 29);
            rdoChuyenKhoan.TabIndex = 89;
            rdoChuyenKhoan.TabStop = true;
            rdoChuyenKhoan.Text = "Chuyển Khoảng";
            rdoChuyenKhoan.UseVisualStyleBackColor = true;
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
            panelTraGop.ResumeLayout(false);
            panelTraGop.PerformLayout();
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
        private Button btnThoat;
        private Button btnLuu;
        private Button btnXoa;
        private DateTimePicker dtpNgayLap;
        private Label label5;
        private Label label4;
        private Label label2;
        private Button btnThem;
        private DataGridView dgvDanhSachHD;
        private TextBox txtGhiChu;
        private Label label1;
        private Label lblTrangThaiTiVi;
        private Button btnSua;
        private TextBox txtSDT_KhachHang;
        private DateTimePicker dtpNgayThangNamSinh;
        private TextBox txtDiaChi;
        private TextBox txtCCCD;
        private TextBox txtTenKhachHang;
        private Label label6;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Panel panelTraGop;
        private TextBox txtKyHanTra;
        private Label label15;
        private TextBox txtLaiSuat;
        private TextBox txtSoTienConNo;
        private TextBox txtSoTienTraTruoc;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label lblTrangThaiKhach;
        private RadioButton rdoTraGop;
        private RadioButton rdoTienMat;
        private Label lblTonKho;
        private RadioButton rdoChuyenKhoan;
        private DataGridViewTextBoxColumn MaTiVi;
        private DataGridViewTextBoxColumn TenTiVi;
        private DataGridViewTextBoxColumn ColKhuyenMai;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;
        private DataGridViewTextBoxColumn colHinhThucThanhToan;
    }
}