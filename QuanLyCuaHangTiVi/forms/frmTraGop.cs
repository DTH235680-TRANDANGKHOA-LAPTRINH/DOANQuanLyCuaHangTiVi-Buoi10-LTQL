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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace QuanLyCuaHangTiVi.forms
{
    public partial class frmTraGop : Form
    {

        AppDbContext db = new AppDbContext();
        bool isThem = false;

        // 2. Hàm điều khiển trạng thái các nút và ô nhập
        private void BatTatChucNang(bool dangThaoTac)
        {
            // dangThaoTac = true: Đang nhập liệu (Hiện Lưu/Hủy)
            // dangThaoTac = false: Đang xem (Hiện Thêm/Sửa/Xóa)

            btnLuu.Enabled = dangThaoTac;
            btnHuyBo.Enabled = dangThaoTac;

            // Các ô nhập liệu
            txtMaTraGop.Enabled = dangThaoTac;
            cboMaHoaDon.Enabled = dangThaoTac;
            txtLaiSuat.Enabled = dangThaoTac;
            txtKyHanTra.Enabled = dangThaoTac;
            txtSoTienTraTruoc.Enabled = dangThaoTac;
            txtSoTienConNo.Enabled = dangThaoTac;

            // Các nút chức năng chính
            btnThem.Enabled = !dangThaoTac;
            btnSua.Enabled = !dangThaoTac;
            btnXoa.Enabled = !dangThaoTac;
            btnThoat.Enabled = !dangThaoTac;
        }
        private void TinhSoTienNo()
        {
            try
            {
                // 1. Lấy tổng tiền từ hóa đơn đã chọn
                if (cboMaHoaDon.SelectedValue == null) return;
                int maHD = (int)cboMaHoaDon.SelectedValue;

                // Tìm hóa đơn trong DB để lấy tổng tiền (Giả sử bảng HoaDon có cột TongTien hoặc tính từ ChiTiet)
                var hoaDon = db.HoaDons.Select(hd => new
                {
                    hd.ID,
                    // Nếu bạn có cột TongTien thì dùng luôn, nếu không phải tính từ HoaDonChiTiet
                    TongTien = hd.HoaDonChiTiets.Sum(ct => ct.SoLuongBan * ct.DonGiaBan)
                }).FirstOrDefault(hd => hd.ID == maHD);

                if (hoaDon == null) return;

                // 2. Lấy số tiền trả trước và lãi suất từ TextBox
                decimal tongTien = hoaDon.TongTien;
                decimal traTruoc = 0;
                decimal laiSuat = 0;

                decimal.TryParse(txtSoTienTraTruoc.Text, out traTruoc);
                decimal.TryParse(txtLaiSuat.Text, out laiSuat);

                // 3. Tính toán
                decimal nợGốc = tongTien - traTruoc;
                decimal tienLai = nợGốc * (laiSuat / 100); // Giả sử lãi suất nhập là số nguyên (VD: 10 cho 10%)
                decimal tongNo = nợGốc + tienLai;

                // 4. Hiển thị lên TextBox (định dạng số không có chữ sau dấu phẩy cho đẹp)
                txtSoTienConNo.Text = tongNo.ToString("0");
            }
            catch
            {
                // Bỏ qua lỗi khi đang nhập liệu dở dang
            }
        }
        public frmTraGop()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTraGop_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            // --- 1. TẢI DỮ LIỆU HÓA ĐƠN VÀO COMBOBOX TRƯỚC ---
            var danhSachHoaDon = db.HoaDons.Select(hd => new
            {
                hd.ID,
                // Tạo chuỗi hiển thị đẹp mắt: VD "HD 1 - KH: KH01"
                ThongTinHienThi = "HD " + hd.ID + " - KH: " + hd.MaKhachHang
            }).ToList();

            cboMaHoaDon.DataSource = danhSachHoaDon;
            cboMaHoaDon.DisplayMember = "ThongTinHienThi"; // Cái người dùng nhìn thấy
            cboMaHoaDon.ValueMember = "ID";                // Giá trị thực sự đem đi lưu (Mã hóa đơn)


            // --- 2. TẢI DỮ LIỆU TRẢ GÓP ---
            var danhSachTraGop = db.TraGops.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachTraGop;

            dgvTraGop.AutoGenerateColumns = false;
            dgvTraGop.DataSource = bindingSource;

            // ... (Cấu hình cột cho lưới dgvTraGop giữ nguyên như cũ) ...

            // --- 3. DATABINDING ---
            txtMaTraGop.DataBindings.Clear();
            cboMaHoaDon.DataBindings.Clear(); // Đổi thành cboMaHoaDon
            txtLaiSuat.DataBindings.Clear();
            txtKyHanTra.DataBindings.Clear();
            txtSoTienTraTruoc.DataBindings.Clear();
            txtSoTienConNo.DataBindings.Clear();

            txtMaTraGop.DataBindings.Add("Text", bindingSource, "MaTraGop", true, DataSourceUpdateMode.Never);

            // ✅ SỬA DÒNG NÀY: Binding vào thuộc tính SelectedValue của ComboBox
            cboMaHoaDon.DataBindings.Add("SelectedValue", bindingSource, "MaHoaDon", true, DataSourceUpdateMode.Never);

            txtLaiSuat.DataBindings.Add("Text", bindingSource, "LaiSuat", true, DataSourceUpdateMode.Never);
            txtKyHanTra.DataBindings.Add("Text", bindingSource, "KyHanTra", true, DataSourceUpdateMode.Never);
            txtSoTienTraTruoc.DataBindings.Add("Text", bindingSource, "SoTienTraTruoc", true, DataSourceUpdateMode.Never);
            txtSoTienConNo.DataBindings.Add("Text", bindingSource, "SoTienConNo", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            BatTatChucNang(true);

            // Xóa trắng để nhập mới
            txtMaTraGop.Clear();
            cboMaHoaDon.SelectedIndex = -1;
            txtLaiSuat.Clear();
            txtKyHanTra.Clear();
            txtSoTienTraTruoc.Clear();
            txtSoTienConNo.Clear();

            txtMaTraGop.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTraGop.Text))
            {
                MessageBox.Show("Chưa chọn bản ghi trả góp để sửa!");
                return;
            }

            isThem = false;
            BatTatChucNang(true);
            // Khi sửa thì KHÔNG ĐƯỢC sửa Mã Trả Góp (Khóa lại vì nó là khóa chính)
            txtMaTraGop.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTraGop.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa bản ghi trả góp: " + txtMaTraGop.Text + "?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var tgXoa = db.TraGops.Find(txtMaTraGop.Text);
                    if (tgXoa != null)
                    {
                        db.TraGops.Remove(tgXoa);
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        frmTraGop_Load(sender, e); // Tải lại dữ liệu
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa: " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra rỗng (Validation)
            if (string.IsNullOrWhiteSpace(txtMaTraGop.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Trả Góp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTraGop.Focus();
                return;
            }

            if (cboMaHoaDon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một Hóa Đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHoaDon.Focus();
                return;
            }

            // ==========================================================
            // ĐÂY LÀ ĐOẠN KHAI BÁO BỊ THIẾU TRONG HÌNH CỦA BẠN GÂY LỖI ĐỎ
            decimal laiSuat, soTienTruoc;
            int kyHan;

            if (!decimal.TryParse(txtLaiSuat.Text, out laiSuat) ||
                !decimal.TryParse(txtSoTienTraTruoc.Text, out soTienTruoc) ||
                !int.TryParse(txtKyHanTra.Text, out kyHan))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho Lãi suất, Kỳ hạn và Số tiền trả trước!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ==========================================================

            try
            {
                // 3. TÍNH TOÁN TIỀN NỢ
                int maHD = (int)cboMaHoaDon.SelectedValue;
                var hoaDon = db.HoaDons.Select(hd => new { hd.ID, TongTien = hd.HoaDonChiTiets.Sum(ct => ct.SoLuongBan * ct.DonGiaBan) }).FirstOrDefault(hd => hd.ID == maHD);
                decimal tongTienHoaDon = hoaDon != null ? hoaDon.TongTien : 0;

                decimal noGoc = tongTienHoaDon - soTienTruoc;
                if (noGoc < 0) noGoc = 0; // Đề phòng khách trả trước nhiều hơn cả tiền tivi
                decimal tienLai = noGoc * (laiSuat / 100);
                decimal soTienNoTinhToan = noGoc + tienLai;
                txtSoTienConNo.Text = soTienNoTinhToan.ToString("0"); // Hiển thị lên UI

                if (isThem)
                {
                    var checkTonTai = db.TraGops.Find(txtMaTraGop.Text);
                    if (checkTonTai != null)
                    {
                        MessageBox.Show("Mã trả góp này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // --- LƯU BẢNG GỐC (HỢP ĐỒNG) ---
                    TraGop tgMoi = new TraGop();
                    tgMoi.MaTraGop = txtMaTraGop.Text;
                    tgMoi.MaHoaDon = maHD;
                    tgMoi.LaiSuat = laiSuat;
                    tgMoi.KyHanTra = kyHan;
                    tgMoi.SoTienTraTruoc = soTienTruoc;
                    tgMoi.SoTienConNo = soTienNoTinhToan;
                    db.TraGops.Add(tgMoi);

                    // --- LƯU TỰ ĐỘNG CÁC THÁNG VÀO BẢNG CHI TIẾT ---
                    decimal gocMoiThang = noGoc / kyHan;
                    decimal laiMoiThang = tienLai / kyHan;
                    decimal tongMoiThang = soTienNoTinhToan / kyHan;
                    DateTime ngayBatDau = DateTime.Now;

                    for (int i = 1; i <= kyHan; i++)
                    {
                        ChiTietTraGop chiTiet = new ChiTietTraGop();
                        chiTiet.MaTraGop = tgMoi.MaTraGop;
                        chiTiet.KyThu = i;
                        chiTiet.NgayCanDong = ngayBatDau.AddMonths(i); // Mỗi kỳ cách nhau 1 tháng
                        chiTiet.SoTienGoc = Math.Round(gocMoiThang, 0);
                        chiTiet.SoTienLai = Math.Round(laiMoiThang, 0);
                        chiTiet.TongTienDong = Math.Round(tongMoiThang, 0);
                        chiTiet.DaThanhToan = false; // Mới tạo thì chưa đóng tiền

                        db.ChiTietTraGops.Add(chiTiet);
                    }
                }
                else
                {
                    // --- TRƯỜNG HỢP SỬA ---
                    var tgSua = db.TraGops.Find(txtMaTraGop.Text);
                    if (tgSua != null)
                    {
                        tgSua.MaHoaDon = maHD;
                        tgSua.LaiSuat = laiSuat;
                        tgSua.KyHanTra = kyHan;
                        tgSua.SoTienTraTruoc = soTienTruoc;
                        tgSua.SoTienConNo = soTienNoTinhToan;
                    }
                }

                db.SaveChanges(); // Lưu tất cả vào Database cùng 1 lúc
                MessageBox.Show("Lưu thành công! Hệ thống đã tự động tính toán và cập nhật dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTraGop_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Hủy thao tác bằng cách load lại dữ liệu ban đầu
            frmTraGop_Load(sender, e);
        }

        private void txtSoTienTraTruoc_TextChanged(object sender, EventArgs e)
        {
            TinhSoTienNo();
        }

        private void txtLaiSuat_TextChanged(object sender, EventArgs e)
        {
            TinhSoTienNo();
        }

        private void cboMaHoaDon_TextChanged(object sender, EventArgs e)
        {
            TinhSoTienNo();
        }

        private void btnXemLichTrinh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTraGop.Text) || btnLuu.Enabled == true)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng hợp lệ trên lưới để xem chi tiết (Không thao tác khi đang thêm mới).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở Form chi tiết và truyền Mã hợp đồng sang
            frmChiTietTraGop frm = new frmChiTietTraGop(txtMaTraGop.Text);
            frm.ShowDialog();
        }
    }
}
