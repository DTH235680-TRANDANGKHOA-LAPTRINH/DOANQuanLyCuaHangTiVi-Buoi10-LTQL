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
        public frmChiTietHoaDon(int maHoaDon = 0, string maNhanVienDangNhap = "")
        {
            InitializeComponent();
            id = maHoaDon;
            maNVHienTai = maNhanVienDangNhap;

        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;

            if (TaiKhoanHienTai.NhanVienDangNhap != null)
            {
                maNVHienTai = TaiKhoanHienTai.NhanVienDangNhap.MaNhanVien;
            }

            LoadComboBox();
            dgvDanhSachHD.AutoGenerateColumns = false;

            // [FIX] Hủy event trước khi gán để tránh lỗi trigger 2 lần (nếu Designer lỡ gán rồi)
            txtSoLuong.KeyPress -= ChinhNhapSo_KeyPress;
            txtDonGia.KeyPress -= ChinhNhapSo_KeyPress;
            txtKhuyenMai.KeyPress -= ChinhNhapSo_KeyPress;
            txtLaiSuat.KeyPress -= ChinhNhapSo_KeyPress;
            txtKyHanTra.KeyPress -= ChinhNhapSo_KeyPress;
            txtSoTienTraTruoc.KeyPress -= ChinhNhapSo_KeyPress;
            txtSDT_KhachHang.TextChanged -= txtSDT_KhachHang_TextChanged;

            // Gắn sự kiện
            txtSoLuong.KeyPress += ChinhNhapSo_KeyPress;
            txtDonGia.KeyPress += ChinhNhapSo_KeyPress;
            txtKhuyenMai.KeyPress += ChinhNhapSo_KeyPress;
            txtLaiSuat.KeyPress += ChinhNhapSo_KeyPress;
            txtKyHanTra.KeyPress += ChinhNhapSo_KeyPress;
            txtSoTienTraTruoc.KeyPress += ChinhNhapSo_KeyPress;
            txtSDT_KhachHang.TextChanged += txtSDT_KhachHang_TextChanged;

            PhanQuyenNhanVien();
            BatTatChucNang(id != 0);

            // CHẾ ĐỘ SỬA: LOAD HÓA ĐƠN CŨ VÀ KHÁCH HÀNG

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

                    if (hoaDon.HinhThucThanhToan == "Trả góp")
                    {
                        rdoTraGop.Checked = true;
                        panelTraGop.Enabled = true;

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

                TinhTienConNo();
            }

            dgvDanhSachHD.DataSource = hoaDonChiTiet;
            txtLaiSuat.TextChanged += txtLaiSuat_TextChanged;
        }

        public void LoadComboBox()
        {
            // [FIX] Cần khai báo ValueMember và DisplayMember TRƯỚC DataSource
            cboNhanVien.ValueMember = "MaNhanVien";
            cboNhanVien.DisplayMember = "HoTenNhanVien";
            cboNhanVien.DataSource = context.NhanViens.ToList();
            cboNhanVien.SelectedValue = maNVHienTai;
            cboNhanVien.Enabled = false;

            cboTenTiVi.ValueMember = "MaTiVi";
            cboTenTiVi.DisplayMember = "TenTiVi";
            cboTenTiVi.DataSource = context.QuanLyTiVis.ToList();
            cboTenTiVi.SelectedIndex = -1; // Để trống lúc đầu
        }

        private void PhanQuyenNhanVien()
        {
            var nv = TaiKhoanHienTai.NhanVienDangNhap;
            if (nv != null)
            {
                string quyen = nv.QuyenHan != null ? nv.QuyenHan.Trim() : "";

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
            else
            {
                // [FIX] Đề phòng trường hợp nv null thì khóa luôn
                rdoTraGop.Enabled = false;
                rdoTienMat.Checked = true;
                panelTraGop.Enabled = false;
            }
        }

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

            // 1. Lấy tổng tiền hóa đơn
            decimal tongTienHoaDon = hoaDonChiTiet.Sum(x => x.ThanhTien);
            decimal traTruoc = 0;
            decimal laiSuat = 0;

            // 2. Lấy số tiền trả trước và lãi suất từ TextBox
            if (!string.IsNullOrEmpty(txtSoTienTraTruoc.Text))
                decimal.TryParse(txtSoTienTraTruoc.Text, out traTruoc);

            if (!string.IsNullOrEmpty(txtLaiSuat.Text))
                decimal.TryParse(txtLaiSuat.Text, out laiSuat);

            // 3. Tính Nợ gốc
            decimal noGoc = tongTienHoaDon - traTruoc;
            if (noGoc < 0) noGoc = 0;

            // 4. Tính Tiền lãi và Tổng nợ (Gốc + Lãi)
            decimal tienLai = noGoc * (laiSuat / 100m);
            decimal tongNo = noGoc + tienLai;

            // 5. Hiển thị lên UI
            txtSoTienConNo.Text = tongNo > 0 ? tongNo.ToString("0") : "0";
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

        // Thêm hàm reset UI nhỏ để dọn dẹp các control nhập liệu sau khi thêm/xóa xong
        private void ClearInputs()
        {
            txtSoLuong.Clear();
            txtKhuyenMai.Text = "0";
            txtDonGia.Clear();
            cboTenTiVi.SelectedIndex = -1;
            cboTenTiVi.Enabled = true;
            lblTonKho.Text = "";
            cboTenTiVi.Focus();
        }
        private string GenerateMaKhachHang(AppDbContext dbContext)
        {
            var dsMaKH = dbContext.KhachHangs.Select(k => k.MaKhachHang).ToList();

            if (dsMaKH.Count == 0)
            {
                return "KH001";
            }

            int maxId = 0;
            foreach (var ma in dsMaKH)
            {
                if (ma.StartsWith("KH") && ma.Length > 2)
                {
                    string soPhanDuoi = ma.Substring(2);
                    if (int.TryParse(soPhanDuoi, out int so))
                    {
                        if (so > maxId)
                        {
                            maxId = so;
                        }
                    }
                }
            }
            return "KH" + (maxId + 1).ToString("D3");
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

            //Tivi phải là số nguyên (int), không dùng decimal
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng hợp lệ (lớn hơn 0)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maTiVi = cboTenTiVi.SelectedValue.ToString();
                var tivi = context.QuanLyTiVis.Find(maTiVi);

                if (tivi == null) return;

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

                decimal donGia = tivi.DonGiaBan;
                decimal khuyenMai1SP = 0;
                if (!string.IsNullOrWhiteSpace(txtKhuyenMai.Text))
                {
                    decimal.TryParse(txtKhuyenMai.Text, out khuyenMai1SP);
                }

                if (khuyenMai1SP > donGia)
                {
                    MessageBox.Show("Số tiền khuyến mãi không thể lớn hơn đơn giá sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal tongKhuyenMai = khuyenMai1SP * soLuong;
                decimal thanhTien = (soLuong * donGia) - tongKhuyenMai;

                var itemExist = hoaDonChiTiet.FirstOrDefault(x => x.MaTiVi == maTiVi);

                if (itemExist != null)
                {
                    itemExist.SoLuongBan = soLuong;
                    itemExist.DonGiaBan = donGia;
                    itemExist.KhuyenMai = tongKhuyenMai;
                    itemExist.ThanhTien = thanhTien;
                }
                else
                {
                    hoaDonChiTiet.Add(new DanhSachHoaDonChiTiet
                    {
                        MaTiVi = maTiVi,
                        TenTiVi = tivi.TenTiVi,
                        SoLuongBan = soLuong,
                        DonGiaBan = donGia,
                        KhuyenMai = tongKhuyenMai,
                        ThanhTien = thanhTien
                    });
                }

                hoaDonChiTiet.ResetBindings();

                BatTatChucNang(true);
                TinhTienConNo();

                //Tái sử dụng hàm dọn dẹp
                ClearInputs();
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
                        TinhTienConNo();
                        ClearInputs(); // [FIX] Xóa thông tin Sửa đang hiển thị thừa (nếu có)
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {


            // 1. KIỂM TRA GIỎ HÀNG
            if (hoaDonChiTiet.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống, vui lòng thêm sản phẩm trước khi lưu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. KIỂM TRA ĐẦU VÀO TRẢ GÓP
            decimal laiSuat = 0, traTruoc = 0;
            int kyHan = 0;
            if (rdoTraGop.Checked)
            {
                if (!decimal.TryParse(txtLaiSuat.Text, out laiSuat) ||
                    !int.TryParse(txtKyHanTra.Text, out kyHan) ||
                    !decimal.TryParse(txtSoTienTraTruoc.Text, out traTruoc))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng số cho Lãi suất, Kỳ hạn và Tiền trả trước!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (kyHan <= 0)
                {
                    MessageBox.Show("Kỳ hạn trả góp phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 3. THỰC HIỆN LƯU VỚI TRANSACTION
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            string hinhThucThanhToan = rdoTraGop.Checked ? "Trả góp" : (rdoChuyenKhoan.Checked ? "Chuyển khoản" : "Tiền mặt");


                            // 3.1: XỬ LÝ KHÁCH HÀNG

                            if (string.IsNullOrEmpty(maKhachHangHienTai))
                            {
                                if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text) || string.IsNullOrWhiteSpace(txtSDT_KhachHang.Text))
                                {
                                    MessageBox.Show("Vui lòng nhập Tên và Số điện thoại khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                KhachHang khMoi = new KhachHang
                                {
                                    // Gọi hàm GenerateMaKhachHang ở đây
                                    MaKhachHang = GenerateMaKhachHang(db),
                                    TenKhachHang = txtTenKhachHang.Text,
                                    SoDienThoai = txtSDT_KhachHang.Text,
                                    CCCD = txtCCCD.Text,
                                    DiaChi = txtDiaChi.Text,
                                    NgayThangNamSinh = dtpNgayThangNamSinh.Value
                                };
                                db.KhachHangs.Add(khMoi);
                                db.SaveChanges();
                                maKhachHangHienTai = khMoi.MaKhachHang;
                            }
                            else
                            {
                                // Cập nhật thông tin khách hàng nếu người dùng có sửa trên màn hình
                                var khCu = db.KhachHangs.FirstOrDefault(k => k.MaKhachHang == maKhachHangHienTai);
                                if (khCu != null)
                                {
                                    khCu.TenKhachHang = txtTenKhachHang.Text;
                                    khCu.CCCD = txtCCCD.Text;
                                    khCu.DiaChi = txtDiaChi.Text;
                                    khCu.NgayThangNamSinh = dtpNgayThangNamSinh.Value;
                                    db.SaveChanges();
                                }
                            }


                            //  3.2: XỬ LÝ HÓA ĐƠN CHÍNH

                            HoaDon hd;
                            if (this.id == 0) // LẬP MỚI
                            {
                                hd = new HoaDon
                                {
                                    MaNhanVien = maNVHienTai,
                                    MaKhachHang = maKhachHangHienTai,
                                    NgayLap = dtpNgayLap.Value,
                                    HinhThucThanhToan = hinhThucThanhToan,
                                    GhiChuHoaDon = txtGhiChu.Text
                                };
                                db.HoaDons.Add(hd);
                                db.SaveChanges();
                                this.id = hd.ID;
                            }
                            else // SỬA HÓA ĐƠN
                            {
                                hd = db.HoaDons.FirstOrDefault(h => h.ID == this.id);
                                if (hd != null)
                                {
                                    hd.MaKhachHang = maKhachHangHienTai;
                                    hd.HinhThucThanhToan = hinhThucThanhToan;
                                    hd.GhiChuHoaDon = txtGhiChu.Text;
                                    db.SaveChanges();
                                }

                                var chiTietCu = db.HoaDonChiTiets.Where(c => c.HoaDonID == this.id).ToList();
                                db.HoaDonChiTiets.RemoveRange(chiTietCu);
                                db.SaveChanges();
                            }


                            // BƯỚC 3.3: LƯU CHI TIẾT GIỎ HÀNG

                            decimal tongTienHoaDon = 0;
                            foreach (var item in hoaDonChiTiet)
                            {
                                db.HoaDonChiTiets.Add(new HoaDonChiTiet
                                {
                                    HoaDonID = this.id,
                                    MaTiVi = item.MaTiVi,
                                    SoLuongBan = item.SoLuongBan,
                                    DonGiaBan = item.DonGiaBan,
                                    KhuyenMai = item.KhuyenMai
                                });
                                tongTienHoaDon += item.ThanhTien;

                                var tivi = db.QuanLyTiVis.Find(item.MaTiVi);
                                if (tivi != null) tivi.SoLuongTon -= item.SoLuongBan;
                            }
                            db.SaveChanges();


                            //  3.4: XỬ LÝ TRẢ GÓP

                            if (rdoTraGop.Checked)
                            {
                                decimal noGoc = tongTienHoaDon - traTruoc;
                                if (noGoc < 0) noGoc = 0;
                                decimal tienLai = noGoc * (laiSuat / 100m);
                                decimal tongNo = noGoc + tienLai;

                                var traGopTonTai = db.TraGops.FirstOrDefault(t => t.MaHoaDon == this.id);
                                int idTraGopHienTai = 0;

                                if (traGopTonTai != null)
                                {
                                    // SỬA TRẢ GÓP THAY VÌ XÓA
                                    traGopTonTai.LaiSuat = laiSuat;
                                    traGopTonTai.KyHanTra = kyHan;
                                    traGopTonTai.SoTienTraTruoc = traTruoc;
                                    traGopTonTai.SoTienConNo = tongNo;

                                    db.SaveChanges();
                                    idTraGopHienTai = traGopTonTai.ID;

                                    // Xóa lịch trình chi tiết cũ để tạo lại lịch mới
                                    var chiTietTraGopCu = db.ChiTietTraGops.Where(c => c.TraGopID == idTraGopHienTai).ToList();
                                    db.ChiTietTraGops.RemoveRange(chiTietTraGopCu);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    // TẠO TRẢ GÓP MỚI
                                    TraGop tgMoi = new TraGop
                                    {
                                        MaHoaDon = this.id,
                                        LaiSuat = laiSuat,
                                        KyHanTra = kyHan,
                                        SoTienTraTruoc = traTruoc,
                                        SoTienConNo = tongNo
                                    };
                                    db.TraGops.Add(tgMoi);
                                    db.SaveChanges();
                                    idTraGopHienTai = tgMoi.ID;
                                }

                                // TÍNH TOÁN RÕ RÀNG TIỀN GỐC/LÃI
                                decimal tienGocMoiThang = Math.Round(noGoc / kyHan, 0);
                                decimal tienLaiMoiThang = Math.Round(tienLai / kyHan, 0);

                                DateTime ngayBatDau = dtpNgayLap.Value;
                                for (int i = 1; i <= kyHan; i++)
                                {
                                    decimal gocKyNay = tienGocMoiThang;
                                    decimal laiKyNay = tienLaiMoiThang;

                                    if (i == kyHan)
                                    {
                                        gocKyNay = noGoc - (tienGocMoiThang * (kyHan - 1));
                                        laiKyNay = tienLai - (tienLaiMoiThang * (kyHan - 1));
                                    }

                                    decimal canThuKyNay = gocKyNay + laiKyNay;

                                    db.ChiTietTraGops.Add(new ChiTietTraGop
                                    {
                                        TraGopID = idTraGopHienTai,
                                        KyThu = i,
                                        NgayCanDong = ngayBatDau.AddMonths(i),
                                        SoTienGoc = gocKyNay,
                                        SoTienLai = laiKyNay,
                                        TongTienDong = canThuKyNay,
                                        SoTienDaDong = 0,
                                    });
                                }
                                db.SaveChanges();
                            }
                            else
                            {
                                // Nếu đổi từ Trả góp -> Tiền mặt, phải xóa dữ liệu Trả góp cũ đi
                                var traGopCu = db.TraGops.FirstOrDefault(t => t.MaHoaDon == this.id);
                                if (traGopCu != null)
                                {
                                    var chiTietTraGopCu = db.ChiTietTraGops.Where(c => c.TraGopID == traGopCu.ID).ToList();
                                    db.ChiTietTraGops.RemoveRange(chiTietTraGopCu);
                                    db.TraGops.Remove(traGopCu);
                                    db.SaveChanges();
                                }
                            }

                            // Chốt Transaction
                            transaction.Commit();
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi trong quá trình lưu dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    decimal km1sp = chiTiet.SoLuongBan > 0 ? (chiTiet.KhuyenMai / chiTiet.SoLuongBan) : 0;
                    txtKhuyenMai.Text = km1sp.ToString("0");

                    txtDonGia.Text = chiTiet.DonGiaBan.ToString("0");

                    BatTatChucNang(true);

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
            if (rdoTienMat.Checked) panelTraGop.Enabled = false;
        }
        private void rdoChuyenKhoan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoChuyenKhoan.Checked) panelTraGop.Enabled = false;
        }

        private void txtSDT_KhachHang_TextChanged(object sender, EventArgs e)
        {

            string sdt = txtSDT_KhachHang.Text.Trim();

            //Thường SĐT có 10 số, nên check >= 10 cho an toàn
            if (sdt.Length >= 10)
            {
                var kh = context.KhachHangs.FirstOrDefault(k => k.SoDienThoai == sdt);
                if (kh != null)
                {
                    // Nếu tìm thấy khách cũ -> Chỉ điền thông tin Khách Hàng
                    txtTenKhachHang.Text = kh.TenKhachHang;
                    txtCCCD.Text = kh.CCCD;
                    txtDiaChi.Text = kh.DiaChi;
                    dtpNgayThangNamSinh.Value = kh.NgayThangNamSinh;
                    maKhachHangHienTai = kh.MaKhachHang;


                }
                else
                {
                    // SĐT mới -> Làm trống các ô Khách Hàng để nhập mới (Nhưng KHÔNG làm trống ô Trả Góp)
                    txtTenKhachHang.Clear();
                    txtCCCD.Clear();
                    txtDiaChi.Clear();
                    dtpNgayThangNamSinh.Value = DateTime.Now;
                    maKhachHangHienTai = "";
                }
            }
            else
            {
                maKhachHangHienTai = "";
            }
        }

        private void txtLaiSuat_TextChanged(object sender, EventArgs e)
        {
            TinhTienConNo();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            if (this.id == 0)
            {
                // === 1. NẾU ĐANG LẬP HÓA ĐƠN MỚI: Xóa trắng toàn bộ giao diện ===

                // Xóa thông tin khách hàng
                txtSDT_KhachHang.Clear(); // Dùng Clear() SDT trước để không kích hoạt tìm kiếm ảo
                txtTenKhachHang.Clear();
                txtCCCD.Clear();
                txtDiaChi.Clear();
                dtpNgayThangNamSinh.Value = DateTime.Now;
                maKhachHangHienTai = "";

                // Xóa thông tin trả góp & hóa đơn
                txtGhiChu.Clear();
                rdoTienMat.Checked = true; // Tự động khóa panel trả góp do event CheckedChanged
                txtLaiSuat.Clear();
                txtKyHanTra.Clear();
                txtSoTienTraTruoc.Clear();
                txtSoTienConNo.Text = "0";

                // Làm sạch giỏ hàng và phần nhập Tivi
                hoaDonChiTiet.Clear();
                ClearInputs();
            }
            else
            {
                // === 2. NẾU ĐANG SỬA HÓA ĐƠN: Khôi phục lại dữ liệu gốc từ DB ===

                // Cố tình xóa trắng trước để tránh kẹt số liệu cũ khi Load lại
                txtLaiSuat.Clear();
                txtKyHanTra.Clear();
                txtSoTienTraTruoc.Clear();

                // Gọi lại Load để kéo lại dữ liệu từ Database (xóa bỏ các thay đổi chưa Lưu)
                frmChiTietHoaDon_Load(sender, e);
            }
        }
    }
}

