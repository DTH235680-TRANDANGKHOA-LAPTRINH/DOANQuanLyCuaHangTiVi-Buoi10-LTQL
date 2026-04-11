using Microsoft.EntityFrameworkCore;
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

namespace QuanLyCuaHangTiVi.forms
{
    public partial class FrmBaoCao : Form
    {

        AppDbContext db = new AppDbContext();
        public FrmBaoCao()
        {
            InitializeComponent();
        }

        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            nudThang.Value = DateTime.Now.Month;
            nudNam.Value = DateTime.Now.Year;

            txtTongDoanhThu.ReadOnly = true;
            txtTongChiPhi.ReadOnly = true;
            txtLoiNhuan.ReadOnly = true;

            LoadBaoCao();
        }
        private void LoadBaoCao()
        {
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;

            try
            {
                // ==========================================
                // 1. TÍNH DOANH THU (Đã đồng bộ logic với frmThongKeDoanhThu)
                // ==========================================
                var listMaHoaDonTraGop = db.TraGops.Select(tg => tg.MaHoaDon).ToList();

                var queryHoaDon = db.HoaDonChiTiets
                                    .Include(ct => ct.HoaDon)
                                    .Where(ct => ct.HoaDon.NgayLap.Year == nam);

                if (thang > 0)
                    queryHoaDon = queryHoaDon.Where(ct => ct.HoaDon.NgayLap.Month == thang);

                var dsHoaDon = queryHoaDon.ToList();

                // 1.1 Doanh thu bán đứt
                decimal thuBanDut = dsHoaDon
                    .Where(ct => !listMaHoaDonTraGop.Contains(ct.HoaDonID))
                    .Sum(ct => (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0));

                // 1.2 Doanh thu trả góp
                var queryTraGop = db.TraGops.Where(tg => tg.HoaDon.NgayLap.Year == nam);
                if (thang > 0) queryTraGop = queryTraGop.Where(tg => tg.HoaDon.NgayLap.Month == thang);

                decimal thuTraTruoc = queryTraGop.Any() ? queryTraGop.Sum(tg => tg.SoTienTraTruoc) : 0;

                var queryChiTietTraGop = db.ChiTietTraGops.Where(ct => ct.NgayCanDong.Year == nam);
                if (thang > 0) queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Month == thang);

                var dsChiTietTraGop = queryChiTietTraGop.ToList();
                decimal thuTraGopDaDong = thuTraTruoc + (dsChiTietTraGop.Any() ? dsChiTietTraGop.Sum(ct => ct.SoTienDaDong) : 0);

                // 1.3 Tổng hợp doanh thu thực tế
                decimal tongDoanhThu = thuBanDut + thuTraGopDaDong;
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";

                // 2. TÍNH CHI PHÍ
                // 2.1 Giá vốn hàng bán (Lấy từ bảng ChiTietPhieuNhap)
                decimal tongGiaVon = 0;
                foreach (var ct in dsHoaDon)
                {
                    var giaNhapHienTai = db.ChiTietPhieuNhaps
                                          .Where(pn => pn.MaTiVi == ct.MaTiVi)
                                          .OrderByDescending(pn => pn.MaCTPN)
                                          .Select(pn => pn.DonGiaNhap)
                                          .FirstOrDefault();
                    tongGiaVon += (decimal)ct.SoLuongBan * giaNhapHienTai;
                }

                // 2.2 Tiền lương (Tính theo số tháng thực tế có hoạt động)
                decimal luongThang = db.NhanViens.Sum(nv => (decimal?)nv.Luong) ?? 0;
                decimal tongLuong = 0;

                if (thang == 0) // Cả năm
                {
                    // Lấy các tháng có phát sinh hóa đơn bán hàng
                    var cacThangBanHang = db.HoaDonChiTiets
                                            .Where(ct => ct.HoaDon.NgayLap.Year == nam)
                                            .Select(ct => ct.HoaDon.NgayLap.Month)
                                            .ToList();

                    // Lấy các tháng có lưu chi phí vận hành
                    var cacThangCoChiPhi = db.ChiPhiVanHanhs
                                             .Where(cp => cp.Nam == nam)
                                             .Select(cp => cp.Thang)
                                             .ToList();

                    // Gộp lại và đếm số tháng duy nhất có hoạt động
                    int soThangHoatDong = cacThangBanHang.Concat(cacThangCoChiPhi).Distinct().Count();
                    if (soThangHoatDong == 0) soThangHoatDong = 1;

                    tongLuong = luongThang * soThangHoatDong;
                }
                else // Từng tháng
                {
                    tongLuong = luongThang;
                }

                // 2.3 Vận hành (Fix lỗi LINQ bằng AsEnumerable)
                var queryVanHanh = db.ChiPhiVanHanhs.Where(cp => cp.Nam == nam);
                if (thang > 0) queryVanHanh = queryVanHanh.Where(cp => cp.Thang == thang);

                decimal tongVanHanh = queryVanHanh.AsEnumerable()
                                                 .Sum(cp => (decimal?)cp.TongChiPhiVanHanh) ?? 0;

                decimal tongChiPhi = tongGiaVon + tongLuong + tongVanHanh;
                txtTongChiPhi.Text = tongChiPhi.ToString("N0") + " VNĐ";

                // 3. TÍNH LỢI NHUẬN
                decimal loiNhuan = tongDoanhThu - tongChiPhi;
                txtLoiNhuan.Text = loiNhuan.ToString("N0") + " VNĐ";
                txtLoiNhuan.ForeColor = (loiNhuan >= 0) ? Color.Green : Color.Red;

                LoadDanhSachTraGop(thang, nam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadDanhSachTraGop(int thang, int nam)
        {
            try
            {
                // 1. Lấy danh sách chi tiết trả góp theo năm
                var queryChiTietTraGop = db.ChiTietTraGops.Where(ct => ct.NgayCanDong.Year == nam);

                // Lọc thêm theo tháng nếu người dùng chọn tháng cụ thể (> 0)
                if (thang > 0)
                {
                    queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Month == thang);
                }

                // 2. Chuyển đổi dữ liệu và tính toán trạng thái
                var dsCanThuTien = queryChiTietTraGop.ToList().Select(ct => new
                {
                    MaTraGop = ct.MaTraGop,
                    NgayCanDong = ct.NgayCanDong.ToString("dd/MM/yyyy"), // Format lại ngày cho đẹp
                    TongTienCanDong = ct.TongTienDong + ct.SoTienPhat,
                    SoTienDaDong = ct.SoTienDaDong,
                    TienConNo = (ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong,

                    // XÁC ĐỊNH TRẠNG THÁI
                    TrangThai = ((ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong > 0 && ct.NgayCanDong.Date < DateTime.Now.Date)
                                ? "QUÁ HẠN"
                                : (((ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong <= 0) ? "ĐÃ ĐÓNG" : "CHƯA ĐÓNG")
                }).ToList();

                // 3. FIX LỖI HIỂN THỊ LÊN DATAGRIDVIEW
                dgvCanThuTien.DataSource = null;           // Xóa binding cũ
                dgvCanThuTien.Columns.Clear();             // XÓA các cột sai ngoài Design (Tên TiVi, Ngày Nhập...)
                dgvCanThuTien.AutoGenerateColumns = true;  // BẬT tự động tạo cột theo dữ liệu mới

                dgvCanThuTien.DataSource = dsCanThuTien;   // Đổ dữ liệu mới vào

                // 4. (Tùy chọn) Đổi lại tên Header cho hiển thị đẹp mắt (Tiếng Việt)
                if (dgvCanThuTien.Columns.Count > 0)
                {
                    dgvCanThuTien.Columns["MaTraGop"].HeaderText = "Mã Trả Góp";
                    dgvCanThuTien.Columns["NgayCanDong"].HeaderText = "Hạn Đóng";
                    dgvCanThuTien.Columns["TongTienCanDong"].HeaderText = "Tổng Cần Đóng (VNĐ)";
                    dgvCanThuTien.Columns["SoTienDaDong"].HeaderText = "Đã Đóng (VNĐ)";
                    dgvCanThuTien.Columns["TienConNo"].HeaderText = "Còn Nợ (VNĐ)";
                    dgvCanThuTien.Columns["TrangThai"].HeaderText = "Trạng Thái";

                    // Format số tiền có dấu phẩy
                    dgvCanThuTien.Columns["TongTienCanDong"].DefaultCellStyle.Format = "N0";
                    dgvCanThuTien.Columns["SoTienDaDong"].DefaultCellStyle.Format = "N0";
                    dgvCanThuTien.Columns["TienConNo"].DefaultCellStyle.Format = "N0";

                    // Chỉnh cột cho dàn đều ra
                    dgvCanThuTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách cần thu tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadBaoCao();
        }

        private void btnChiTietDoanhThu_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frmDT = new frmThongKeDoanhThu();
            frmDT.ShowDialog();
        }

        private void btnChiTietChiPhi_Click(object sender, EventArgs e)
        {
            frmThongkeChiPhi frmCP = new frmThongkeChiPhi();
            frmCP.ShowDialog();
        }
        private void dgvCanThuTien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCanThuTien.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                if (e.Value.ToString() == "QUÁ HẠN")
                {
                    dgvCanThuTien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    dgvCanThuTien.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        
    }
}
