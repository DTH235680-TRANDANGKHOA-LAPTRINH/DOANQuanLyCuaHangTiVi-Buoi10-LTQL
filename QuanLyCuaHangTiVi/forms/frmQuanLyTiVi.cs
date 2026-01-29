using QuanLyCuaHangTiVi.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangTiVi.DATA;
namespace QuanLyCuaHangTiVi.forms
{
    public partial class frmQuanLyTiVi : Form
    {


        // 1. Khởi tạo Context và biến toàn cục
        AppDbContext context = new AppDbContext();
        bool xuLyThem = false;
        // 2. Hàm Bật/Tắt các nút và ô nhập
        private void BatTatChucNang(bool giaTri)
        {
            // true: Đang nhập liệu (Hiện Lưu/Hủy)
            // false: Đang xem (Hiện Thêm/Sửa/Xóa)

            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            // Các ô nhập liệu
            txtMaTiVi.Enabled = giaTri;
            txtTenTiVi.Enabled = giaTri;
            cboHangSanXuat.Enabled = giaTri;
            dtpNgayNhap.Enabled = giaTri;
            txtDonGiaBan.Enabled = giaTri;
            txtKhuyenMai.Enabled = giaTri;
            txtSoLuongTon.Enabled = giaTri;

            // Các nút chức năng
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
        }
        // Hàm phụ để nạp ComboBox
        private void LoadComboBoxHang()
        {
            cboHangSanXuat.Items.Clear();
            cboHangSanXuat.Items.AddRange(new string[] { "Sony", "Samsung", "LG", "Toshiba", "Panasonic" });
        }
        public frmQuanLyTiVi()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmQuanLyTiVi_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadComboBoxHang(); // Nạp dữ liệu cho ComboBox trước

            // 1. Load dữ liệu từ DB
            var listTiVi = context.QuanLyTiVis.ToList();

            // 2. Tạo BindingSource (Cầu nối dữ liệu)
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = listTiVi;

            // 3. Cấu hình DataGridView
            dgvDanhSachTiVi.AutoGenerateColumns = false;
            dgvDanhSachTiVi.DataSource = bindingSource;

            // Ánh xạ tên cột (DataPropertyName) cho khớp với DB
            // Đảm bảo tên cột trong Design (Name) của bạn là: Ma, Ten, Hang, Gia...
            if (dgvDanhSachTiVi.Columns.Contains("Ma")) dgvDanhSachTiVi.Columns["Ma"].DataPropertyName = "MaTiVi";
            if (dgvDanhSachTiVi.Columns.Contains("Ten")) dgvDanhSachTiVi.Columns["Ten"].DataPropertyName = "TenTiVi";
            if (dgvDanhSachTiVi.Columns.Contains("Hang")) dgvDanhSachTiVi.Columns["Hang"].DataPropertyName = "HangSanXuat";
            if (dgvDanhSachTiVi.Columns.Contains("Nhap")) dgvDanhSachTiVi.Columns["Nhap"].DataPropertyName = "NgayNhap";
            if (dgvDanhSachTiVi.Columns.Contains("Gia")) dgvDanhSachTiVi.Columns["Gia"].DataPropertyName = "DonGiaBan";
            if (dgvDanhSachTiVi.Columns.Contains("KM")) dgvDanhSachTiVi.Columns["KM"].DataPropertyName = "KhuyenMai";
            if (dgvDanhSachTiVi.Columns.Contains("SL")) dgvDanhSachTiVi.Columns["SL"].DataPropertyName = "SoLuongTon";

            // 4. DataBinding: Tự động đổ dữ liệu vào TextBox khi chọn dòng trên lưới
            // Xóa binding cũ để tránh lỗi khi reload
            txtMaTiVi.DataBindings.Clear();
            txtTenTiVi.DataBindings.Clear();
            cboHangSanXuat.DataBindings.Clear();
            dtpNgayNhap.DataBindings.Clear();
            txtDonGiaBan.DataBindings.Clear();
            txtKhuyenMai.DataBindings.Clear();
            txtSoLuongTon.DataBindings.Clear();

