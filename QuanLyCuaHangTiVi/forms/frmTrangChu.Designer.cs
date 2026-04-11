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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrangChu));
            groupBox1 = new GroupBox();
            flowLayoutPanelMenu = new FlowLayoutPanel();
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
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            flowLayoutPanelMenu.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(45, 66, 91);
            groupBox1.Controls.Add(flowLayoutPanelMenu);
            groupBox1.Controls.Add(btnDangXuat);
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
            // flowLayoutPanelMenu
            // 
            flowLayoutPanelMenu.AutoScroll = true;
            flowLayoutPanelMenu.Controls.Add(btnQuanLyTiVi);
            flowLayoutPanelMenu.Controls.Add(btnNhanVien);
            flowLayoutPanelMenu.Controls.Add(btnKhachHang);
            flowLayoutPanelMenu.Controls.Add(btnPhieuNhap);
            flowLayoutPanelMenu.Controls.Add(btnCTPhieuNhap);
            flowLayoutPanelMenu.Controls.Add(btnHoaDon);
            flowLayoutPanelMenu.Controls.Add(btnTraGop);
            flowLayoutPanelMenu.Controls.Add(btnTKChiPhi);
            flowLayoutPanelMenu.Controls.Add(btnTKDoanhThu);
            flowLayoutPanelMenu.Controls.Add(btnTroGiup);
            flowLayoutPanelMenu.Dock = DockStyle.Fill;
            flowLayoutPanelMenu.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelMenu.Location = new Point(10, 35);
            flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            flowLayoutPanelMenu.Padding = new Padding(2, 5, 0, 0);
            flowLayoutPanelMenu.Size = new Size(188, 440);
            flowLayoutPanelMenu.TabIndex = 0;
            flowLayoutPanelMenu.WrapContents = false;
            // 
            // btnQuanLyTiVi
            // 
            btnQuanLyTiVi.BackColor = Color.FromArgb(60, 85, 115);
            btnQuanLyTiVi.FlatAppearance.BorderSize = 0;
            btnQuanLyTiVi.FlatStyle = FlatStyle.Flat;
            btnQuanLyTiVi.ForeColor = Color.White;
            btnQuanLyTiVi.Location = new Point(5, 10);
            btnQuanLyTiVi.Margin = new Padding(3, 5, 3, 5);
            btnQuanLyTiVi.Name = "btnQuanLyTiVi";
            btnQuanLyTiVi.Size = new Size(175, 40);
            btnQuanLyTiVi.TabIndex = 0;
            btnQuanLyTiVi.Text = "Quản Lý TiVi";
            btnQuanLyTiVi.UseVisualStyleBackColor = false;
            btnQuanLyTiVi.Click += btnQuanLyTiVi_Click;
            // 
            // btnNhanVien
            // 
            btnNhanVien.BackColor = Color.FromArgb(60, 85, 115);
            btnNhanVien.FlatAppearance.BorderSize = 0;
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.Location = new Point(5, 60);
            btnNhanVien.Margin = new Padding(3, 5, 3, 5);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(175, 40);
            btnNhanVien.TabIndex = 1;
            btnNhanVien.Text = "Nhân Viên";
            btnNhanVien.UseVisualStyleBackColor = false;
            btnNhanVien.Click += btnNhanVien_Click;
            // 
            // btnKhachHang
            // 
            btnKhachHang.BackColor = Color.FromArgb(60, 85, 115);
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.ForeColor = Color.White;
            btnKhachHang.Location = new Point(5, 110);
            btnKhachHang.Margin = new Padding(3, 5, 3, 5);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(175, 40);
            btnKhachHang.TabIndex = 2;
            btnKhachHang.Text = "Khách Hàng";
            btnKhachHang.UseVisualStyleBackColor = false;
            btnKhachHang.Click += btnKhachHang_Click;
            // 
            // btnPhieuNhap
            // 
            btnPhieuNhap.BackColor = Color.FromArgb(60, 85, 115);
            btnPhieuNhap.FlatAppearance.BorderSize = 0;
            btnPhieuNhap.FlatStyle = FlatStyle.Flat;
            btnPhieuNhap.ForeColor = Color.White;
            btnPhieuNhap.Location = new Point(5, 160);
            btnPhieuNhap.Margin = new Padding(3, 5, 3, 5);
            btnPhieuNhap.Name = "btnPhieuNhap";
            btnPhieuNhap.Size = new Size(175, 40);
            btnPhieuNhap.TabIndex = 3;
            btnPhieuNhap.Text = "Phiếu Nhập";
            btnPhieuNhap.UseVisualStyleBackColor = false;
            btnPhieuNhap.Click += btnPhieuNhap_Click;
            // 
            // btnCTPhieuNhap
            // 
            btnCTPhieuNhap.BackColor = Color.FromArgb(60, 85, 115);
            btnCTPhieuNhap.FlatAppearance.BorderSize = 0;
            btnCTPhieuNhap.FlatStyle = FlatStyle.Flat;
            btnCTPhieuNhap.ForeColor = Color.White;
            btnCTPhieuNhap.Location = new Point(5, 210);
            btnCTPhieuNhap.Margin = new Padding(3, 5, 3, 5);
            btnCTPhieuNhap.Name = "btnCTPhieuNhap";
            btnCTPhieuNhap.Size = new Size(175, 40);
            btnCTPhieuNhap.TabIndex = 4;
            btnCTPhieuNhap.Text = "CT Phiếu Nhập";
            btnCTPhieuNhap.UseVisualStyleBackColor = false;
            btnCTPhieuNhap.Click += btnCTPhieuNhap_Click;
            // 
            // btnHoaDon
            // 
            btnHoaDon.BackColor = Color.FromArgb(60, 85, 115);
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatStyle = FlatStyle.Flat;
            btnHoaDon.ForeColor = Color.White;
            btnHoaDon.Location = new Point(5, 260);
            btnHoaDon.Margin = new Padding(3, 5, 3, 5);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(175, 40);
            btnHoaDon.TabIndex = 5;
            btnHoaDon.Text = "Hóa Đơn";
            btnHoaDon.UseVisualStyleBackColor = false;
            btnHoaDon.Click += btnHoaDon_Click;
            // 
            // btnTraGop
            // 
            btnTraGop.BackColor = Color.FromArgb(60, 85, 115);
            btnTraGop.FlatAppearance.BorderSize = 0;
            btnTraGop.FlatStyle = FlatStyle.Flat;
            btnTraGop.ForeColor = Color.White;
            btnTraGop.Location = new Point(5, 310);
            btnTraGop.Margin = new Padding(3, 5, 3, 5);
            btnTraGop.Name = "btnTraGop";
            btnTraGop.Size = new Size(175, 40);
            btnTraGop.TabIndex = 29;
            btnTraGop.Text = "Trả Góp";
            btnTraGop.UseVisualStyleBackColor = false;
            btnTraGop.Click += btnTraGop_Click;
            // 
            // btnTKChiPhi
            // 
            btnTKChiPhi.BackColor = Color.FromArgb(60, 85, 115);
            btnTKChiPhi.FlatAppearance.BorderSize = 0;
            btnTKChiPhi.FlatStyle = FlatStyle.Flat;
            btnTKChiPhi.ForeColor = Color.White;
            btnTKChiPhi.Location = new Point(5, 360);
            btnTKChiPhi.Margin = new Padding(3, 5, 3, 5);
            btnTKChiPhi.Name = "btnTKChiPhi";
            btnTKChiPhi.Size = new Size(175, 40);
            btnTKChiPhi.TabIndex = 30;
            btnTKChiPhi.Text = "TK Chi Phí";
            btnTKChiPhi.UseVisualStyleBackColor = false;
            btnTKChiPhi.Click += btnTKChiPhi_Click;
            // 
            // btnTKDoanhThu
            // 
            btnTKDoanhThu.BackColor = Color.FromArgb(60, 85, 115);
            btnTKDoanhThu.FlatAppearance.BorderSize = 0;
            btnTKDoanhThu.FlatStyle = FlatStyle.Flat;
            btnTKDoanhThu.ForeColor = Color.White;
            btnTKDoanhThu.Location = new Point(5, 410);
            btnTKDoanhThu.Margin = new Padding(3, 5, 3, 5);
            btnTKDoanhThu.Name = "btnTKDoanhThu";
            btnTKDoanhThu.Size = new Size(175, 40);
            btnTKDoanhThu.TabIndex = 31;
            btnTKDoanhThu.Text = "TK Doanh Thu";
            btnTKDoanhThu.UseVisualStyleBackColor = false;
            btnTKDoanhThu.Click += btnTKDoanhThu_Click;
            // 
            // btnTroGiup
            // 
            btnTroGiup.BackColor = Color.FromArgb(60, 85, 115);
            btnTroGiup.FlatAppearance.BorderSize = 0;
            btnTroGiup.FlatStyle = FlatStyle.Flat;
            btnTroGiup.ForeColor = Color.White;
            btnTroGiup.Location = new Point(5, 460);
            btnTroGiup.Margin = new Padding(3, 5, 3, 5);
            btnTroGiup.Name = "btnTroGiup";
            btnTroGiup.Size = new Size(175, 40);
            btnTroGiup.TabIndex = 32;
            btnTroGiup.Text = "Báo Cáo";
            btnTroGiup.UseVisualStyleBackColor = false;
            btnTroGiup.Click += btnTroGiup_Click;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.FromArgb(220, 53, 69);
            btnDangXuat.Dock = DockStyle.Bottom;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(10, 475);
            btnDangXuat.Margin = new Padding(15, 15, 15, 10);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(188, 50);
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
            panelContent.Controls.Add(pictureBox1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(208, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1716, 535);
            panelContent.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1716, 535);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
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
            flowLayoutPanelMenu.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanelMenu;
        private StatusStrip statusStrip1;
        public ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel toolStripStatusLabel4;

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
        private PictureBox pictureBox1;
    }
}