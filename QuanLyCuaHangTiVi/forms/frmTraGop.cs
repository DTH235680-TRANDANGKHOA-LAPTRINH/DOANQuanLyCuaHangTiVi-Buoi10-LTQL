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
            var danhSachHoaDon = db.HoaDons.Select(hd => new
            {
                ID = hd.ID,
                ThongTinHienThi = hd.KhachHang.TenKhachHang + " - Mua: " +
                                  (hd.HoaDonChiTiets.Any() ? hd.HoaDonChiTiets.FirstOrDefault().QuanLyTiVi.TenTiVi : "Không rõ")
            }).ToList();

            cboMaHoaDon.DataSource = danhSachHoaDon;
            cboMaHoaDon.DisplayMember = "ThongTinHienThi";
            cboMaHoaDon.ValueMember = "ID";
        }

        private void LoadDanhSachTraGop()
        {
            var danhSachTraGop = db.TraGops.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachTraGop;
            dgvTraGop.DataSource = bindingSource;

            if (dgvTraGop.Columns["HoaDon"] != null) dgvTraGop.Columns["HoaDon"].Visible = false;
            if (dgvTraGop.Columns["ChiTietTraGops"] != null) dgvTraGop.Columns["ChiTietTraGops"].Visible = false;

            // Xóa binding cũ
            txtID.DataBindings.Clear(); // ID thay thế cho MaTraGop
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
            var ds = db.ChiTietTraGops.Where(ct => ct.TraGopID == traGopID).OrderBy(ct => ct.KyThu).ToList();
            dgvChiTiet.DataSource = ds;

            if (dgvChiTiet.Columns["TraGop"] != null) dgvChiTiet.Columns["TraGop"].Visible = false;
            if (dgvChiTiet.Columns["TraGopID"] != null) dgvChiTiet.Columns["TraGopID"].Visible = false;
            if (dgvChiTiet.Columns["ID"] != null) dgvChiTiet.Columns["ID"].Visible = false;

            dgvChiTiet.Columns["KyThu"].HeaderText = "Kỳ";
            dgvChiTiet.Columns["NgayCanDong"].HeaderText = "Hạn Chót";
            dgvChiTiet.Columns["TongTienDong"].HeaderText = "Cần Thu";
            dgvChiTiet.Columns["SoTienPhat"].HeaderText = "Tiền Phạt";
            dgvChiTiet.Columns["SoTienDaDong"].HeaderText = "Đã Đóng";
            dgvChiTiet.Columns["TrangThai"].HeaderText = "Tình Trạng";

            dgvChiTiet.Columns["TongTienDong"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["SoTienDaDong"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["SoTienPhat"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["NgayCanDong"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
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
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng!");
                return;
            }

            try
            {
                int maHD = (int)cboMaHoaDon.SelectedValue;
                decimal soTienNo = decimal.Parse(txtSoTienConNo.Text);
                decimal tongMoiThang = soTienNo / kyHan;
                DateTime ngayBatDau = DateTime.Now;

                int savedTraGopID = -1; // TẠO BIẾN NÀY ĐỂ NHỚ ID VỪA LƯU

                if (isThem)
                {
                    TraGop tgMoi = new TraGop
                    {
                        MaHoaDon = maHD,
                        LaiSuat = laiSuat,
                        KyHanTra = kyHan,
                        SoTienTraTruoc = soTienTruoc,
                        SoTienConNo = soTienNo
                    };

                    db.TraGops.Add(tgMoi);
                    db.SaveChanges(); // Lưu để lấy ID tự sinh

                    for (int i = 1; i <= kyHan; i++)
                    {
                        db.ChiTietTraGops.Add(new ChiTietTraGop
                        {
                            TraGopID = tgMoi.ID,
                            KyThu = i,
                            NgayCanDong = ngayBatDau.AddMonths(i),
                            TongTienDong = Math.Round(tongMoiThang, 0)
                        });
                    }
                    db.SaveChanges();
                    savedTraGopID = tgMoi.ID; // Bắt lấy ID vừa sinh ra
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

                        // Xóa lịch cũ, tạo lịch mới
                        var chiTietCu = db.ChiTietTraGops.Where(ct => ct.TraGopID == idSua);
                        db.ChiTietTraGops.RemoveRange(chiTietCu);

                        for (int i = 1; i <= kyHan; i++)
                        {
                            db.ChiTietTraGops.Add(new ChiTietTraGop
                            {
                                TraGopID = tgSua.ID,
                                KyThu = i,
                                NgayCanDong = ngayBatDau.AddMonths(i),
                                TongTienDong = Math.Round(tongMoiThang, 0)
                            });
                        }
                    }
                    db.SaveChanges();
                    savedTraGopID = idSua; // Bắt lấy ID vừa sửa
                }

                MessageBox.Show("Lưu thành công!");

                // FIX LỖI Ở ĐÂY: Không gọi frmTraGop_Load nữa
                isThem = false;
                BatTatChucNang(false);
                LoadDanhSachTraGop(); // Cập nhật lại DataGridView cha

                // VÀNG TÂM: Tự động cuộn và click vào dòng hợp đồng vừa tạo
                foreach (DataGridViewRow row in dgvTraGop.Rows)
                {
                    if (row.DataBoundItem is TraGop tg && tg.ID == savedTraGopID)
                    {
                        row.Selected = true;
                        dgvTraGop.CurrentCell = row.Cells[0]; // Ép kích hoạt SelectionChanged ngay lập tức
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
            if (dgvChiTiet.Rows[e.RowIndex].DataBoundItem is ChiTietTraGop row)
            {
                decimal tienCanThu = row.TongTienDong + row.SoTienPhat;

                if (row.SoTienDaDong >= tienCanThu)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else if (DateTime.Now.Date >= row.NgayCanDong.Date)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (row.SoTienDaDong > 0 && row.SoTienDaDong < tienCanThu)
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
            if (!decimal.TryParse(txtSoTienNop.Text.Replace(",", ""), out decimal soTienKhachDua) || soTienKhachDua <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!"); return;
            }

            if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn Kỳ muốn nộp trên lưới chi tiết!"); return;
            }

            if (string.IsNullOrEmpty(txtID.Text)) return;
            int currentTraGopID = int.Parse(txtID.Text);

            var kyDangChon = dgvChiTiet.CurrentRow.DataBoundItem as ChiTietTraGop;
            DateTime ngayKhachNop = dtpNgayNop.Value.Date;
            string nguoiNop = string.IsNullOrWhiteSpace(txtNguoiNop.Text) ? "Chủ hợp đồng" : txtNguoiNop.Text;
            decimal soTienDu = soTienKhachDua;

            // 1. Rót tiền vào kỳ đang chọn
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

            // 2. Nếu dư, quét các kỳ tiếp theo
            if (soTienDu > 0)
            {
                var cacKyKhac = db.ChiTietTraGops.Where(ct => ct.TraGopID == currentTraGopID && ct.KyThu != kyDangChon.KyThu).OrderBy(ct => ct.KyThu).ToList();
                foreach (var kyGop in cacKyKhac)
                {
                    if (soTienDu <= 0) break;

                    if (ngayKhachNop > kyGop.NgayCanDong.Date && kyGop.SoTienDaDong < (kyGop.TongTienDong + kyGop.SoTienPhat))
                        kyGop.SoTienPhat = (ngayKhachNop - kyGop.NgayCanDong.Date).Days * 10000;

                    decimal canThuKyKhac = (kyGop.TongTienDong + kyGop.SoTienPhat) - kyGop.SoTienDaDong;
                    if (canThuKyKhac <= 0) continue;

                    decimal tienDapVao = Math.Min(soTienDu, canThuKyKhac);
                    kyGop.SoTienDaDong += tienDapVao;
                    kyGop.NgayThucDong = ngayKhachNop;
                    kyGop.NguoiNopTien = nguoiNop;
                    soTienDu -= tienDapVao;
                }
            }

            // 3. Nếu vẫn dư, dồn vào kỳ cuối
            if (soTienDu > 0)
            {
                var kyCuoi = db.ChiTietTraGops.Where(ct => ct.TraGopID == currentTraGopID).OrderByDescending(ct => ct.KyThu).FirstOrDefault();
                if (kyCuoi != null)
                {
                    kyCuoi.SoTienDaDong += soTienDu;
                    kyCuoi.NgayThucDong = ngayKhachNop;
                    kyCuoi.NguoiNopTien = nguoiNop;
                }
                MessageBox.Show($"Khách thanh toán dư {soTienDu:N0} VNĐ. Tiền thừa được cộng dồn vào kỳ cuối!");
            }

            db.SaveChanges();
            MessageBox.Show("Thu tiền thành công!");

            // Tải lại lưới chi tiết để cập nhật màu sắc và số liệu
            LoadChiTietTraGop(currentTraGopID);
            txtSoTienNop.Clear();
            txtNguoiNop.Clear();
        }
    }
}
