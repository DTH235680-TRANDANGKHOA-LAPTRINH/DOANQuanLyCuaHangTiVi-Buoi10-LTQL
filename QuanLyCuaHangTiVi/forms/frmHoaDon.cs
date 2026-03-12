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
                // Sử dụng (decimal)(ct.KhuyenMai ?? 0) để tránh lỗi null và sai kiểu dữ liệu
                TongTien = r.HoaDonChiTiets.Sum(ct => (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0))
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
    }
}
