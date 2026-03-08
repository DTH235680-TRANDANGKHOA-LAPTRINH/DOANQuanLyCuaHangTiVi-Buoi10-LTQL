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
            dgvPhieuNhap = new DataGridView();
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
            MaPhieuNhap = new DataGridViewTextBoxColumn();
            NgayNhap = new DataGridViewTextBoxColumn();
            GhiChu = new DataGridViewTextBoxColumn();
            NguoiGiaoHang = new DataGridViewTextBoxColumn();
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
            txtMaPhieuNhap.Location = new Point(268, 12);
            txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            txtMaPhieuNhap.Size = new Size(150, 31);
            txtMaPhieuNhap.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(95, 88);
            label5.Name = "label5";
            label5.Size = new Size(151, 25);
            label5.TabIndex = 6;
            label5.Text = "Người Giao Hàng";
            // 
            // txtNguoiGiaoHang
            // 
            txtNguoiGiaoHang.Location = new Point(268, 82);
            txtNguoiGiaoHang.Name = "txtNguoiGiaoHang";
            txtNguoiGiaoHang.Size = new Size(150, 31);
            txtNguoiGiaoHang.TabIndex = 11;
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(505, 85);
            label6.Name = "label6";
            label6.Size = new Size(74, 25);
            label6.TabIndex = 23;
            label6.Text = "Ghi Chú";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(639, 79);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(587, 31);
            txtGhiChu.TabIndex = 24;
            // 
            // panel1
            // 
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
            dtpNgayNhap.Location = new Point(639, 10);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(300, 31);
            dtpNgayNhap.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(505, 12);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 25;
            label2.Text = "Ngày Nhập";
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