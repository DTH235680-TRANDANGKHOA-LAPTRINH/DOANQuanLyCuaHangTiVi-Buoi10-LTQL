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
using QuanLyCuaHangTiVi.DATA; // Namespace chứa AppDbContext và class KhachHang
namespace QuanLyCuaHangTiVi.forms
{
    public partial class frmKhachHang : Form
    {
        // 1. Khai báo Context và biến cờ
        AppDbContext db = new AppDbContext();
        bool isThem = false; // true = Đang thêm, false = Đang sửa

        // 2. Hàm điều khiển trạng thái các nút và ô nhập
        private void BatTatChucNang(bool dangThaoTac)
        {
            btnLuu.Enabled = dangThaoTac;
            btnHuyBo.Enabled = dangThaoTac;

            txtMaKhachHang.Enabled = dangThaoTac;
            txtTenKhachHang.Enabled = dangThaoTac;
            txtSoDienThoai.Enabled = dangThaoTac;
            txtCCCD.Enabled = dangThaoTac;
            txtDiaChi.Enabled = dangThaoTac;
            dtpNgayThangNamSinh.Enabled = dangThaoTac;

            btnThem.Enabled = !dangThaoTac;
            btnSua.Enabled = !dangThaoTac;
            btnXoa.Enabled = !dangThaoTac;
            btnThoat.Enabled = !dangThaoTac;
        }
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            // Tải dữ liệu từ CSDL
            var danhSachKH = db.KhachHangs.ToList();

            // Tạo BindingSource
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachKH;

            // Gán dữ liệu cho DataGridView
            dgvDanhSachKhachHang.AutoGenerateColumns = false;
            dgvDanhSachKhachHang.DataSource = bindingSource;

            // --- CẤU HÌNH CỘT CHO LƯỚI ---
            if (dgvDanhSachKhachHang.Columns.Contains("Ma")) dgvDanhSachKhachHang.Columns["Ma"].DataPropertyName = "MaKhachHang";
            if (dgvDanhSachKhachHang.Columns.Contains("Ten")) dgvDanhSachKhachHang.Columns["Ten"].DataPropertyName = "TenKhachHang";
            if (dgvDanhSachKhachHang.Columns.Contains("SDT")) dgvDanhSachKhachHang.Columns["SDT"].DataPropertyName = "SoDienThoai";
            if (dgvDanhSachKhachHang.Columns.Contains("NgaySinh")) dgvDanhSachKhachHang.Columns["NgaySinh"].DataPropertyName = "NgayThangNamSinh";
            if (dgvDanhSachKhachHang.Columns.Contains("CCCD")) dgvDanhSachKhachHang.Columns["CCCD"].DataPropertyName = "CCCD";
            if (dgvDanhSachKhachHang.Columns.Contains("DiaChi")) dgvDanhSachKhachHang.Columns["DiaChi"].DataPropertyName = "DiaChi";

            // --- DATABINDING ---
            txtMaKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Clear();
            txtCCCD.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            dtpNgayThangNamSinh.DataBindings.Clear();

