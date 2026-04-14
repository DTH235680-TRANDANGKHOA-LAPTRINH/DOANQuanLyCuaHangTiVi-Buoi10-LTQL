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
        // 1. Tạo biến để hứng ID từ form Trả Góp ném sang
        private int _traGopID;
        public FrmBaoCao(int idTuFormTraGop)
        {
            InitializeComponent();
            // Cất ID nhận được vào biến toàn cục để dùng
            _traGopID = idTuFormTraGop;
        }
        public FrmBaoCao()
        {
            InitializeComponent();
            _traGopID = 0; // Gán mặc định bằng 0
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
                // 1. TÍNH DOANH THU 
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

                // ==========================================
                // 2. TÍNH CHI PHÍ
                // ==========================================
                // 2.1 Giá vốn hàng bán (TỐI ƯU KHÔNG LỖI N+1, KHÔNG CẦN SỬA DB)
                decimal tongGiaVon = 0;
                if (dsHoaDon.Any())
                {
                    var listMaTiVi = dsHoaDon.Select(ct => ct.MaTiVi).Distinct().ToList();

                    var lichSuNhap = db.ChiTietPhieuNhaps
                        .Where(pn => listMaTiVi.Contains(pn.MaTiVi))
                        .Select(pn => new {
                            MaTiVi = pn.MaTiVi,
                            NgayNhap = pn.PhieuNhap.NgayNhap,
                            DonGiaNhap = pn.DonGiaNhap
                        }).ToList();

                    foreach (var ct in dsHoaDon)
                    {
                        DateTime ngayBan = ct.HoaDon.NgayLap;

                        var giaNhapLichSu = lichSuNhap
                            .Where(pn => pn.MaTiVi == ct.MaTiVi && pn.NgayNhap <= ngayBan)
                            .OrderByDescending(pn => pn.NgayNhap)
                            .Select(pn => pn.DonGiaNhap)
                            .FirstOrDefault();

                        if (giaNhapLichSu == 0)
                        {
                            giaNhapLichSu = lichSuNhap
                                .Where(pn => pn.MaTiVi == ct.MaTiVi)
                                .OrderBy(pn => pn.NgayNhap)
                                .Select(pn => pn.DonGiaNhap)
                                .FirstOrDefault();
                        }

                        tongGiaVon += (decimal)ct.SoLuongBan * giaNhapLichSu;
                    }
                }

                // 2.2 Tiền lương (Sửa logic ảo)
                decimal tongLuongMotThang = db.NhanViens.Any() ? db.NhanViens.Sum(x => (decimal?)x.Luong ?? 0) : 0;
                decimal tongLuong = 0;

                if (thang == 0)
                {
                    if (nam < DateTime.Now.Year)
                        tongLuong = tongLuongMotThang * 12;
                    else if (nam == DateTime.Now.Year)
                        tongLuong = tongLuongMotThang * DateTime.Now.Month;
                    else
                        tongLuong = 0;
                }
                else
                {
                    tongLuong = tongLuongMotThang;
                }

                // 2.3 Vận hành
                var queryVanHanh = db.ChiPhiVanHanhs.Where(cp => cp.Nam == nam);
                if (thang > 0) queryVanHanh = queryVanHanh.Where(cp => cp.Thang == thang);

                decimal tongVanHanh = queryVanHanh.AsEnumerable()
                                                  .Sum(cp => (decimal?)cp.TongChiPhiVanHanh) ?? 0;

                decimal tongChiPhi = tongGiaVon + tongLuong + tongVanHanh;
                txtTongChiPhi.Text = tongChiPhi.ToString("N0") + " VNĐ";

                // ==========================================
                // 3. TÍNH LỢI NHUẬN
                // ==========================================
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
                // 1. Tạo Query gốc và dùng Include để JOIN các bảng lấy Tên Khách Hàng
                var queryChiTietTraGop = db.ChiTietTraGops
                    .Include(ct => ct.TraGop)
                        .ThenInclude(tg => tg.HoaDon)
                            .ThenInclude(hd => hd.KhachHang)
                    .AsQueryable();

                // LỌC THÔNG MINH: Nếu form được gọi từ nút "Xem Báo Cáo" mang theo ID (> 0)
                if (_traGopID > 0)
                {
                    queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.TraGopID == _traGopID);
                }
                else
                {
                    // Nếu mở form bình thường thì mới lọc theo năm/tháng
                    queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Year == nam);
                    if (thang > 0)
                    {
                        queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Month == thang);
                    }
                }

                // 2. Chuyển đổi dữ liệu, ĐỔI MÃ TRẢ GÓP THÀNH ID VÀ THÊM TÊN, SĐT KHÁCH HÀNG
                var dsCanThuTien = queryChiTietTraGop.ToList().Select(ct => new
                {
                    ID = ct.TraGopID,

                    // Lấy tên khách hàng từ bảng KhachHang
                    TenKhachHang = ct.TraGop?.HoaDon?.KhachHang?.TenKhachHang ?? "Không xác định",

                    // Lấy số điện thoại từ bảng KhachHang (THÊM MỚI Ở ĐÂY)
                    SoDienThoai = ct.TraGop?.HoaDon?.KhachHang?.SoDienThoai ?? "Trống",

                    NgayCanDong = ct.NgayCanDong.ToString("dd/MM/yyyy"),
                    TongTienCanDong = ct.TongTienDong + ct.SoTienPhat,
                    SoTienDaDong = ct.SoTienDaDong,
                    TienConNo = (ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong,

                    // XÁC ĐỊNH TRẠNG THÁI
                    TrangThai = ((ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong > 0 && ct.NgayCanDong.Date < DateTime.Now.Date)
                                ? "QUÁ HẠN"
                                : (((ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong <= 0) ? "ĐÃ ĐÓNG" : "CHƯA ĐÓNG")
                }).ToList();

                // 3. FIX LỖI HIỂN THỊ LÊN DATAGRIDVIEW
                dgvCanThuTien.DataSource = null;
                dgvCanThuTien.Columns.Clear();
                dgvCanThuTien.AutoGenerateColumns = true;

                dgvCanThuTien.DataSource = dsCanThuTien;

                // 4. Đổi lại tên Header cho hiển thị đẹp mắt
                if (dgvCanThuTien.Columns.Count > 0)
                {
                    dgvCanThuTien.Columns["ID"].HeaderText = "ID Trả Góp";
                    dgvCanThuTien.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
                    dgvCanThuTien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại"; // CỘT SĐT MỚI THÊM
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
            _traGopID = 0;
            LoadBaoCao();
        }

        private void btnChiTietDoanhThu_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frmDT = new frmThongKeDoanhThu();
            frmDT.WindowState = FormWindowState.Maximized;
            frmDT.ShowDialog();
        }

        private void btnChiTietChiPhi_Click(object sender, EventArgs e)
        {
            frmThongkeChiPhi frmCP = new frmThongkeChiPhi();
            frmCP.WindowState = FormWindowState.Maximized;
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
