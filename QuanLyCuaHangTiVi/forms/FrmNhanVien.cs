using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangTiVi.DATA; // Đảm bảo dùng đúng namespace chứa Model


namespace QuanLyCuaHangTiVi.forms
{
    public partial class FrmNhanVien : Form
    {
        AppDbContext db = new AppDbContext();
        bool isThem = false;
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        // 2. Hàm điều khiển trạng thái các nút và ô nhập
        private void BatTatChucNang(bool dangThaoTac)
        {
            // dangThaoTac = true: Đang nhập liệu (Hiện Lưu/Hủy)
            // dangThaoTac = false: Đang xem (Hiện Thêm/Sửa/Xóa)

            btnLuu.Enabled = dangThaoTac;
            btnHuyBo.Enabled = dangThaoTac;

            // Các ô nhập liệu (Riêng mã nhân viên chỉ được nhập khi Thêm)
            txtMaNhanVien.Enabled = dangThaoTac && isThem;
            txtHoTenNhanVien.Enabled = dangThaoTac;
            txtTenDangNhap.Enabled = dangThaoTac;
            txtMatKhau.Enabled = dangThaoTac;
            cboQuyenHan.Enabled = dangThaoTac;

            // Các nút chức năng chính
            btnThem.Enabled = !dangThaoTac;
            btnSua.Enabled = !dangThaoTac;
            btnXoa.Enabled = !dangThaoTac;
            btnThoat.Enabled = !dangThaoTac;
        }
        private void txtDonGiaBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            // Tải dữ liệu từ CSDL
            var danhSachNV = db.NhanViens.ToList();

            // Tạo BindingSource
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachNV;

            // Gán dữ liệu cho DataGridView
            dgvDanhSachNhanVien.AutoGenerateColumns = false;
            dgvDanhSachNhanVien.DataSource = bindingSource;

            // --- CẤU HÌNH CỘT CHO LƯỚI ---
            // (Bạn nhớ kiểm tra Property Name của các cột trong giao diện Design nhé)
            if (dgvDanhSachNhanVien.Columns.Contains("MaNhanVien")) dgvDanhSachNhanVien.Columns["MaNhanVien"].DataPropertyName = "MaNhanVien";
            if (dgvDanhSachNhanVien.Columns.Contains("HoTen")) dgvDanhSachNhanVien.Columns["HoTen"].DataPropertyName = "HoTenNhanVien";
            if (dgvDanhSachNhanVien.Columns.Contains("TenDangNhap")) dgvDanhSachNhanVien.Columns["TenDangNhap"].DataPropertyName = "TenDangNhap";
            if (dgvDanhSachNhanVien.Columns.Contains("QuyenHan")) dgvDanhSachNhanVien.Columns["QuyenHan"].DataPropertyName = "QuyenHan";
            // Không map cột Mật Khẩu để tránh lộ mã băm (hash) lên lưới

            // --- DATABINDING (Tự đổ dữ liệu vào TextBox) ---
            txtMaNhanVien.DataBindings.Clear();
            txtHoTenNhanVien.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Clear();
            cboQuyenHan.DataBindings.Clear();

            txtMaNhanVien.DataBindings.Add("Text", bindingSource, "MaNhanVien", true, DataSourceUpdateMode.Never);
            txtHoTenNhanVien.DataBindings.Add("Text", bindingSource, "HoTenNhanVien", true, DataSourceUpdateMode.Never);
            txtTenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", true, DataSourceUpdateMode.Never);
            cboQuyenHan.DataBindings.Add("Text", bindingSource, "QuyenHan", true, DataSourceUpdateMode.Never);

            // Cố tình làm rỗng ô mật khẩu khi click vào các dòng (vì nó đã mã hóa, hiển thị ra cũng không đọc được)
            txtMatKhau.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            BatTatChucNang(true);

            // Xóa trắng để nhập mới
            txtMaNhanVien.Clear();
            txtHoTenNhanVien.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.SelectedIndex = -1; // Chọn rỗng ComboBox

            txtMaNhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                MessageBox.Show("Chưa chọn nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isThem = false;
            BatTatChucNang(true);
            txtMatKhau.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên: " + txtHoTenNhanVien.Text + "?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var nvXoa = db.NhanViens.Find(txtMaNhanVien.Text);
                    if (nvXoa != null)
                    {
                        db.NhanViens.Remove(nvXoa);
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        FrmNhanVien_Load(sender, e); // Tải lại dữ liệu
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (có thể do nhân viên đã lập hóa đơn/phiếu nhập): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtHoTenNhanVien.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenNhanVien.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Đăng Nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            try
            {
                if (isThem)
                {
                    // --- THÊM MỚI ---
                    var checkID = db.NhanViens.Find(txtMaNhanVien.Text);
                    if (checkID != null)
                    {
                        MessageBox.Show("Mã nhân viên này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        MessageBox.Show("Vui lòng nhập Mật Khẩu cho nhân viên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMatKhau.Focus();
                        return;
                    }

                    NhanVien nv = new NhanVien();
                    nv.MaNhanVien = txtMaNhanVien.Text;
                    nv.HoTenNhanVien = txtHoTenNhanVien.Text;
                    nv.TenDangNhap = txtTenDangNhap.Text;
                    nv.MatKhau = txtMatKhau.Text; // Lưu mật khẩu thường, không mã hóa nữa
                    nv.QuyenHan = cboQuyenHan.Text;

                    db.NhanViens.Add(nv);
                }
                else
                {
                    // --- SỬA ---
                    var nvSua = db.NhanViens.Find(txtMaNhanVien.Text);
                    if (nvSua == null)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để sửa!");
                        return;
                    }

                    nvSua.HoTenNhanVien = txtHoTenNhanVien.Text;
                    nvSua.TenDangNhap = txtTenDangNhap.Text;
                    nvSua.QuyenHan = cboQuyenHan.Text;

                    // Chỉ đổi mật khẩu nếu người dùng nhập vào ô TextBox
                    if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        nvSua.MatKhau = txtMatKhau.Text;
                    }
                }

                db.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset lại form
                FrmNhanVien_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Load lại dữ liệu ban đầu
            FrmNhanVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
