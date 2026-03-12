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
    public partial class frmChiTietHoaDon : Form
    {
        AppDbContext context = new AppDbContext();
        int id; // Chứa ID hóa đơn (Nếu = 0 là Thêm mới, khác 0 là Sửa)
        BindingList<DanhSachHoaDonChiTiet> hoaDonChiTiet = new BindingList<DanhSachHoaDonChiTiet>();
        public frmChiTietHoaDon(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
        }
        public void LoadComboBox()
        {
            cboNhanVien.DataSource = context.NhanViens.ToList();
            cboNhanVien.ValueMember = "MaNhanVien";
            cboNhanVien.DisplayMember = "HoTenNhanVien";

            cboKhachHang.DataSource = context.KhachHangs.ToList();
            cboKhachHang.ValueMember = "MaKhachHang";
            cboKhachHang.DisplayMember = "TenKhachHang";

            cboTenTiVi.DataSource = context.QuanLyTiVis.ToList();
            cboTenTiVi.ValueMember = "MaTiVi";
            cboTenTiVi.DisplayMember = "TenTiVi";
        }

        private void BatTatChucNang(bool dangThaoTac)
        {
            txtSoLuong.ReadOnly = !dangThaoTac;
            txtKhuyenMai.ReadOnly = !dangThaoTac;
            txtDonGia.ReadOnly = true; // Luôn khóa vì giá lấy từ DB
            txtGhiChu.ReadOnly = !dangThaoTac;

            cboTenTiVi.Enabled = dangThaoTac;
            cboKhachHang.Enabled = dangThaoTac;
            cboNhanVien.Enabled = dangThaoTac;
            dtpNgayLap.Enabled = dangThaoTac;

            btnXoa.Enabled = dangThaoTac;

            // Nút Thêm luôn sáng nếu đang thao tác
            btnThem.Enabled = true;

            // THÔNG MINH: Chỉ bật nút Lưu nếu Giỏ hàng (lưới) có dữ liệu
            if (dangThaoTac == true && hoaDonChiTiet.Count > 0)
            {
                btnLuu.Enabled = true;
            }
            else
            {
                btnLuu.Enabled = false;
            }
        }
        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {

            LoadComboBox();
            dgvDanhSachHD.AutoGenerateColumns = false;

            if (id == 0)
                BatTatChucNang(false);
            else
                BatTatChucNang(true);

            if (id != 0) // Chế độ Sửa
            {
                var hoaDon = context.HoaDons.FirstOrDefault(r => r.ID == id);
                if (hoaDon != null)
                {
                    cboNhanVien.SelectedValue = hoaDon.MaNhanVien;
                    cboKhachHang.SelectedValue = hoaDon.MaKhachHang;
                    dtpNgayLap.Value = hoaDon.NgayLap;
                    txtGhiChu.Text = hoaDon.GhiChuHoaDon;
                }

                // --- FIX: Gán dữ liệu vào biến hoaDonChiTiet thay vì chỉ tạo biến ct ---
                var ct = context.HoaDonChiTiets.Where(r => r.HoaDonID == id).Select(r => new DanhSachHoaDonChiTiet
                {
                    ID = r.ID,
                    HoaDonID = r.HoaDonID,
                    MaTiVi = r.MaTiVi,
                    TenTiVi = r.QuanLyTiVi.TenTiVi,
                    SoLuongBan = r.SoLuongBan,
                    DonGiaBan = r.DonGiaBan,
                    KhuyenMai = r.KhuyenMai ?? 0,
                    ThanhTien = (r.SoLuongBan * r.DonGiaBan) - (r.KhuyenMai ?? 0)
                }).ToList();

                // Ghi đè danh sách tạm bằng dữ liệu từ DB
                hoaDonChiTiet.Clear();
                foreach (var item in ct) hoaDonChiTiet.Add(item);
            }

            dgvDanhSachHD.DataSource = hoaDonChiTiet; // Gán nguồn dữ liệu

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Nếu form đang khóa, nhấn Thêm để mở khóa nhập liệu
            if (txtSoLuong.ReadOnly == true)
            {
                BatTatChucNang(true);
                cboTenTiVi.Focus();
                return;
            }

            // 2. Kiểm tra dữ liệu bắt buộc
            if (cboTenTiVi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một loại Tivi!", "Thông báo");
                return;
            }

            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Số Lượng!", "Lỗi");
                return;
            }

            try
            {
                // Lấy số lượng và khuyến mãi từ giao diện
                decimal soLuong = Convert.ToDecimal(txtSoLuong.Text);
                decimal khuyenMai = string.IsNullOrEmpty(txtKhuyenMai.Text) ? 0 : Convert.ToDecimal(txtKhuyenMai.Text);

                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!");
                    return;
                }

                string maTiVi = cboTenTiVi.SelectedValue.ToString();
                decimal donGia = 0;

                // Tự động lấy đơn giá từ DB nếu trên form trống
                if (string.IsNullOrEmpty(txtDonGia.Text))
                {
                    var tivi = context.QuanLyTiVis.Find(maTiVi);
                    if (tivi != null)
                    {
                        donGia = tivi.DonGiaBan;
                        txtDonGia.Text = donGia.ToString();
                    }
                }
                else
                {
                    donGia = Convert.ToDecimal(txtDonGia.Text);
                }

                // Tính thành tiền ban đầu
                decimal thanhTien = (soLuong * donGia) - khuyenMai;

                // Kiểm tra xem Tivi này đã có trong lưới chưa
                var itemExist = hoaDonChiTiet.FirstOrDefault(x => x.MaTiVi == maTiVi);

                if (itemExist != null)
                {
                    // --- ĐÃ FIX Ở ĐÂY ---
                    // Nếu đã có, CẬP NHẬT lại số lượng và khuyến mãi mới (dùng dấu = thay vì +=)
                    itemExist.SoLuongBan = (int)soLuong;
                    itemExist.KhuyenMai = khuyenMai;
                    itemExist.ThanhTien = (itemExist.SoLuongBan * donGia) - itemExist.KhuyenMai;
                    dgvDanhSachHD.Refresh(); // Làm mới lưới để hiện số liệu mới
                }
                else
                {
                    // Nếu chưa có thì thêm một dòng hoàn toàn mới vào lưới
                    hoaDonChiTiet.Add(new DanhSachHoaDonChiTiet
                    {
                        MaTiVi = maTiVi,
                        TenTiVi = cboTenTiVi.Text,
                        SoLuongBan = (int)soLuong,
                        DonGiaBan = donGia,
                        KhuyenMai = khuyenMai,
                        ThanhTien = thanhTien
                    });
                }

                // 3. Cập nhật lại lưới và kiểm tra bật/tắt nút Lưu
                dgvDanhSachHD.DataSource = null;
                dgvDanhSachHD.DataSource = hoaDonChiTiet;
                BatTatChucNang(true);

                // 4. Xóa trắng các ô nhập liệu để chuẩn bị nhập mặt hàng tiếp theo
                txtSoLuong.Clear();
                txtKhuyenMai.Text = "0";
                cboTenTiVi.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ: " + ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHD.CurrentRow != null)
            {
                string maTiVi = dgvDanhSachHD.CurrentRow.Cells["MaTiVi"].Value.ToString();
                var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.MaTiVi == maTiVi);
                if (chiTiet != null)
                {
                    hoaDonChiTiet.Remove(chiTiet);
                    BatTatChucNang(true);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra ràng buộc dữ liệu đầu vào cơ bản
            if (cboNhanVien.SelectedValue == null || cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khách Hàng và Nhân Viên!", "Thông báo");
                return;
            }

            if (hoaDonChiTiet.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất một mặt hàng!", "Thông báo");
                return;
            }

            // 2. Sử dụng Transaction để đảm bảo an toàn dữ liệu (tránh lỗi trừ kho mà không lưu được hóa đơn)
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    HoaDon hd;
                    if (id != 0) // TRƯỜNG HỢP: SỬA HÓA ĐƠN ĐÃ CÓ
                    {
                        hd = context.HoaDons.Find(id);
                        if (hd == null) throw new Exception("Không tìm thấy hóa đơn cần sửa!");

                        hd.MaNhanVien = cboNhanVien.SelectedValue.ToString();
                        hd.MaKhachHang = cboKhachHang.SelectedValue.ToString();
                        hd.NgayLap = dtpNgayLap.Value;
                        hd.GhiChuHoaDon = txtGhiChu.Text;

                        // --- BƯỚC 1: HOÀN TRẢ KHO CŨ ---
                        var oldDetails = context.HoaDonChiTiets.Where(r => r.HoaDonID == id).ToList();
                        foreach (var old in oldDetails)
                        {
                            var tvCu = context.QuanLyTiVis.Find(old.MaTiVi);
                            if (tvCu != null) tvCu.SoLuongTon += old.SoLuongBan; // Cộng lại kho
                        }

                        // Xóa các chi tiết cũ để chuẩn bị ghi đè chi tiết mới
                        context.HoaDonChiTiets.RemoveRange(oldDetails);
                    }
                    else // TRƯỜNG HỢP: THÊM MỚI HÓA ĐƠN
                    {
                        hd = new HoaDon
                        {
                            MaNhanVien = cboNhanVien.SelectedValue.ToString(),
                            MaKhachHang = cboKhachHang.SelectedValue.ToString(),
                            NgayLap = dtpNgayLap.Value,
                            GhiChuHoaDon = txtGhiChu.Text
                        };
                        context.HoaDons.Add(hd);
                    }

                    // LƯU LẦN 1: Để Entity Framework và SQL tạo ID tự động cho hóa đơn
                    context.SaveChanges();

                    // --- BƯỚC 2: DUYỆT DANH SÁCH TRÊN LƯỚI ĐỂ LƯU CHI TIẾT VÀ TRỪ KHO ---
                    foreach (var item in hoaDonChiTiet)
                    {
                        // Thêm chi tiết hóa đơn mới
                        context.HoaDonChiTiets.Add(new HoaDonChiTiet
                        {
                            HoaDonID = hd.ID, // Lấy ID vừa sinh ra ở trên (QUAN TRỌNG)
                            MaTiVi = item.MaTiVi,
                            SoLuongBan = item.SoLuongBan,
                            DonGiaBan = item.DonGiaBan,
                            KhuyenMai = item.KhuyenMai // Đảm bảo không truyền null vào DB
                        });

                        // Cập nhật lại số lượng tồn kho (Trừ kho)
                        var tvMoi = context.QuanLyTiVis.Find(item.MaTiVi);
                        if (tvMoi != null)
                        {
                            tvMoi.SoLuongTon -= item.SoLuongBan;

                            // Kiểm tra nếu kho bị âm thì báo lỗi ngay
                            if (tvMoi.SoLuongTon < 0)
                            {
                                throw new Exception($"Sản phẩm '{item.TenTiVi}' không đủ số lượng trong kho!");
                            }
                        }
                    }

                    // LƯU LẦN 2: Chốt tất cả thay đổi chi tiết và số lượng kho
                    context.SaveChanges();

                    // Xác nhận hoàn tất giao dịch
                    transaction.Commit();

                    MessageBox.Show("Lưu hóa đơn và cập nhật kho thành công!", "Hoàn tất");

                    // Sau khi lưu thành công, khóa form lại
                    BatTatChucNang(false);

                    // Tùy chọn: Đóng form sau khi lưu
                    // this.Close(); 
                }
                catch (Exception ex)
                {
                    // Nếu có bất kỳ lỗi nào, hủy bỏ toàn bộ quá trình (không lưu gì cả, kho không bị trừ bậy)
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTiVi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string maTiVi = cboTenTiVi.SelectedValue.ToString();
            var tivi = context.QuanLyTiVis.Find(maTiVi);

            if (tivi != null)
            {
                // Gán giá trị vào TextBox thì dùng .Text và chuyển số thành chuỗi (.ToString())
                txtDonGia.Text = tivi.DonGiaBan.ToString();
            }
        }

        private void cboTenTiVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Đảm bảo là đã chọn một item
            if (cboTenTiVi.SelectedValue != null)
            {
                string maTiVi = cboTenTiVi.SelectedValue.ToString();
                var tivi = context.QuanLyTiVis.Find(maTiVi);

                if (tivi != null)
                {
                    txtDonGia.Text = tivi.DonGiaBan.ToString();
                }
            }
        }
    }
}
