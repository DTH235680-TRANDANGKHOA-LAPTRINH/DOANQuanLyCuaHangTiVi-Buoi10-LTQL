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
            // Lấy thông tin tháng và năm từ các control NumericUpDown trên giao diện
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;

            try
            {
                // ==========================================
                // 1. TÍNH DOANH THU 
                // ==========================================

                // Lấy danh sách các mã hóa đơn thuộc diện mua trả góp
                var listMaHoaDonTraGop = db.TraGops.Select(tg => tg.MaHoaDon).ToList();

                // Khởi tạo truy vấn lấy chi tiết hóa đơn, bao gồm thông tin hóa đơn gốc và lọc theo năm được chọn
                var queryHoaDon = db.HoaDonChiTiets
                                    .Include(ct => ct.HoaDon)
                                    .Where(ct => ct.HoaDon.NgayLap.Year == nam);

                // Nếu người dùng có chọn tháng cụ thể (tháng > 0), tiếp tục lọc chi tiết hóa đơn theo tháng
                if (thang > 0)
                    queryHoaDon = queryHoaDon.Where(ct => ct.HoaDon.NgayLap.Month == thang);

                // Thực thi truy vấn và đẩy kết quả ra một danh sách (List) trong bộ nhớ
                var dsHoaDon = queryHoaDon.ToList();

                // 1.1 Doanh thu bán đứt (Trả thẳng một lần)
                // Lọc ra các hóa đơn KHÔNG NẰM trong danh sách hóa đơn trả góp
                // Công thức: Tổng của (Số lượng * Đơn giá) - Khuyến mãi
                decimal thuBanDut = dsHoaDon
                    .Where(ct => !listMaHoaDonTraGop.Contains(ct.HoaDonID))
                    .Sum(ct => (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0));

                // 1.2 Doanh thu trả góp
                // Lấy các hợp đồng trả góp lập trong năm (và tháng nếu có)
                var queryTraGop = db.TraGops.Where(tg => tg.HoaDon.NgayLap.Year == nam);
                if (thang > 0) queryTraGop = queryTraGop.Where(tg => tg.HoaDon.NgayLap.Month == thang);

                // Tính tổng số tiền khách hàng đã trả trước khi làm hợp đồng trả góp
                decimal thuTraTruoc = queryTraGop.Any() ? queryTraGop.Sum(tg => tg.SoTienTraTruoc) : 0;

                // Lấy chi tiết các đợt đóng tiền trả góp theo hạn (trong năm/tháng đang xét)
                var queryChiTietTraGop = db.ChiTietTraGops.Where(ct => ct.NgayCanDong.Year == nam);
                if (thang > 0) queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Month == thang);

                var dsChiTietTraGop = queryChiTietTraGop.ToList();
                // Tính tổng tiền trả góp thực tế đã thu được = Tiền trả trước + Tổng các đợt đã đóng
                decimal thuTraGopDaDong = thuTraTruoc + (dsChiTietTraGop.Any() ? dsChiTietTraGop.Sum(ct => ct.SoTienDaDong) : 0);

                // 1.3 Tổng hợp doanh thu thực tế
                // Tổng doanh thu = Doanh thu bán đứt + Tiền trả góp (đã thu được tiền mặt/chuyển khoản)
                decimal tongDoanhThu = thuBanDut + thuTraGopDaDong;
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ"; // Hiển thị lên UI

                // ==========================================
                // 2. TÍNH CHI PHÍ
                // ==========================================

                // 2.1 Giá vốn hàng bán (TỐI ƯU KHÔNG LỖI N+1, KHÔNG CẦN SỬA DB)
                decimal tongGiaVon = 0;
                if (dsHoaDon.Any())
                {
                    // Lấy danh sách các mã TiVi không trùng lặp đã được bán ra trong kỳ
                    var listMaTiVi = dsHoaDon.Select(ct => ct.MaTiVi).Distinct().ToList();

                    // Truy xuất lịch sử nhập hàng của các TiVi này để tìm giá nhập
                    var lichSuNhap = db.ChiTietPhieuNhaps
                        .Where(pn => listMaTiVi.Contains(pn.MaTiVi))
                        .Select(pn => new {
                            MaTiVi = pn.MaTiVi,
                            NgayNhap = pn.PhieuNhap.NgayNhap,
                            DonGiaNhap = pn.DonGiaNhap
                        }).ToList();

                    // Duyệt qua từng chi tiết hóa đơn bán ra để tính giá vốn tương ứng
                    foreach (var ct in dsHoaDon)
                    {
                        DateTime ngayBan = ct.HoaDon.NgayLap;

                        // Tìm giá nhập của đợt nhập hàng gần nhất TRƯỚC HOẶC BẰNG ngày bán
                        var giaNhapLichSu = lichSuNhap
                            .Where(pn => pn.MaTiVi == ct.MaTiVi && pn.NgayNhap <= ngayBan)
                            .OrderByDescending(pn => pn.NgayNhap)
                            .Select(pn => pn.DonGiaNhap)
                            .FirstOrDefault();

                        // Nếu không tìm thấy lô nhập nào trước ngày bán (có thể do lỗi dữ liệu hoặc nhập sau bán)
                        // thì lấy giá nhập của đợt nhập hàng đầu tiên (cũ nhất) của mã Tivi đó
                        if (giaNhapLichSu == 0)
                        {
                            giaNhapLichSu = lichSuNhap
                                .Where(pn => pn.MaTiVi == ct.MaTiVi)
                                .OrderBy(pn => pn.NgayNhap)
                                .Select(pn => pn.DonGiaNhap)
                                .FirstOrDefault();
                        }

                        // Cộng dồn: Giá vốn = Số lượng bán * Giá nhập của lô hàng đó
                        tongGiaVon += (decimal)ct.SoLuongBan * giaNhapLichSu;
                    }
                }

                // 2.2 Tiền lương (Sửa logic ảo)
                // Tính tổng quỹ lương của tất cả nhân viên trong 1 tháng
                decimal tongLuongMotThang = db.NhanViens.Any() ? db.NhanViens.Sum(x => (decimal?)x.Luong ?? 0) : 0;
                decimal tongLuong = 0;

                if (thang == 0) // Trường hợp xem báo cáo cả năm
                {
                    if (nam < DateTime.Now.Year)
                        // Nếu xem năm cũ, tiền lương = lương 1 tháng * 12 tháng
                        tongLuong = tongLuongMotThang * 12;
                    else if (nam == DateTime.Now.Year)
                        // Nếu xem năm hiện tại, chỉ tính tiền lương đến tháng hiện tại (Year To Date)
                        tongLuong = tongLuongMotThang * DateTime.Now.Month;
                    else
                        // Nếu xem năm tương lai, chưa phát sinh lương
                        tongLuong = 0;
                }
                else // Trường hợp xem báo cáo theo 1 tháng cụ thể
                {
                    tongLuong = tongLuongMotThang;
                }

                // 2.3 Chi phí vận hành (Mặt bằng, điện nước,...)
                var queryVanHanh = db.ChiPhiVanHanhs.Where(cp => cp.Nam == nam);
                if (thang > 0) queryVanHanh = queryVanHanh.Where(cp => cp.Thang == thang);

                // Tính tổng chi phí vận hành trong kỳ báo cáo
                decimal tongVanHanh = queryVanHanh.AsEnumerable()
                                                  .Sum(cp => (decimal?)cp.TongChiPhiVanHanh) ?? 0;

                // Tổng hợp toàn bộ chi phí = Giá vốn + Quỹ lương + Chi phí vận hành
                decimal tongChiPhi = tongGiaVon + tongLuong + tongVanHanh;
                txtTongChiPhi.Text = tongChiPhi.ToString("N0") + " VNĐ"; // Hiển thị lên UI

                // ==========================================
                // 3. TÍNH LỢI NHUẬN
                // ==========================================

                // Lợi nhuận = Tổng doanh thu thực tế - Tổng chi phí
                decimal loiNhuan = tongDoanhThu - tongChiPhi;
                txtLoiNhuan.Text = loiNhuan.ToString("N0") + " VNĐ";

                // Đổi màu text: Lãi (>= 0) màu Xanh, Lỗ (< 0) màu Đỏ
                txtLoiNhuan.ForeColor = (loiNhuan >= 0) ? Color.Green : Color.Red;

                // Tải danh sách các khoản khách hàng cần trả góp để hiển thị lên lưới dữ liệu (DataGridView)
                LoadDanhSachTraGop(thang, nam);
            }
            catch (Exception ex)
            {
                // Bắt lỗi và hiển thị thông báo nếu có Exception (lỗi DB, chia cho 0, null reference...)
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void LoadDanhSachTraGop(int thang, int nam)
        {
            try
            {
                // ==========================================
                // 1. TẠO TRUY VẤN VÀ LIÊN KẾT CÁC BẢNG (JOIN)
                // ==========================================
                // Sử dụng Include và ThenInclude của Entity Framework để tải trước (Eager Loading) dữ liệu liên quan.
                // Việc này giúp kết nối các bảng lại với nhau để lấy Tên và SĐT Khách Hàng, tránh lỗi N+1 query.
                var queryChiTietTraGop = db.ChiTietTraGops
                    .Include(ct => ct.TraGop)                           // Nối bảng ChiTietTraGop với bảng TraGop
                        .ThenInclude(tg => tg.HoaDon)                   // Từ bảng TraGop nối tiếp sang bảng HoaDon
                            .ThenInclude(hd => hd.KhachHang)            // Từ bảng HoaDon nối tiếp sang bảng KhachHang
                    .AsQueryable();

                // ==========================================
                // 2. LỌC DỮ LIỆU THÔNG MINH
                // ==========================================
                // Kiểm tra xem form có được mở từ một sự kiện cụ thể mang theo _traGopID hay không (VD: Xem chi tiết 1 hợp đồng)
                if (_traGopID > 0)
                {
                    // Nếu có ID cụ thể, chỉ lấy đúng chi tiết của hợp đồng trả góp đó (bỏ qua lọc theo tháng/năm)
                    queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.TraGopID == _traGopID);
                }
                else
                {
                    // Nếu mở form bình thường để xem báo cáo thì lọc theo thời gian (Năm và Tháng)
                    queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Year == nam);

                    // Nếu người dùng có chọn tháng cụ thể (tháng > 0), thì lọc thêm theo tháng
                    if (thang > 0)
                    {
                        queryChiTietTraGop = queryChiTietTraGop.Where(ct => ct.NgayCanDong.Month == thang);
                    }
                }

                // ==========================================
                // 3. CHUYỂN ĐỔI VÀ TÍNH TOÁN DỮ LIỆU ĐẦU RA
                // ==========================================
                // Thực thi truy vấn (.ToList()) và tạo một cấu trúc dữ liệu mới (Anonymous Type) để dễ dàng đưa lên UI
                var dsCanThuTien = queryChiTietTraGop.ToList().Select(ct => new
                {
                    ID = ct.TraGopID,

                    // Trích xuất Tên và SĐT khách hàng
                    // Dùng toán tử '?.' và '??' để đề phòng trường hợp mất dữ liệu (null) gây lỗi văng app (crash)
                    TenKhachHang = ct.TraGop?.HoaDon?.KhachHang?.TenKhachHang ?? "Không xác định",
                    SoDienThoai = ct.TraGop?.HoaDon?.KhachHang?.SoDienThoai ?? "Trống",

                    // Định dạng lại ngày tháng năm thành chuỗi cho dễ nhìn
                    NgayCanDong = ct.NgayCanDong.ToString("dd/MM/yyyy"),

                    // Tổng tiền khách phải đóng đợt này = Tiền gốc/lãi cần đóng + Tiền phạt trễ hạn (nếu có)
                    TongTienCanDong = ct.TongTienDong + ct.SoTienPhat,
                    SoTienDaDong = ct.SoTienDaDong,

                    // Số tiền còn nợ trong kỳ = Tổng cần đóng - Số tiền khách đã đóng
                    TienConNo = (ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong,

                    // Xác định Trạng Thái thanh toán bằng toán tử 3 ngôi (Ternary Operator)
                    // - Điều kiện 1: Nếu còn nợ (> 0) VÀ ngày cần đóng đã qua (< ngày hiện tại) => "QUÁ HẠN"
                    // - Điều kiện 2: Nếu đã đóng hết nợ (<= 0) => "ĐÃ ĐÓNG"
                    // - Điều kiện 3: Nếu còn nợ nhưng vẫn chưa tới hạn đóng => "CHƯA ĐÓNG"
                    TrangThai = ((ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong > 0 && ct.NgayCanDong.Date < DateTime.Now.Date)
                                ? "QUÁ HẠN"
                                : (((ct.TongTienDong + ct.SoTienPhat) - ct.SoTienDaDong <= 0) ? "ĐÃ ĐÓNG" : "CHƯA ĐÓNG")
                }).ToList();

                // ==========================================
                // 4. CẤU HÌNH VÀ ĐỔ DỮ LIỆU LÊN DATAGRIDVIEW
                // ==========================================
                // Làm sạch DataGridView và cho phép tự động tạo cột dựa trên cấu trúc dữ liệu phía trên
                dgvCanThuTien.DataSource = null;
                dgvCanThuTien.Columns.Clear();
                dgvCanThuTien.AutoGenerateColumns = true;

                // Gán danh sách đã xử lý làm nguồn dữ liệu
                dgvCanThuTien.DataSource = dsCanThuTien;

                // Đổi lại tiêu đề cột (HeaderText) tiếng Việt cho đẹp và dễ hiểu với người dùng
                if (dgvCanThuTien.Columns.Count > 0)
                {
                    dgvCanThuTien.Columns["ID"].HeaderText = "ID Trả Góp";
                    dgvCanThuTien.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
                    dgvCanThuTien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                    dgvCanThuTien.Columns["NgayCanDong"].HeaderText = "Hạn Đóng";
                    dgvCanThuTien.Columns["TongTienCanDong"].HeaderText = "Tổng Cần Đóng (VNĐ)";
                    dgvCanThuTien.Columns["SoTienDaDong"].HeaderText = "Đã Đóng (VNĐ)";
                    dgvCanThuTien.Columns["TienConNo"].HeaderText = "Còn Nợ (VNĐ)";
                    dgvCanThuTien.Columns["TrangThai"].HeaderText = "Trạng Thái";

                    // Định dạng các cột số tiền có dấu phân cách hàng nghìn (Ví dụ: 1,000,000)
                    dgvCanThuTien.Columns["TongTienCanDong"].DefaultCellStyle.Format = "N0";
                    dgvCanThuTien.Columns["SoTienDaDong"].DefaultCellStyle.Format = "N0";
                    dgvCanThuTien.Columns["TienConNo"].DefaultCellStyle.Format = "N0";

                    // Yêu cầu các cột tự động giãn nở lấp đầy chiều rộng của DataGridView
                    dgvCanThuTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi và hiển thị thông báo với biểu tượng Error nếu có sự cố (Lỗi DB, lỗi format...)
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
