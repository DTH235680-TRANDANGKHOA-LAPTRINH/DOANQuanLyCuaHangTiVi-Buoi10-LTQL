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
using Microsoft.EntityFrameworkCore;

namespace QuanLyCuaHangTiVi.forms
{
    public partial class frmTraGop : Form
    {

        AppDbContext db = new AppDbContext();
        bool isThem = false;

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

            // Khóa khu vực thu tiền nếu đang thêm/sửa hợp đồng
            btnThuTien.Enabled = !dangThaoTac;
            txtSoTienNop.Enabled = !dangThaoTac;
            dtpNgayNop.Enabled = !dangThaoTac;
            txtNguoiNop.Enabled = !dangThaoTac;
        }

        private void ChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        // ==========================================================
        // 2. LOAD VÀ BINDING DỮ LIỆU DANH SÁCH HỢP ĐỒNG
        // ==========================================================
        private void LoadDuLieuHoaDon()
        {
            // Lọc ra các hóa đơn mua theo hình thức Trả góp 
            // (Lưu ý: Chữ "Trả góp" phải khớp với dữ liệu bạn lưu trong DB ở frmChiTietHoaDon)
            var danhSachHoaDon = db.HoaDons
                .Where(hd => hd.HinhThucThanhToan.Contains("Trả góp"))
                .Select(hd => new
                {
                    ID = hd.ID,
                    ThongTinHienThi = "HĐ " + hd.ID.ToString() + " | " + hd.KhachHang.TenKhachHang + " - Mua: " +
                                      (hd.HoaDonChiTiets.Any() ? hd.HoaDonChiTiets.FirstOrDefault().QuanLyTiVi.TenTiVi : "Không rõ")
                }).ToList();

            cboMaHoaDon.DataSource = danhSachHoaDon;
            cboMaHoaDon.DisplayMember = "ThongTinHienThi";
            cboMaHoaDon.ValueMember = "ID";
        }

