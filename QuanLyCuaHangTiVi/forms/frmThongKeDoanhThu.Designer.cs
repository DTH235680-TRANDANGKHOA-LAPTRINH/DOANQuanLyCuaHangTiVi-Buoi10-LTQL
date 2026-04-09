namespace QuanLyCuaHangTiVi.forms
{
    partial class frmThongKeDoanhThu
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            groupBox2 = new GroupBox();
            dgvDoanhThu = new DataGridView();
            label8 = new Label();
            txtThuHoaDon = new TextBox();
            label1 = new Label();
            txtThuTraGopDaDong = new TextBox();
            label2 = new Label();
            txtTongDoanhThu = new TextBox();
            groupBox1 = new GroupBox();
            label9 = new Label();
            label7 = new Label();
            nudNam = new NumericUpDown();
            nudThang = new NumericUpDown();
            btnThongKe = new Button();
            txtThuTraGopChuaDong = new TextBox();
            label3 = new Label();
            ColMaTiVi = new DataGridViewTextBoxColumn();
            ColTenTiVi = new DataGridViewTextBoxColumn();
            ColKhuyenMai = new DataGridViewTextBoxColumn();
            ColSoLuong = new DataGridViewTextBoxColumn();
            ColDonGia = new DataGridViewTextBoxColumn();
            ColThanhTien = new DataGridViewTextBoxColumn();
            Colhinhthuc = new DataGridViewTextBoxColumn();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDoanhThu);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 255);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1580, 277);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách ";
            // 
            // dgvDoanhThu
            // 
            dgvDoanhThu.AllowUserToAddRows = false;
            dgvDoanhThu.AllowUserToDeleteRows = false;
            dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoanhThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoanhThu.Columns.AddRange(new DataGridViewColumn[] { ColMaTiVi, ColTenTiVi, ColKhuyenMai, ColSoLuong, ColDonGia, ColThanhTien, Colhinhthuc });
            dgvDoanhThu.Dock = DockStyle.Fill;
            dgvDoanhThu.Location = new Point(3, 27);
            dgvDoanhThu.MultiSelect = false;
            dgvDoanhThu.Name = "dgvDoanhThu";
            dgvDoanhThu.ReadOnly = true;
            dgvDoanhThu.RowHeadersWidth = 62;
            dgvDoanhThu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoanhThu.Size = new Size(1574, 247);
            dgvDoanhThu.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 46);
            label8.Name = "label8";
            label8.Size = new Size(195, 25);
            label8.TabIndex = 52;
            label8.Text = "Thu Hóa Đơn (Bán đứt)";
            // 
            // txtThuHoaDon
            // 
            txtThuHoaDon.Location = new Point(209, 46);
            txtThuHoaDon.Name = "txtThuHoaDon";
            txtThuHoaDon.ReadOnly = true;
            txtThuHoaDon.Size = new Size(308, 31);
            txtThuHoaDon.TabIndex = 53;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 107);
            label1.Name = "label1";
            label1.Size = new Size(192, 25);
            label1.TabIndex = 54;
            label1.Text = "Thu Trả Góp (Đã đóng)";
            // 
            // txtThuTraGopDaDong
            // 
            txtThuTraGopDaDong.Location = new Point(209, 103);
            txtThuTraGopDaDong.Name = "txtThuTraGopDaDong";
            txtThuTraGopDaDong.ReadOnly = true;
            txtThuTraGopDaDong.Size = new Size(308, 31);
            txtThuTraGopDaDong.TabIndex = 55;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 200);
            label2.Name = "label2";
            label2.Size = new Size(169, 25);
            label2.TabIndex = 56;
            label2.Text = "TỔNG DOANH THU";
            // 
            // txtTongDoanhThu
            // 
            txtTongDoanhThu.Location = new Point(209, 194);
            txtTongDoanhThu.Name = "txtTongDoanhThu";
            txtTongDoanhThu.ReadOnly = true;
            txtTongDoanhThu.Size = new Size(308, 31);
            txtTongDoanhThu.TabIndex = 57;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(192, 255, 255);
            groupBox1.Controls.Add(txtThuTraGopChuaDong);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(nudNam);
            groupBox1.Controls.Add(nudThang);
            groupBox1.Controls.Add(btnThongKe);
            groupBox1.Controls.Add(txtTongDoanhThu);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtThuTraGopDaDong);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtThuHoaDon);
            groupBox1.Controls.Add(label8);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1580, 255);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(656, 109);
            label9.Name = "label9";
            label9.Size = new Size(50, 25);
            label9.TabIndex = 72;
            label9.Text = "Năm";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(645, 54);
            label7.Name = "label7";
            label7.Size = new Size(61, 25);
            label7.TabIndex = 71;
            label7.Text = "Tháng";
            // 
            // nudNam
            // 
            nudNam.Location = new Point(728, 103);
            nudNam.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudNam.Name = "nudNam";
            nudNam.Size = new Size(180, 31);
            nudNam.TabIndex = 70;
            nudNam.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // nudThang
            // 
            nudThang.Location = new Point(728, 63);
            nudThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudThang.Name = "nudThang";
            nudThang.Size = new Size(180, 31);
            nudThang.TabIndex = 69;
            // 
            // btnThongKe
            // 
            btnThongKe.Font = new Font("Times New Roman", 26F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnThongKe.Location = new Point(1011, 54);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(257, 99);
            btnThongKe.TabIndex = 68;
            btnThongKe.Text = "Thống Kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // txtThuTraGopChuaDong
            // 
            txtThuTraGopChuaDong.Location = new Point(232, 144);
            txtThuTraGopChuaDong.Name = "txtThuTraGopChuaDong";
            txtThuTraGopChuaDong.ReadOnly = true;
            txtThuTraGopChuaDong.Size = new Size(308, 31);
            txtThuTraGopChuaDong.TabIndex = 74;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 144);
            label3.Name = "label3";
            label3.Size = new Size(208, 25);
            label3.TabIndex = 73;
            label3.Text = "Thu Trả Góp (chưa đóng)";
            // 
            // ColMaTiVi
            // 
            ColMaTiVi.DataPropertyName = "MaTiVi";
            ColMaTiVi.HeaderText = "Mã TiVi";
            ColMaTiVi.MinimumWidth = 8;
            ColMaTiVi.Name = "ColMaTiVi";
            ColMaTiVi.ReadOnly = true;
            // 
            // ColTenTiVi
            // 
            ColTenTiVi.DataPropertyName = "TenTiVi";
            ColTenTiVi.HeaderText = "Tên TiVi";
            ColTenTiVi.MinimumWidth = 8;
            ColTenTiVi.Name = "ColTenTiVi";
            ColTenTiVi.ReadOnly = true;
            // 
            // ColKhuyenMai
            // 
            ColKhuyenMai.DataPropertyName = "KhuyenMai";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            ColKhuyenMai.DefaultCellStyle = dataGridViewCellStyle5;
            ColKhuyenMai.HeaderText = "Khuyến Mãi";
            ColKhuyenMai.MinimumWidth = 8;
            ColKhuyenMai.Name = "ColKhuyenMai";
            ColKhuyenMai.ReadOnly = true;
            // 
            // ColSoLuong
            // 
            ColSoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            ColSoLuong.DefaultCellStyle = dataGridViewCellStyle6;
            ColSoLuong.HeaderText = "Số Lượng ";
            ColSoLuong.MinimumWidth = 8;
            ColSoLuong.Name = "ColSoLuong";
            ColSoLuong.ReadOnly = true;
            // 
            // ColDonGia
            // 
            ColDonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            ColDonGia.DefaultCellStyle = dataGridViewCellStyle7;
            ColDonGia.HeaderText = "Đơn Gía";
            ColDonGia.MinimumWidth = 8;
            ColDonGia.Name = "ColDonGia";
            ColDonGia.ReadOnly = true;
            // 
            // ColThanhTien
            // 
            ColThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            ColThanhTien.DefaultCellStyle = dataGridViewCellStyle8;
            ColThanhTien.HeaderText = "Thành Tiền ";
            ColThanhTien.MinimumWidth = 8;
            ColThanhTien.Name = "ColThanhTien";
            ColThanhTien.ReadOnly = true;
            // 
            // Colhinhthuc
            // 
            Colhinhthuc.DataPropertyName = "HinhThuc";
            Colhinhthuc.HeaderText = "Hình Thức";
            Colhinhthuc.MinimumWidth = 8;
            Colhinhthuc.Name = "Colhinhthuc";
            Colhinhthuc.ReadOnly = true;
            // 
            // frmThongKeDoanhThu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1580, 532);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmThongKeDoanhThu";
            Text = "Thống Kê Doanh Thu";
            Load += frmThongKeDoanhThu_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private DataGridView dgvDoanhThu;
        private Label label8;
        private TextBox txtThuHoaDon;
        private Label label1;
        private TextBox txtThuTraGopDaDong;
        private Label label2;
        private TextBox txtTongDoanhThu;
        private GroupBox groupBox1;
        private Label label9;
        private Label label7;
        private NumericUpDown nudNam;
        private NumericUpDown nudThang;
        private Button btnThongKe;
        private TextBox txtThuTraGopChuaDong;
        private Label label3;
        private DataGridViewTextBoxColumn ColMaTiVi;
        private DataGridViewTextBoxColumn ColTenTiVi;
        private DataGridViewTextBoxColumn ColKhuyenMai;
        private DataGridViewTextBoxColumn ColSoLuong;
        private DataGridViewTextBoxColumn ColDonGia;
        private DataGridViewTextBoxColumn ColThanhTien;
        private DataGridViewTextBoxColumn Colhinhthuc;
    }
}