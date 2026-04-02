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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            btnXemChiTiet = new Button();
            cboMaHoaDon = new ComboBox();
            txtKyHanTra = new TextBox();
            label4 = new Label();
            txtLaiSuat = new TextBox();
            btnThoat = new Button();
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
            txtMaTraGop = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            groupBox2 = new GroupBox();
            dgvTraGop = new DataGridView();
            ColMaTraGop = new DataGridViewTextBoxColumn();
            ColMaHoaDon = new DataGridViewTextBoxColumn();
            ColLaiSuat = new DataGridViewTextBoxColumn();
            ColKyHanTra = new DataGridViewTextBoxColumn();
            ColSoTienTraTruoc = new DataGridViewTextBoxColumn();
            ColSoTienConNo = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTraGop).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXemChiTiet);
            groupBox1.Controls.Add(cboMaHoaDon);
            groupBox1.Controls.Add(txtKyHanTra);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtLaiSuat);
            groupBox1.Controls.Add(btnThoat);
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
            groupBox1.Controls.Add(txtMaTraGop);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(577, 502);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Trả Góp";
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.Location = new Point(198, 416);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(208, 65);
            btnXemChiTiet.TabIndex = 45;
            btnXemChiTiet.Text = "Xem Lịch Trình Trả góp";
            btnXemChiTiet.UseVisualStyleBackColor = true;
            btnXemChiTiet.Click += btnXemLichTrinh_Click;
            // 
            // cboMaHoaDon
            // 
            cboMaHoaDon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHoaDon.FormattingEnabled = true;
            cboMaHoaDon.Location = new Point(155, 105);
            cboMaHoaDon.Name = "cboMaHoaDon";
            cboMaHoaDon.Size = new Size(182, 33);
            cboMaHoaDon.TabIndex = 44;
            cboMaHoaDon.TextChanged += cboMaHoaDon_TextChanged;
            // 
            // txtKyHanTra
            // 
            txtKyHanTra.Location = new Point(155, 213);
            txtKyHanTra.Name = "txtKyHanTra";
            txtKyHanTra.Size = new Size(182, 31);
            txtKyHanTra.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 214);
            label4.Name = "label4";
            label4.Size = new Size(94, 25);
            label4.TabIndex = 42;
            label4.Text = "Kỳ Hạn Trả";
            // 
            // txtLaiSuat
            // 
            txtLaiSuat.Location = new Point(155, 160);
            txtLaiSuat.Name = "txtLaiSuat";
            txtLaiSuat.Size = new Size(182, 31);
            txtLaiSuat.TabIndex = 41;
            txtLaiSuat.TextChanged += txtLaiSuat_TextChanged;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(128, 255, 128);
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(408, 315);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 57);
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
            btnHuyBo.Location = new Point(408, 262);
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
            btnLuu.Location = new Point(408, 209);
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
            btnSua.Location = new Point(408, 156);
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
            btnXoa.Location = new Point(408, 103);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 57);
            btnXoa.TabIndex = 35;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtSoTienConNo
            // 
            txtSoTienConNo.Location = new Point(155, 319);
            txtSoTienConNo.Name = "txtSoTienConNo";
            txtSoTienConNo.Size = new Size(182, 31);
            txtSoTienConNo.TabIndex = 33;
            // 
            // txtSoTienTraTruoc
            // 
            txtSoTienTraTruoc.Location = new Point(155, 266);
            txtSoTienTraTruoc.Name = "txtSoTienTraTruoc";
            txtSoTienTraTruoc.Size = new Size(182, 31);
            txtSoTienTraTruoc.TabIndex = 32;
            txtSoTienTraTruoc.TextChanged += txtSoTienTraTruoc_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 320);
            label6.Name = "label6";
            label6.Size = new Size(136, 25);
            label6.TabIndex = 30;
            label6.Text = "Số Tiền Còn Nợ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 267);
            label5.Name = "label5";
            label5.Size = new Size(145, 25);
            label5.TabIndex = 29;
            label5.Text = "Số Tiền Trả Trước";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 161);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 27;
            label3.Text = "Lãi Suất";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 108);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 26;
            label2.Text = "Mã Hóa Đơn";
            // 
            // txtMaTraGop
            // 
            txtMaTraGop.Location = new Point(155, 52);
            txtMaTraGop.Name = "txtMaTraGop";
            txtMaTraGop.Size = new Size(182, 31);
            txtMaTraGop.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 55);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 24;
            label1.Text = "Mã Trả Góp";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(128, 255, 255);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(408, 50);
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
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(577, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1047, 502);
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
            dgvTraGop.Columns.AddRange(new DataGridViewColumn[] { ColMaTraGop, ColMaHoaDon, ColLaiSuat, ColKyHanTra, ColSoTienTraTruoc, ColSoTienConNo });
            dgvTraGop.Dock = DockStyle.Fill;
            dgvTraGop.Location = new Point(3, 27);
            dgvTraGop.MultiSelect = false;
            dgvTraGop.Name = "dgvTraGop";
            dgvTraGop.RowHeadersWidth = 62;
            dgvTraGop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTraGop.Size = new Size(1041, 472);
            dgvTraGop.TabIndex = 3;
            // 
            // ColMaTraGop
            // 
            ColMaTraGop.DataPropertyName = "MaTraGop";
            ColMaTraGop.HeaderText = "Mã Trả Góp";
            ColMaTraGop.MinimumWidth = 8;
            ColMaTraGop.Name = "ColMaTraGop";
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
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            ColSoTienTraTruoc.DefaultCellStyle = dataGridViewCellStyle5;
            ColSoTienTraTruoc.HeaderText = "Số Tiền Trả Trước";
            ColSoTienTraTruoc.MinimumWidth = 8;
            ColSoTienTraTruoc.Name = "ColSoTienTraTruoc";
            // 
            // ColSoTienConNo
            // 
            ColSoTienConNo.DataPropertyName = "SoTienConNo";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            ColSoTienConNo.DefaultCellStyle = dataGridViewCellStyle6;
            ColSoTienConNo.HeaderText = "Số Tiền Còn Nợ";
            ColSoTienConNo.MinimumWidth = 8;
            ColSoTienConNo.Name = "ColSoTienConNo";
            // 
            // frmTraGop
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1624, 502);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmTraGop";
            Text = "Trả Góp";
            Load += frmTraGop_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTraGop).EndInit();
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
        private TextBox txtMaTraGop;
        private Label label1;
        private Button btnThem;
        private GroupBox groupBox2;
        private DataGridView dgvTraGop;
        private TextBox txtKyHanTra;
        private Label label4;
        private DataGridViewTextBoxColumn ColMaTraGop;
        private DataGridViewTextBoxColumn ColMaHoaDon;
        private DataGridViewTextBoxColumn ColLaiSuat;
        private DataGridViewTextBoxColumn ColKyHanTra;
        private DataGridViewTextBoxColumn ColSoTienTraTruoc;
        private DataGridViewTextBoxColumn ColSoTienConNo;
        private ComboBox cboMaHoaDon;
        private Button btnXemChiTiet;
    }
}