            txtMaKhachHang.DataBindings.Add("Text", bindingSource, "MaKhachHang", true, DataSourceUpdateMode.Never);
            txtTenKhachHang.DataBindings.Add("Text", bindingSource, "TenKhachHang", true, DataSourceUpdateMode.Never);
            txtSoDienThoai.DataBindings.Add("Text", bindingSource, "SoDienThoai", true, DataSourceUpdateMode.Never);
            txtCCCD.DataBindings.Add("Text", bindingSource, "CCCD", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", true, DataSourceUpdateMode.Never);
            dtpNgayThangNamSinh.DataBindings.Add("Value", bindingSource, "NgayThangNamSinh", true, DataSourceUpdateMode.Never);

            // 1. Giới hạn độ dài tối đa
            txtSoDienThoai.MaxLength = 10;
            txtCCCD.MaxLength = 12;

            // 2. Gắn sự kiện chặn chữ (đã có)
            txtSoDienThoai.KeyPress -= ChiNhapSo_KeyPress;
            txtCCCD.KeyPress -= ChiNhapSo_KeyPress;
            txtSoDienThoai.KeyPress += ChiNhapSo_KeyPress;
            txtCCCD.KeyPress += ChiNhapSo_KeyPress;

            // 3. Gắn sự kiện kiểm tra độ dài khi rời ô (đã có)
            txtSoDienThoai.Leave -= txtSoDienThoai_Leave;
            txtSoDienThoai.Leave += txtSoDienThoai_Leave;
            txtCCCD.Leave -= txtCCCD_Leave;
            txtCCCD.Leave += txtCCCD_Leave;

            // --- ĐÂY LÀ PHẦN THÊM MỚI (KIỂM TRA TRÙNG MÃ GIỐNG TIVI) ---
            txtMaKhachHang.Leave -= txtMaKhachHang_Leave;
            txtMaKhachHang.Leave += txtMaKhachHang_Leave;
        }
        private void ChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (như Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số, không được nhập chữ hay ký tự đặc biệt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Bạn cũng cần thêm hàm xử lý này ở bên ngoài hàm Load
        private void txtMaKhachHang_Leave(object sender, EventArgs e)
        {
            // isThem là biến bool bạn dùng để xác định đang nhấn nút Thêm
            if (isThem && !string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                string maCheck = txtMaKhachHang.Text.Trim();
                bool biTrung = db.KhachHangs.Any(x => x.MaKhachHang == maCheck);

                if (biTrung)
                {
                    MessageBox.Show($"Mã khách hàng '{maCheck}' đã tồn tại! Vui lòng nhập mã khác.",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKhachHang.Clear();
                    txtMaKhachHang.Focus();
                }
            }
        }
        private void txtSoDienThoai_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSoDienThoai.Text) && txtSoDienThoai.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải bao gồm đúng 10 số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
            }
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCCCD.Text) && txtCCCD.Text.Length != 12)
            {
                MessageBox.Show("Căn cước công dân phải bao gồm đúng 12 số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            BatTatChucNang(true);

            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtCCCD.Clear();
            txtDiaChi.Clear();

            // Mặc định lùi lại 18 năm để đủ tuổi
            dtpNgayThangNamSinh.Value = DateTime.Now.AddYears(-18);

            txtMaKhachHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhachHang.Text))
            {
                MessageBox.Show("Chưa chọn khách hàng để sửa!");
                return;
            }

            isThem = false;
            BatTatChucNang(true);
            txtMaKhachHang.Enabled = false; // Khóa mã KH khi sửa
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhachHang.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng: " + txtTenKhachHang.Text + "?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var khXoa = db.KhachHangs.Find(txtMaKhachHang.Text);
                    if (khXoa != null)
                    {
                        db.KhachHangs.Remove(khXoa);
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        frmKhachHang_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (có thể do khách hàng đã có hóa đơn): " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Dữ liệu rỗng
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Khách Hàng");
                txtMaKhachHang.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Khách Hàng");
                txtTenKhachHang.Focus();
                return;
            }

            // 2. Kiểm tra độ dài SDT & CCCD (chốt chặn an toàn)
            if (txtSoDienThoai.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ (phải đủ 10 số)!");
                txtSoDienThoai.Focus();
                return;
            }
            if (txtCCCD.Text.Length != 12)
            {
                MessageBox.Show("CCCD không hợp lệ (phải đủ 12 số)!");
                txtCCCD.Focus();
                return;
            }

            // 3. Kiểm tra Tuổi (>= 18)
            int tuoi = DateTime.Now.Year - dtpNgayThangNamSinh.Value.Year;
            if (dtpNgayThangNamSinh.Value.Date > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 18)
            {
                MessageBox.Show("Khách hàng phải từ đủ 18 tuổi trở lên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayThangNamSinh.Focus();
                return;
            }

            // 4. Lưu dữ liệu
            try
            {
                if (isThem)
                {
                    var checkID = db.KhachHangs.Find(txtMaKhachHang.Text);
                    if (checkID != null)
                    {
                        MessageBox.Show("Mã khách hàng này đã tồn tại!");
                        return;
                    }

                    KhachHang kh = new KhachHang();
                    kh.MaKhachHang = txtMaKhachHang.Text;
                    kh.TenKhachHang = txtTenKhachHang.Text;
                    kh.SoDienThoai = txtSoDienThoai.Text;
                    kh.CCCD = txtCCCD.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    kh.NgayThangNamSinh = dtpNgayThangNamSinh.Value;

                    db.KhachHangs.Add(kh);
                }
                else
                {
                    var khSua = db.KhachHangs.Find(txtMaKhachHang.Text);
                    if (khSua == null)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để sửa!");
                        return;
                    }

                    khSua.TenKhachHang = txtTenKhachHang.Text;
                    khSua.SoDienThoai = txtSoDienThoai.Text;
                    khSua.CCCD = txtCCCD.Text;
                    khSua.DiaChi = txtDiaChi.Text;
                    khSua.NgayThangNamSinh = dtpNgayThangNamSinh.Value;
                }

                db.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!");

                frmKhachHang_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Hủy thao tác bằng cách load lại dữ liệu ban đầu
            frmKhachHang_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
