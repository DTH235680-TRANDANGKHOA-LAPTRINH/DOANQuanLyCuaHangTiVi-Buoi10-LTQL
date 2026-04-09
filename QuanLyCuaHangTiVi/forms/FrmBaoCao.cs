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
            int thangLoc = (thang == 0) ? 12 : thang;

            var dsCanThu = db.ChiTietTraGops
                .Include(ct => ct.TraGop)
                    .ThenInclude(tg => tg.HoaDon)
                        .ThenInclude(hd => hd.HoaDonChiTiets)
                            .ThenInclude(hdct => hdct.QuanLyTiVi)
                .Where(ct => ct.NgayCanDong.Year == nam && ct.NgayCanDong.Month <= thangLoc)
                .Where(ct => ct.SoTienDaDong < (ct.TongTienDong + ct.SoTienPhat))
                .ToList();

            // 1. Xóa sạch các cột bị thừa/thiếu từ giao diện Designer
            dgvCanThuTien.Columns.Clear();
            dgvCanThuTien.AutoGenerateColumns = true;

            // 2. Đổ dữ liệu
            dgvCanThuTien.DataSource = dsCanThu.Select(ct =>
            {
                var ctHoaDon = ct.TraGop.HoaDon.HoaDonChiTiets.FirstOrDefault();
                var tivi = ctHoaDon?.QuanLyTiVi;
                var maTivi = ctHoaDon?.MaTiVi;

                // Tránh lỗi văng app nếu hóa đơn không có mã tivi
                var thongTinNhap = string.IsNullOrEmpty(maTivi) ? null : db.ChiTietPhieuNhaps
                                     .Include(p => p.PhieuNhap)
                                     .Where(pn => pn.MaTiVi == maTivi)
                                     .OrderByDescending(pn => pn.MaCTPN)
                                     .FirstOrDefault();

                return new
                {
                    TenTiVi = tivi?.TenTiVi ?? "N/A",
                    HangSanXuat = tivi?.HangSanXuat ?? "N/A",
                    NgayNhapHang = thongTinNhap?.PhieuNhap?.NgayNhap.ToString("dd/MM/yyyy") ?? "N/A",
                    DonGiaNhap = thongTinNhap?.DonGiaNhap.ToString("N0") ?? "0",
                    MaHoaDon = ct.TraGop.MaHoaDon,
                    KyThu = "Kỳ " + ct.KyThu,
                    NgayCanDong = ct.NgayCanDong.ToString("dd/MM/yyyy"),
                    TongTien = (ct.TongTienDong + ct.SoTienPhat).ToString("N0"),
                    ConThieu = ((ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong).ToString("N0"),
                    TrangThai = ct.NgayCanDong < DateTime.Now.Date ? "QUÁ HẠN" : "Chờ thu"
                };
            }).ToList();

            // 3. Đổi tên Header cho chuẩn tiếng Việt
            dgvCanThuTien.Columns["TenTiVi"].HeaderText = "Tên TiVi";
            dgvCanThuTien.Columns["HangSanXuat"].HeaderText = "Hãng Sản Xuất";
            dgvCanThuTien.Columns["NgayNhapHang"].HeaderText = "Ngày Nhập Hàng";
            dgvCanThuTien.Columns["DonGiaNhap"].HeaderText = "Đơn Giá Nhập";
            dgvCanThuTien.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
            dgvCanThuTien.Columns["KyThu"].HeaderText = "Kỳ Thu";
            dgvCanThuTien.Columns["NgayCanDong"].HeaderText = "Ngày Cần Đóng";
            dgvCanThuTien.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dgvCanThuTien.Columns["ConThieu"].HeaderText = "Còn Thiếu";
            dgvCanThuTien.Columns["TrangThai"].HeaderText = "Trạng Thái";

            // Tùy chỉnh nhẹ lại độ rộng cột nếu muốn
            dgvCanThuTien.Columns["TenTiVi"].Width = 150;
            dgvCanThuTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
