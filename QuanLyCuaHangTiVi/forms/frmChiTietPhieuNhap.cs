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
    public partial class frmChiTietPhieuNhap : Form
    {
        // 1. Khai báo Context và biến điều khiển
        AppDbContext context = new AppDbContext();
        bool xuLyThem = false;
        BindingSource bindingSource = new BindingSource();
        public frmChiTietPhieuNhap()
        {
            InitializeComponent();

        }
        // --- HÀM BỔ TRỢ GIAO DIỆN ---
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            // Bật/tắt các ô mới
            cboNguoiGiaoHang.Enabled = giaTri;
            dtpNgayNhap.Enabled = giaTri;

            cboMaTiVi.Enabled = giaTri;
            txtSoLuong.Enabled = giaTri;
            txtDonGiaNhap.Enabled = giaTri;

            txtMaCTPN.Enabled = false;
            txtThanhTien.Enabled = false;
            txtMaPhieuNhap.Enabled = false; // Luôn khóa vì nó tự sinh

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
        }

        private void LoadComboBox()
        {
            // Lấy danh sách Người Giao Hàng từ bảng Phiếu Nhập (Distinct để không bị trùng tên)
            var dsNguoiGiao = context.PhieuNhaps.Select(p => p.NguoiGiaoHang).Distinct().ToList();
            cboNguoiGiaoHang.DataSource = dsNguoiGiao;

            cboMaTiVi.DataSource = context.QuanLyTiVis.ToList();
            cboMaTiVi.DisplayMember = "TenTiVi";
            cboMaTiVi.ValueMember = "MaTiVi";
        }

        private void BindingDuLieu()
        {
            txtMaCTPN.DataBindings.Clear();
            txtMaPhieuNhap.DataBindings.Clear();
            cboNguoiGiaoHang.DataBindings.Clear();
            dtpNgayNhap.DataBindings.Clear();
            cboMaTiVi.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.Clear();

            txtMaCTPN.DataBindings.Add("Text", bindingSource, "MaCTPN", true, DataSourceUpdateMode.Never);

            // Binding các ô mới
            txtMaPhieuNhap.DataBindings.Add("Text", bindingSource, "MaPhieuNhap", true, DataSourceUpdateMode.Never);
            cboNguoiGiaoHang.DataBindings.Add("Text", bindingSource, "NguoiGiaoHang", true, DataSourceUpdateMode.Never);
            dtpNgayNhap.DataBindings.Add("Value", bindingSource, "NgayNhap", true, DataSourceUpdateMode.Never);

            cboMaTiVi.DataBindings.Add("SelectedValue", bindingSource, "MaTiVi", true, DataSourceUpdateMode.Never);
            txtSoLuong.DataBindings.Add("Text", bindingSource, "SoLuongNhap", true, DataSourceUpdateMode.Never);
            txtDonGiaNhap.DataBindings.Add("Text", bindingSource, "DonGiaNhap", true, DataSourceUpdateMode.Never);
        }

        private void TinhThanhTien()
        {
            if (decimal.TryParse(txtSoLuong.Text, out decimal sl) && decimal.TryParse(txtDonGiaNhap.Text, out decimal dg))
            {
                txtThanhTien.Text = (sl * dg).ToString("N0");
            }
            else
            {
                txtThanhTien.Text = "0";
            }
        }

        // --- XỬ LÝ SỰ KIỆN RÀNG BUỘC NHẬP SỐ (GIỐNG FORM QUẢN LÝ TIVI) ---
        private void ChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép các phím điều khiển (Backspace) và các phím số từ 0-9
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn phím không cho hiện vào TextBox
                MessageBox.Show("Trường này chỉ được phép nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadComboBox();

            var listCTPN = context.ChiTietPhieuNhaps.ToList();
            bindingSource.DataSource = listCTPN;

            dgvChiTietPhieuNhap.AutoGenerateColumns = false;
            dgvChiTietPhieuNhap.DataSource = bindingSource;

            // Mapping cột DataGridView
            if (dgvChiTietPhieuNhap.Columns.Contains("colMaCTPN")) dgvChiTietPhieuNhap.Columns["colMaCTPN"].DataPropertyName = "MaCTPN";
            if (dgvChiTietPhieuNhap.Columns.Contains("colMaPhieuNhap")) dgvChiTietPhieuNhap.Columns["colMaPhieuNhap"].DataPropertyName = "MaPhieuNhap";
            if (dgvChiTietPhieuNhap.Columns.Contains("colMaTiVi")) dgvChiTietPhieuNhap.Columns["colMaTiVi"].DataPropertyName = "MaTiVi";
            if (dgvChiTietPhieuNhap.Columns.Contains("colSoLuong")) dgvChiTietPhieuNhap.Columns["colSoLuong"].DataPropertyName = "SoLuongNhap";
            if (dgvChiTietPhieuNhap.Columns.Contains("colDonGia")) dgvChiTietPhieuNhap.Columns["colDonGia"].DataPropertyName = "DonGiaNhap";

            // Gán sự kiện KeyPress cho 2 ô nhập số
            txtSoLuong.KeyPress += ChiNhapSo_KeyPress;
            txtDonGiaNhap.KeyPress += ChiNhapSo_KeyPress;

            // Gán sự kiện đổi giá trị để tính tiền tự động
            txtSoLuong.TextChanged += (s, ev) => TinhThanhTien();
            txtDonGiaNhap.TextChanged += (s, ev) => TinhThanhTien();

            BindingDuLieu();
        }



        private void TimMaPhieuNhapTuDong()
        {
            if (xuLyThem && cboNguoiGiaoHang.Text != "" && dtpNgayNhap.Value != null)
            {
                string nguoiGiao = cboNguoiGiaoHang.Text;
                DateTime ngayChon = dtpNgayNhap.Value.Date;

                // Tìm Phiếu Nhập khớp tên và khớp ngày
                var phieu = context.PhieuNhaps.ToList().FirstOrDefault(p => p.NguoiGiaoHang == nguoiGiao && p.NgayNhap.Date == ngayChon);

                if (phieu != null)
                {
                    txtMaPhieuNhap.Text = phieu.MaPhieuNhap; // Tự hiện mã
                }
                else
                {
                    txtMaPhieuNhap.Text = ""; // Không thấy thì để trống
                }
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
        
            xuLyThem = true;
            BatTatChucNang(true);
            txtMaCTPN.Clear();
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtMaPhieuNhap.Clear(); // Đảm bảo làm sạch mã phiếu

            // Tránh lỗi null bằng cách tự động chọn mục đầu tiên (nếu có dữ liệu)
            if (cboNguoiGiaoHang.Items.Count > 0) cboNguoiGiaoHang.SelectedIndex = 0;
            if (cboMaTiVi.Items.Count > 0) cboMaTiVi.SelectedIndex = 0;

            cboNguoiGiaoHang.Focus(); // Thay đổi Focus vào ô Người giao hàng
        }
        

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuNhap.CurrentRow != null)
            {
                xuLyThem = false;
                BatTatChucNang(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuNhap.CurrentRow == null) return;

            if (MessageBox.Show("Bạn có muốn xóa chi tiết này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maCT = int.Parse(txtMaCTPN.Text);
                var ct = context.ChiTietPhieuNhaps.Find(maCT);
                if (ct != null)
                {
                    var tivi = context.QuanLyTiVis.Find(ct.MaTiVi);
                    if (tivi != null) tivi.SoLuongTon -= ct.SoLuongNhap;

                    context.ChiTietPhieuNhaps.Remove(ct);
                    context.SaveChanges();
                    frmChiTietPhieuNhap_Load(sender, e);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {

            frmChiTietPhieuNhap_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng mã phiếu
            if (string.IsNullOrWhiteSpace(txtMaPhieuNhap.Text))
            {
                MessageBox.Show("Không tìm thấy Mã Phiếu Nhập cho người giao hàng và ngày này!\nVui lòng lập Phiếu Nhập bên form kia trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int soLuong = string.IsNullOrWhiteSpace(txtSoLuong.Text) ? 0 : int.Parse(txtSoLuong.Text);
                decimal donGia = string.IsNullOrWhiteSpace(txtDonGiaNhap.Text) ? 0 : decimal.Parse(txtDonGiaNhap.Text);

                if (xuLyThem)
                {
                    ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();

                    // THAY ĐỔI Ở ĐÂY: Dùng txtMaPhieuNhap thay vì cboMaPhieuNhap
                    ctpn.MaPhieuNhap = txtMaPhieuNhap.Text;
                    ctpn.MaTiVi = cboMaTiVi.SelectedValue.ToString();
                    ctpn.SoLuongNhap = soLuong;
                    ctpn.DonGiaNhap = donGia;

                    context.ChiTietPhieuNhaps.Add(ctpn);

                    var tivi = context.QuanLyTiVis.Find(ctpn.MaTiVi);
                    if (tivi != null) tivi.SoLuongTon += soLuong;
                }
                else
                {
                    int maCTPN = int.Parse(txtMaCTPN.Text);
                    var ctSua = context.ChiTietPhieuNhaps.Find(maCTPN);
                    if (ctSua != null)
                    {
                        var tivi = context.QuanLyTiVis.Find(ctSua.MaTiVi);
                        if (tivi != null)
                        {
                            tivi.SoLuongTon = tivi.SoLuongTon - ctSua.SoLuongNhap + soLuong;
                        }

                        // THAY ĐỔI Ở ĐÂY CŨNG VẬY
                        ctSua.MaPhieuNhap = txtMaPhieuNhap.Text;
                        ctSua.MaTiVi = cboMaTiVi.SelectedValue.ToString();
                        ctSua.SoLuongNhap = soLuong;
                        ctSua.DonGiaNhap = donGia;
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmChiTietPhieuNhap_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + ex.Message);
            }
        
        }

        private void dgvChiTietPhieuNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name == "colThanhTien" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = val.ToString("N0");
                }
            }
        }

        private void cboNguoiGiaoHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimMaPhieuNhapTuDong();
        }

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            TimMaPhieuNhapTuDong();
        }
    }
}