            // Thêm binding mới
            txtMaTiVi.DataBindings.Add("Text", bindingSource, "MaTiVi", true, DataSourceUpdateMode.Never);
            txtTenTiVi.DataBindings.Add("Text", bindingSource, "TenTiVi", true, DataSourceUpdateMode.Never);
            cboHangSanXuat.DataBindings.Add("Text", bindingSource, "HangSanXuat", true, DataSourceUpdateMode.Never);
            dtpNgayNhap.DataBindings.Add("Value", bindingSource, "NgayNhap", true, DataSourceUpdateMode.Never);

            // Format số cho đẹp (nếu cần)
            txtDonGiaBan.DataBindings.Add("Text", bindingSource, "DonGiaBan", true, DataSourceUpdateMode.Never);
            txtKhuyenMai.DataBindings.Add("Text", bindingSource, "KhuyenMai", true, DataSourceUpdateMode.Never);
            txtSoLuongTon.DataBindings.Add("Text", bindingSource, "SoLuongTon", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            // Xóa trắng ô nhập để nhập mới
            txtMaTiVi.Clear();
            txtTenTiVi.Clear();
            cboHangSanXuat.SelectedIndex = -1;
            txtDonGiaBan.Text = "0";
            txtKhuyenMai.Text = "0";
            txtSoLuongTon.Text = "0";
            dtpNgayNhap.Value = DateTime.Now;

            txtMaTiVi.Focus();        // Đặt con trỏ vào ô Mã
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Tải lại form để hủy bỏ thao tác
            frmQuanLyTiVi_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachTiVi.CurrentRow != null)
            {
                xuLyThem = false;
                BatTatChucNang(true);
                // Khi sửa thì KHÔNG cho sửa Mã TiVi (Khóa cứng lại)
                txtMaTiVi.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachTiVi.CurrentRow != null)
            {
                string maCanXoa = txtMaTiVi.Text; // Lấy mã từ ô TextBox đang hiển thị binding

                if (MessageBox.Show("Xác nhận xóa TiVi có mã " + maCanXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var tivi = context.QuanLyTiVis.Find(maCanXoa);
                    if (tivi != null)
                    {
                        context.QuanLyTiVis.Remove(tivi);
                        context.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                    }
                    // Tải lại dữ liệu
                    frmQuanLyTiVi_Load(sender, e);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaTiVi.Text) || string.IsNullOrWhiteSpace(txtTenTiVi.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên TiVi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (xuLyThem)
                {
                    // --- THÊM MỚI ---
                    // Kiểm tra trùng mã
                    if (context.QuanLyTiVis.Any(x => x.MaTiVi == txtMaTiVi.Text))
                    {
                        MessageBox.Show("Mã TiVi này đã tồn tại!");
                        return;
                    }

                    QuanLyTiVi tvMoi = new QuanLyTiVi();
                    tvMoi.MaTiVi = txtMaTiVi.Text;
                    tvMoi.TenTiVi = txtTenTiVi.Text;
                    tvMoi.HangSanXuat = cboHangSanXuat.Text;
                    tvMoi.NgayNhap = dtpNgayNhap.Value;
                    tvMoi.DonGiaBan = decimal.Parse(txtDonGiaBan.Text);
                    tvMoi.KhuyenMai = float.Parse(txtKhuyenMai.Text);
                    tvMoi.SoLuongTon = int.Parse(txtSoLuongTon.Text);

                    context.QuanLyTiVis.Add(tvMoi);
                }
                else
                {
                    // --- SỬA ---
                    // Tìm theo Mã (Vì Mã bị khóa nên textbox chứa đúng mã cần sửa)
                    var tvSua = context.QuanLyTiVis.Find(txtMaTiVi.Text);
                    if (tvSua != null)
                    {
                        tvSua.TenTiVi = txtTenTiVi.Text;
                        tvSua.HangSanXuat = cboHangSanXuat.Text;
                        tvSua.NgayNhap = dtpNgayNhap.Value;
                        tvSua.DonGiaBan = decimal.Parse(txtDonGiaBan.Text);
                        tvSua.KhuyenMai = float.Parse(txtKhuyenMai.Text);
                        tvSua.SoLuongTon = int.Parse(txtSoLuongTon.Text);

                        context.QuanLyTiVis.Update(tvSua);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại để cập nhật lưới
                frmQuanLyTiVi_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi định dạng số hoặc dữ liệu: " + ex.Message);
            }
        }
    }
}
    

