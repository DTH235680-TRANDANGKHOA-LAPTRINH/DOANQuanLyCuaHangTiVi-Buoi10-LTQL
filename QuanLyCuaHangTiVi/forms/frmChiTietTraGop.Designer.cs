namespace QuanLyCuaHangTiVi.forms
{
    partial class frmChiTietTraGop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietTraGop));
            groupBox3 = new GroupBox();
            dgvChiTiet = new DataGridView();
            lblTieuDe = new Label();
            btnThoat = new Button();
            btnThuTien = new Button();
            dtpNgayNop = new DateTimePicker();
            label1 = new Label();
            txtNguoiNop = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtSoTienNop = new TextBox();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvChiTiet);
            groupBox3.Dock = DockStyle.Bottom;
            groupBox3.Location = new Point(0, 162);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1704, 288);
            groupBox3.TabIndex = 4;
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
            dgvChiTiet.Size = new Size(1698, 258);
            dgvChiTiet.TabIndex = 3;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.ForeColor = Color.FromArgb(64, 64, 64);
            lblTieuDe.Location = new Point(624, 31);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(300, 25);
            lblTieuDe.TabIndex = 5;
            lblTieuDe.Text = "LỊCH TRÌNH THANH TOÁN TRẢ GÓP";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(255, 128, 128);
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(288, 85);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(147, 60);
            btnThoat.TabIndex = 41;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnThuTien
            // 
            btnThuTien.BackColor = Color.Cyan;
            btnThuTien.Image = (Image)resources.GetObject("btnThuTien.Image");
            btnThuTien.ImageAlign = ContentAlignment.MiddleLeft;
            btnThuTien.Location = new Point(38, 85);
            btnThuTien.Name = "btnThuTien";
            btnThuTien.Size = new Size(196, 60);
            btnThuTien.TabIndex = 40;
            btnThuTien.Text = "Thu Tiền Kỳ Này";
            btnThuTien.UseVisualStyleBackColor = false;
            btnThuTien.Click += btnThuTien_Click;
            // 
            // dtpNgayNop
            // 
            dtpNgayNop.Location = new Point(635, 77);
            dtpNgayNop.Name = "dtpNgayNop";
            dtpNgayNop.Size = new Size(300, 31);
            dtpNgayNop.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(441, 85);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 43;
            label1.Text = "Ngày Nộp";
            // 
            // txtNguoiNop
            // 
            txtNguoiNop.Location = new Point(1424, 65);
            txtNguoiNop.Name = "txtNguoiNop";
            txtNguoiNop.Size = new Size(150, 31);
            txtNguoiNop.TabIndex = 44;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1318, 73);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 45;
            label2.Text = "Người Nộp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(988, 71);
            label3.Name = "label3";
            label3.Size = new Size(110, 25);
            label3.TabIndex = 47;
            label3.Text = "Số Tiền Nộp";
            // 
            // txtSoTienNop
            // 
            txtSoTienNop.Location = new Point(1120, 65);
            txtSoTienNop.Name = "txtSoTienNop";
            txtSoTienNop.Size = new Size(150, 31);
            txtSoTienNop.TabIndex = 46;
            // 
            // frmChiTietTraGop
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            ClientSize = new Size(1704, 450);
            Controls.Add(label3);
            Controls.Add(txtSoTienNop);
            Controls.Add(label2);
            Controls.Add(txtNguoiNop);
            Controls.Add(label1);
            Controls.Add(dtpNgayNop);
            Controls.Add(btnThoat);
            Controls.Add(btnThuTien);
            Controls.Add(lblTieuDe);
            Controls.Add(groupBox3);
            Name = "frmChiTietTraGop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi Tiết Trả Góp";
            Load += frmChiTietTraGop_Load;
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox3;
        private DataGridView dgvChiTiet;
        private Label lblTieuDe;
        private Button btnThoat;
        private Button btnThuTien;
        private DateTimePicker dtpNgayNop;
        private Label label1;
        private TextBox txtNguoiNop;
        private Label label2;
        private Label label3;
        private TextBox txtSoTienNop;
    }
}