namespace QuanLyCuaHangTiVi.forms
{
    partial class frmChiTietPhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietPhieuNhap));
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            txtThanhTien = new TextBox();
            label7 = new Label();
            txtDonGiaNhap = new TextBox();
            label6 = new Label();
            cboMaTiVi = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            dtpNgayNhap = new DateTimePicker();
            cboMaPhieuNhap = new ComboBox();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            txtSoLuong = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtMaCTPN = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            dgvChiTietPhieuNhap = new DataGridView();
            MaCTPN = new DataGridViewTextBoxColumn();
            MaPhieuNhap = new DataGridViewTextBoxColumn();
            NgayNhap = new DataGridViewTextBoxColumn();
            MaTiVi = new DataGridViewTextBoxColumn();
            SoLuongNhap = new DataGridViewTextBoxColumn();
            DonGiaNhap = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieuNhap).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtThanhTien);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtDonGiaNhap);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cboMaTiVi);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtpNgayNhap);
            panel1.Controls.Add(cboMaPhieuNhap);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnHuyBo);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(txtSoLuong);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtMaCTPN);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1632, 233);
            panel1.TabIndex = 2;
            // 
            // txtThanhTien
            // 
            txtThanhTien.Location = new Point(1401, 26);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.Size = new Size(150, 31);
            txtThanhTien.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1243, 29);
            label7.Name = "label7";
            label7.Size = new Size(97, 25);
            label7.TabIndex = 25;
            label7.Text = "Thành Tiền";
            // 
            // txtDonGiaNhap
            // 
            txtDonGiaNhap.Location = new Point(1076, 79);
            txtDonGiaNhap.Name = "txtDonGiaNhap";
            txtDonGiaNhap.Size = new Size(150, 31);
            txtDonGiaNhap.TabIndex = 24;
            txtDonGiaNhap.TextChanged += txtSoLuong_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(937, 82);
            label6.Name = "label6";
            label6.Size = new Size(124, 25);
            label6.TabIndex = 23;
            label6.Text = "Đơn Gía Nhập";
            // 
            // cboMaTiVi
            // 
            cboMaTiVi.FormattingEnabled = true;
            cboMaTiVi.Items.AddRange(new object[] { "Quản Lý", "Nhân Viên ", "Chủ Quán" });
            cboMaTiVi.Location = new Point(639, 78);
            cboMaTiVi.Name = "cboMaTiVi";
            cboMaTiVi.Size = new Size(182, 33);
            cboMaTiVi.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(483, 82);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 21;
            label3.Text = "Tên TIVI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(483, 29);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 20;
            label2.Text = "ngày nhập";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(639, 26);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(300, 31);
            dtpNgayNhap.TabIndex = 19;
            // 
            // cboMaPhieuNhap
            // 
            cboMaPhieuNhap.FormattingEnabled = true;
            cboMaPhieuNhap.Items.AddRange(new object[] { "Quản Lý", "Nhân Viên ", "Chủ Quán" });
            cboMaPhieuNhap.Location = new Point(268, 78);
            cboMaPhieuNhap.Name = "cboMaPhieuNhap";
            cboMaPhieuNhap.Size = new Size(182, 33);
            cboMaPhieuNhap.TabIndex = 18;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(128, 255, 128);
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(990, 148);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(127, 53);
            btnThoat.TabIndex = 17;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.FromArgb(255, 192, 192);
            btnHuyBo.Image = (Image)resources.GetObject("btnHuyBo.Image");
            btnHuyBo.ImageAlign = ContentAlignment.MiddleLeft;
            btnHuyBo.Location = new Point(850, 148);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(117, 53);
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
            btnLuu.Location = new Point(686, 148);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(119, 53);
            btnLuu.TabIndex = 15;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Yellow;
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(519, 148);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(119, 53);
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
            btnXoa.Location = new Point(325, 148);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(125, 53);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(1076, 26);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(150, 31);
            txtSoLuong.TabIndex = 11;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(113, 82);
            label5.Name = "label5";
            label5.Size = new Size(133, 25);
            label5.TabIndex = 6;
            label5.Text = "Mã Phiếu Nhập";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(972, 29);
            label4.Name = "label4";
            label4.Size = new Size(89, 25);
            label4.TabIndex = 5;
            label4.Text = "Số Lượng";
            // 
            // txtMaCTPN
            // 
            txtMaCTPN.Location = new Point(268, 26);
            txtMaCTPN.Name = "txtMaCTPN";
            txtMaCTPN.Size = new Size(182, 31);
            txtMaCTPN.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 29);
            label1.Name = "label1";
            label1.Size = new Size(196, 25);
            label1.TabIndex = 1;
            label1.Text = "Mã Chi Tiết Phiếu Nhập";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Cyan;
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(134, 148);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(133, 53);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvChiTietPhieuNhap
            // 
            dgvChiTietPhieuNhap.AllowUserToAddRows = false;
            dgvChiTietPhieuNhap.AllowUserToDeleteRows = false;
            dgvChiTietPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietPhieuNhap.Columns.AddRange(new DataGridViewColumn[] { MaCTPN, MaPhieuNhap, NgayNhap, MaTiVi, SoLuongNhap, DonGiaNhap, ThanhTien });
            dgvChiTietPhieuNhap.Dock = DockStyle.Fill;
            dgvChiTietPhieuNhap.Location = new Point(0, 233);
            dgvChiTietPhieuNhap.MultiSelect = false;
            dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            dgvChiTietPhieuNhap.RowHeadersWidth = 62;
            dgvChiTietPhieuNhap.Size = new Size(1632, 340);
            dgvChiTietPhieuNhap.TabIndex = 3;
            dgvChiTietPhieuNhap.CellFormatting += dgvChiTietPhieuNhap_CellFormatting;
            // 
            // MaCTPN
            // 
            MaCTPN.DataPropertyName = "MaCTPN";
            MaCTPN.HeaderText = "Mã CTPN";
            MaCTPN.MinimumWidth = 8;
            MaCTPN.Name = "MaCTPN";
            // 
            // MaPhieuNhap
            // 
            MaPhieuNhap.DataPropertyName = "MaPhieuNhap";
            MaPhieuNhap.HeaderText = "Mã Phiếu Nhập";
            MaPhieuNhap.MinimumWidth = 8;
            MaPhieuNhap.Name = "MaPhieuNhap";
            // 
            // NgayNhap
            // 
            NgayNhap.DataPropertyName = "NgayNhap";
            NgayNhap.HeaderText = "Ngày Nhập";
            NgayNhap.MinimumWidth = 8;
            NgayNhap.Name = "NgayNhap";
            // 
            // MaTiVi
            // 
            MaTiVi.DataPropertyName = "MaTiVi";
            MaTiVi.HeaderText = "Mã TiVi";
            MaTiVi.MinimumWidth = 8;
            MaTiVi.Name = "MaTiVi";
            // 
            // SoLuongNhap
            // 
            SoLuongNhap.DataPropertyName = "SoLuongNhap";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            SoLuongNhap.DefaultCellStyle = dataGridViewCellStyle4;
            SoLuongNhap.HeaderText = "Số Lượng";
            SoLuongNhap.MinimumWidth = 8;
            SoLuongNhap.Name = "SoLuongNhap";
            // 
            // DonGiaNhap
            // 
            DonGiaNhap.DataPropertyName = "DonGiaNhap";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            DonGiaNhap.DefaultCellStyle = dataGridViewCellStyle5;
            DonGiaNhap.HeaderText = "Đơn Gía Nhập";
            DonGiaNhap.MinimumWidth = 8;
            DonGiaNhap.Name = "DonGiaNhap";
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            ThanhTien.DefaultCellStyle = dataGridViewCellStyle6;
            ThanhTien.HeaderText = "Thành Tiền";
            ThanhTien.MinimumWidth = 8;
            ThanhTien.Name = "ThanhTien";
            // 
            // frmChiTietPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1632, 573);
            Controls.Add(dgvChiTietPhieuNhap);
            Controls.Add(panel1);
            Name = "frmChiTietPhieuNhap";
            Text = "Chi Tiết Phiếu Nhập";
            Load += frmChiTietPhieuNhap_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieuNhap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cboMaPhieuNhap;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private TextBox txtSoLuong;
        private Label label5;
        private Label label4;
        private TextBox txtMaCTPN;
        private Label label1;
        private Button btnThem;
        private DataGridView dgvChiTietPhieuNhap;
        private DateTimePicker dtpNgayNhap;
        private Label label3;
        private Label label2;
        private ComboBox cboMaTiVi;
        private TextBox txtDonGiaNhap;
        private Label label6;
        private TextBox txtThanhTien;
        private Label label7;
        private DataGridViewTextBoxColumn MaCTPN;
        private DataGridViewTextBoxColumn MaPhieuNhap;
        private DataGridViewTextBoxColumn NgayNhap;
        private DataGridViewTextBoxColumn MaTiVi;
        private DataGridViewTextBoxColumn SoLuongNhap;
        private DataGridViewTextBoxColumn DonGiaNhap;
        private DataGridViewTextBoxColumn ThanhTien;
    }
}