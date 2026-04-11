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

        // ==========================================================
        // CÁC HÀM BỔ TRỢ
        // ==========================================================

        // Hàm tự động sinh mã Khách Hàng
        private string GenerateMaKhachHang()
        {
            var dsMaKH = db.KhachHangs.Select(k => k.MaKhachHang).ToList();

            if (dsMaKH.Count == 0)
            {
                return "KH001";
            }

            int maxId = 0;
            foreach (var ma in dsMaKH)
            {
                if (ma.StartsWith("KH") && ma.Length > 2)
                {
                    string soPhanDuoi = ma.Substring(2);
                    if (int.TryParse(soPhanDuoi, out int so))
                    {
                        if (so > maxId)
                        {
                            maxId = so;
                        }
                    }
                }
            }
            return "KH" + (maxId + 1).ToString("D3");
        }

        // Hàm điều khiển trạng thái bật/tắt các nút và ô nhập
        private void BatTatChucNang(bool dangThaoTac)
        {
            btnLuu.Enabled = dangThaoTac;
            btnHuyBo.Enabled = dangThaoTac;

            txtMaKhachHang.Enabled = false; // Luôn khóa vì tự sinh mã

            txtTenKhachHang.Enabled = dangThaoTac;
            txtSoDienThoai.Enabled = dangThaoTac;
            txtCCCD.Enabled = dangThaoTac;
            txtDiaChi.Enabled = dangThaoTac;
            dtpNgayThangNamSinh.Enabled = dangThaoTac;

            btnThem.Enabled = !dangThaoTac;
            btnSua.Enabled = !dangThaoTac;
            btnXoa.Enabled = !dangThaoTac;
            btnThoat.Enabled = !dangThaoTac;
            dgvDanhSachKhachHang.Enabled = !dangThaoTac; // Khóa lưới khi đang nhập để tránh lỗi click nhầm
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

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachKH;

            dgvDanhSachKhachHang.AutoGenerateColumns = false;
            dgvDanhSachKhachHang.DataSource = bindingSource;

            // Cấu hình cột
            if (dgvDanhSachKhachHang.Columns.Contains("Ma")) dgvDanhSachKhachHang.Columns["Ma"].DataPropertyName = "MaKhachHang";
            if (dgvDanhSachKhachHang.Columns.Contains("Ten")) dgvDanhSachKhachHang.Columns["Ten"].DataPropertyName = "TenKhachHang";
            if (dgvDanhSachKhachHang.Columns.Contains("SDT")) dgvDanhSachKhachHang.Columns["SDT"].DataPropertyName = "SoDienThoai";
            if (dgvDanhSachKhachHang.Columns.Contains("NgaySinh")) dgvDanhSachKhachHang.Columns["NgaySinh"].DataPropertyName = "NgayThangNamSinh";
            if (dgvDanhSachKhachHang.Columns.Contains("CCCD")) dgvDanhSachKhachHang.Columns["CCCD"].DataPropertyName = "CCCD";
            if (dgvDanhSachKhachHang.Columns.Contains("DiaChi")) dgvDanhSachKhachHang.Columns["DiaChi"].DataPropertyName = "DiaChi";

            // DataBinding
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

            // Giới hạn độ dài tối đa
            txtSoDienThoai.MaxLength = 10;
            txtCCCD.MaxLength = 12;

            // Gắn sự kiện (hủy đăng ký trước để tránh bị lặp sự kiện nếu Load nhiều lần)
            txtSoDienThoai.KeyPress -= ChiNhapSo_KeyPress;
            txtCCCD.KeyPress -= ChiNhapSo_KeyPress;
            txtSoDienThoai.KeyPress += ChiNhapSo_KeyPress;
            txtCCCD.KeyPress += ChiNhapSo_KeyPress;

            txtSoDienThoai.Leave -= txtSoDienThoai_Leave;
            txtSoDienThoai.Leave += txtSoDienThoai_Leave;
            txtCCCD.Leave -= txtCCCD_Leave;
            txtCCCD.Leave += txtCCCD_Leave;
        }
        private void ChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số, không được nhập chữ hay ký tự đặc biệt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSoDienThoai_Leave(object sender, EventArgs e)
        {
            string sdt = txtSoDienThoai.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt)) return;

            if (sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải bao gồm đúng 10 số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            string maKHCurrent = txtMaKhachHang.Text.Trim();
            bool isTrung = db.KhachHangs.Any(k => k.SoDienThoai == sdt && k.MaKhachHang != maKHCurrent);
            if (isTrung)
            {
                MessageBox.Show("Số điện thoại này đã được sử dụng cho một khách hàng khác!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
            }
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (string.IsNullOrWhiteSpace(cccd)) return;

            if (cccd.Length != 12)
            {
                MessageBox.Show("Căn cước công dân phải bao gồm đúng 12 số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            string maKHCurrent = txtMaKhachHang.Text.Trim();
            bool isTrung = db.KhachHangs.Any(k => k.CCCD == cccd && k.MaKhachHang != maKHCurrent);
            if (isTrung)
            {
                MessageBox.Show("Số CCCD này đã tồn tại trong hệ thống!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            BatTatChucNang(true);

            txtMaKhachHang.Text = GenerateMaKhachHang();

            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtCCCD.Clear();
            txtDiaChi.Clear();

            dtpNgayThangNamSinh.Value = DateTime.Now.AddYears(-18);
            txtTenKhachHang.Focus();
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
            txtTenKhachHang.Focus();
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
            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Lỗi: Mã Khách Hàng trống. Hãy thử bấm Hủy và Thêm lại.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Khách Hàng");
                txtTenKhachHang.Focus();
                return;
            }

            string sdtCheck = txtSoDienThoai.Text.Trim();
            string cccdCheck = txtCCCD.Text.Trim();
            string maKHCurrent = txtMaKhachHang.Text.Trim();

            // 2. Kiểm tra độ dài SDT & CCCD (chốt chặn an toàn)
            if (sdtCheck.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ (phải đủ 10 số)!");
                txtSoDienThoai.Focus();
                return;
            }
            if (cccdCheck.Length != 12)
            {
                MessageBox.Show("CCCD không hợp lệ (phải đủ 12 số)!");
                txtCCCD.Focus();
                return;
            }

            // 3. Kiểm tra trùng (chốt chặn cuối nếu họ bấm Lưu nhanh mà chưa kích hoạt sự kiện Leave)
            if (db.KhachHangs.Any(k => k.SoDienThoai == sdtCheck && k.MaKhachHang != maKHCurrent))
            {
                MessageBox.Show("Số điện thoại này đã được sử dụng cho một khách hàng khác!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (db.KhachHangs.Any(k => k.CCCD == cccdCheck && k.MaKhachHang != maKHCurrent))
            {
                MessageBox.Show("Số CCCD này đã tồn tại trong hệ thống!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            // 4. Kiểm tra Tuổi (>= 18)
            int tuoi = DateTime.Now.Year - dtpNgayThangNamSinh.Value.Year;
            if (dtpNgayThangNamSinh.Value.Date > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 18)
            {
                MessageBox.Show("Khách hàng phải từ đủ 18 tuổi trở lên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayThangNamSinh.Focus();
                return;
            }

            // 5. Lưu dữ liệu
            try
            {
                if (isThem)
                {
                    var checkID = db.KhachHangs.Find(txtMaKhachHang.Text);
                    if (checkID != null)
                    {
                        txtMaKhachHang.Text = GenerateMaKhachHang();
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

                frmKhachHang_Load(sender, e); // Load lại form và khóa control
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
