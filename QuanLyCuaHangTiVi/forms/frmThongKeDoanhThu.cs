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
                // ==========================================
                // 1. TÍNH DOANH THU THỰC TẾ
                // ==========================================

                // 1.1 Doanh thu bán đứt 
                var queryHoaDon = db.HoaDonChiTiets.Where(ct => ct.HoaDon.NgayLap.Year == nam);
                if (thang > 0)
                    queryHoaDon = queryHoaDon.Where(ct => ct.HoaDon.NgayLap.Month == thang);

                var dsHoaDon = queryHoaDon.ToList();
                decimal thuHoaDon = dsHoaDon.Any() ? dsHoaDon.Sum(ct => (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0)) : 0;

                // 1.2 Doanh thu trả góp
                var queryTraGop = db.TraGops.Where(tg => tg.HoaDon.NgayLap.Year == nam);
                if (thang > 0)
                    queryTraGop = queryTraGop.Where(tg => tg.HoaDon.NgayLap.Month == thang);

                decimal thuTraTruoc = queryTraGop.Any() ? queryTraGop.Sum(tg => tg.SoTienTraTruoc) : 0;

                var queryChiTietTraGop = db.ChiTietTraGops.Where(ct => ct.DaThanhToan == true && ct.NgayCanDong.Year == nam);
                if (thang > 0)
                    queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Month == thang);

                decimal thuTienGop = queryChiTietTraGop.Any() ? queryChiTietTraGop.Sum(ct => ct.TongTienDong) : 0;

                decimal tongThuTraGop = thuTraTruoc + thuTienGop;
                decimal tongDoanhThu = thuHoaDon + tongThuTraGop;

                // ==========================================
                // 2. TÍNH CHI PHÍ (GIÁ VỐN HÀNG BÁN & VẬN HÀNH)
                // ==========================================
                var dictGiaNhap = db.ChiTietPhieuNhaps
                                    .GroupBy(ct => ct.MaTiVi)
                                    .ToDictionary(g => g.Key, g => g.FirstOrDefault()?.DonGiaNhap ?? 0);

                decimal chiPhiGiaVon = 0;
                foreach (var item in dsHoaDon)
                {
                    decimal giaNhap = dictGiaNhap.ContainsKey(item.MaTiVi) ? dictGiaNhap[item.MaTiVi] : 0;
                    chiPhiGiaVon += item.SoLuongBan * giaNhap;
                }

                decimal luongMotThang = db.NhanViens.Any() ? db.NhanViens.Sum(nv => nv.Luong) : 0;
                int soThangTinhLuong = (thang == 0) ? (nam == DateTime.Now.Year ? DateTime.Now.Month : 12) : 1;
                decimal chiLuong = luongMotThang * soThangTinhLuong;

                decimal chiVanHanh = 0;
                if (thang > 0)
                {
                    var cpVH = db.ChiPhiVanHanhs.FirstOrDefault(cp => cp.Thang == thang && cp.Nam == nam);
                    chiVanHanh = cpVH != null ? cpVH.TongChiPhiVanHanh : 0;
                }
                else
                {
                    var dsChiPhiNam = db.ChiPhiVanHanhs.Where(cp => cp.Nam == nam).ToList();
                    chiVanHanh = dsChiPhiNam.Any() ? dsChiPhiNam.Sum(x => x.TongChiPhiVanHanh) : 0;
                }

                decimal tongChi = chiPhiGiaVon + chiLuong + chiVanHanh;

                // ==========================================
                // 3. TÍNH LỢI NHUẬN & ĐỔ DỮ LIỆU LÊN GIAO DIỆN
                // ==========================================
                decimal loiNhuan = tongDoanhThu - tongChi;

                txtThuHoaDon.Text = thuHoaDon.ToString("N0") + " VNĐ";
                txtThuTraGop.Text = tongThuTraGop.ToString("N0") + " VNĐ";
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";

                txtChiNhapHang.Text = chiPhiGiaVon.ToString("N0") + " VNĐ";
                txtTienLuong.Text = chiLuong.ToString("N0") + " VNĐ";
                txtTienVanHanh.Text = chiVanHanh.ToString("N0") + " VNĐ";
                txtTongChiPhi.Text = tongChi.ToString("N0") + " VNĐ";

                txtLoiNhuan.Text = loiNhuan.ToString("N0") + " VNĐ";
                txtLoiNhuan.ForeColor = (loiNhuan < 0) ? Color.Red : Color.Green;

                // Kéo danh sách tivi từ database lên làm từ điển để tra cứu nhanh
                var dictTenTiVi = db.QuanLyTiVis.ToDictionary(tv => tv.MaTiVi, tv => tv.TenTiVi);

                var dsTiviDaBan = dsHoaDon.Select(ct => new
                {
                    MaTiVi = ct.MaTiVi,
                    TenTiVi = dictTenTiVi.ContainsKey(ct.MaTiVi) ? dictTenTiVi[ct.MaTiVi] : "Không xác định",
                    KhuyenMai = ct.KhuyenMai ?? 0,
                    SoLuong = ct.SoLuongBan,
                    DonGia = ct.DonGiaBan,
                    ThanhTien = (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0)
                }).ToList();

                // ====================================================
                // CHỈ GIỮ LẠI 3 DÒNG NÀY CHO DATAGRIDVIEW
                // ====================================================
                dgvDoanhThu.AutoGenerateColumns = false; // Tắt tự động đẻ cột
                dgvDoanhThu.DataSource = null;           // Làm sạch dữ liệu cũ
                dgvDoanhThu.DataSource = dsTiviDaBan;    // Đổ dữ liệu mới vào
                // ====================================================

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
