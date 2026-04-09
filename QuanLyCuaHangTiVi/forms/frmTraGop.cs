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

        // --- HÀM TẮT BẬT NÚT ---
        private void BatTatChucNang(bool dangThaoTac)
        {
            btnLuu.Enabled = dangThaoTac;
            btnHuyBo.Enabled = dangThaoTac;

            cboMaHoaDon.Enabled = dangThaoTac;
            txtLaiSuat.Enabled = dangThaoTac;
            txtKyHanTra.Enabled = dangThaoTac;
            txtSoTienTraTruoc.Enabled = dangThaoTac;

            btnThem.Enabled = !dangThaoTac;
            btnSua.Enabled = !dangThaoTac;
            btnXoa.Enabled = !dangThaoTac;
            btnXemLichTrinh.Enabled = !dangThaoTac;
        }

        // --- HÀM TÍNH TIỀN NỢ ---
        private void TinhSoTienNo()
        {
            try
            {
                if (cboMaHoaDon.SelectedValue == null) return;
                int maHD = (int)cboMaHoaDon.SelectedValue;

                var hoaDon = db.HoaDons.Select(hd => new
                {
                    hd.ID,
                    TongTien = hd.HoaDonChiTiets.Sum(ct => ct.SoLuongBan * ct.DonGiaBan)
                }).FirstOrDefault(hd => hd.ID == maHD);

                if (hoaDon == null) return;

                decimal tongTien = hoaDon.TongTien;
                decimal.TryParse(txtSoTienTraTruoc.Text, out decimal traTruoc);
                decimal.TryParse(txtLaiSuat.Text, out decimal laiSuat);

                decimal noGoc = tongTien - traTruoc;
                if (noGoc < 0) noGoc = 0;

                decimal tienLai = noGoc * (laiSuat / 100);
                decimal tongNo = noGoc + tienLai;

                txtSoTienConNo.Text = tongNo.ToString("0");
            }
            catch { }
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
            isThem = false;
            BatTatChucNang(false);

            var danhSachHoaDon = db.HoaDons.Select(hd => new
            {
                ID = hd.ID,
                ThongTinHienThi = hd.KhachHang.TenKhachHang + " - Mua: " +
                                  (hd.HoaDonChiTiets.Any() ? hd.HoaDonChiTiets.FirstOrDefault().QuanLyTiVi.TenTiVi : "Không rõ")
            }).ToList();

            cboMaHoaDon.DataSource = danhSachHoaDon;
            cboMaHoaDon.DisplayMember = "ThongTinHienThi";
            cboMaHoaDon.ValueMember = "ID";

            var danhSachTraGop = db.TraGops.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachTraGop;
            dgvTraGop.DataSource = bindingSource;

            if (dgvTraGop.Columns["HoaDon"] != null) dgvTraGop.Columns["HoaDon"].Visible = false;
            if (dgvTraGop.Columns["ChiTietTraGops"] != null) dgvTraGop.Columns["ChiTietTraGops"].Visible = false;

            txtMaTraGop.DataBindings.Clear();
            cboMaHoaDon.DataBindings.Clear();
            txtLaiSuat.DataBindings.Clear();
            txtKyHanTra.DataBindings.Clear();
            txtSoTienTraTruoc.DataBindings.Clear();
            txtSoTienConNo.DataBindings.Clear();

            txtMaTraGop.DataBindings.Add("Text", bindingSource, "MaTraGop", true, DataSourceUpdateMode.Never);
            cboMaHoaDon.DataBindings.Add("SelectedValue", bindingSource, "MaHoaDon", true, DataSourceUpdateMode.Never);
            txtLaiSuat.DataBindings.Add("Text", bindingSource, "LaiSuat", true, DataSourceUpdateMode.Never);
            txtKyHanTra.DataBindings.Add("Text", bindingSource, "KyHanTra", true, DataSourceUpdateMode.Never);
            txtSoTienTraTruoc.DataBindings.Add("Text", bindingSource, "SoTienTraTruoc", true, DataSourceUpdateMode.Never);
            txtSoTienConNo.DataBindings.Add("Text", bindingSource, "SoTienConNo", true, DataSourceUpdateMode.Never);

            txtLaiSuat.KeyPress += ChiNhapSo_KeyPress;
            txtKyHanTra.KeyPress += ChiNhapSo_KeyPress;
            txtSoTienTraTruoc.KeyPress += ChiNhapSo_KeyPress;
        }
        private void ChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép các phím điều khiển (Backspace), phím số từ 0-9 và dấu chấm (.) cho số thập phân
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Chặn phím không cho gõ vào
                MessageBox.Show("Trường này chỉ được phép nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Nâng cao: Chỉ cho phép nhập TỐI ĐA 1 dấu chấm (để gõ lãi suất ví dụ 1.5)
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Chặn chặn nếu phát hiện đã có 1 dấu chấm rồi
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            BatTatChucNang(true);

            txtMaTraGop.Text = ""; // Để trống vì tự tăng
            cboMaHoaDon.SelectedIndex = -1;
            txtLaiSuat.Clear();
            txtKyHanTra.Clear();
            txtSoTienTraTruoc.Clear();
            txtSoTienConNo.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTraGop.Text))
            {
                MessageBox.Show("Chưa chọn bản ghi trả góp để sửa!");
                return;
            }

            int maTG = int.Parse(txtMaTraGop.Text);
            bool daThuTien = db.ChiTietTraGops.Any(ct => ct.MaTraGop == maTG && ct.SoTienDaDong > 0);
            if (daThuTien)
            {
                MessageBox.Show("Khách hàng đã đóng tiền cho hợp đồng này. Không được phép sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isThem = false;
            BatTatChucNang(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTraGop.CurrentRow == null || dgvTraGop.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy đối tượng an toàn 100% không sợ lỗi tên cột
            TraGop hopDongDuocChon = dgvTraGop.CurrentRow.DataBoundItem as TraGop;
            int maTraGop = hopDongDuocChon.MaTraGop;

            // Bật cảnh báo nguy hiểm vì thao tác này sẽ bay màu toàn bộ dữ liệu tiền bạc
            DialogResult dr = MessageBox.Show(
                "Bạn có CHẮC CHẮN muốn xóa hợp đồng này không?\nLưu ý: Toàn bộ lịch sử đóng tiền (chi tiết trả góp) của hợp đồng này cũng sẽ bị XÓA VĨNH VIỄN!",
                "Cảnh báo nguy hiểm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                // 1. Tìm hợp đồng cần xóa trong DB
                var hopDong = db.TraGops.Find(maTraGop);

                if (hopDong != null)
                {
                    // 2. TÌM VÀ DIỆT TOÀN BỘ ĐÁM CON (ChiTietTraGop) TRƯỚC
                    var danhSachChiTiet = db.ChiTietTraGops.Where(ct => ct.MaTraGop == maTraGop).ToList();
                    if (danhSachChiTiet.Count > 0)
                    {
                        db.ChiTietTraGops.RemoveRange(danhSachChiTiet);
                    }

                    // 3. SAU KHI ĐÃ SẠCH BÓNG ĐÁM CON, TIẾN HÀNH XÓA THẰNG CHA (TraGop)
                    db.TraGops.Remove(hopDong);

                    // 4. Lưu lại toàn bộ thay đổi xuống Database
                    db.SaveChanges();

                    MessageBox.Show("Đã xóa thành công hợp đồng và dọn sạch lịch sử đóng tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Làm mới lại danh sách
                    frmTraGop_Load(sender, e);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboMaHoaDon.SelectedValue == null) { MessageBox.Show("Chọn một Hóa Đơn!"); return; }

            if (!decimal.TryParse(txtLaiSuat.Text, out decimal laiSuat) ||
                !decimal.TryParse(txtSoTienTraTruoc.Text, out decimal soTienTruoc) ||
                !int.TryParse(txtKyHanTra.Text, out int kyHan))
            {
                MessageBox.Show("Định dạng số bị sai (Lãi suất, Tiền trả trước, Kỳ hạn)!");
                return;
            }

            try
            {
                int maHD = (int)cboMaHoaDon.SelectedValue;
                decimal soTienNoTinhToan = decimal.Parse(txtSoTienConNo.Text);

                if (isThem)
                {
                    TraGop tgMoi = new TraGop
                    {
                        MaHoaDon = maHD,
                        LaiSuat = laiSuat,
                        KyHanTra = kyHan,
                        SoTienTraTruoc = soTienTruoc,
                        SoTienConNo = soTienNoTinhToan
                    };

                    db.TraGops.Add(tgMoi);
                    db.SaveChanges(); // LƯU TRƯỚC ĐỂ SQL TẠO RA ID (MaTraGop)

                    decimal tongMoiThang = soTienNoTinhToan / kyHan;
                    DateTime ngayBatDau = DateTime.Now;

                    for (int i = 1; i <= kyHan; i++)
                    {
                        ChiTietTraGop chiTiet = new ChiTietTraGop
                        {
                            MaTraGop = tgMoi.MaTraGop, // Lấy ID vừa được tự sinh gán vào chi tiết
                            KyThu = i,
                            NgayCanDong = ngayBatDau.AddMonths(i),
                            SoTienGoc = 0,
                            SoTienLai = 0,
                            TongTienDong = Math.Round(tongMoiThang, 0),
                            SoTienPhat = 0
                        };
                        db.ChiTietTraGops.Add(chiTiet);
                    }
                    db.SaveChanges(); // Lưu tiếp phần chi tiết
                }
                else
                {
                    int maTG = int.Parse(txtMaTraGop.Text);
                    var tgSua = db.TraGops.Find(maTG);
                    if (tgSua != null)
                    {
                        tgSua.MaHoaDon = maHD;
                        tgSua.LaiSuat = laiSuat;
                        tgSua.KyHanTra = kyHan;
                        tgSua.SoTienTraTruoc = soTienTruoc;
                        tgSua.SoTienConNo = soTienNoTinhToan;

                        var chiTietCu = db.ChiTietTraGops.Where(ct => ct.MaTraGop == maTG);
                        db.ChiTietTraGops.RemoveRange(chiTietCu);

                        decimal tongMoiThang = soTienNoTinhToan / kyHan;
                        DateTime ngayBatDau = DateTime.Now;
                        for (int i = 1; i <= kyHan; i++)
                        {
                            db.ChiTietTraGops.Add(new ChiTietTraGop
                            {
                                MaTraGop = tgSua.MaTraGop,
                                KyThu = i,
                                NgayCanDong = ngayBatDau.AddMonths(i),
                                TongTienDong = Math.Round(tongMoiThang, 0)
                            });
                        }
                    }
                    db.SaveChanges();
                }

                MessageBox.Show("Lưu thành công!");
                frmTraGop_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + ex.Message);
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
            // Kiểm tra xem có đang ở chế độ thêm mới không
            if (isThem)
            {
                MessageBox.Show("Vui lòng LƯU hợp đồng trước khi xem lịch trình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra xem có mã trả góp trên TextBox chưa
            if (string.IsNullOrEmpty(txtMaTraGop.Text))
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng trên lưới danh sách để xem lịch trình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // An toàn ép kiểu từ chữ sang số và gọi form
            if (int.TryParse(txtMaTraGop.Text, out int maTG))
            {
                frmChiTietTraGop frm = new frmChiTietTraGop(maTG);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mã trả góp không hợp lệ!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
