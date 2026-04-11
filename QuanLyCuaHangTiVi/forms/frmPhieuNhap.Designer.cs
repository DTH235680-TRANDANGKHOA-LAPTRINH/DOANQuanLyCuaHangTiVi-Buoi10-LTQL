namespace QuanLyCuaHangTiVi.forms
{
    partial class frmPhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuNhap));
            dgvPhieuNhap = new DataGridView();
            MaPhieuNhap = new DataGridViewTextBoxColumn();
            NgayNhap = new DataGridViewTextBoxColumn();
            GhiChu = new DataGridViewTextBoxColumn();
            NguoiGiaoHang = new DataGridViewTextBoxColumn();
            btnThem = new Button();
            label1 = new Label();
            txtMaPhieuNhap = new TextBox();
            label5 = new Label();
            txtNguoiGiaoHang = new TextBox();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            btnHuyBo = new Button();
            btnThoat = new Button();
            label6 = new Label();
            txtGhiChu = new TextBox();
            panel1 = new Panel();
            dtpNgayNhap = new DateTimePicker();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPhieuNhap
            // 
            dgvPhieuNhap.AllowUserToAddRows = false;
            dgvPhieuNhap.AllowUserToDeleteRows = false;
            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuNhap.Columns.AddRange(new DataGridViewColumn[] { MaPhieuNhap, NgayNhap, GhiChu, NguoiGiaoHang });
            dgvPhieuNhap.Dock = DockStyle.Fill;
            dgvPhieuNhap.Location = new Point(0, 233);
            dgvPhieuNhap.MultiSelect = false;
            dgvPhieuNhap.Name = "dgvPhieuNhap";
            dgvPhieuNhap.RowHeadersWidth = 62;
            dgvPhieuNhap.Size = new Size(1672, 294);
            dgvPhieuNhap.TabIndex = 4;
            dgvPhieuNhap.CellValueChanged += dgvChiTietPhieuNhap_CellValueChanged;
            dgvPhieuNhap.DataError += dgvChiTietPhieuNhap_DataError;
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
            NgayNhap.HeaderText = "Ngày Nhập ";
            NgayNhap.MinimumWidth = 8;
            NgayNhap.Name = "NgayNhap";
            // 
            // GhiChu
            // 
            GhiChu.DataPropertyName = "GhiChu";
            GhiChu.HeaderText = "Ghi Chú";
            GhiChu.MinimumWidth = 8;
            GhiChu.Name = "GhiChu";
            // 
            // NguoiGiaoHang
            // 
            NguoiGiaoHang.DataPropertyName = "NguoiGiaoHang";
            NguoiGiaoHang.HeaderText = "Người Giao Hàng";
            NguoiGiaoHang.MinimumWidth = 8;
            NguoiGiaoHang.Name = "NguoiGiaoHang";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Cyan;
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(134, 148);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(133, 52);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 20);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 1;
            label1.Text = "Mã Phiếu Nhập";
            // 
            // txtMaPhieuNhap
            // 
            txtMaPhieuNhap.Location = new Point(196, 12);
            txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            txtMaPhieuNhap.Size = new Size(150, 31);
            txtMaPhieuNhap.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(786, 16);
            label5.Name = "label5";
            label5.Size = new Size(151, 25);
            label5.TabIndex = 6;
            label5.Text = "Người Giao Hàng";
            // 
            // txtNguoiGiaoHang
            // 
            txtNguoiGiaoHang.Location = new Point(943, 13);
            txtNguoiGiaoHang.Name = "txtNguoiGiaoHang";
            txtNguoiGiaoHang.Size = new Size(226, 31);
            txtNguoiGiaoHang.TabIndex = 11;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(325, 148);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(129, 52);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Yellow;
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(489, 148);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(122, 52);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Fuchsia;
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(637, 148);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(123, 52);
            btnLuu.TabIndex = 15;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.FromArgb(255, 192, 192);
            btnHuyBo.Image = (Image)resources.GetObject("btnHuyBo.Image");
            btnHuyBo.ImageAlign = ContentAlignment.MiddleLeft;
            btnHuyBo.Location = new Point(795, 148);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(123, 52);
            btnHuyBo.TabIndex = 16;
            btnHuyBo.Text = "Hủy Bỏ";
            btnHuyBo.UseVisualStyleBackColor = false;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Lime;
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(933, 148);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(130, 52);
            btnThoat.TabIndex = 17;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(116, 81);
            label6.Name = "label6";
            label6.Size = new Size(74, 25);
            label6.TabIndex = 23;
            label6.Text = "Ghi Chú";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(196, 75);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(973, 31);
            txtGhiChu.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(dtpNgayNhap);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtGhiChu);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnHuyBo);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(txtNguoiGiaoHang);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtMaPhieuNhap);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1672, 233);
            panel1.TabIndex = 3;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(460, 13);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(300, 31);
            dtpNgayNhap.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(352, 18);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 25;
            label2.Text = "Ngày Nhập";
            // 
            // frmPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1672, 527);
            Controls.Add(dgvPhieuNhap);
            Controls.Add(panel1);
            Name = "frmPhieuNhap";
            Text = "frmPhieuNhap";
            Load += frmPhieuNhap_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cboPhieuNhap;
        private TextBox txtSoLuong;
        private DataGridView dgvPhieuNhap;
        private Button btnThem;
        private Label label1;
        private TextBox txtMaPhieuNhap;
        private Label label5;
        private TextBox txtNguoiGiaoHang;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLuu;
        private Button btnHuyBo;
        private Button btnThoat;
        private Label label6;
        private TextBox txtGhiChu;
        private Panel panel1;
        private DateTimePicker dtpNgayNhap;
        private Label label2;
        private DataGridViewTextBoxColumn MaPhieuNhap;
        private DataGridViewTextBoxColumn NgayNhap;
        private DataGridViewTextBoxColumn GhiChu;
        private DataGridViewTextBoxColumn NguoiGiaoHang;
    }
}