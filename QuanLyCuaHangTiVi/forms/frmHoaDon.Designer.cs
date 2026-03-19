namespace QuanLyCuaHangTiVi.forms
{
    partial class frmHoaDon
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
            btnXuatHoaDon = new Button();
            btnLapHoaDon = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThoat = new Button();
            dgvDanhSachHD = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            TenKhachHang = new DataGridViewTextBoxColumn();
            NgayLap = new DataGridViewTextBoxColumn();
            TongTien = new DataGridViewTextBoxColumn();
            HoTenNhanVien = new DataGridViewTextBoxColumn();
            colXemChiTiet = new DataGridViewLinkColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHD).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXuatHoaDon);
            groupBox1.Controls.Add(btnLapHoaDon);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1707, 126);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hóa Đơn";
            // 
            // btnXuatHoaDon
            // 
            btnXuatHoaDon.Location = new Point(794, 66);
            btnXuatHoaDon.Name = "btnXuatHoaDon";
            btnXuatHoaDon.Size = new Size(203, 34);
            btnXuatHoaDon.TabIndex = 43;
            btnXuatHoaDon.Text = "Xuất hóa đơn...";
            btnXuatHoaDon.UseVisualStyleBackColor = true;
            btnXuatHoaDon.Click += btnXuatHoaDon_Click;
            // 
            // btnLapHoaDon
            // 
            btnLapHoaDon.Location = new Point(69, 66);
            btnLapHoaDon.Name = "btnLapHoaDon";
            btnLapHoaDon.Size = new Size(174, 34);
            btnLapHoaDon.TabIndex = 42;
            btnLapHoaDon.Text = "Lập Hóa Đơn";
            btnLapHoaDon.UseVisualStyleBackColor = true;
            btnLapHoaDon.Click += btnLapHoaDon_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(294, 66);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 34);
            btnXoa.TabIndex = 41;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(468, 66);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 40;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(621, 66);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 34);
            btnThoat.TabIndex = 39;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dgvDanhSachHD
            // 
            dgvDanhSachHD.AllowUserToAddRows = false;
            dgvDanhSachHD.AllowUserToDeleteRows = false;
            dgvDanhSachHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachHD.Columns.AddRange(new DataGridViewColumn[] { colID, TenKhachHang, NgayLap, TongTien, HoTenNhanVien, colXemChiTiet });
            dgvDanhSachHD.Dock = DockStyle.Fill;
            dgvDanhSachHD.Location = new Point(0, 126);
            dgvDanhSachHD.MultiSelect = false;
            dgvDanhSachHD.Name = "dgvDanhSachHD";
            dgvDanhSachHD.ReadOnly = true;
            dgvDanhSachHD.RowHeadersWidth = 62;
            dgvDanhSachHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachHD.Size = new Size(1707, 391);
            dgvDanhSachHD.TabIndex = 6;
            dgvDanhSachHD.CellContentClick += dgvDanhSachHD_CellContentClick;
            // 
            // colID
            // 
            colID.DataPropertyName = "ID";
            colID.HeaderText = "Mã HĐ";
            colID.MinimumWidth = 8;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // TenKhachHang
            // 
            TenKhachHang.DataPropertyName = "TenKhachHang";
            TenKhachHang.HeaderText = "Khách Hàng";
            TenKhachHang.MinimumWidth = 8;
            TenKhachHang.Name = "TenKhachHang";
            TenKhachHang.ReadOnly = true;
            // 
            // NgayLap
            // 
            NgayLap.DataPropertyName = "NgayLap";
            NgayLap.HeaderText = "Ngày Lập";
            NgayLap.MinimumWidth = 8;
            NgayLap.Name = "NgayLap";
            NgayLap.ReadOnly = true;
            // 
            // TongTien
            // 
            TongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            TongTien.DefaultCellStyle = dataGridViewCellStyle1;
            TongTien.HeaderText = "Tổng Tiền";
            TongTien.MinimumWidth = 8;
            TongTien.Name = "TongTien";
            TongTien.ReadOnly = true;
            // 
            // HoTenNhanVien
            // 
            HoTenNhanVien.DataPropertyName = "HoTenNhanVien";
            HoTenNhanVien.HeaderText = "Nhân Viên Lập";
            HoTenNhanVien.MinimumWidth = 8;
            HoTenNhanVien.Name = "HoTenNhanVien";
            HoTenNhanVien.ReadOnly = true;
            // 
            // colXemChiTiet
            // 
            colXemChiTiet.DataPropertyName = "XemChiTiet";
            colXemChiTiet.HeaderText = "Xem Chi Tiết";
            colXemChiTiet.MinimumWidth = 8;
            colXemChiTiet.Name = "colXemChiTiet";
            colXemChiTiet.ReadOnly = true;
            colXemChiTiet.Resizable = DataGridViewTriState.True;
            colXemChiTiet.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // frmHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1707, 517);
            Controls.Add(dgvDanhSachHD);
            Controls.Add(groupBox1);
            Name = "frmHoaDon";
            Text = "frmHoaDon";
            Load += frmHoaDon_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHD).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThoat;
        private DataGridView dgvDanhSachHD;
        private Button btnLapHoaDon;
        private Button btnXuatHoaDon;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn TenKhachHang;
        private DataGridViewTextBoxColumn NgayLap;
        private DataGridViewTextBoxColumn TongTien;
        private DataGridViewTextBoxColumn HoTenNhanVien;
        private DataGridViewLinkColumn colXemChiTiet;
    }
}