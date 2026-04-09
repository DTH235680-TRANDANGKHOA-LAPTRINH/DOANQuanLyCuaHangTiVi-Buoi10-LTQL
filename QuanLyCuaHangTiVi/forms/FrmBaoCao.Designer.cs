namespace QuanLyCuaHangTiVi.forms
{
    partial class FrmBaoCao
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
            groupBox1 = new GroupBox();
            label9 = new Label();
            label7 = new Label();
            nudNam = new NumericUpDown();
            nudThang = new NumericUpDown();
            btnXemBaoCao = new Button();
            groupBox2 = new GroupBox();
            btnChiTietDoanhThu = new Button();
            txtTongDoanhThu = new TextBox();
            label2 = new Label();
            groupBox4 = new GroupBox();
            dgvCanThuTien = new DataGridView();
            colTenTiVi = new DataGridViewTextBoxColumn();
            colHangSanXuat = new DataGridViewTextBoxColumn();
            colNgayNhap = new DataGridViewTextBoxColumn();
            colDonGiaNhap = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtTongChiPhi = new TextBox();
            groupBox3 = new GroupBox();
            txtLoiNhuan = new TextBox();
            label3 = new Label();
            btnChiTietChiPhi = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCanThuTien).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(224, 224, 224);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(nudNam);
            groupBox1.Controls.Add(nudThang);
            groupBox1.Controls.Add(btnXemBaoCao);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1694, 105);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(325, 47);
            label9.Name = "label9";
            label9.Size = new Size(50, 25);
            label9.TabIndex = 72;
            label9.Text = "Năm";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 32);
            label7.Name = "label7";
            label7.Size = new Size(61, 25);
            label7.TabIndex = 71;
            label7.Text = "Tháng";
            // 
            // nudNam
            // 
            nudNam.Location = new Point(397, 41);
            nudNam.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudNam.Name = "nudNam";
            nudNam.Size = new Size(180, 31);
            nudNam.TabIndex = 70;
            nudNam.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // nudThang
            // 
            nudThang.Location = new Point(97, 41);
            nudThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudThang.Name = "nudThang";
            nudThang.Size = new Size(180, 31);
            nudThang.TabIndex = 69;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.Font = new Font("Times New Roman", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnXemBaoCao.Location = new Point(1081, 20);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(315, 52);
            btnXemBaoCao.TabIndex = 68;
            btnXemBaoCao.Text = "Xem Báo Cáo";
            btnXemBaoCao.UseVisualStyleBackColor = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(224, 224, 224);
            groupBox2.Controls.Add(btnChiTietDoanhThu);
            groupBox2.Controls.Add(txtTongDoanhThu);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 105);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1694, 112);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông Tin";
            // 
            // btnChiTietDoanhThu
            // 
            btnChiTietDoanhThu.Font = new Font("Times New Roman", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnChiTietDoanhThu.Location = new Point(1081, 21);
            btnChiTietDoanhThu.Name = "btnChiTietDoanhThu";
            btnChiTietDoanhThu.Size = new Size(315, 46);
            btnChiTietDoanhThu.TabIndex = 69;
            btnChiTietDoanhThu.Text = "Chi Tiết Doanh Thu";
            btnChiTietDoanhThu.UseVisualStyleBackColor = true;
            btnChiTietDoanhThu.Click += btnChiTietDoanhThu_Click;
            // 
            // txtTongDoanhThu
            // 
            txtTongDoanhThu.Location = new Point(210, 45);
            txtTongDoanhThu.Name = "txtTongDoanhThu";
            txtTongDoanhThu.ReadOnly = true;
            txtTongDoanhThu.Size = new Size(308, 31);
            txtTongDoanhThu.TabIndex = 59;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 51);
            label2.Name = "label2";
            label2.Size = new Size(169, 25);
            label2.TabIndex = 58;
            label2.Text = "TỔNG DOANH THU";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvCanThuTien);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(0, 347);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1694, 164);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "DANH SÁCH KHÁCH HÀNG CẦN ĐÓNG TRẢ GÓP TRONG THÁNG";
            // 
            // dgvCanThuTien
            // 
            dgvCanThuTien.AllowUserToAddRows = false;
            dgvCanThuTien.AllowUserToDeleteRows = false;
            dgvCanThuTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanThuTien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanThuTien.Columns.AddRange(new DataGridViewColumn[] { colTenTiVi, colHangSanXuat, colNgayNhap, colDonGiaNhap });
            dgvCanThuTien.Dock = DockStyle.Fill;
            dgvCanThuTien.Location = new Point(3, 27);
            dgvCanThuTien.MultiSelect = false;
            dgvCanThuTien.Name = "dgvCanThuTien";
            dgvCanThuTien.RowHeadersWidth = 62;
            dgvCanThuTien.Size = new Size(1688, 134);
            dgvCanThuTien.TabIndex = 2;
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
            dataGridViewCellStyle1.Format = "N0";
            colDonGiaNhap.DefaultCellStyle = dataGridViewCellStyle1;
            colDonGiaNhap.HeaderText = "Đơn Gía Nhập";
            colDonGiaNhap.MinimumWidth = 8;
            colDonGiaNhap.Name = "colDonGiaNhap";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 60);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 15;
            label1.Text = "Tổng Chi Phí";
            // 
            // txtTongChiPhi
            // 
            txtTongChiPhi.BackColor = Color.White;
            txtTongChiPhi.Location = new Point(163, 58);
            txtTongChiPhi.Multiline = true;
            txtTongChiPhi.Name = "txtTongChiPhi";
            txtTongChiPhi.ReadOnly = true;
            txtTongChiPhi.Size = new Size(287, 28);
            txtTongChiPhi.TabIndex = 16;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(224, 224, 224);
            groupBox3.Controls.Add(txtLoiNhuan);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(btnChiTietChiPhi);
            groupBox3.Controls.Add(txtTongChiPhi);
            groupBox3.Controls.Add(label1);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 217);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1694, 130);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông Tin";
            // 
            // txtLoiNhuan
            // 
            txtLoiNhuan.BackColor = Color.White;
            txtLoiNhuan.Location = new Point(622, 50);
            txtLoiNhuan.Multiline = true;
            txtLoiNhuan.Name = "txtLoiNhuan";
            txtLoiNhuan.ReadOnly = true;
            txtLoiNhuan.Size = new Size(282, 44);
            txtLoiNhuan.TabIndex = 72;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(490, 60);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 71;
            label3.Text = "Lợi Nhuận";
            // 
            // btnChiTietChiPhi
            // 
            btnChiTietChiPhi.Font = new Font("Times New Roman", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnChiTietChiPhi.Location = new Point(1081, 30);
            btnChiTietChiPhi.Name = "btnChiTietChiPhi";
            btnChiTietChiPhi.Size = new Size(315, 44);
            btnChiTietChiPhi.TabIndex = 70;
            btnChiTietChiPhi.Text = "Chi Tiết Chi Phí";
            btnChiTietChiPhi.UseVisualStyleBackColor = true;
            btnChiTietChiPhi.Click += btnChiTietChiPhi_Click;
            // 
            // FrmBaoCao
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1694, 511);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmBaoCao";
            Text = "Báo Cáo";
            Load += FrmBaoCao_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCanThuTien).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label9;
        private Label label7;
        private NumericUpDown nudNam;
        private NumericUpDown nudThang;
        private Button btnXemBaoCao;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private DataGridView dgvCanThuTien;
        private DataGridViewTextBoxColumn colTenTiVi;
        private DataGridViewTextBoxColumn colHangSanXuat;
        private DataGridViewTextBoxColumn colNgayNhap;
        private DataGridViewTextBoxColumn colDonGiaNhap;
        private Button btnChiTietDoanhThu;
        private TextBox txtTongDoanhThu;
        private Label label2;
        private Label label1;
        private TextBox txtTongChiPhi;
        private GroupBox groupBox3;
        private TextBox txtLoiNhuan;
        private Label label3;
        private Button btnChiTietChiPhi;
    }
}