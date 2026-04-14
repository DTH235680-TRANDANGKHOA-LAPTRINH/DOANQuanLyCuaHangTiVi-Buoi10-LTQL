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
    public partial class frmThongKeDoanhThu : Form
    {

        AppDbContext db = new AppDbContext();
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy mốc thời gian người dùng chọn trên giao diện
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;

            try
            {
                // Tạo "bộ lọc" mã hóa đơn trả góp. 
                // Lệnh Select chỉ bốc cột MaHoaDon ra, đưa vào RAM (ToList) để lát nữa đối chiếu, giúp giảm tải cho Database.
                var listMaHoaDonTraGop = db.TraGops.Select(tg => tg.MaHoaDon).ToList();

                // ==========================================
                // 1. TÍNH DOANH THU BÁN ĐỨT (THU TIỀN MẶT 1 LẦN)
                // ==========================================

                // Khởi tạo truy vấn: Lọc chi tiết hóa đơn theo Năm
                var queryHoaDon = db.HoaDonChiTiets.Where(ct => ct.HoaDon.NgayLap.Year == nam);

                // Nếu người dùng chọn tháng cụ thể (> 0), đắp thêm điều kiện lọc theo Tháng
                if (thang > 0)
                    queryHoaDon = queryHoaDon.Where(ct => ct.HoaDon.NgayLap.Month == thang);

                // Kích hoạt truy vấn, tải dữ liệu hóa đơn đã lọc lên bộ nhớ (RAM)
                var dsHoaDon = queryHoaDon.ToList();

                // Tính tổng doanh thu Bán đứt:
                // - Dùng !Contains để LOẠI TRỪ các hóa đơn nằm trong danh sách Trả Góp ở trên.
                // - Tính tiền = (Số lượng * Đơn giá) - Khuyến mãi.
                // - Toán tử ?? 0: Nếu Khuyến mãi bị null (để trống), tự động hiểu là 0 để tránh lỗi văng app.
                decimal thuBanDut = dsHoaDon
                    .Where(ct => !listMaHoaDonTraGop.Contains(ct.HoaDonID))
                    .Sum(ct => (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0));

                // ==========================================
                // 2. TÍNH DOANH THU TRẢ GÓP (DÒNG TIỀN THỰC & CÔNG NỢ)
                // ==========================================

                // Truy vấn bảng Trả Góp theo Năm và Tháng (để lấy khoản Trả Trước)
                var queryTraGop = db.TraGops.Where(tg => tg.HoaDon.NgayLap.Year == nam);
                if (thang > 0)
                    queryTraGop = queryTraGop.Where(tg => tg.HoaDon.NgayLap.Month == thang);

                // 2.1 Tính tổng Tiền trả trước (Lúc làm hợp đồng)
                decimal thuTraTruoc = queryTraGop.Any() ? queryTraGop.Sum(tg => tg.SoTienTraTruoc) : 0;

                // Truy vấn bảng Chi Tiết Trả Góp theo Năm và Tháng (để lấy tiền đóng theo kỳ)
                var queryChiTietTraGop = db.ChiTietTraGops.Where(ct => ct.NgayCanDong.Year == nam);
                if (thang > 0)
                    queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Month == thang);

                var dsChiTietTraGop = queryChiTietTraGop.ToList();

                // 2.2 Tiền đã thu trong kỳ = Trả trước + Tổng tiền thực tế khách đã đóng các kỳ
                decimal thuTraGopDaDong = thuTraTruoc + (dsChiTietTraGop.Any() ? dsChiTietTraGop.Sum(ct => ct.SoTienDaDong) : 0);

                // 2.3 Tiền chưa thu (Công nợ) = (Tổng tiền cần đóng + Phạt) - Tiền đã đóng
                // Dùng Math.Max(0, ...) để khóa đáy, nếu khách đóng dư tiền thì công nợ trả về 0 chứ không bị âm tiền.
                decimal thuTraGopChuaDong = dsChiTietTraGop.Any()
                    ? dsChiTietTraGop.Sum(ct => Math.Max(0, (ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong))
                    : 0;

                // ==========================================
                // 3. TỔNG KẾT VÀ HIỂN THỊ LÊN TEXTBOX
                // ==========================================

                // Tổng tiền thực tế đã cầm trên tay = Tiền bán đứt + Tiền trả góp khách đã đóng
                decimal tongDoanhThuThucTe = thuBanDut + thuTraGopDaDong;

                // Hiển thị lên UI, dùng format "N0" để thêm dấu phẩy ngăn cách hàng nghìn (VD: 15,000,000)
                txtThuHoaDon.Text = thuBanDut.ToString("N0");
                txtThuTraGopDaDong.Text = thuTraGopDaDong.ToString("N0");
                txtThuTraGopChuaDong.Text = thuTraGopChuaDong.ToString("N0");
                txtTongDoanhThu.Text = tongDoanhThuThucTe.ToString("N0");

                // ==========================================
                // 4. ĐỔ DỮ LIỆU LÊN DATAGRIDVIEW (KÈM CỘT HÌNH THỨC)
                // ==========================================

                // Tối ưu hiệu năng: Kéo mã và tên Tivi lên RAM thành Dictionary (Cấu trúc Key-Value).
                // Giúp tốc độ tra cứu tên Tivi đạt O(1) thay vì dùng lệnh JOIN SQL phức tạp gây giật lag.
                var dictTenTiVi = db.QuanLyTiVis.ToDictionary(tv => tv.MaTiVi, tv => tv.TenTiVi);

                // Tạo danh sách (DataSource) mới chứa các thông tin cần hiển thị
                var dsTiviDaBan = dsHoaDon.Select(ct => new
                {
                    MaTiVi = ct.MaTiVi,
                    // Tra cứu tên Tivi từ Dictionary
                    TenTiVi = dictTenTiVi.ContainsKey(ct.MaTiVi) ? dictTenTiVi[ct.MaTiVi] : "Không xác định",
                    KhuyenMai = ct.KhuyenMai ?? 0,
                    SoLuong = ct.SoLuongBan,
                    DonGia = ct.DonGiaBan,
                    ThanhTien = (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0),

                    // Tự động phân loại: Nếu mã hóa đơn nằm trong bộ lọc Trả Góp -> Trả Góp, ngược lại -> Bán Đứt
                    HinhThuc = listMaHoaDonTraGop.Contains(ct.HoaDonID) ? "Trả Góp" : "Bán Đứt"
                }).ToList();

                // Gắn dữ liệu lên DataGridView
                dgvDoanhThu.AutoGenerateColumns = false; // Tắt tự động tạo cột thừa, chỉ nhận cột đã thiết kế
                dgvDoanhThu.DataSource = null;           // Reset data cũ
                dgvDoanhThu.DataSource = dsTiviDaBan;    // Đổ data mới vào
            }
            catch (Exception ex)
            {
                // Bẫy lỗi: Đảm bảo app không bị crash nếu mất kết nối CSDL, hiển thị thông báo lỗi rõ ràng.
                MessageBox.Show("Lỗi thống kê: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            // Set mặc định thời gian hiện tại để tránh thống kê nhầm năm 2000
            nudThang.Value = DateTime.Now.Month;
            nudNam.Value = DateTime.Now.Year;
        }
    }
}
