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
    public partial class frmChiTietHoaDon : Form
    {
        AppDbContext context = new AppDbContext();
        int id; // ID của hóa đơn (nếu = 0 là lập mới, khác 0 là sửa)
        string maNVHienTai = "";
        string maKhachHangHienTai = "";
        BindingList<DanhSachHoaDonChiTiet> hoaDonChiTiet = new BindingList<DanhSachHoaDonChiTiet>();

        // Đã đổi từ Tên sang SĐT để chống lặp Leave
        string sdtKhachHangVuaTim = "";
        public frmChiTietHoaDon(int maHoaDon = 0, string maNhanVienDangNhap = "")
        {
            InitializeComponent();
            id = maHoaDon;
            maNVHienTai = maNhanVienDangNhap;

        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            // Nếu có thông tin đăng nhập tĩnh thì ưu tiên lấy
            if (TaiKhoanHienTai.NhanVienDangNhap != null)
            {
                maNVHienTai = TaiKhoanHienTai.NhanVienDangNhap.MaNhanVien;
            }

            LoadComboBox();
            dgvDanhSachHD.AutoGenerateColumns = false;

            // Gắn sự kiện chỉ cho phép nhập số vào các ô nhập liệu
            txtSoLuong.KeyPress += ChinhNhapSo_KeyPress;
            txtDonGia.KeyPress += ChinhNhapSo_KeyPress;
            txtKhuyenMai.KeyPress += ChinhNhapSo_KeyPress;
            txtLaiSuat.KeyPress += ChinhNhapSo_KeyPress;
            txtKyHanTra.KeyPress += ChinhNhapSo_KeyPress;
            txtSoTienTraTruoc.KeyPress += ChinhNhapSo_KeyPress;

            // YÊU CẦU 3: Phân quyền ngay khi load form
            PhanQuyenNhanVien();

            BatTatChucNang(id != 0);

            // ==========================================
            // CHẾ ĐỘ SỬA: LOAD HÓA ĐƠN CŨ VÀ KHÁCH HÀNG
            // ==========================================
            if (id != 0)
            {
                var hoaDon = context.HoaDons.FirstOrDefault(r => r.ID == id);
                if (hoaDon != null)
                {
                    cboNhanVien.SelectedValue = hoaDon.MaNhanVien;
                    dtpNgayLap.Value = hoaDon.NgayLap;
                    txtGhiChu.Text = hoaDon.GhiChuHoaDon;

                    maKhachHangHienTai = hoaDon.MaKhachHang;
                    var kh = context.KhachHangs.FirstOrDefault(k => k.MaKhachHang == maKhachHangHienTai);
                    if (kh != null)
                    {
                        txtTenKhachHang.Text = kh.TenKhachHang;
                        txtSDT_KhachHang.Text = kh.SoDienThoai;
                        txtCCCD.Text = kh.CCCD;
                        txtDiaChi.Text = kh.DiaChi;
                        dtpNgayThangNamSinh.Value = kh.NgayThangNamSinh;
                    }

                    // ==========================================================
                    // ĐÂY LÀ ĐOẠN CODE MỚI THÊM VÀO ĐỂ FIX LỖI LOAD TRẢ GÓP NÈ:
                    // ==========================================================
                    if (hoaDon.HinhThucThanhToan == "Trả góp")
                    {
                        rdoTraGop.Checked = true;
                        panelTraGop.Enabled = true;

                        // Load lại thông tin khế ước trả góp cũ
                        var thongTinTraGop = context.TraGops.FirstOrDefault(t => t.MaHoaDon == id);
                        if (thongTinTraGop != null)
                        {
                            txtLaiSuat.Text = thongTinTraGop.LaiSuat.ToString();
                            txtKyHanTra.Text = thongTinTraGop.KyHanTra.ToString();
                            txtSoTienTraTruoc.Text = thongTinTraGop.SoTienTraTruoc.ToString("0");
                            txtSoTienConNo.Text = thongTinTraGop.SoTienConNo.ToString("0");
                        }
                    }
                    else if (hoaDon.HinhThucThanhToan == "Chuyển khoản")
                    {
                        rdoChuyenKhoan.Checked = true;
                    }
                    else
                    {
                        rdoTienMat.Checked = true;
                    }
                    // ==========================================================
                    // KẾT THÚC ĐOẠN CODE THÊM MỚI
                    // ==========================================================
                }

                // Load chi tiết giỏ hàng
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

                TinhTienConNo(); // Tính lại nợ nếu là trả góp
            }

            dgvDanhSachHD.DataSource = hoaDonChiTiet;

            // Gắn sự kiện Leave vào ô SĐT thay vì ô Tên
            txtSDT_KhachHang.Leave += txtSDT_KhachHang_Leave;
        }

        public void LoadComboBox()
        {
            cboNhanVien.DataSource = context.NhanViens.ToList();
            cboNhanVien.ValueMember = "MaNhanVien";
            cboNhanVien.DisplayMember = "HoTenNhanVien";
            cboNhanVien.SelectedValue = maNVHienTai;
            cboNhanVien.Enabled = false;

            cboTenTiVi.DataSource = context.QuanLyTiVis.ToList();
            cboTenTiVi.ValueMember = "MaTiVi";
            cboTenTiVi.DisplayMember = "TenTiVi";
            cboTenTiVi.SelectedIndex = -1; // Để trống lúc đầu
        }

        // ==========================================
        // YÊU CẦU 3: PHÂN QUYỀN TRẢ GÓP
        // ==========================================
        private void PhanQuyenNhanVien()
        {
            var nv = TaiKhoanHienTai.NhanVienDangNhap;
            if (nv != null)
            {
                string quyen = nv.QuyenHan != null ? nv.QuyenHan.Trim() : "";

                // Quản lý và NV Trả góp được thao tác Trả góp
                if (quyen == "Quản lý" || quyen == "Nhân viên trả góp")
                {
                    rdoTraGop.Enabled = true;
                }
                else
                {
                    rdoTraGop.Enabled = false;
                    rdoTienMat.Checked = true;
                    panelTraGop.Enabled = false;
                }
            }
        }

        // Ràng buộc chỉ nhập số
        private void ChinhNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập SỐ vào ô này!", "Cảnh báo nhập sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TinhTienConNo()
        {
            if (!rdoTraGop.Checked) return;

            decimal tongTienHoaDon = hoaDonChiTiet.Sum(x => x.ThanhTien);
            decimal traTruoc = 0;

            if (!string.IsNullOrEmpty(txtSoTienTraTruoc.Text))
                decimal.TryParse(txtSoTienTraTruoc.Text, out traTruoc);

            decimal conNo = tongTienHoaDon - traTruoc;

            // Nếu khách trả trước dư tiền, nợ = 0
            txtSoTienConNo.Text = conNo > 0 ? conNo.ToString("0") : "0";
        }


        private void BatTatChucNang(bool dangThaoTac)
        {
            txtSoLuong.ReadOnly = !dangThaoTac;
            txtKhuyenMai.ReadOnly = !dangThaoTac;
            cboTenTiVi.Enabled = dangThaoTac;
            btnXoa.Enabled = dangThaoTac;
            btnThem.Enabled = true;

            btnLuu.Enabled = (dangThaoTac && hoaDonChiTiet.Count > 0);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.ReadOnly == true)
            {
                BatTatChucNang(true);
                cboTenTiVi.Focus();
                return;
            }

            if (cboTenTiVi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một loại Tivi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSoLuong.Text, out decimal soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng hợp lệ (lớn hơn 0)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maTiVi = cboTenTiVi.SelectedValue.ToString();
                var tivi = context.QuanLyTiVis.Find(maTiVi);

                if (tivi == null) return;

                // Tính tồn kho thực tế (cộng trả lại số lượng khách đã mua trước đó nếu đang sửa hóa đơn cũ)
                decimal soLuongKhachDaMuaTruocDo = 0;
                if (id != 0)
                {
                    var oldDetail = context.HoaDonChiTiets.AsNoTracking().FirstOrDefault(r => r.HoaDonID == id && r.MaTiVi == maTiVi);
                    if (oldDetail != null)
                        soLuongKhachDaMuaTruocDo = oldDetail.SoLuongBan;
                }

                decimal tonKhoThucTe = tivi.SoLuongTon + soLuongKhachDaMuaTruocDo;

                if (tonKhoThucTe == 0)
                {
                    MessageBox.Show("Rất tiếc! Tivi này hiện đã hết hàng trong kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (soLuong > tonKhoThucTe)
                {
                    MessageBox.Show($"Kho không đủ! Tổng số lượng tối đa bạn có thể xuất cho mặt hàng này là {tonKhoThucTe}.", "Lỗi số lượng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ==========================================
                // FIX LOGIC: TÍNH TOÁN TIỀN VÀ KHUYẾN MÃI
                // ==========================================
                decimal donGia = tivi.DonGiaBan;

                // Ưu tiên lấy số tiền Khuyến Mãi từ ô Textbox do nhân viên tự nhập/sửa
                decimal khuyenMai1SP = 0;
                if (!string.IsNullOrWhiteSpace(txtKhuyenMai.Text))
                {
                    decimal.TryParse(txtKhuyenMai.Text, out khuyenMai1SP);
                }

                // Kiểm tra an toàn: Không cho phép khuyến mãi lố tiền sản phẩm
                if (khuyenMai1SP > donGia)
                {
                    MessageBox.Show("Số tiền khuyến mãi không thể lớn hơn đơn giá sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal tongKhuyenMai = khuyenMai1SP * soLuong;
                decimal thanhTien = (soLuong * donGia) - tongKhuyenMai;

                // ==========================================
                // CẬP NHẬT VÀO LƯỚI DATA GRID VIEW
                // ==========================================
                var itemExist = hoaDonChiTiet.FirstOrDefault(x => x.MaTiVi == maTiVi);

                if (itemExist != null)
                {
                    // NẾU ĐÃ CÓ TRONG GIỎ -> ĐÂY LÀ HÀNH ĐỘNG SỬA
                    itemExist.SoLuongBan = (int)soLuong;
                    itemExist.DonGiaBan = donGia;
                    itemExist.KhuyenMai = tongKhuyenMai;
                    itemExist.ThanhTien = thanhTien;
                }
                else
                {
                    // NẾU CHƯA CÓ TRONG GIỎ -> ĐÂY LÀ HÀNH ĐỘNG THÊM MỚI
                    hoaDonChiTiet.Add(new DanhSachHoaDonChiTiet
                    {
                        MaTiVi = maTiVi,
                        TenTiVi = tivi.TenTiVi,
                        SoLuongBan = (int)soLuong,
                        DonGiaBan = donGia,
                        KhuyenMai = tongKhuyenMai,
                        ThanhTien = thanhTien
                    });
                }

                // Refresh lại lưới để hiển thị dữ liệu mới
                hoaDonChiTiet.ResetBindings();

                BatTatChucNang(true);
                TinhTienConNo();

                // Reset lại form nhập liệu để chuẩn bị cho món hàng tiếp theo
                txtSoLuong.Clear();
                txtKhuyenMai.Text = "0";
                txtDonGia.Clear();
                cboTenTiVi.Enabled = true; // Mở lại Combobox
                cboTenTiVi.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHD.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Tivi này khỏi hóa đơn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string maTiVi = dgvDanhSachHD.CurrentRow.Cells["MaTiVi"].Value.ToString();
                    var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.MaTiVi == maTiVi);
                    if (chiTiet != null)
                    {
                        hoaDonChiTiet.Remove(chiTiet);
                        BatTatChucNang(true);
                        TinhTienConNo(); // Cập nhật lại nợ
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // === 1. KIỂM TRA DỮ LIỆU ĐẦU VÀO ===
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text) || string.IsNullOrWhiteSpace(txtSDT_KhachHang.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên, SĐT và CCCD của Khách Hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (hoaDonChiTiet.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 TiVi vào giỏ hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdoTraGop.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtLaiSuat.Text) || string.IsNullOrWhiteSpace(txtKyHanTra.Text) || string.IsNullOrWhiteSpace(txtSoTienTraTruoc.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Lãi Suất, Kỳ Hạn và Tiền Trả Trước!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // === 2. XÁC ĐỊNH HÌNH THỨC THANH TOÁN ===
            string hinhThuc = rdoTraGop.Checked ? "Trả góp" : (rdoChuyenKhoan.Checked ? "Chuyển khoản" : "Tiền mặt");

            // === BẮT ĐẦU TRANSACTION ĐỂ LƯU DỮ LIỆU AN TOÀN ===
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // --- 3. XỬ LÝ KHÁCH HÀNG ---
                    if (string.IsNullOrEmpty(maKhachHangHienTai))
                    {
                        // Thêm mới
                        KhachHang khMoi = new KhachHang
                        {
                            MaKhachHang = "KH" + DateTime.Now.ToString("ddMMyyHHmmss"),
                            TenKhachHang = txtTenKhachHang.Text.Trim(),
                            SoDienThoai = txtSDT_KhachHang.Text.Trim(),
                            CCCD = txtCCCD.Text.Trim(),
                            DiaChi = txtDiaChi.Text.Trim(),
                            NgayThangNamSinh = dtpNgayThangNamSinh.Value
                        };
                        context.KhachHangs.Add(khMoi);
                        context.SaveChanges();
                        maKhachHangHienTai = khMoi.MaKhachHang;
                    }
                    else
                    {
                        // FIX LỖI: Khách cũ nhưng có thể họ thay đổi Địa chỉ/CCCD trực tiếp trên Form -> Phải update lại
                        var khCu = context.KhachHangs.Find(maKhachHangHienTai);
                        if (khCu != null)
                        {
                            khCu.TenKhachHang = txtTenKhachHang.Text.Trim();
                            khCu.CCCD = txtCCCD.Text.Trim();
                            khCu.DiaChi = txtDiaChi.Text.Trim();
                            khCu.NgayThangNamSinh = dtpNgayThangNamSinh.Value;
                            // Tạm chưa gọi SaveChanges, để chung xuống dưới
                        }
                    }

                    // --- 4. XỬ LÝ HÓA ĐƠN VÀ CHI TIẾT ---
                    HoaDon hd;
                    if (id != 0) // Chế độ sửa hóa đơn cũ
                    {
                        hd = context.HoaDons.Find(id);
                        hd.MaKhachHang = maKhachHangHienTai;
                        hd.NgayLap = dtpNgayLap.Value;
                        hd.GhiChuHoaDon = txtGhiChu.Text;
                        hd.HinhThucThanhToan = hinhThuc; // LƯU HÌNH THỨC VÀO DB

                        // Hoàn trả lại số lượng tồn kho cũ trước khi cập nhật mới
                        var oldDetails = context.HoaDonChiTiets.Where(r => r.HoaDonID == id).ToList();
                        foreach (var old in oldDetails)
                        {
                            var tvCu = context.QuanLyTiVis.Find(old.MaTiVi);
                            if (tvCu != null) tvCu.SoLuongTon += old.SoLuongBan;
                        }
                        context.HoaDonChiTiets.RemoveRange(oldDetails);
                    }
                    else // Chế độ lập mới
                    {
                        hd = new HoaDon
                        {
                            MaNhanVien = maNVHienTai,
                            MaKhachHang = maKhachHangHienTai,
                            NgayLap = dtpNgayLap.Value,
                            GhiChuHoaDon = txtGhiChu.Text,
                            HinhThucThanhToan = hinhThuc // LƯU HÌNH THỨC VÀO DB
                        };
                        context.HoaDons.Add(hd);
                    }
                    context.SaveChanges(); // Lấy ID hóa đơn (nếu thêm mới) và cập nhật tồn kho tạm thời

                    // Lưu chi tiết hóa đơn và trừ tồn kho
                    decimal tongTienHoaDon = 0;
                    foreach (var item in hoaDonChiTiet)
                    {
                        tongTienHoaDon += item.ThanhTien;

                        context.HoaDonChiTiets.Add(new HoaDonChiTiet
                        {
                            HoaDonID = hd.ID,
                            MaTiVi = item.MaTiVi,
                            SoLuongBan = item.SoLuongBan,
                            DonGiaBan = item.DonGiaBan,
                            KhuyenMai = item.KhuyenMai
                        });

                        // TRỪ TỒN KHO TIVI
                        var tvMoi = context.QuanLyTiVis.Find(item.MaTiVi);
                        if (tvMoi != null)
                        {
                            tvMoi.SoLuongTon -= item.SoLuongBan;
                            if (tvMoi.SoLuongTon < 0) throw new Exception($"Sản phẩm '{item.TenTiVi}' không đủ số lượng trong kho!");
                        }
                    }
                    context.SaveChanges();

                    // --- 5. XỬ LÝ TRẢ GÓP & LỊCH TRẢ GÓP ---
                    if (rdoTraGop.Checked)
                    {
                        // FIX LỖI: Dùng TryParse để an toàn, tránh văng lỗi nếu lỡ bị dính ký tự lạ
                        decimal.TryParse(txtSoTienTraTruoc.Text, out decimal traTruoc);
                        int.TryParse(txtKyHanTra.Text, out int kyHan);
                        decimal.TryParse(txtLaiSuat.Text, out decimal laiSuat);

                        if (kyHan <= 0) throw new Exception("Kỳ hạn trả góp phải lớn hơn 0 tháng!");

                        decimal conNo = tongTienHoaDon - traTruoc;

                        // Nếu sửa hóa đơn, xóa phiếu trả góp cũ đi tạo lại
                        var oldTraGop = context.TraGops.FirstOrDefault(t => t.MaHoaDon == hd.ID);
                        if (oldTraGop != null)
                        {
                            var oldCTTraGop = context.ChiTietTraGops.Where(c => c.TraGopID == oldTraGop.ID).ToList();
                            context.ChiTietTraGops.RemoveRange(oldCTTraGop);
                            context.TraGops.Remove(oldTraGop);
                            context.SaveChanges();
                        }

                        // Tạo phiếu trả góp mới
                        var phieuTraGop = new TraGop
                        {
                            MaHoaDon = hd.ID,
                            LaiSuat = laiSuat,
                            KyHanTra = kyHan,
                            SoTienTraTruoc = traTruoc,
                            SoTienConNo = conNo > 0 ? conNo : 0,
                            PhiPhuThuDinhKy = 0
                        };
                        context.TraGops.Add(phieuTraGop);
                        context.SaveChanges(); // Phải Save để sinh ra ID

                        // Tự động sinh Lịch trả góp
                        if (conNo > 0)
                        {
                            decimal tienGocMoiKy = conNo / kyHan;
                            // FIX LỖI ÉP KIỂU: 100m
                            decimal tienLaiMoiKy = conNo * (laiSuat / 100m);

                            for (int i = 1; i <= kyHan; i++)
                            {
                                var chiTiet = new ChiTietTraGop
                                {
                                    TraGopID = phieuTraGop.ID,
                                    MaTraGop = phieuTraGop.ID,
                                    KyThu = i,
                                    NgayCanDong = hd.NgayLap.AddMonths(i),
                                    SoTienGoc = Math.Round(tienGocMoiKy, 0),
                                    SoTienLai = Math.Round(tienLaiMoiKy, 0),
                                    TongTienDong = Math.Round(tienGocMoiKy + tienLaiMoiKy, 0),
                                    SoTienDaDong = 0,
                                    SoTienPhat = 0
                                };
                                context.ChiTietTraGops.Add(chiTiet);
                            }
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        // FIX LỖI ĐẶC BIỆT: 
                        // Nếu đây là đang "SỬA" hóa đơn, từ "Trả Góp" khách đổi thành "Tiền Mặt"
                        // => Bắt buộc phải clear dữ liệu Trả góp cũ của hóa đơn này trong Database
                        if (id != 0)
                        {
                            var oldTraGop = context.TraGops.FirstOrDefault(t => t.MaHoaDon == hd.ID);
                            if (oldTraGop != null)
                            {
                                var oldCTTraGop = context.ChiTietTraGops.Where(c => c.TraGopID == oldTraGop.ID).ToList();
                                context.ChiTietTraGops.RemoveRange(oldCTTraGop);
                                context.TraGops.Remove(oldTraGop);
                                context.SaveChanges();
                            }
                        }
                    }

                    // HOÀN TẤT GIAO DỊCH
                    transaction.Commit();
                    MessageBox.Show("Lưu hóa đơn thành công! Dữ liệu đã được cập nhật.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       



        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHD.CurrentRow != null && dgvDanhSachHD.CurrentRow.Index >= 0)
            {
                string maTiVi = dgvDanhSachHD.CurrentRow.Cells["MaTiVi"].Value.ToString();
                var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.MaTiVi == maTiVi);

                if (chiTiet != null)
                {
                    cboTenTiVi.SelectedValue = chiTiet.MaTiVi;
                    txtSoLuong.Text = chiTiet.SoLuongBan.ToString();

                    // Hiển thị lại số tiền Khuyến Mãi của 1 sản phẩm (Tổng KM / Số Lượng)
                    decimal km1sp = chiTiet.SoLuongBan > 0 ? (chiTiet.KhuyenMai / chiTiet.SoLuongBan) : 0;
                    txtKhuyenMai.Text = km1sp.ToString("0");

                    txtDonGia.Text = chiTiet.DonGiaBan.ToString("0");

                    BatTatChucNang(true);

                    // Khóa ComboBox Tên Tivi lại để khi đang sửa thì không được đổi sang Tivi khác
                    cboTenTiVi.Enabled = false;
                    txtSoLuong.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng dưới danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboTenTiVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenTiVi.SelectedValue == null || cboTenTiVi.SelectedValue.GetType() != typeof(string))
                return;

            string maTiVi = cboTenTiVi.SelectedValue.ToString();
            var tivi = context.QuanLyTiVis.Find(maTiVi);

            if (tivi != null)
            {
                lblTonKho.Text = $"(Tồn kho: {tivi.SoLuongTon})";
                lblTonKho.ForeColor = tivi.SoLuongTon > 0 ? Color.Green : Color.Red;

                txtDonGia.Text = tivi.DonGiaBan.ToString("0");

                // FIX LỖI: Ép kiểu decimal (100m) để không bị lỗi chia số nguyên = 0
                decimal phanTramKM = Convert.ToDecimal(tivi.KhuyenMai);
                decimal tienKhuyenMai1SP = tivi.DonGiaBan * (phanTramKM / 100m);

                txtKhuyenMai.Text = tienKhuyenMai1SP.ToString("0");
                txtSoLuong.Focus();
            }
            else
            {
                lblTonKho.Text = "";
                txtDonGia.Clear();
                txtKhuyenMai.Clear();
            }

        }

       

        private void txtSoTienTraTruoc_TextChanged(object sender, EventArgs e)
        {
            TinhTienConNo();
        }

        private void rdoTraGop_CheckedChanged(object sender, EventArgs e)
        {
            panelTraGop.Enabled = rdoTraGop.Checked;
            TinhTienConNo();

        }
        private void rdoTienMat_CheckedChanged(object sender, EventArgs e)
        {
            // Tắt panel trả góp nếu chọn Tiền mặt
            if (rdoTienMat.Checked)
            {
                panelTraGop.Enabled = false;
            }
        }
        private void rdoChuyenKhoan_CheckedChanged(object sender, EventArgs e)
        {
            // Tắt panel trả góp nếu chọn Chuyển khoản
            if (rdoChuyenKhoan.Checked)
            {
                panelTraGop.Enabled = false;
            }
        }
        private void txtSDT_KhachHang_Leave(object sender, EventArgs e)
        {
            string sdt = txtSDT_KhachHang.Text.Trim();

            // Nếu ô trống HOẶC sdt này vừa mới tìm xong rồi thì bỏ qua luôn
            if (string.IsNullOrEmpty(sdt) || sdt == sdtKhachHangVuaTim)
                return;

            var kh = context.KhachHangs.FirstOrDefault(k => k.SoDienThoai == sdt);

            if (kh != null)
            {
                // Điền thông tin cũ vào các ô
                txtTenKhachHang.Text = kh.TenKhachHang;
                txtCCCD.Text = kh.CCCD;
                txtDiaChi.Text = kh.DiaChi;
                dtpNgayThangNamSinh.Value = kh.NgayThangNamSinh;

                maKhachHangHienTai = kh.MaKhachHang;

                // Gán sdt đã tìm để lần sau không bị lặp
                sdtKhachHangVuaTim = sdt;

                MessageBox.Show("Đã tìm thấy thông tin Khách hàng cũ qua Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu không tìm thấy, làm sạch các ô để nhập khách mới (Giữ nguyên SĐT họ vừa nhập)
                txtTenKhachHang.Clear();
                txtCCCD.Clear();
                txtDiaChi.Clear();
                dtpNgayThangNamSinh.Value = DateTime.Now;
                maKhachHangHienTai = "";

                // Gán sdt đã tìm để nếu khách cứ click ra click vào ô này cũng không popup
                sdtKhachHangVuaTim = sdt;
            }
        }
    }
}

