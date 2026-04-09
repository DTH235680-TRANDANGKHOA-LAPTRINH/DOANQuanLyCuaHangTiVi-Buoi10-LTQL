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
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;

            try
            {
                // Lấy danh sách Hóa Đơn ID thuộc diện Trả Góp để phân loại
                var listMaHoaDonTraGop = db.TraGops.Select(tg => tg.MaHoaDon).ToList();

                // ==========================================
                // 1. TÍNH DOANH THU BÁN ĐỨT
                // ==========================================
                var queryHoaDon = db.HoaDonChiTiets.Where(ct => ct.HoaDon.NgayLap.Year == nam);
                if (thang > 0)
                    queryHoaDon = queryHoaDon.Where(ct => ct.HoaDon.NgayLap.Month == thang);

                var dsHoaDon = queryHoaDon.ToList();

                // Tổng doanh thu bán đứt (Loại trừ các hóa đơn nằm trong bảng TraGop)
                decimal thuBanDut = dsHoaDon
                    .Where(ct => !listMaHoaDonTraGop.Contains(ct.HoaDonID))
                    .Sum(ct => (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0));

                // ==========================================
                // 2. TÍNH DOANH THU TRẢ GÓP (Đã đóng & Chưa đóng)
                // ==========================================
                var queryTraGop = db.TraGops.Where(tg => tg.HoaDon.NgayLap.Year == nam);
                if (thang > 0)
                    queryTraGop = queryTraGop.Where(tg => tg.HoaDon.NgayLap.Month == thang);

                // 2.1 Tiền trả trước của các hợp đồng trả góp
                decimal thuTraTruoc = queryTraGop.Any() ? queryTraGop.Sum(tg => tg.SoTienTraTruoc) : 0;

                // 2.2 Chi tiết từng kỳ trả góp
                var queryChiTietTraGop = db.ChiTietTraGops.Where(ct => ct.NgayCanDong.Year == nam);
                if (thang > 0)
                    queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Month == thang);

                var dsChiTietTraGop = queryChiTietTraGop.ToList();

                // Tiền đã thu trong kỳ (gồm trả trước + tiền thực tế đã đóng các kỳ)
                decimal thuTraGopDaDong = thuTraTruoc + (dsChiTietTraGop.Any() ? dsChiTietTraGop.Sum(ct => ct.SoTienDaDong) : 0);

                // Tiền chưa thu trong kỳ = Tổng cần đóng (gốc + lãi + phạt) - Tổng đã đóng
                decimal thuTraGopChuaDong = dsChiTietTraGop.Any()
                    ? dsChiTietTraGop.Sum(ct => Math.Max(0, (ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong))
                    : 0;

                // ==========================================
                // 3. TỔNG KẾT VÀ HIỂN THỊ LÊN TEXTBOX
                // ==========================================
                decimal tongDoanhThuThucTe = thuBanDut + thuTraGopDaDong;

                // Thay tên các textbox bên dưới cho khớp với tên (Name) bạn đã đặt trên giao diện Design
                txtThuHoaDon.Text = thuBanDut.ToString("N0"); // Thu Hóa Đơn (Bán đứt)

                // GIẢ SỬ 3 TEXTBOX CÒN LẠI TÊN LÀ NHƯ SAU (Bạn hãy sửa lại tên nếu giao diện đặt khác)
                 txtThuTraGopDaDong.Text = thuTraGopDaDong.ToString("N0");
                 txtThuTraGopChuaDong.Text = thuTraGopChuaDong.ToString("N0");
                 txtTongDoanhThu.Text = tongDoanhThuThucTe.ToString("N0");


                // ==========================================
                // 4. ĐỔ DỮ LIỆU LÊN DATAGRIDVIEW (THÊM CỘT HÌNH THỨC)
                // ==========================================
                var dictTenTiVi = db.QuanLyTiVis.ToDictionary(tv => tv.MaTiVi, tv => tv.TenTiVi);

                var dsTiviDaBan = dsHoaDon.Select(ct => new
                {
                    MaTiVi = ct.MaTiVi,
                    TenTiVi = dictTenTiVi.ContainsKey(ct.MaTiVi) ? dictTenTiVi[ct.MaTiVi] : "Không xác định",
                    KhuyenMai = ct.KhuyenMai ?? 0,
                    SoLuong = ct.SoLuongBan,
                    DonGia = ct.DonGiaBan,
                    ThanhTien = (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0),

                    // XÁC ĐỊNH HÌNH THỨC DỰA VÀO VIỆC HOÁ ĐƠN CÓ TRONG BẢNG TRẢ GÓP HAY KHÔNG
                    HinhThuc = listMaHoaDonTraGop.Contains(ct.HoaDonID) ? "Trả Góp" : "Bán Đứt"
                }).ToList();

                dgvDoanhThu.AutoGenerateColumns = false; // Bắt buộc để DataGridView nhận đúng mapping
                dgvDoanhThu.DataSource = null;           // Làm sạch dữ liệu cũ
                dgvDoanhThu.DataSource = dsTiviDaBan;    // Đổ dữ liệu mới vào
            }
            catch (Exception ex)
            {
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
