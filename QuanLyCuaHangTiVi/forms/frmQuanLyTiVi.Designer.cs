namespace QuanLyCuaHangTiVi.forms
{
    partial class frmQuanLyTiVi
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
            panel1 = new Panel();
            btnThem = new Button();
            label1 = new Label();
            txtMaTiVi = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtTenTiVi = new TextBox();
            txtTenKhachHang = new TextBox();
            txtDonGia = new TextBox();
            txtKhuyenMai = new TextBox();
            dtpNgayThangNam = new DateTimePicker();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            btnHuyBo = new Button();
            btnThoat = new Button();
            dataGridView = new DataGridView();
            MaTiVi = new DataGridViewTextBoxColumn();
            TenTiVi = new DataGridViewTextBoxColumn();
            TenKhachHang = new DataGridViewTextBoxColumn();
            NgayThangNam = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            KhuyenMai = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnHuyBo);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(dtpNgayThangNam);
            panel1.Controls.Add(txtKhuyenMai);
            panel1.Controls.Add(txtDonGia);
            panel1.Controls.Add(txtTenKhachHang);
            panel1.Controls.Add(txtTenTiVi);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtMaTiVi);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1602, 208);
            panel1.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(134, 148);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 20);
            label1.Name = "label1";
            label1.Size = new Size(70, 25);
            label1.TabIndex = 1;
            label1.Text = "Mã TiVi";
            // 
            // txtMaTiVi
            // 
            txtMaTiVi.Location = new Point(133, 12);
            txtMaTiVi.Name = "txtMaTiVi";
            txtMaTiVi.Size = new Size(150, 31);
            txtMaTiVi.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 59);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 3;
            label2.Text = "Tên TiVi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(387, 20);
            label3.Name = "label3";
            label3.Size = new Size(138, 25);
            label3.TabIndex = 4;
            label3.Text = "Tên Khách Hàng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 59);
            label4.Name = "label4";
            label4.Size = new Size(155, 25);
            label4.TabIndex = 5;
            label4.Text = "Ngày/Tháng/Năm";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1026, 20);
            label5.Name = "label5";
            label5.Size = new Size(76, 25);
            label5.TabIndex = 6;
            label5.Text = "Đơn Gía";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1026, 83);
            label6.Name = "label6";
            label6.Size = new Size(104, 25);
            label6.TabIndex = 7;
            label6.Text = "Khuyến Mãi";
            // 
            // txtTenTiVi
            // 
            txtTenTiVi.Location = new Point(134, 59);
            txtTenTiVi.Name = "txtTenTiVi";
            txtTenTiVi.Size = new Size(150, 31);
            txtTenTiVi.TabIndex = 8;
            // 
            // txtTenKhachHang
            // 
            txtTenKhachHang.Location = new Point(545, 12);
            txtTenKhachHang.Name = "txtTenKhachHang";
            txtTenKhachHang.Size = new Size(150, 31);
            txtTenKhachHang.TabIndex = 9;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(1136, 20);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(150, 31);
            txtDonGia.TabIndex = 10;
            // 
            // txtKhuyenMai
            // 
            txtKhuyenMai.Location = new Point(1136, 77);
            txtKhuyenMai.Name = "txtKhuyenMai";
            txtKhuyenMai.Size = new Size(150, 31);
            txtKhuyenMai.TabIndex = 11;
            txtKhuyenMai.TextChanged += textBox3_TextChanged;
            // 
            // dtpNgayThangNam
            // 
            dtpNgayThangNam.Location = new Point(545, 57);
            dtpNgayThangNam.Name = "dtpNgayThangNam";
            dtpNgayThangNam.Size = new Size(300, 31);
            dtpNgayThangNam.TabIndex = 12;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(325, 148);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 34);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(519, 148);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(686, 148);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 15;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(850, 148);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(112, 34);
            btnHuyBo.TabIndex = 16;
            btnHuyBo.Text = "Hủy Bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(990, 148);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 34);
            btnThoat.TabIndex = 17;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { MaTiVi, TenTiVi, TenKhachHang, NgayThangNam, DonGia, KhuyenMai });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 208);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(1602, 242);
            dataGridView.TabIndex = 1;
            // 
            // MaTiVi
            // 
            MaTiVi.DataPropertyName = "MaTiVi";
            MaTiVi.HeaderText = "Mã TiVi";
            MaTiVi.MinimumWidth = 8;
            MaTiVi.Name = "MaTiVi";
            // 
            // TenTiVi
            // 
            TenTiVi.DataPropertyName = "TenTiVi";
            TenTiVi.HeaderText = "Tên TiVi";
            TenTiVi.MinimumWidth = 8;
            TenTiVi.Name = "TenTiVi";
            // 
            // TenKhachHang
            // 
            TenKhachHang.DataPropertyName = "TenKhachHang";
            TenKhachHang.HeaderText = "Tên Khách Hàng";
            TenKhachHang.MinimumWidth = 8;
            TenKhachHang.Name = "TenKhachHang";
            // 
            // NgayThangNam
            // 
            NgayThangNam.DataPropertyName = "NgayThangNam";
            NgayThangNam.HeaderText = "Ngày Tháng Năm";
            NgayThangNam.MinimumWidth = 8;
            NgayThangNam.Name = "NgayThangNam";
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn Gía";
            DonGia.MinimumWidth = 8;
            DonGia.Name = "DonGia";
            // 
            // KhuyenMai
            // 
            KhuyenMai.DataPropertyName = "KhuyenMai";
            KhuyenMai.HeaderText = "Khuyến Mãi";
            KhuyenMai.MinimumWidth = 8;
            KhuyenMai.Name = "KhuyenMai";
            // 
            // frmQuanLyTiVi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1602, 450);
            Controls.Add(dataGridView);
            Controls.Add(panel1);
            Name = "frmQuanLyTiVi";
            Text = "frmQuanLyTiVi";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtMaTiVi;
        private Label label1;
        private Button btnThem;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTenTiVi;
        private Label label6;
        private Label label5;
        private DateTimePicker dtpNgayThangNam;
        private TextBox txtKhuyenMai;
        private TextBox txtDonGia;
        private TextBox txtTenKhachHang;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn MaTiVi;
        private DataGridViewTextBoxColumn TenTiVi;
        private DataGridViewTextBoxColumn TenKhachHang;
        private DataGridViewTextBoxColumn NgayThangNam;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn KhuyenMai;
    }
}