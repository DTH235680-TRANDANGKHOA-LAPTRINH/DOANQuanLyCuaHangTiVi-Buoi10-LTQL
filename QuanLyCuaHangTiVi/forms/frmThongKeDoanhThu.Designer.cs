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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            groupBox2 = new GroupBox();
            dgvDoanhThu = new DataGridView();
            ColMaTiVi = new DataGridViewTextBoxColumn();
            ColTenTiVi = new DataGridViewTextBoxColumn();
            ColKhuyenMai = new DataGridViewTextBoxColumn();
            ColSoLuong = new DataGridViewTextBoxColumn();
            ColDonGia = new DataGridViewTextBoxColumn();
            ColThanhTien = new DataGridViewTextBoxColumn();
            label8 = new Label();
            txtThuHoaDon = new TextBox();
            label1 = new Label();
            txtThuTraGop = new TextBox();
            label2 = new Label();
            txtTongDoanhThu = new TextBox();
            groupBox1 = new GroupBox();
            txtTienLuong = new TextBox();
            label4 = new Label();
            txtTongChiPhi = new TextBox();
            label3 = new Label();
            label9 = new Label();
            label7 = new Label();
            nudNam = new NumericUpDown();
            nudThang = new NumericUpDown();
            btnThongKe = new Button();
            txtLoiNhuan = new TextBox();
            label6 = new Label();
            txtTienVanHanh = new TextBox();
            label10 = new Label();
            txtChiNhapHang = new TextBox();
            label5 = new Label();
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
            dgvDoanhThu.Columns.AddRange(new DataGridViewColumn[] { ColMaTiVi, ColTenTiVi, ColKhuyenMai, ColSoLuong, ColDonGia, ColThanhTien });
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            ColKhuyenMai.DefaultCellStyle = dataGridViewCellStyle1;
            ColKhuyenMai.HeaderText = "Khuyến Mãi";
            ColKhuyenMai.MinimumWidth = 8;
            ColKhuyenMai.Name = "ColKhuyenMai";
            ColKhuyenMai.ReadOnly = true;
            // 
            // ColSoLuong
            // 
            ColSoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            ColSoLuong.DefaultCellStyle = dataGridViewCellStyle2;
            ColSoLuong.HeaderText = "Số Lượng ";
            ColSoLuong.MinimumWidth = 8;
            ColSoLuong.Name = "ColSoLuong";
            ColSoLuong.ReadOnly = true;
            // 
            // ColDonGia
            // 
            ColDonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            ColDonGia.DefaultCellStyle = dataGridViewCellStyle3;
            ColDonGia.HeaderText = "Đơn Gía";
            ColDonGia.MinimumWidth = 8;
            ColDonGia.Name = "ColDonGia";
            ColDonGia.ReadOnly = true;
            // 
            // ColThanhTien
            // 
            ColThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            ColThanhTien.DefaultCellStyle = dataGridViewCellStyle4;
            ColThanhTien.HeaderText = "Thành Tiền ";
            ColThanhTien.MinimumWidth = 8;
            ColThanhTien.Name = "ColThanhTien";
            ColThanhTien.ReadOnly = true;
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
            // txtThuTraGop
            // 
            txtThuTraGop.Location = new Point(209, 103);
            txtThuTraGop.Name = "txtThuTraGop";
            txtThuTraGop.ReadOnly = true;
            txtThuTraGop.Size = new Size(308, 31);
            txtThuTraGop.TabIndex = 55;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 169);
            label2.Name = "label2";
            label2.Size = new Size(169, 25);
            label2.TabIndex = 56;
            label2.Text = "TỔNG DOANH THU";
            // 
            // txtTongDoanhThu
            // 
            txtTongDoanhThu.Location = new Point(209, 163);
            txtTongDoanhThu.Name = "txtTongDoanhThu";
            txtTongDoanhThu.ReadOnly = true;
            txtTongDoanhThu.Size = new Size(308, 31);
            txtTongDoanhThu.TabIndex = 57;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(192, 255, 255);
            groupBox1.Controls.Add(txtTienLuong);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtTongChiPhi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(nudNam);
            groupBox1.Controls.Add(nudThang);
            groupBox1.Controls.Add(btnThongKe);
            groupBox1.Controls.Add(txtLoiNhuan);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtTienVanHanh);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtChiNhapHang);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtTongDoanhThu);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtThuTraGop);
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
            // txtTienLuong
            // 
            txtTienLuong.Location = new Point(732, 71);
            txtTienLuong.Name = "txtTienLuong";
            txtTienLuong.ReadOnly = true;
            txtTienLuong.Size = new Size(308, 31);
            txtTienLuong.TabIndex = 76;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(541, 75);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 75;
            label4.Text = "Tiền Lương";
            // 
            // txtTongChiPhi
            // 
            txtTongChiPhi.Location = new Point(732, 169);
            txtTongChiPhi.Name = "txtTongChiPhi";
            txtTongChiPhi.ReadOnly = true;
            txtTongChiPhi.Size = new Size(308, 31);
            txtTongChiPhi.TabIndex = 74;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(541, 173);
            label3.Name = "label3";
            label3.Size = new Size(127, 25);
            label3.TabIndex = 73;
            label3.Text = "TỔNG CHI PHÍ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1072, 54);
            label9.Name = "label9";
            label9.Size = new Size(50, 25);
            label9.TabIndex = 72;
            label9.Text = "Năm";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1072, 21);
            label7.Name = "label7";
            label7.Size = new Size(61, 25);
            label7.TabIndex = 71;
            label7.Text = "Tháng";
            // 
            // nudNam
            // 
            nudNam.Location = new Point(1239, 52);
            nudNam.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudNam.Name = "nudNam";
            nudNam.Size = new Size(180, 31);
            nudNam.TabIndex = 70;
            nudNam.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // nudThang
            // 
            nudThang.Location = new Point(1239, 15);
            nudThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudThang.Name = "nudThang";
            nudThang.Size = new Size(180, 31);
            nudThang.TabIndex = 69;
            // 
            // btnThongKe
            // 
            btnThongKe.Font = new Font("Times New Roman", 26F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnThongKe.Location = new Point(1213, 145);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(257, 99);
            btnThongKe.TabIndex = 68;
            btnThongKe.Text = "Thống Kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // txtLoiNhuan
            // 
            txtLoiNhuan.Location = new Point(1239, 102);
            txtLoiNhuan.Name = "txtLoiNhuan";
            txtLoiNhuan.ReadOnly = true;
            txtLoiNhuan.Size = new Size(308, 31);
            txtLoiNhuan.TabIndex = 67;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1072, 108);
            label6.Name = "label6";
            label6.Size = new Size(152, 25);
            label6.TabIndex = 66;
            label6.Text = "LỢI NHUẬN TỊNH";
            // 
            // txtTienVanHanh
            // 
            txtTienVanHanh.Location = new Point(732, 108);
            txtTienVanHanh.Name = "txtTienVanHanh";
            txtTienVanHanh.ReadOnly = true;
            txtTienVanHanh.Size = new Size(308, 31);
            txtTienVanHanh.TabIndex = 65;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(541, 112);
            label10.Name = "label10";
            label10.Size = new Size(238, 25);
            label10.TabIndex = 64;
            label10.Text = "Tiền Vận Hành (Điện, nước...)";
            // 
            // txtChiNhapHang
            // 
            txtChiNhapHang.Location = new Point(732, 18);
            txtChiNhapHang.Name = "txtChiNhapHang";
            txtChiNhapHang.ReadOnly = true;
            txtChiNhapHang.Size = new Size(308, 31);
            txtChiNhapHang.TabIndex = 59;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(541, 18);
            label5.Name = "label5";
            label5.Size = new Size(184, 25);
            label5.TabIndex = 58;
            label5.Text = "Tiền Vốn (Nhập hàng)";
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
        private TextBox txtThuTraGop;
        private Label label2;
        private TextBox txtTongDoanhThu;
        private GroupBox groupBox1;
        private TextBox txtTienVanHanh;
        private Label label10;
        private TextBox txtChiNhapHang;
        private Label label5;
        private Label label9;
        private Label label7;
        private NumericUpDown nudNam;
        private NumericUpDown nudThang;
        private Button btnThongKe;
        private TextBox txtLoiNhuan;
        private Label label6;
        private TextBox txtTienLuong;
        private Label label4;
        private TextBox txtTongChiPhi;
        private Label label3;
        private DataGridViewTextBoxColumn ColMaTiVi;
        private DataGridViewTextBoxColumn ColTenTiVi;
        private DataGridViewTextBoxColumn ColKhuyenMai;
        private DataGridViewTextBoxColumn ColSoLuong;
        private DataGridViewTextBoxColumn ColDonGia;
        private DataGridViewTextBoxColumn ColThanhTien;
    }
}