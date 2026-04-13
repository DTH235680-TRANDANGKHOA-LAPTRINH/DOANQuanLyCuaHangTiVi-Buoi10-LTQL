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
            groupBox1 = new GroupBox();
            txtLoiNhuan = new TextBox();
            label3 = new Label();
            btnChiTietChiPhi = new Button();
            txtTongDoanhThu = new TextBox();
            btnChiTietDoanhThu = new Button();
            btnXemBaoCao = new Button();
            txtTongChiPhi = new TextBox();
            label1 = new Label();
            label9 = new Label();
            label7 = new Label();
            nudNam = new NumericUpDown();
            label2 = new Label();
            nudThang = new NumericUpDown();
            groupBox4 = new GroupBox();
            dgvCanThuTien = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCanThuTien).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(224, 224, 224);
            groupBox1.Controls.Add(txtLoiNhuan);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnChiTietChiPhi);
            groupBox1.Controls.Add(txtTongDoanhThu);
            groupBox1.Controls.Add(btnChiTietDoanhThu);
            groupBox1.Controls.Add(btnXemBaoCao);
            groupBox1.Controls.Add(txtTongChiPhi);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(nudNam);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(nudThang);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1694, 323);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin chi phí và doanh thu";
            // 
            // txtLoiNhuan
            // 
            txtLoiNhuan.BackColor = Color.White;
            txtLoiNhuan.Location = new Point(1198, 144);
            txtLoiNhuan.Multiline = true;
            txtLoiNhuan.Name = "txtLoiNhuan";
            txtLoiNhuan.ReadOnly = true;
            txtLoiNhuan.Size = new Size(279, 28);
            txtLoiNhuan.TabIndex = 72;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1069, 146);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 71;
            label3.Text = "Lợi Nhuận";
            // 
            // btnChiTietChiPhi
            // 
            btnChiTietChiPhi.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnChiTietChiPhi.Location = new Point(745, 198);
            btnChiTietChiPhi.Name = "btnChiTietChiPhi";
            btnChiTietChiPhi.Size = new Size(215, 53);
            btnChiTietChiPhi.TabIndex = 70;
            btnChiTietChiPhi.Text = "Chi Tiết Chi Phí";
            btnChiTietChiPhi.UseVisualStyleBackColor = true;
            btnChiTietChiPhi.Click += btnChiTietChiPhi_Click;
            // 
            // txtTongDoanhThu
            // 
            txtTongDoanhThu.Location = new Point(230, 143);
            txtTongDoanhThu.Name = "txtTongDoanhThu";
            txtTongDoanhThu.ReadOnly = true;
            txtTongDoanhThu.Size = new Size(308, 31);
            txtTongDoanhThu.TabIndex = 59;
            // 
            // btnChiTietDoanhThu
            // 
            btnChiTietDoanhThu.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnChiTietDoanhThu.Location = new Point(254, 198);
            btnChiTietDoanhThu.Name = "btnChiTietDoanhThu";
            btnChiTietDoanhThu.Size = new Size(239, 53);
            btnChiTietDoanhThu.TabIndex = 69;
            btnChiTietDoanhThu.Text = "Chi Tiết Doanh Thu";
            btnChiTietDoanhThu.UseVisualStyleBackColor = true;
            btnChiTietDoanhThu.Click += btnChiTietDoanhThu_Click;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnXemBaoCao.Location = new Point(1198, 199);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(241, 52);
            btnXemBaoCao.TabIndex = 68;
            btnXemBaoCao.Text = "Xem Báo Cáo";
            btnXemBaoCao.UseVisualStyleBackColor = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // txtTongChiPhi
            // 
            txtTongChiPhi.BackColor = Color.White;
            txtTongChiPhi.Location = new Point(724, 144);
            txtTongChiPhi.Multiline = true;
            txtTongChiPhi.Name = "txtTongChiPhi";
            txtTongChiPhi.ReadOnly = true;
            txtTongChiPhi.Size = new Size(308, 28);
            txtTongChiPhi.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(575, 146);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 15;
            label1.Text = "Tổng Chi Phí";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(417, 41);
            label9.Name = "label9";
            label9.Size = new Size(50, 25);
            label9.TabIndex = 72;
            label9.Text = "Năm";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(109, 41);
            label7.Name = "label7";
            label7.Size = new Size(61, 25);
            label7.TabIndex = 71;
            label7.Text = "Tháng";
            // 
            // nudNam
            // 
            nudNam.Location = new Point(507, 38);
            nudNam.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudNam.Name = "nudNam";
            nudNam.Size = new Size(180, 31);
            nudNam.TabIndex = 70;
            nudNam.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 148);
            label2.Name = "label2";
            label2.Size = new Size(172, 20);
            label2.TabIndex = 58;
            label2.Text = "TỔNG DOANH THU";
            // 
            // nudThang
            // 
            nudThang.Location = new Point(210, 38);
            nudThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudThang.Name = "nudThang";
            nudThang.Size = new Size(180, 31);
            nudThang.TabIndex = 69;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvCanThuTien);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(0, 323);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1694, 188);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "DANH SÁCH KHÁCH HÀNG CẦN ĐÓNG TRẢ GÓP";
            // 
            // dgvCanThuTien
            // 
            dgvCanThuTien.AllowUserToAddRows = false;
            dgvCanThuTien.AllowUserToDeleteRows = false;
            dgvCanThuTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanThuTien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanThuTien.Dock = DockStyle.Fill;
            dgvCanThuTien.Location = new Point(3, 27);
            dgvCanThuTien.MultiSelect = false;
            dgvCanThuTien.Name = "dgvCanThuTien";
            dgvCanThuTien.RowHeadersWidth = 62;
            dgvCanThuTien.Size = new Size(1688, 158);
            dgvCanThuTien.TabIndex = 2;
            // 
            // FrmBaoCao
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1694, 511);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            Name = "FrmBaoCao";
            Text = "Báo Cáo";
            Load += FrmBaoCao_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCanThuTien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label9;
        private Label label7;
        private NumericUpDown nudNam;
        private NumericUpDown nudThang;
        private Button btnXemBaoCao;
        private GroupBox groupBox4;
        private DataGridView dgvCanThuTien;
        private Button btnChiTietDoanhThu;
        private TextBox txtTongDoanhThu;
        private Label label2;
        private Label label1;
        private TextBox txtTongChiPhi;
        private TextBox txtLoiNhuan;
        private Label label3;
        private Button btnChiTietChiPhi;
    }
}