        private void LoadDanhSachTraGop()
        {
            var danhSachTraGop = db.TraGops
                .Include(t => t.HoaDon)
                    .ThenInclude(h => h.KhachHang)   // Lấy thông tin Khách Hàng
                .Include(t => t.HoaDon)
                    .ThenInclude(h => h.HoaDonChiTiets)
                        .ThenInclude(ct => ct.QuanLyTiVi) // Lấy thông tin TiVi
                .ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachTraGop;
            dgvTraGop.DataSource = bindingSource;

            if (dgvTraGop.Columns["HoaDon"] != null) dgvTraGop.Columns["HoaDon"].Visible = false;
            if (dgvTraGop.Columns["ChiTietTraGops"] != null) dgvTraGop.Columns["ChiTietTraGops"].Visible = false;

            // Đổi tiêu đề cột Mã Hóa Đơn cho đẹp
            if (dgvTraGop.Columns["MaHoaDon"] != null)
            {
                dgvTraGop.Columns["MaHoaDon"].HeaderText = "Khách Hàng / TiVi";
                dgvTraGop.Columns["MaHoaDon"].Width = 200; // Nới rộng cột để chứa tên
            }

            // Xóa binding cũ
            txtID.DataBindings.Clear();
            cboMaHoaDon.DataBindings.Clear();
            txtLaiSuat.DataBindings.Clear();
            txtKyHanTra.DataBindings.Clear();
            txtSoTienTraTruoc.DataBindings.Clear();
            txtSoTienConNo.DataBindings.Clear();

            // Add binding mới
            txtID.DataBindings.Add("Text", bindingSource, "ID", true, DataSourceUpdateMode.Never);
            cboMaHoaDon.DataBindings.Add("SelectedValue", bindingSource, "MaHoaDon", true, DataSourceUpdateMode.Never);
            txtLaiSuat.DataBindings.Add("Text", bindingSource, "LaiSuat", true, DataSourceUpdateMode.Never);
            txtKyHanTra.DataBindings.Add("Text", bindingSource, "KyHanTra", true, DataSourceUpdateMode.Never);
            txtSoTienTraTruoc.DataBindings.Add("Text", bindingSource, "SoTienTraTruoc", true, DataSourceUpdateMode.Never);
            txtSoTienConNo.DataBindings.Add("Text", bindingSource, "SoTienConNo", true, DataSourceUpdateMode.Never);
        }
        public frmTraGop()
        {
            InitializeComponent();
            // CHUYỂN TOÀN BỘ ĐĂNG KÝ SỰ KIỆN VÀO ĐÂY
            txtLaiSuat.KeyPress += ChiNhapSo_KeyPress;
            txtKyHanTra.KeyPress += ChiNhapSo_KeyPress;
            txtSoTienTraTruoc.KeyPress += ChiNhapSo_KeyPress;
            txtSoTienNop.KeyPress += ChiNhapSo_KeyPress;

            dgvTraGop.SelectionChanged += dgvTraGop_SelectionChanged;
            dgvChiTiet.CellFormatting += dgvChiTiet_CellFormatting;

            // THÊM DÒNG NÀY ĐỂ RÁP TÊN KHÁCH HÀNG VÀO LƯỚI
            dgvTraGop.CellFormatting += dgvTraGop_CellFormatting;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTraGop_Load(object sender, EventArgs e)
        {
            isThem = false;
            BatTatChucNang(false);
            LoadDuLieuHoaDon();
            LoadDanhSachTraGop();


        }
        private void LoadChiTietTraGop(int traGopID)
        {
            var dsGoc = db.ChiTietTraGops.Where(ct => ct.TraGopID == traGopID).OrderBy(ct => ct.KyThu).ToList();

            var dsHienThi = dsGoc.Select(ct => new
            {
                ID = ct.ID,
                TraGopID = ct.TraGopID,
                KyThu = ct.KyThu,
                NgayCanDong = ct.NgayCanDong,
                TongTienDong = ct.TongTienDong,
                SoTienDaDong = ct.SoTienDaDong,
                NgayThucDong = ct.NgayThucDong,
                NguoiNopTien = ct.NguoiNopTien,
                SoTienPhat = ct.SoTienPhat,
                TinhTrang = (ct.SoTienDaDong >= (ct.TongTienDong + ct.SoTienPhat)) ? "Đã đóng đủ" :
                            (DateTime.Now.Date > ct.NgayCanDong.Date && ct.SoTienDaDong == 0) ? "Trễ hạn" :
                            (DateTime.Now.Date > ct.NgayCanDong.Date && ct.SoTienDaDong > 0) ? "Đóng thiếu (Trễ)" :
                            (ct.SoTienDaDong > 0) ? "Đóng thiếu" : "Chưa đóng"
            }).ToList();

            // 1. ÉP DATAGRIDVIEW TỰ ĐỘNG TẠO CỘT THEO DANH SÁCH TRÊN
            dgvChiTiet.AutoGenerateColumns = true;
            dgvChiTiet.DataSource = dsHienThi;

            // 2. KIỂM TRA TỒN TẠI TRƯỚC KHI ẨN CỘT
            if (dgvChiTiet.Columns["ID"] != null) dgvChiTiet.Columns["ID"].Visible = false;
            if (dgvChiTiet.Columns["TraGopID"] != null) dgvChiTiet.Columns["TraGopID"].Visible = false;

            // 3. KIỂM TRA TỒN TẠI TRƯỚC KHI ĐỔI TÊN HEADER
            if (dgvChiTiet.Columns["KyThu"] != null) dgvChiTiet.Columns["KyThu"].HeaderText = "Kỳ";
            if (dgvChiTiet.Columns["NgayCanDong"] != null) dgvChiTiet.Columns["NgayCanDong"].HeaderText = "Hạn Chót";
            if (dgvChiTiet.Columns["TongTienDong"] != null) dgvChiTiet.Columns["TongTienDong"].HeaderText = "Cần Thu";
            if (dgvChiTiet.Columns["SoTienDaDong"] != null) dgvChiTiet.Columns["SoTienDaDong"].HeaderText = "Đã Đóng";
            if (dgvChiTiet.Columns["NgayThucDong"] != null) dgvChiTiet.Columns["NgayThucDong"].HeaderText = "Ngày Đóng";
            if (dgvChiTiet.Columns["NguoiNopTien"] != null) dgvChiTiet.Columns["NguoiNopTien"].HeaderText = "Người Nộp";
            if (dgvChiTiet.Columns["SoTienPhat"] != null) dgvChiTiet.Columns["SoTienPhat"].HeaderText = "Tiền Phạt";
            if (dgvChiTiet.Columns["TinhTrang"] != null) dgvChiTiet.Columns["TinhTrang"].HeaderText = "Tình Trạng";

            // 4. KIỂM TRA TỒN TẠI TRƯỚC KHI FORMAT
            if (dgvChiTiet.Columns["TongTienDong"] != null) dgvChiTiet.Columns["TongTienDong"].DefaultCellStyle.Format = "N0";
            if (dgvChiTiet.Columns["SoTienDaDong"] != null) dgvChiTiet.Columns["SoTienDaDong"].DefaultCellStyle.Format = "N0";
            if (dgvChiTiet.Columns["SoTienPhat"] != null) dgvChiTiet.Columns["SoTienPhat"].DefaultCellStyle.Format = "N0";
            if (dgvChiTiet.Columns["NgayCanDong"] != null) dgvChiTiet.Columns["NgayCanDong"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvChiTiet.Columns["NgayThucDong"] != null) dgvChiTiet.Columns["NgayThucDong"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private void TinhSoTienNo()
        {
            try
            {
                if (cboMaHoaDon.SelectedValue == null) return;
                int maHD = (int)cboMaHoaDon.SelectedValue;

                // Đã sửa: Thêm phần trừ đi Khuyến Mãi (KhuyenMai ?? 0) để khớp tuyệt đối với frmHoaDon
                var hoaDon = db.HoaDons.Select(hd => new
                {
                    hd.ID,
                    TongTien = hd.HoaDonChiTiets.Sum(ct => (ct.SoLuongBan * ct.DonGiaBan) - (ct.KhuyenMai ?? 0))
                }).FirstOrDefault(hd => hd.ID == maHD);

                if (hoaDon == null) return;

                decimal tongTien = hoaDon.TongTien;
                decimal.TryParse(txtSoTienTraTruoc.Text, out decimal traTruoc);
                decimal.TryParse(txtLaiSuat.Text, out decimal laiSuat);

                // Tính nợ gốc
                decimal noGoc = tongTien - traTruoc;
                if (noGoc < 0) noGoc = 0;

                // Tính lãi dựa trên phần nợ gốc còn lại
                decimal tienLai = noGoc * (laiSuat / 100);
                decimal tongNo = noGoc + tienLai;

                txtSoTienConNo.Text = tongNo.ToString("0");
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            BatTatChucNang(true);

            txtID.Text = ""; // Để trống vì DB tự tăng
            cboMaHoaDon.SelectedIndex = -1;
            txtLaiSuat.Clear();
            txtKyHanTra.Clear();
            txtSoTienTraTruoc.Clear();
            txtSoTienConNo.Clear();
            dgvChiTiet.DataSource = null; // Xóa lưới chi tiết
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chưa chọn hợp đồng để sửa!");
                return;
            }

            int idTraGop = int.Parse(txtID.Text);
            bool daThuTien = db.ChiTietTraGops.Any(ct => ct.TraGopID == idTraGop && ct.SoTienDaDong > 0);
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
            if (dgvTraGop.CurrentRow == null || dgvTraGop.CurrentRow.DataBoundItem == null) return;

            TraGop hopDong = dgvTraGop.CurrentRow.DataBoundItem as TraGop;

            DialogResult dr = MessageBox.Show($"Xóa hợp đồng ID {hopDong.ID} và toàn bộ lịch sử đóng tiền?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                var hopDongDB = db.TraGops.Find(hopDong.ID);
                if (hopDongDB != null)
                {
                    // Xóa chi tiết trước
                    var dsChiTiet = db.ChiTietTraGops.Where(ct => ct.TraGopID == hopDong.ID).ToList();
                    db.ChiTietTraGops.RemoveRange(dsChiTiet);

                    // Xóa hợp đồng cha
                    db.TraGops.Remove(hopDongDB);
                    db.SaveChanges();

                    MessageBox.Show("Đã xóa thành công!");
                    frmTraGop_Load(sender, e);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {


            if (cboMaHoaDon.SelectedValue == null || !decimal.TryParse(txtLaiSuat.Text, out decimal laiSuat) ||
                !decimal.TryParse(txtSoTienTraTruoc.Text, out decimal soTienTruoc) || !int.TryParse(txtKyHanTra.Text, out int kyHan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng các thông tin số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kyHan <= 0)
            {
                MessageBox.Show("Kỳ hạn trả phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    int maHD = (int)cboMaHoaDon.SelectedValue;
                    decimal soTienNo = decimal.Parse(txtSoTienConNo.Text);

                    // Chia đều các tháng, gánh số lẻ vào tháng cuối
                    decimal tongMoiThang = Math.Round(soTienNo / kyHan, 0);
                    decimal tienThangCuoi = soTienNo - (tongMoiThang * (kyHan - 1));

                    DateTime ngayBatDau = DateTime.Now;
                    int savedTraGopID = -1;

                    if (isThem)
                    {//Một hóa đơn bán hàng chỉ được phép có duy nhất một hợp đồng trả góp đi kèm. 
                      //Nếu nhân viên lỡ tay chọn lại một hóa đơn đã làm trả góp hôm qua, hệ thống lập tức báo lỗi đỏ, chặn việc tạo ra 2 hợp đồng đè lên nhau gây thất thoát tiền bạc.
                        if (db.TraGops.Any(tg => tg.MaHoaDon == maHD))
                        {
                            MessageBox.Show("Hóa đơn này đã có hợp đồng trả góp. Vui lòng chọn hóa đơn khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        TraGop tgMoi = new TraGop
                        {
                            MaHoaDon = maHD,
                            LaiSuat = laiSuat,
                            KyHanTra = kyHan,
                            SoTienTraTruoc = soTienTruoc,
                            SoTienConNo = soTienNo
                        };

                        db.TraGops.Add(tgMoi);
                        db.SaveChanges();

                        for (int i = 1; i <= kyHan; i++)
                        {
                            db.ChiTietTraGops.Add(new ChiTietTraGop
                            {
                                TraGopID = tgMoi.ID,
                                KyThu = i,
                                NgayCanDong = ngayBatDau.AddMonths(i),
                                // Nếu là tháng cuối cùng thì nhận số tiền gánh dư, ngược lại lấy tiền đều
                                TongTienDong = (i == kyHan) ? tienThangCuoi : tongMoiThang,
                                SoTienDaDong = 0,
                                SoTienPhat = 0
                            });
                        }
                        db.SaveChanges();
                        savedTraGopID = tgMoi.ID;
                    }
                    else
                    {
                        int idSua = int.Parse(txtID.Text);
                        var tgSua = db.TraGops.Find(idSua);
                        if (tgSua != null)
                        {
                            tgSua.MaHoaDon = maHD;
                            tgSua.LaiSuat = laiSuat;
                            tgSua.KyHanTra = kyHan;
                            tgSua.SoTienTraTruoc = soTienTruoc;
                            tgSua.SoTienConNo = soTienNo;

                            var chiTietCu = db.ChiTietTraGops.Where(ct => ct.TraGopID == idSua);
                            db.ChiTietTraGops.RemoveRange(chiTietCu);
                            db.SaveChanges();

                            for (int i = 1; i <= kyHan; i++)
                            {
                                db.ChiTietTraGops.Add(new ChiTietTraGop
                                {
                                    TraGopID = tgSua.ID,
                                    KyThu = i,
                                    NgayCanDong = ngayBatDau.AddMonths(i),
                                    // Nếu là tháng cuối cùng thì nhận số tiền gánh dư, ngược lại lấy tiền đều
                                    TongTienDong = (i == kyHan) ? tienThangCuoi : tongMoiThang,
                                    SoTienDaDong = 0,
                                    SoTienPhat = 0
                                });
                            }
                            db.SaveChanges();
                            savedTraGopID = idSua;
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Lưu hợp đồng trả góp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    isThem = false;
                    BatTatChucNang(false);
                    LoadDanhSachTraGop();

                    foreach (DataGridViewRow row in dgvTraGop.Rows)
                    {
                        if (row.DataBoundItem is TraGop tg && tg.ID == savedTraGopID)
                        {
                            row.Selected = true;
                            dgvTraGop.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void dgvTraGop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTraGop.CurrentRow != null && dgvTraGop.CurrentRow.DataBoundItem is TraGop selectedTraGop)
            {
                LoadChiTietTraGop(selectedTraGop.ID);
            }
            else
            {
                dgvChiTiet.DataSource = null; // Xóa lưới chi tiết nếu không chọn hợp đồng nào
            }
        }

        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvChiTiet.Columns["TongTienDong"] == null) return;
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị trực tiếp từ các ô trên lưới
                decimal tongTienDong = Convert.ToDecimal(dgvChiTiet.Rows[e.RowIndex].Cells["TongTienDong"].Value ?? 0);
                decimal soTienPhat = Convert.ToDecimal(dgvChiTiet.Rows[e.RowIndex].Cells["SoTienPhat"].Value ?? 0);
                decimal soTienDaDong = Convert.ToDecimal(dgvChiTiet.Rows[e.RowIndex].Cells["SoTienDaDong"].Value ?? 0);
                DateTime ngayCanDong = Convert.ToDateTime(dgvChiTiet.Rows[e.RowIndex].Cells["NgayCanDong"].Value);

                decimal tienCanThu = tongTienDong + soTienPhat;

                // Xử lý tô màu
                if (soTienDaDong >= tienCanThu && tienCanThu > 0)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else if (DateTime.Now.Date > ngayCanDong.Date && soTienDaDong < tienCanThu)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (soTienDaDong > 0 && soTienDaDong < tienCanThu)
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                }
            }
        }

        private void txtSoTienNop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSoTienNop.Text)) return;
                decimal value = decimal.Parse(txtSoTienNop.Text.Replace(",", ""));
                txtSoTienNop.Text = value.ToString("N0");
                txtSoTienNop.SelectionStart = txtSoTienNop.Text.Length;
            }
            catch { }
        }

        private void btnThuTien_Click(object sender, EventArgs e)
        {
       
            // 1. Kiểm tra đầu vào số tiền
            if (!decimal.TryParse(txtSoTienNop.Text.Replace(",", ""), out decimal soTienKhachDua) || soTienKhachDua <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra xem đã chọn kỳ trả góp trên lưới chưa
            if (dgvChiTiet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn Kỳ muốn nộp trên lưới chi tiết!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtID.Text)) return;
            int currentTraGopID = int.Parse(txtID.Text);

            // Lấy ID trực tiếp từ Cell ẩn trên DataGridView thay vì ép kiểu DataBoundItem
            int idChiTiet = Convert.ToInt32(dgvChiTiet.CurrentRow.Cells["ID"].Value);

            // Lấy thông tin Kỳ đang chọn từ cơ sở dữ liệu
            var kyDangChon = db.ChiTietTraGops.Find(idChiTiet);
            if (kyDangChon == null)
            {
                MessageBox.Show("Lỗi dữ liệu: Không tìm thấy thông tin kỳ này trong Database!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngayKhachNop = dtpNgayNop.Value.Date;
            string nguoiNop = string.IsNullOrWhiteSpace(txtNguoiNop.Text) ? "Chủ hợp đồng" : txtNguoiNop.Text;
            decimal soTienDu = soTienKhachDua;

          
            // 1: RÓT TIỀN VÀO KỲ ĐANG CHỌN
          
            // Tính tiền phạt trễ hạn (nếu đóng trễ và chưa đóng đủ)
            if (ngayKhachNop > kyDangChon.NgayCanDong.Date && kyDangChon.SoTienDaDong < (kyDangChon.TongTienDong + kyDangChon.SoTienPhat))
            {
                kyDangChon.SoTienPhat = (ngayKhachNop - kyDangChon.NgayCanDong.Date).Days * 10000;
            }

            decimal canThu = (kyDangChon.TongTienDong + kyDangChon.SoTienPhat) - kyDangChon.SoTienDaDong;
            if (canThu > 0)
            {
                decimal tienDapVao = Math.Min(soTienDu, canThu);
                kyDangChon.SoTienDaDong += tienDapVao;
                kyDangChon.NgayThucDong = ngayKhachNop;
                kyDangChon.NguoiNopTien = nguoiNop;
                soTienDu -= tienDapVao;
            }

          
            // BƯỚC 2: NẾU DƯ TIỀN, QUÉT VÀ RÓT VÀO CÁC KỲ TIẾP THEO
       
            if (soTienDu > 0)
            {
                var cacKyKhac = db.ChiTietTraGops
                                  .Where(ct => ct.TraGopID == currentTraGopID && ct.KyThu != kyDangChon.KyThu)
                                  .OrderBy(ct => ct.KyThu)
                                  .ToList();

                foreach (var kyGop in cacKyKhac)
                {
                    if (soTienDu <= 0) break;

                    // Tính phạt trễ hạn cho các kỳ khác (nếu hạn chót của nó cũng đã qua)
                    if (ngayKhachNop > kyGop.NgayCanDong.Date && kyGop.SoTienDaDong < (kyGop.TongTienDong + kyGop.SoTienPhat))
                    {
                        kyGop.SoTienPhat = (ngayKhachNop - kyGop.NgayCanDong.Date).Days * 10000;
                    }

                    decimal canThuKyKhac = (kyGop.TongTienDong + kyGop.SoTienPhat) - kyGop.SoTienDaDong;
                    if (canThuKyKhac <= 0) continue;

                    decimal tienDapVao = Math.Min(soTienDu, canThuKyKhac);
                    kyGop.SoTienDaDong += tienDapVao;
                    kyGop.NgayThucDong = ngayKhachNop;
                    kyGop.NguoiNopTien = nguoiNop;
                    soTienDu -= tienDapVao;
                }
            }

           
            //  3: NẾU VẪN CÒN DƯ, DỒN HẾT VÀO KỲ CUỐI CÙNG
            if (soTienDu > 0)
            {
                var kyCuoi = db.ChiTietTraGops
                               .Where(ct => ct.TraGopID == currentTraGopID)
                               .OrderByDescending(ct => ct.KyThu)
                               .FirstOrDefault();

                if (kyCuoi != null)
                {
                    kyCuoi.SoTienDaDong += soTienDu;
                    kyCuoi.NgayThucDong = ngayKhachNop;
                    kyCuoi.NguoiNopTien = nguoiNop;
                }
                MessageBox.Show($"Khách thanh toán dư {soTienDu:N0} VNĐ. Tiền thừa đã được tự động cộng dồn vào kỳ cuối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

          
            // 4: LƯU DB VÀ LÀM MỚI GIAO DIỆN
          
            try
            {
                db.SaveChanges();
                MessageBox.Show("Thu tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại lưới chi tiết để cập nhật ngay lập tức màu sắc (xanh, đỏ, vàng) và số liệu
                LoadChiTietTraGop(currentTraGopID);

                // Reset ô nhập liệu
                txtSoTienNop.Clear();
                txtNguoiNop.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu vào cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void dgvTraGop_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
      
            // Kiểm tra nếu đang render cột MaHoaDon (mà ta đã đổi tiêu đề là Khách Hàng / TiVi)
            if (dgvTraGop.Columns[e.ColumnIndex].Name == "MaHoaDon" && e.RowIndex >= 0)
            {
                if (dgvTraGop.Rows[e.RowIndex].DataBoundItem is TraGop tg && tg.HoaDon != null && tg.HoaDon.KhachHang != null)
                {
                    // Lấy tên khách hàng
                    string tenKhach = tg.HoaDon.KhachHang.TenKhachHang;

                    // Lấy tên tivi (nếu có)
                    string tenTiVi = "Không rõ";
                    if (tg.HoaDon.HoaDonChiTiets != null && tg.HoaDon.HoaDonChiTiets.Any())
                    {
                        var tivi = tg.HoaDon.HoaDonChiTiets.FirstOrDefault().QuanLyTiVi;
                        if (tivi != null) tenTiVi = tivi.TenTiVi;
                    }

                    // Ghi đè giá trị hiển thị trên lưới thành Chuỗi Tên thay vì số Mã Hóa Đơn
                    e.Value = tenKhach + " - " + tenTiVi;
                    e.FormattingApplied = true;
                }
            }
        }
    
    }
}
