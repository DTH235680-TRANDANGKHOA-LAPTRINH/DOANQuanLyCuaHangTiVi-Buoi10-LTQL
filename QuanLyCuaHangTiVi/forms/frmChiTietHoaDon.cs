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

            // [MỚI] Tự động gán sự kiện chặn nhập chữ cho các TextBox trực tiếp bằng code
            txtSoLuong.KeyPress += ChinhNhapSo_KeyPress;
            txtDonGia.KeyPress += ChinhNhapSo_KeyPress;
            txtKhuyenMai.KeyPress += ChinhNhapSo_KeyPress;

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

                hoaDonChiTiet.Clear();
                foreach (var item in ct) hoaDonChiTiet.Add(item);
            }

            dgvDanhSachHD.DataSource = hoaDonChiTiet;

        }
        private void ChinhNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu phím bấm không phải là số, không phải phím điều khiển (như Backspace) và không phải dấu chấm
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Hủy thao tác nhập ký tự đó

                // HIỆN THÔNG BÁO NGAY LẬP TỨC
                MessageBox.Show("Bạn chỉ được phép nhập số vào ô này!", "Cảnh báo nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chỉ cho phép nhập 1 dấu chấm thập phân duy nhất
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; // Hủy thao tác nhập dấu chấm thứ 2

                // HIỆN THÔNG BÁO KHI NHẬP DƯ DẤU CHẤM
                MessageBox.Show("Chỉ được nhập một dấu chấm thập phân!", "Cảnh báo nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                decimal soLuong = Convert.ToDecimal(txtSoLuong.Text);
                decimal khuyenMai = string.IsNullOrEmpty(txtKhuyenMai.Text) ? 0 : Convert.ToDecimal(txtKhuyenMai.Text);

                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!");
                    return;
                }

                string maTiVi = cboTenTiVi.SelectedValue.ToString();
                var tivi = context.QuanLyTiVis.Find(maTiVi);
                decimal donGia = 0;

                if (tivi != null)
                {
                    // =========================================================================
                    // [MỚI] TÍNH NĂNG 2: KIỂM TRA SỐ LƯỢNG TỒN KHO TRƯỚC KHI CHO THÊM VÀO GIỎ
                    // =========================================================================
                    if (tivi.SoLuongTon == 0)
                    {
                        MessageBox.Show("Rất tiếc! Tivi này hiện đã hết hàng trong kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (soLuong > tivi.SoLuongTon)
                    {
                        MessageBox.Show($"Trong kho chỉ còn {tivi.SoLuongTon} sản phẩm. Không đủ số lượng bạn yêu cầu!", "Lỗi số lượng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    donGia = tivi.DonGiaBan;
                    txtDonGia.Text = donGia.ToString();
                }

                decimal thanhTien = (soLuong * donGia) - khuyenMai;
                var itemExist = hoaDonChiTiet.FirstOrDefault(x => x.MaTiVi == maTiVi);

                if (itemExist != null)
                {
                    itemExist.SoLuongBan = (int)soLuong;
                    itemExist.KhuyenMai = khuyenMai;
                    itemExist.ThanhTien = (itemExist.SoLuongBan * donGia) - itemExist.KhuyenMai;
                    dgvDanhSachHD.Refresh();
                }
                else
                {
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

                dgvDanhSachHD.DataSource = null;
                dgvDanhSachHD.DataSource = hoaDonChiTiet;
                BatTatChucNang(true);

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
                // =========================================================================
                // [MỚI] TÍNH NĂNG 3: HIỆN THÔNG BÁO XÁC NHẬN KHI XÓA KHỎI GIỎ HÀNG
                // =========================================================================
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Tivi này khỏi hóa đơn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
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
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
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

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    HoaDon hd;
                    if (id != 0)
                    {
                        hd = context.HoaDons.Find(id);
                        if (hd == null) throw new Exception("Không tìm thấy hóa đơn cần sửa!");

                        hd.MaNhanVien = cboNhanVien.SelectedValue.ToString();
                        hd.MaKhachHang = cboKhachHang.SelectedValue.ToString();
                        hd.NgayLap = dtpNgayLap.Value;
                        hd.GhiChuHoaDon = txtGhiChu.Text;

                        var oldDetails = context.HoaDonChiTiets.Where(r => r.HoaDonID == id).ToList();
                        foreach (var old in oldDetails)
                        {
                            var tvCu = context.QuanLyTiVis.Find(old.MaTiVi);
                            if (tvCu != null) tvCu.SoLuongTon += old.SoLuongBan;
                        }
                        context.HoaDonChiTiets.RemoveRange(oldDetails);
                    }
                    else
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

                    context.SaveChanges();

                    foreach (var item in hoaDonChiTiet)
                    {
                        context.HoaDonChiTiets.Add(new HoaDonChiTiet
                        {
                            HoaDonID = hd.ID,
                            MaTiVi = item.MaTiVi,
                            SoLuongBan = item.SoLuongBan,
                            DonGiaBan = item.DonGiaBan,
                            KhuyenMai = item.KhuyenMai
                        });

                        var tvMoi = context.QuanLyTiVis.Find(item.MaTiVi);
                        if (tvMoi != null)
                        {
                            tvMoi.SoLuongTon -= item.SoLuongBan;
                            if (tvMoi.SoLuongTon < 0)
                            {
                                throw new Exception($"Sản phẩm '{item.TenTiVi}' không đủ số lượng trong kho!");
                            }
                        }
                    }

                    context.SaveChanges();
                    transaction.Commit();

                    MessageBox.Show("Lưu hóa đơn và cập nhật kho thành công!", "Hoàn tất");
                    BatTatChucNang(false);
                }
                catch (Exception ex)
                {
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
            if (cboTenTiVi.SelectedValue != null)
            {
                string maTiVi = cboTenTiVi.SelectedValue.ToString();
                var tivi = context.QuanLyTiVis.Find(maTiVi);

                if (tivi != null)
                {
                    txtDonGia.Text = tivi.DonGiaBan.ToString();

                    // =========================================================================
                    // [MỚI] TÍNH NĂNG 4: NHẬN BIẾT BÁN CHẠY/ CHẬM & THÔNG BÁO TỒN KHO LÊN LABEL
                    // =========================================================================
                    int tongDaBan = context.HoaDonChiTiets.Where(ct => ct.MaTiVi == maTiVi).Sum(ct => (int?)ct.SoLuongBan) ?? 0;
                    string doHot = tongDaBan >= 20 ? "🔥 Rất được ưa chuộng" : "❄️ Mức bán bình thường";

                    // (Đảm bảo bạn đã tạo 1 Label tên là lblTrangThaiTiVi trên giao diện như Hướng dẫn Bước 1)
                    if (lblTrangThaiTiVi != null)
                    {
                        lblTrangThaiTiVi.Text = $"Kho còn: {tivi.SoLuongTon} cái | {tivi.TrangThai} | {doHot}";
                        lblTrangThaiTiVi.ForeColor = tivi.SoLuongTon == 0 ? Color.Red : Color.Green;
                    }
                }
            }
        }

        private void btnThemKhachNhanh_Click(object sender, EventArgs e)
        {
            // Thay frmKhachHang bằng tên Form Quản lý khách hàng thực tế của bạn
            using (frmKhachHang fKhachHang = new frmKhachHang())
            {
                fKhachHang.ShowDialog(); // Mở Form Khách lên

                // Load lại dữ liệu vào ComboBox sau khi Form Khách Hàng đóng lại
                cboKhachHang.DataSource = null;
                cboKhachHang.DataSource = context.KhachHangs.ToList();
                cboKhachHang.ValueMember = "MaKhachHang";
                cboKhachHang.DisplayMember = "TenKhachHang";

                // Tự động focus vào người khách cuối cùng vừa mới tạo
                var khachMoiNhat = context.KhachHangs.OrderByDescending(k => k.MaKhachHang).FirstOrDefault();
                if (khachMoiNhat != null)
                {
                    cboKhachHang.SelectedValue = khachMoiNhat.MaKhachHang;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn dòng nào trên DataGridView chưa
            if (dgvDanhSachHD.CurrentRow != null && dgvDanhSachHD.CurrentRow.Index >= 0)
            {
                // Lấy Mã TiVi từ dòng đang chọn (Đảm bảo cột chứa mã TiVi tên là "MaTiVi")
                string maTiVi = dgvDanhSachHD.CurrentRow.Cells["MaTiVi"].Value.ToString();

                // 2. Tìm sản phẩm đó trong danh sách giỏ hàng (BindingList)
                var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.MaTiVi == maTiVi);

                if (chiTiet != null)
                {
                    // 3. Đưa thông tin từ dưới lưới ngược lên các ô nhập liệu
                    cboTenTiVi.SelectedValue = chiTiet.MaTiVi;
                    txtSoLuong.Text = chiTiet.SoLuongBan.ToString();
                    txtKhuyenMai.Text = chiTiet.KhuyenMai.ToString();
                    txtDonGia.Text = chiTiet.DonGiaBan.ToString();

                    // Mở khóa các ô nhập liệu để người dùng thao tác
                    BatTatChucNang(true);

                    // [Tùy chọn UX] Khóa ComboBox TiVi lại để người dùng chỉ được sửa Số Lượng/Khuyến Mãi
                    // Tránh việc họ chọn nhầm sang TiVi khác gây lỗi logic sửa. 
                    // Nút "Thêm" sau khi chạy xong sẽ tự động mở khóa lại ComboBox này.
                    cboTenTiVi.Enabled = false;

                    // Focus con trỏ chuột vào ô Số lượng để tiện gõ luôn
                    txtSoLuong.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng trong danh sách bên dưới để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

