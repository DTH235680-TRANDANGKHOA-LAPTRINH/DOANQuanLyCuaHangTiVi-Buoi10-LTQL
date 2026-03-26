namespace QuanLyCuaHangTiVi.forms
{
    partial class frmThongkeChiPhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongkeChiPhi));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnLuu = new Button();
            txtTienDien = new TextBox();
            label5 = new Label();
            btnLamMoi = new Button();
            btnSua = new Button();
            txtTienBaoTri = new TextBox();
            label4 = new Label();
            nudNam = new NumericUpDown();
            label2 = new Label();
            nudThang = new NumericUpDown();
            btnThongKe = new Button();
            txtTienNuoc = new TextBox();
            txtTienMatBang = new TextBox();
            label1 = new Label();
            lblTienMatBang = new Label();
            lblTienDienNuoc = new Label();
            lblTongTienNhap = new Label();
            panel4 = new Panel();
            txtTongChiPhi = new TextBox();
            label7 = new Label();
            txtTongChiPhiVanHanh = new TextBox();
            label6 = new Label();
            txtTongTienNhap = new TextBox();
            txtTongLuong = new TextBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            dgvChiPhiNhapHang = new DataGridView();
            colTenTiVi = new DataGridViewTextBoxColumn();
            colHangSanXuat = new DataGridViewTextBoxColumn();
            colNgayNhap = new DataGridViewTextBoxColumn();
            colDonGiaNhap = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            dgvChiPhiLuongNhanVien = new DataGridView();
            MaNhanVien = new DataGridViewTextBoxColumn();
            HoTenNhanVien = new DataGridViewTextBoxColumn();
            QuyenHan = new DataGridViewTextBoxColumn();
            ColLuong = new DataGridViewTextBoxColumn();
            dgvNhanVien = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            panel4.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiPhiNhapHang).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiPhiLuongNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(txtTienDien);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(txtTienBaoTri);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(nudNam);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(nudThang);
            panel1.Controls.Add(btnThongKe);
            panel1.Controls.Add(txtTienNuoc);
            panel1.Controls.Add(txtTienMatBang);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblTienMatBang);
            panel1.Controls.Add(lblTienDienNuoc);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 689);
            panel1.TabIndex = 0;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(128, 255, 128);
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(158, 592);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 42;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // txtTienDien
            // 
            txtTienDien.BackColor = Color.FromArgb(255, 192, 192);
            txtTienDien.Location = new Point(12, 303);
            txtTienDien.Multiline = true;
            txtTienDien.Name = "txtTienDien";
            txtTienDien.Size = new Size(278, 43);
            txtTienDien.TabIndex = 41;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 275);
            label5.Name = "label5";
            label5.Size = new Size(85, 25);
            label5.TabIndex = 40;
            label5.Text = "Tiền Điện";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(255, 128, 128);
            btnLamMoi.Image = (Image)resources.GetObject("btnLamMoi.Image");
            btnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamMoi.Location = new Point(80, 634);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(138, 43);
            btnLamMoi.TabIndex = 39;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 255, 128);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(31, 592);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 38;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // txtTienBaoTri
            // 
            txtTienBaoTri.BackColor = Color.FromArgb(128, 255, 128);
            txtTienBaoTri.Location = new Point(12, 534);
            txtTienBaoTri.Multiline = true;
            txtTienBaoTri.Name = "txtTienBaoTri";
            txtTienBaoTri.Size = new Size(278, 43);
            txtTienBaoTri.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 506);
            label4.Name = "label4";
            label4.Size = new Size(106, 25);
            label4.TabIndex = 15;
            label4.Text = "Tiền Bảo Trì ";
            // 
            // nudNam
            // 
            nudNam.Location = new Point(21, 103);
            nudNam.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudNam.Name = "nudNam";
            nudNam.Size = new Size(180, 31);
            nudNam.TabIndex = 14;
            nudNam.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 75);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 13;
            label2.Text = "Năm";
            // 
            // nudThang
            // 
            nudThang.Location = new Point(21, 39);
            nudThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudThang.Name = "nudThang";
            nudThang.Size = new Size(180, 31);
            nudThang.TabIndex = 12;
            nudThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.Cyan;
            btnThongKe.Font = new Font("Times New Roman", 26F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnThongKe.ForeColor = Color.Red;
            btnThongKe.Location = new Point(18, 151);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(257, 99);
            btnThongKe.TabIndex = 11;
            btnThongKe.Text = "Thống Kê";
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // txtTienNuoc
            // 
            txtTienNuoc.BackColor = Color.DeepSkyBlue;
            txtTienNuoc.Location = new Point(12, 377);
            txtTienNuoc.Multiline = true;
            txtTienNuoc.Name = "txtTienNuoc";
            txtTienNuoc.Size = new Size(278, 43);
            txtTienNuoc.TabIndex = 6;
            // 
            // txtTienMatBang
            // 
            txtTienMatBang.BackColor = Color.Silver;
            txtTienMatBang.Location = new Point(12, 449);
            txtTienMatBang.Multiline = true;
            txtTienMatBang.Name = "txtTienMatBang";
            txtTienMatBang.Size = new Size(278, 43);
            txtTienMatBang.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 11);
            label1.Name = "label1";
            label1.Size = new Size(61, 25);
            label1.TabIndex = 0;
            label1.Text = "Tháng";
            // 
            // lblTienMatBang
            // 
            lblTienMatBang.AutoSize = true;
            lblTienMatBang.Location = new Point(18, 421);
            lblTienMatBang.Name = "lblTienMatBang";
            lblTienMatBang.Size = new Size(125, 25);
            lblTienMatBang.TabIndex = 2;
            lblTienMatBang.Text = "Tiền Mặt Bằng";
            // 
            // lblTienDienNuoc
            // 
            lblTienDienNuoc.AutoSize = true;
            lblTienDienNuoc.Location = new Point(21, 349);
            lblTienDienNuoc.Name = "lblTienDienNuoc";
            lblTienDienNuoc.Size = new Size(92, 25);
            lblTienDienNuoc.TabIndex = 3;
            lblTienDienNuoc.Text = "Tiền Nước";
            // 
            // lblTongTienNhap
            // 
            lblTongTienNhap.AutoSize = true;
            lblTongTienNhap.Location = new Point(9, 17);
            lblTongTienNhap.Name = "lblTongTienNhap";
            lblTongTienNhap.Size = new Size(186, 25);
            lblTongTienNhap.TabIndex = 4;
            lblTongTienNhap.Text = "Tổng Tiền Nhập Hàng";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(224, 224, 224);
            panel4.Controls.Add(txtTongChiPhi);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(txtTongChiPhiVanHanh);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(txtTongTienNhap);
            panel4.Controls.Add(txtTongLuong);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(lblTongTienNhap);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1488, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(210, 689);
            panel4.TabIndex = 3;
            // 
            // txtTongChiPhi
            // 
            txtTongChiPhi.BackColor = Color.Lime;
            txtTongChiPhi.Location = new Point(6, 532);
            txtTongChiPhi.Multiline = true;
            txtTongChiPhi.Name = "txtTongChiPhi";
            txtTongChiPhi.ReadOnly = true;
            txtTongChiPhi.Size = new Size(201, 145);
            txtTongChiPhi.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 487);
            label7.Name = "label7";
            label7.Size = new Size(112, 25);
            label7.TabIndex = 13;
            label7.Text = "Tổng Chi Phí";
            // 
            // txtTongChiPhiVanHanh
            // 
            txtTongChiPhiVanHanh.BackColor = Color.Yellow;
            txtTongChiPhiVanHanh.Location = new Point(9, 332);
            txtTongChiPhiVanHanh.Multiline = true;
            txtTongChiPhiVanHanh.Name = "txtTongChiPhiVanHanh";
            txtTongChiPhiVanHanh.ReadOnly = true;
            txtTongChiPhiVanHanh.Size = new Size(194, 114);
            txtTongChiPhiVanHanh.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 287);
            label6.Name = "label6";
            label6.Size = new Size(194, 25);
            label6.TabIndex = 11;
            label6.Text = "Tổng Chi Phí Vận Hành";
            // 
            // txtTongTienNhap
            // 
            txtTongTienNhap.BackColor = Color.FromArgb(255, 128, 128);
            txtTongTienNhap.Location = new Point(9, 72);
            txtTongTienNhap.Multiline = true;
            txtTongTienNhap.Name = "txtTongTienNhap";
            txtTongTienNhap.ReadOnly = true;
            txtTongTienNhap.Size = new Size(198, 79);
            txtTongTienNhap.TabIndex = 10;
            // 
            // txtTongLuong
            // 
            txtTongLuong.BackColor = Color.Cyan;
            txtTongLuong.Location = new Point(9, 213);
            txtTongLuong.Multiline = true;
            txtTongLuong.Name = "txtTongLuong";
            txtTongLuong.ReadOnly = true;
            txtTongLuong.Size = new Size(198, 71);
            txtTongLuong.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 154);
            label3.Name = "label3";
            label3.Size = new Size(146, 25);
            label3.TabIndex = 7;
            label3.Text = "Tổng Tiền Lương";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvChiPhiNhapHang);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(300, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1188, 689);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chi Phí Nhập Hàng";
            // 
            // dgvChiPhiNhapHang
            // 
            dgvChiPhiNhapHang.AllowUserToAddRows = false;
            dgvChiPhiNhapHang.AllowUserToDeleteRows = false;
            dgvChiPhiNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiPhiNhapHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiPhiNhapHang.Columns.AddRange(new DataGridViewColumn[] { colTenTiVi, colHangSanXuat, colNgayNhap, colDonGiaNhap });
            dgvChiPhiNhapHang.Dock = DockStyle.Fill;
            dgvChiPhiNhapHang.Location = new Point(3, 27);
            dgvChiPhiNhapHang.MultiSelect = false;
            dgvChiPhiNhapHang.Name = "dgvChiPhiNhapHang";
            dgvChiPhiNhapHang.RowHeadersWidth = 62;
            dgvChiPhiNhapHang.Size = new Size(1182, 659);
            dgvChiPhiNhapHang.TabIndex = 2;
            dgvChiPhiNhapHang.CellContentClick += dgvChiPhiNhapHang_CellContentClick;
            // 
            // colTenTiVi
            // 
            colTenTiVi.DataPropertyName = "TenTiVi";
            colTenTiVi.HeaderText = "Tên TiVi";
            colTenTiVi.MinimumWidth = 8;
            colTenTiVi.Name = "colTenTiVi";
            // 
            // colHangSanXuat
            // 
            colHangSanXuat.DataPropertyName = "HangSanXuat";
            colHangSanXuat.HeaderText = "Hãng Sản Xuất";
            colHangSanXuat.MinimumWidth = 8;
            colHangSanXuat.Name = "colHangSanXuat";
            // 
            // colNgayNhap
            // 
            colNgayNhap.DataPropertyName = "NgayNhap";
            colNgayNhap.HeaderText = "Ngày Nhập Hàng";
            colNgayNhap.MinimumWidth = 8;
            colNgayNhap.Name = "colNgayNhap";
            // 
            // colDonGiaNhap
            // 
            colDonGiaNhap.DataPropertyName = "DonGiaNhap";
            dataGridViewCellStyle3.Format = "N0";
            colDonGiaNhap.DefaultCellStyle = dataGridViewCellStyle3;
            colDonGiaNhap.HeaderText = "Đơn Gía Nhập";
            colDonGiaNhap.MinimumWidth = 8;
            colDonGiaNhap.Name = "colDonGiaNhap";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvChiPhiLuongNhanVien);
            groupBox2.Controls.Add(dgvNhanVien);
            groupBox2.Dock = DockStyle.Bottom;
            groupBox2.Location = new Point(300, 401);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1188, 288);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi Phí Lương Nhân Viên";
            // 
            // dgvChiPhiLuongNhanVien
            // 
            dgvChiPhiLuongNhanVien.AllowUserToAddRows = false;
            dgvChiPhiLuongNhanVien.AllowUserToDeleteRows = false;
            dgvChiPhiLuongNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiPhiLuongNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiPhiLuongNhanVien.Columns.AddRange(new DataGridViewColumn[] { MaNhanVien, HoTenNhanVien, QuyenHan, ColLuong });
            dgvChiPhiLuongNhanVien.Dock = DockStyle.Fill;
            dgvChiPhiLuongNhanVien.Location = new Point(3, 27);
            dgvChiPhiLuongNhanVien.MultiSelect = false;
            dgvChiPhiLuongNhanVien.Name = "dgvChiPhiLuongNhanVien";
            dgvChiPhiLuongNhanVien.RowHeadersWidth = 62;
            dgvChiPhiLuongNhanVien.Size = new Size(1182, 258);
            dgvChiPhiLuongNhanVien.TabIndex = 3;
            // 
            // MaNhanVien
            // 
            MaNhanVien.DataPropertyName = "MaNhanVien";
            MaNhanVien.HeaderText = "Mã Nhân Viên";
            MaNhanVien.MinimumWidth = 8;
            MaNhanVien.Name = "MaNhanVien";
            // 
            // HoTenNhanVien
            // 
            HoTenNhanVien.DataPropertyName = "HoTenNhanVien";
            HoTenNhanVien.HeaderText = "Họ Tên";
            HoTenNhanVien.MinimumWidth = 8;
            HoTenNhanVien.Name = "HoTenNhanVien";
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            ColLuong.DefaultCellStyle = dataGridViewCellStyle4;
            ColLuong.HeaderText = "Lương";
            ColLuong.MinimumWidth = 8;
            ColLuong.Name = "ColLuong";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(3, 27);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 62;
            dgvNhanVien.Size = new Size(1182, 258);
            dgvNhanVien.TabIndex = 1;
            // 
            // frmThongkeChiPhi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1698, 689);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "frmThongkeChiPhi";
            Text = "Thống Kê Chi Phi";
            Load += frmThongkeChiPhi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiPhiNhapHang).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiPhiLuongNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblTongTienNhap;
        private Label lblTienDienNuoc;
        private Label lblTienMatBang;
        private DataGridView dgvNhanVien;
        private TextBox txtTienMatBang;
        private Label label3;
        private TextBox txtTongTienNhap;
        private TextBox txtTongLuong;
        private TextBox txtTienNuoc;
        private DataGridView dgvChiPhiLuongNhanVien;
        private DataGridViewTextBoxColumn MaNhanVien;
        private DataGridViewTextBoxColumn HoTenNhanVien;
        private DataGridViewTextBoxColumn QuyenHan;
        private DataGridViewTextBoxColumn ColLuong;
        private DataGridView dgvChiPhiNhapHang;
        private Button btnThongKe;
        private TextBox txtTienBaoTri;
        private Label label4;
        private NumericUpDown nudNam;
        private Label label2;
        private NumericUpDown nudThang;
        private Button btnLamMoi;
        private Button btnSua;
        private TextBox txtTienDien;
        private Label label5;
        private TextBox txtTongChiPhiVanHanh;
        private Label label6;
        private Button btnLuu;
        private TextBox txtTongChiPhi;
        private Label label7;
        private DataGridViewTextBoxColumn colTenTiVi;
        private DataGridViewTextBoxColumn colHangSanXuat;
        private DataGridViewTextBoxColumn colNgayNhap;
        private DataGridViewTextBoxColumn colDonGiaNhap;
    }
}