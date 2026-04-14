namespace QuanLyCuaHangTiVi.forms
{
    partial class frmTraGop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraGop));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dtpNgayNop = new DateTimePicker();
            txtNguoiNop = new TextBox();
            cboMaHoaDon = new ComboBox();
            label8 = new Label();
            txtKyHanTra = new TextBox();
            label9 = new Label();
            label4 = new Label();
            btnThuTien = new Button();
            txtLaiSuat = new TextBox();
            label7 = new Label();
            btnThoat = new Button();
            txtSoTienNop = new TextBox();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            txtSoTienConNo = new TextBox();
            txtSoTienTraTruoc = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            groupBox2 = new GroupBox();
            dgvTraGop = new DataGridView();
            ColID = new DataGridViewTextBoxColumn();
            ColMaHoaDon = new DataGridViewTextBoxColumn();
            ColLaiSuat = new DataGridViewTextBoxColumn();
            ColKyHanTra = new DataGridViewTextBoxColumn();
            ColSoTienTraTruoc = new DataGridViewTextBoxColumn();
            ColSoTienConNo = new DataGridViewTextBoxColumn();
            groupBox3 = new GroupBox();
            dgvChiTiet = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTraGop).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpNgayNop);
            groupBox1.Controls.Add(txtNguoiNop);
            groupBox1.Controls.Add(cboMaHoaDon);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtKyHanTra);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnThuTien);
            groupBox1.Controls.Add(txtLaiSuat);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(txtSoTienNop);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(txtSoTienConNo);
            groupBox1.Controls.Add(txtSoTienTraTruoc);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1624, 296);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Trả Góp";
            // 
            // dtpNgayNop
            // 
            dtpNgayNop.Location = new Point(1039, 237);
            dtpNgayNop.Name = "dtpNgayNop";
            dtpNgayNop.Size = new Size(182, 31);
            dtpNgayNop.TabIndex = 61;
            // 
            // txtNguoiNop
            // 
            txtNguoiNop.Location = new Point(1040, 170);
            txtNguoiNop.Name = "txtNguoiNop";
            txtNguoiNop.Size = new Size(181, 31);
            txtNguoiNop.TabIndex = 63;
            // 
            // cboMaHoaDon
            // 
            cboMaHoaDon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHoaDon.FormattingEnabled = true;
            cboMaHoaDon.Location = new Point(508, 28);
            cboMaHoaDon.Name = "cboMaHoaDon";
            cboMaHoaDon.Size = new Size(464, 33);
            cboMaHoaDon.TabIndex = 44;
            cboMaHoaDon.TextChanged += cboMaHoaDon_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(911, 92);
            label8.Name = "label8";
            label8.Size = new Size(110, 25);
            label8.TabIndex = 66;
            label8.Text = "Số Tiền Nộp";
            // 
            // txtKyHanTra
            // 
            txtKyHanTra.Location = new Point(155, 67);
            txtKyHanTra.Name = "txtKyHanTra";
            txtKyHanTra.Size = new Size(181, 31);
            txtKyHanTra.TabIndex = 43;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(911, 172);
            label9.Name = "label9";
            label9.Size = new Size(102, 25);
            label9.TabIndex = 64;
            label9.Text = "Người Nộp";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 67);
            label4.Name = "label4";
            label4.Size = new Size(94, 25);
            label4.TabIndex = 42;
            label4.Text = "Kỳ Hạn Trả";
            // 
            // btnThuTien
            // 
            btnThuTien.BackColor = Color.Cyan;
            btnThuTien.Image = (Image)resources.GetObject("btnThuTien.Image");
            btnThuTien.ImageAlign = ContentAlignment.MiddleLeft;
            btnThuTien.Location = new Point(1244, 162);
            btnThuTien.Name = "btnThuTien";
            btnThuTien.Size = new Size(196, 60);
            btnThuTien.TabIndex = 60;
            btnThuTien.Text = "Thu Tiền Kỳ Này";
            btnThuTien.UseVisualStyleBackColor = false;
            btnThuTien.Click += btnThuTien_Click;
            // 
            // txtLaiSuat
            // 
            txtLaiSuat.Location = new Point(155, 103);
            txtLaiSuat.Name = "txtLaiSuat";
            txtLaiSuat.Size = new Size(181, 31);
            txtLaiSuat.TabIndex = 41;
            txtLaiSuat.TextChanged += txtLaiSuat_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(904, 237);
            label7.Name = "label7";
            label7.Size = new Size(94, 25);
            label7.TabIndex = 62;
            label7.Text = "Ngày Nộp";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(128, 255, 128);
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(663, 211);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 57);
            btnThoat.TabIndex = 39;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtSoTienNop
            // 
            txtSoTienNop.Location = new Point(1040, 96);
            txtSoTienNop.Name = "txtSoTienNop";
            txtSoTienNop.Size = new Size(181, 31);
            txtSoTienNop.TabIndex = 65;
            txtSoTienNop.TextChanged += txtSoTienNop_TextChanged;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.FromArgb(255, 192, 128);
            btnHuyBo.Image = (Image)resources.GetObject("btnHuyBo.Image");
            btnHuyBo.ImageAlign = ContentAlignment.MiddleLeft;
            btnHuyBo.Location = new Point(508, 211);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(120, 57);
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
            btnLuu.Location = new Point(665, 77);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 57);
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
            btnSua.Location = new Point(508, 148);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 57);
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
            btnXoa.Location = new Point(665, 144);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 57);
            btnXoa.TabIndex = 35;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtSoTienConNo
            // 
            txtSoTienConNo.Location = new Point(155, 177);
            txtSoTienConNo.Name = "txtSoTienConNo";
            txtSoTienConNo.ReadOnly = true;
            txtSoTienConNo.Size = new Size(181, 31);
            txtSoTienConNo.TabIndex = 33;
            // 
            // txtSoTienTraTruoc
            // 
            txtSoTienTraTruoc.Location = new Point(155, 140);
            txtSoTienTraTruoc.Name = "txtSoTienTraTruoc";
            txtSoTienTraTruoc.Size = new Size(181, 31);
            txtSoTienTraTruoc.TabIndex = 32;
            txtSoTienTraTruoc.TextChanged += txtSoTienTraTruoc_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 180);
            label6.Name = "label6";
            label6.Size = new Size(136, 25);
            label6.TabIndex = 30;
            label6.Text = "Số Tiền Còn Nợ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 146);
            label5.Name = "label5";
            label5.Size = new Size(145, 25);
            label5.TabIndex = 29;
            label5.Text = "Số Tiền Trả Trước";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 109);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 27;
            label3.Text = "Lãi Suất";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 34);
            label2.Name = "label2";
            label2.Size = new Size(147, 25);
            label2.TabIndex = 26;
            label2.Text = "Khách hàng / Tivi";
            // 
            // txtID
            // 
            txtID.Location = new Point(155, 30);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(181, 31);
            txtID.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 36);
            label1.Name = "label1";
            label1.Size = new Size(30, 25);
            label1.TabIndex = 24;
            label1.Text = "ID";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(128, 255, 255);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(508, 77);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 57);
            btnThem.TabIndex = 23;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvTraGop);
            groupBox2.Location = new Point(0, 296);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1564, 408);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Trả Góp";
            // 
            // dgvTraGop
            // 
            dgvTraGop.AllowUserToAddRows = false;
            dgvTraGop.AllowUserToDeleteRows = false;
            dgvTraGop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTraGop.BackgroundColor = Color.Silver;
            dgvTraGop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTraGop.Columns.AddRange(new DataGridViewColumn[] { ColID, ColMaHoaDon, ColLaiSuat, ColKyHanTra, ColSoTienTraTruoc, ColSoTienConNo });
            dgvTraGop.Dock = DockStyle.Fill;
            dgvTraGop.Location = new Point(3, 27);
            dgvTraGop.MultiSelect = false;
            dgvTraGop.Name = "dgvTraGop";
            dgvTraGop.RowHeadersWidth = 62;
            dgvTraGop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTraGop.Size = new Size(1558, 378);
            dgvTraGop.TabIndex = 3;
            dgvTraGop.CellFormatting += dgvTraGop_CellFormatting;
            dgvTraGop.SelectionChanged += dgvTraGop_SelectionChanged;
            // 
            // ColID
            // 
            ColID.DataPropertyName = "ID";
            ColID.HeaderText = "ID";
            ColID.MinimumWidth = 8;
            ColID.Name = "ColID";
            // 
            // ColMaHoaDon
            // 
            ColMaHoaDon.DataPropertyName = "MaHoaDon";
            ColMaHoaDon.HeaderText = "Mã Hóa Đơn";
            ColMaHoaDon.MinimumWidth = 8;
            ColMaHoaDon.Name = "ColMaHoaDon";
            // 
            // ColLaiSuat
            // 
            ColLaiSuat.DataPropertyName = "LaiSuat";
            ColLaiSuat.HeaderText = "Lãi Suất";
            ColLaiSuat.MinimumWidth = 8;
            ColLaiSuat.Name = "ColLaiSuat";
            // 
            // ColKyHanTra
            // 
            ColKyHanTra.DataPropertyName = "KyHanTra";
            ColKyHanTra.HeaderText = "Kỳ hạn";
            ColKyHanTra.MinimumWidth = 8;
            ColKyHanTra.Name = "ColKyHanTra";
            // 
            // ColSoTienTraTruoc
            // 
            ColSoTienTraTruoc.DataPropertyName = "SoTienTraTruoc";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            ColSoTienTraTruoc.DefaultCellStyle = dataGridViewCellStyle1;
            ColSoTienTraTruoc.HeaderText = "Số Tiền Trả Trước";
            ColSoTienTraTruoc.MinimumWidth = 8;
            ColSoTienTraTruoc.Name = "ColSoTienTraTruoc";
            // 
            // ColSoTienConNo
            // 
            ColSoTienConNo.DataPropertyName = "SoTienConNo";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            ColSoTienConNo.DefaultCellStyle = dataGridViewCellStyle2;
            ColSoTienConNo.HeaderText = "Số Tiền Còn Nợ";
            ColSoTienConNo.MinimumWidth = 8;
            ColSoTienConNo.Name = "ColSoTienConNo";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvChiTiet);
            groupBox3.Dock = DockStyle.Bottom;
            groupBox3.Location = new Point(0, 710);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1624, 340);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Lịch Trình Trả Góp";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.Location = new Point(3, 27);
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersWidth = 62;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(1618, 310);
            dgvChiTiet.TabIndex = 3;
            dgvChiTiet.CellFormatting += dgvChiTiet_CellFormatting;
            // 
            // frmTraGop
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1624, 1050);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmTraGop";
            Text = "Trả Góp";
            Load += frmTraGop_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTraGop).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtLaiSuat;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private TextBox txtSoTienConNo;
        private TextBox txtSoTienTraTruoc;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Button btnThem;
        private GroupBox groupBox2;
        private DataGridView dgvTraGop;
        private TextBox txtKyHanTra;
        private Label label4;
        private ComboBox cboMaHoaDon;
        private GroupBox groupBox3;
        private DataGridView dgvChiTiet;
        private Label label8;
        private TextBox txtSoTienNop;
        private Label label9;
        private TextBox txtNguoiNop;
        private Label label7;
        private DateTimePicker dtpNgayNop;
        private Button btnThuTien;
        private DataGridViewTextBoxColumn ColID;
        private DataGridViewTextBoxColumn ColMaHoaDon;
        private DataGridViewTextBoxColumn ColLaiSuat;
        private DataGridViewTextBoxColumn ColKyHanTra;
        private DataGridViewTextBoxColumn ColSoTienTraTruoc;
        private DataGridViewTextBoxColumn ColSoTienConNo;
        private TextBox txtID;
        private Label label1;
    }
}