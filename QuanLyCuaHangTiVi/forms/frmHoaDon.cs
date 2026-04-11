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
using ClosedXML.Excel;
namespace QuanLyCuaHangTiVi.forms
{
    public partial class frmHoaDon : Form
    {
        AppDbContext context = new AppDbContext();

        int id;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dgvDanhSachHD.AutoGenerateColumns = false;

            // Lấy danh sách hóa đơn hiển thị lên Grid
            List<DanhSachHoaDon> hd = context.HoaDons.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                MaNhanVien = r.MaNhanVien,
                HoTenNhanVien = r.NhanVien.HoTenNhanVien,
                MaKhachHang = r.MaKhachHang,
                TenKhachHang = r.KhachHang.TenKhachHang,
                NgayLap = r.NgayLap,

                // ---> THÊM DÒNG NÀY ĐỂ LẤY HÌNH THỨC THANH TOÁN TỪ DB <---
                HinhThucThanhToan = r.HinhThucThanhToan,

                // Sử dụng (decimal)(ct.KhuyenMai ?? 0) để tránh lỗi null và sai kiểu dữ liệu
                TongTien = r.HoaDonChiTiets.Sum(ct => (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0)),
                XemChiTiet = "Xem chi tiết"
            }).ToList();

            dgvDanhSachHD.DataSource = hd;
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmChiTietHoaDon chiTiet = new frmChiTietHoaDon(0)) // 0 là chế độ thêm mới
            {
                chiTiet.ShowDialog();
                frmHoaDon_Load(sender, e); // Load lại dữ liệu sau khi đóng form
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHD.CurrentRow != null)
            {
                id = Convert.ToInt32(dgvDanhSachHD.CurrentRow.Cells["colID"].Value);
                using (frmChiTietHoaDon chiTiet = new frmChiTietHoaDon(id)) // Truyền ID vào để Sửa
                {
                    chiTiet.ShowDialog();
                    frmHoaDon_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHD.CurrentRow != null)
            {
                if (MessageBox.Show("Xác nhận xóa hóa đơn này? Số lượng tivi đã bán sẽ được hoàn lại vào kho.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    id = Convert.ToInt32(dgvDanhSachHD.CurrentRow.Cells["colID"].Value);

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Lấy chi tiết hóa đơn và HOÀN TRẢ SỐ LƯỢNG KHO
                            var chiTiets = context.HoaDonChiTiets.Where(ct => ct.HoaDonID == id).ToList();
                            foreach (var item in chiTiets)
                            {
                                var tivi = context.QuanLyTiVis.Find(item.MaTiVi);
                                if (tivi != null)
                                {
                                    tivi.SoLuongTon += item.SoLuongBan; // Cộng trả lại kho
                                }
                            }

                            // 2. Xóa chi tiết trước (để tránh lỗi khóa ngoại)
                            context.HoaDonChiTiets.RemoveRange(chiTiets);

                            // 3. Xóa hóa đơn
                            var hoaDon = context.HoaDons.Find(id);
                            if (hoaDon != null)
                            {
                                context.HoaDons.Remove(hoaDon);
                            }

                            context.SaveChanges();
                            transaction.Commit(); // Hoàn tất giao dịch
                            frmHoaDon_Load(sender, e);
                            MessageBox.Show("Xóa thành công và đã hoàn trả kho!");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Lỗi thì quay lại từ đầu
                            MessageBox.Show("Lỗi xóa: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu Hóa đơn ra Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xlsx";
            saveFileDialog.FileName = "DanhSachHoaDon_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // ==========================================
                        // --- SHEET 1: DANH SÁCH HÓA ĐƠN ---
                        // ==========================================
                        DataTable dtHoaDon = new DataTable();
                        dtHoaDon.Columns.AddRange(new DataColumn[] {
            new DataColumn("Mã HĐ", typeof(int)),
            new DataColumn("Tên Nhân Viên", typeof(string)),
            new DataColumn("Tên Khách Hàng", typeof(string)),
            new DataColumn("Ngày Lập", typeof(DateTime)),
            new DataColumn("Hình Thức TT", typeof(string)), // ---> THÊM CỘT NÀY VÀO EXCEL
            new DataColumn("Tổng Tiền", typeof(decimal))
        });

                        // Lấy dữ liệu Hóa Đơn 
                        var dsHoaDon = context.HoaDons.Select(r => new
                        {
                            ID = r.ID,
                            HoTenNhanVien = r.NhanVien.HoTenNhanVien,
                            TenKhachHang = r.KhachHang.TenKhachHang,
                            NgayLap = r.NgayLap,
                            HinhThucThanhToan = r.HinhThucThanhToan, // ---> LẤY DỮ LIỆU TỪ DB
                            TongTien = r.HoaDonChiTiets.Sum(ct => (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0))
                        }).ToList();

                        // Đổ dữ liệu vào DataTable
                        foreach (var hd in dsHoaDon)
                        {
                            // ---> THÊM hd.HinhThucThanhToan VÀO DÒNG BÊN DƯỚI
                            dtHoaDon.Rows.Add(hd.ID, hd.HoTenNhanVien, hd.TenKhachHang, hd.NgayLap, hd.HinhThucThanhToan, hd.TongTien);
                        }
                        var sheetHD = wb.Worksheets.Add(dtHoaDon, "DanhSachHoaDon");
                        sheetHD.Columns().AdjustToContents(); // Tự động giãn cột cho đẹp

                        // ==========================================
                        // --- SHEET 2: CHI TIẾT HÓA ĐƠN ---
                        // ==========================================
                        DataTable dtChiTiet = new DataTable();
                        dtChiTiet.Columns.AddRange(new DataColumn[] {
            new DataColumn("Mã HĐ", typeof(int)),
            new DataColumn("Mã TiVi", typeof(string)),
            new DataColumn("Số Lượng", typeof(int)),
            new DataColumn("Đơn Giá", typeof(decimal)),
            new DataColumn("Khuyến Mãi", typeof(decimal)),
            new DataColumn("Thành Tiền", typeof(decimal))
        });

                        // Lấy dữ liệu Chi Tiết Hóa Đơn
                        var dsChiTiet = context.HoaDonChiTiets.Select(ct => new
                        {
                            HoaDonID = ct.HoaDonID,
                            MaTiVi = ct.MaTiVi,
                            SoLuongBan = ct.SoLuongBan,
                            DonGiaBan = ct.DonGiaBan,
                            KhuyenMai = ct.KhuyenMai ?? 0,
                            ThanhTien = (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0)
                        }).ToList();

                        // Đổ dữ liệu vào DataTable
                        foreach (var ct in dsChiTiet)
                        {
                            dtChiTiet.Rows.Add(ct.HoaDonID, ct.MaTiVi, ct.SoLuongBan, ct.DonGiaBan, ct.KhuyenMai, ct.ThanhTien);
                        }
                        var sheetCT = wb.Worksheets.Add(dtChiTiet, "ChiTietHoaDon");
                        sheetCT.Columns().AdjustToContents();

                        // --- LƯU FILE ---
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất báo cáo hóa đơn thành công!\nFile đã được lưu tại: " + saveFileDialog.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất Excel: File có thể đang được mở bởi một chương trình khác. \nChi tiết lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDanhSachHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có click vào tiêu đề không (e.RowIndex < 0 thì bỏ qua)
            if (e.RowIndex < 0) return;

            // Kiểm tra xem cột vừa click có phải là cột "Xem Chi Tiết" không
            // Thay "colXemChiTiet" bằng đúng (Name) bạn đã kiểm tra ở Bước 1
            if (dgvDanhSachHD.Columns[e.ColumnIndex].Name == "colXemChiTiet")
            {
                // 1. Lấy ID hóa đơn từ dòng hiện tại
                // Đảm bảo "colID" là (Name) của cột chứa mã hóa đơn
                int idHoaDon = Convert.ToInt32(dgvDanhSachHD.Rows[e.RowIndex].Cells["colID"].Value);

                // 2. Mở form chi tiết và truyền ID sang
                using (frmChiTietHoaDon fChiTiet = new frmChiTietHoaDon(idHoaDon))
                {
                    fChiTiet.ShowDialog();

                    // 3. Load lại dữ liệu sau khi đóng form chi tiết để cập nhật thay đổi (nếu có)
                    frmHoaDon_Load(sender, e);
                }
            }
        }
    }
}
