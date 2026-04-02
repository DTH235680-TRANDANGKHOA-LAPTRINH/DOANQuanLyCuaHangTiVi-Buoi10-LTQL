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
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvChiTiet);
            groupBox3.Dock = DockStyle.Bottom;
            groupBox3.Location = new Point(0, 213);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1704, 237);
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
            dgvChiTiet.Dock = DockStyle.Bottom;
            dgvChiTiet.Location = new Point(3, 36);
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersWidth = 62;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(1698, 198);
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
            btnThoat.Location = new Point(993, 90);
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
            btnThuTien.Location = new Point(481, 90);
            btnThuTien.Name = "btnThuTien";
            btnThuTien.Size = new Size(196, 60);
            btnThuTien.TabIndex = 40;
            btnThuTien.Text = "Thu Tiền Kỳ Này";
            btnThuTien.UseVisualStyleBackColor = false;
            btnThuTien.Click += btnThuTien_Click;
            // 
            // frmChiTietTraGop
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            ClientSize = new Size(1704, 450);
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
    }
}