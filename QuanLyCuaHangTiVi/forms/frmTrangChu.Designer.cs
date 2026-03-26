namespace QuanLyCuaHangTiVi.forms
{
    partial class frmTrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnQuanLyTiVi = new Button();
            btnNhanVien = new Button();
            btnKhachHang = new Button();
            btnPhieuNhap = new Button();
            btnCTPhieuNhap = new Button();
            btnHoaDon = new Button();
            btnTraGop = new Button();
            btnTKChiPhi = new Button();
            btnTKDoanhThu = new Button();
            btnTroGiup = new Button();
            btnDangXuat = new Button();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            panelContent = new Panel();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(45, 66, 91);
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(208, 535);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "DANH MỤC";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnQuanLyTiVi, 0, 0);
            tableLayoutPanel1.Controls.Add(btnNhanVien, 0, 1);
            tableLayoutPanel1.Controls.Add(btnKhachHang, 0, 2);
            tableLayoutPanel1.Controls.Add(btnPhieuNhap, 0, 3);
            tableLayoutPanel1.Controls.Add(btnCTPhieuNhap, 0, 4);
            tableLayoutPanel1.Controls.Add(btnHoaDon, 0, 5);
            tableLayoutPanel1.Controls.Add(btnTraGop, 0, 6);
            tableLayoutPanel1.Controls.Add(btnTKChiPhi, 0, 7);
            tableLayoutPanel1.Controls.Add(btnTKDoanhThu, 0, 8);
            tableLayoutPanel1.Controls.Add(btnTroGiup, 0, 9);
            tableLayoutPanel1.Controls.Add(btnDangXuat, 0, 12);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 37);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 13;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(188, 488);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnQuanLyTiVi
            // 
            btnQuanLyTiVi.BackColor = Color.FromArgb(60, 85, 115);
            btnQuanLyTiVi.Dock = DockStyle.Fill;
            btnQuanLyTiVi.FlatAppearance.BorderSize = 0;
            btnQuanLyTiVi.FlatStyle = FlatStyle.Flat;
            btnQuanLyTiVi.ForeColor = Color.White;
            btnQuanLyTiVi.Location = new Point(15, 2);
            btnQuanLyTiVi.Margin = new Padding(15, 2, 15, 2);
            btnQuanLyTiVi.Name = "btnQuanLyTiVi";
            btnQuanLyTiVi.Size = new Size(158, 36);
            btnQuanLyTiVi.TabIndex = 0;
            btnQuanLyTiVi.Text = "Quản Lý TiVi";
            btnQuanLyTiVi.UseVisualStyleBackColor = false;
            btnQuanLyTiVi.Click += btnQuanLyTiVi_Click;
            // 
            // btnNhanVien
            // 
            btnNhanVien.BackColor = Color.FromArgb(60, 85, 115);
            btnNhanVien.Dock = DockStyle.Fill;
            btnNhanVien.FlatAppearance.BorderSize = 0;
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.Location = new Point(15, 42);
            btnNhanVien.Margin = new Padding(15, 2, 15, 2);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(158, 36);
            btnNhanVien.TabIndex = 1;
            btnNhanVien.Text = "Nhân Viên";
            btnNhanVien.UseVisualStyleBackColor = false;
            btnNhanVien.Click += btnNhanVien_Click;
            // 
            // btnKhachHang
            // 
            btnKhachHang.BackColor = Color.FromArgb(60, 85, 115);
            btnKhachHang.Dock = DockStyle.Fill;
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.ForeColor = Color.White;
            btnKhachHang.Location = new Point(15, 82);
            btnKhachHang.Margin = new Padding(15, 2, 15, 2);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(158, 36);
            btnKhachHang.TabIndex = 2;
            btnKhachHang.Text = "Khách Hàng";
            btnKhachHang.UseVisualStyleBackColor = false;
            btnKhachHang.Click += btnKhachHang_Click;
            // 
            // btnPhieuNhap
            // 
            btnPhieuNhap.BackColor = Color.FromArgb(60, 85, 115);
            btnPhieuNhap.Dock = DockStyle.Fill;
            btnPhieuNhap.FlatAppearance.BorderSize = 0;
            btnPhieuNhap.FlatStyle = FlatStyle.Flat;
            btnPhieuNhap.ForeColor = Color.White;
            btnPhieuNhap.Location = new Point(15, 122);
            btnPhieuNhap.Margin = new Padding(15, 2, 15, 2);
            btnPhieuNhap.Name = "btnPhieuNhap";
            btnPhieuNhap.Size = new Size(158, 36);
            btnPhieuNhap.TabIndex = 3;
            btnPhieuNhap.Text = "Phiếu Nhập";
            btnPhieuNhap.UseVisualStyleBackColor = false;
            btnPhieuNhap.Click += btnPhieuNhap_Click;
            // 
            // btnCTPhieuNhap
            // 
            btnCTPhieuNhap.BackColor = Color.FromArgb(60, 85, 115);
            btnCTPhieuNhap.Dock = DockStyle.Fill;
            btnCTPhieuNhap.FlatAppearance.BorderSize = 0;
            btnCTPhieuNhap.FlatStyle = FlatStyle.Flat;
            btnCTPhieuNhap.ForeColor = Color.White;
            btnCTPhieuNhap.Location = new Point(15, 162);
            btnCTPhieuNhap.Margin = new Padding(15, 2, 15, 2);
            btnCTPhieuNhap.Name = "btnCTPhieuNhap";
            btnCTPhieuNhap.Size = new Size(158, 36);
            btnCTPhieuNhap.TabIndex = 4;
            btnCTPhieuNhap.Text = "CT Phiếu Nhập";
            btnCTPhieuNhap.UseVisualStyleBackColor = false;
            btnCTPhieuNhap.Click += btnCTPhieuNhap_Click;
            // 
            // btnHoaDon
            // 
            btnHoaDon.BackColor = Color.FromArgb(60, 85, 115);
            btnHoaDon.Dock = DockStyle.Fill;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatStyle = FlatStyle.Flat;
            btnHoaDon.ForeColor = Color.White;
            btnHoaDon.Location = new Point(15, 202);
            btnHoaDon.Margin = new Padding(15, 2, 15, 2);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(158, 36);
            btnHoaDon.TabIndex = 5;
            btnHoaDon.Text = "Hóa Đơn";
            btnHoaDon.UseVisualStyleBackColor = false;
            btnHoaDon.Click += btnHoaDon_Click;
            // 
            // btnTraGop
            // 
            btnTraGop.BackColor = Color.FromArgb(60, 85, 115);
            btnTraGop.Dock = DockStyle.Fill;
            btnTraGop.FlatAppearance.BorderSize = 0;
            btnTraGop.FlatStyle = FlatStyle.Flat;
            btnTraGop.ForeColor = Color.White;
            btnTraGop.Location = new Point(15, 242);
            btnTraGop.Margin = new Padding(15, 2, 15, 2);
            btnTraGop.Name = "btnTraGop";
            btnTraGop.Size = new Size(158, 36);
            btnTraGop.TabIndex = 29;
            btnTraGop.Text = "Trả Góp";
            btnTraGop.UseVisualStyleBackColor = false;
            btnTraGop.Click += btnTraGop_Click;
            // 
            // btnTKChiPhi
            // 
            btnTKChiPhi.BackColor = Color.FromArgb(60, 85, 115);
            btnTKChiPhi.Dock = DockStyle.Fill;
            btnTKChiPhi.FlatAppearance.BorderSize = 0;
            btnTKChiPhi.FlatStyle = FlatStyle.Flat;
            btnTKChiPhi.ForeColor = Color.White;
            btnTKChiPhi.Location = new Point(15, 282);
            btnTKChiPhi.Margin = new Padding(15, 2, 15, 2);
            btnTKChiPhi.Name = "btnTKChiPhi";
            btnTKChiPhi.Size = new Size(158, 36);
            btnTKChiPhi.TabIndex = 30;
            btnTKChiPhi.Text = "TK Chi Phí";
            btnTKChiPhi.UseVisualStyleBackColor = false;
            btnTKChiPhi.Click += btnTKChiPhi_Click;
            // 
            // btnTKDoanhThu
            // 
            btnTKDoanhThu.BackColor = Color.FromArgb(60, 85, 115);
            btnTKDoanhThu.Dock = DockStyle.Fill;
            btnTKDoanhThu.FlatAppearance.BorderSize = 0;
            btnTKDoanhThu.FlatStyle = FlatStyle.Flat;
            btnTKDoanhThu.ForeColor = Color.White;
            btnTKDoanhThu.Location = new Point(15, 322);
            btnTKDoanhThu.Margin = new Padding(15, 2, 15, 2);
            btnTKDoanhThu.Name = "btnTKDoanhThu";
            btnTKDoanhThu.Size = new Size(158, 36);
            btnTKDoanhThu.TabIndex = 31;
            btnTKDoanhThu.Text = "TK Doanh Thu";
            btnTKDoanhThu.UseVisualStyleBackColor = false;
            btnTKDoanhThu.Click += btnTKDoanhThu_Click;
            // 
            // btnTroGiup
            // 
            btnTroGiup.BackColor = Color.FromArgb(60, 85, 115);
            btnTroGiup.Dock = DockStyle.Fill;
            btnTroGiup.FlatAppearance.BorderSize = 0;
            btnTroGiup.FlatStyle = FlatStyle.Flat;
            btnTroGiup.ForeColor = Color.White;
            btnTroGiup.Location = new Point(15, 362);
            btnTroGiup.Margin = new Padding(15, 2, 15, 2);
            btnTroGiup.Name = "btnTroGiup";
            btnTroGiup.Size = new Size(158, 36);
            btnTroGiup.TabIndex = 32;
            btnTroGiup.Text = "Trợ Giúp";
            btnTroGiup.UseVisualStyleBackColor = false;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.FromArgb(220, 53, 69);
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(15, 443);
            btnDangXuat.Margin = new Padding(15, 5, 15, 5);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(158, 40);
            btnDangXuat.TabIndex = 28;
            btnDangXuat.Text = "ĐĂNG XUẤT";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(240, 240, 240);
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTrangThai, toolStripStatusLabel4 });
            statusStrip1.Location = new Point(0, 535);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1924, 32);
            statusStrip1.TabIndex = 2;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(144, 25);
            lblTrangThai.Text = "Chưa đăng nhập";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(1765, 25);
            toolStripStatusLabel4.Spring = true;
            toolStripStatusLabel4.Text = " ";
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(208, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1716, 535);
            panelContent.TabIndex = 4;
            // 
            // frmTrangChu
            // 
            ClientSize = new Size(1924, 567);
            Controls.Add(panelContent);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            IsMdiContainer = true;
            Name = "frmTrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang Chủ - Quản Lý TiVi";
            WindowState = FormWindowState.Maximized;
            Load += frmTrangChu_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private StatusStrip statusStrip1;
        public ToolStripStatusLabel lblTrangThai; // Đổi thành Public để dễ điều khiển
        private ToolStripStatusLabel toolStripStatusLabel4;

        // Khai báo các Button là Public để file .cs điều khiển được (Enable/Disable)
        public Button btnQuanLyTiVi;
        public Button btnNhanVien;
        public Button btnKhachHang;
        public Button btnPhieuNhap;
        public Button btnCTPhieuNhap;
        public Button btnHoaDon;
        public Button btnTraGop;
        public Button btnTKChiPhi;
        public Button btnTKDoanhThu;
        public Button btnTroGiup;
        public Button btnDangXuat;
        private Panel panelContent;
    }
}