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
            cboMaPhieuNhap.Enabled = giaTri;
            cboMaTiVi.Enabled = giaTri;
            txtSoLuong.Enabled = giaTri;
            txtDonGiaNhap.Enabled = giaTri;

            txtMaCTPN.Enabled = false;
            txtThanhTien.Enabled = false;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
        }

        private void LoadComboBox()
        {
            cboMaPhieuNhap.DataSource = context.PhieuNhaps.ToList();
            cboMaPhieuNhap.DisplayMember = "MaPhieuNhap";
            cboMaPhieuNhap.ValueMember = "MaPhieuNhap";

            cboMaTiVi.DataSource = context.QuanLyTiVis.ToList();
            cboMaTiVi.DisplayMember = "TenTiVi";
            cboMaTiVi.ValueMember = "MaTiVi";
        }

        private void BindingDuLieu()
        {
            txtMaCTPN.DataBindings.Clear();
            cboMaPhieuNhap.DataBindings.Clear();
            cboMaTiVi.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.Clear();

            txtMaCTPN.DataBindings.Add("Text", bindingSource, "MaCTPN", true, DataSourceUpdateMode.Never);
            cboMaPhieuNhap.DataBindings.Add("SelectedValue", bindingSource, "MaPhieuNhap", true, DataSourceUpdateMode.Never);
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
       
        
       
       

        
        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtMaCTPN.Clear();
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            cboMaPhieuNhap.Focus();
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
            try
            {
                int soLuong = string.IsNullOrWhiteSpace(txtSoLuong.Text) ? 0 : int.Parse(txtSoLuong.Text);
                decimal donGia = string.IsNullOrWhiteSpace(txtDonGiaNhap.Text) ? 0 : decimal.Parse(txtDonGiaNhap.Text);

                if (xuLyThem)
                {
                    ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                    ctpn.MaPhieuNhap = cboMaPhieuNhap.SelectedValue.ToString();
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
                            // Cập nhật lại tồn kho: trừ số lượng cũ, cộng số lượng mới
                            tivi.SoLuongTon = tivi.SoLuongTon - ctSua.SoLuongNhap + soLuong;
                        }

                        ctSua.MaPhieuNhap = cboMaPhieuNhap.SelectedValue.ToString();
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
       
    }
}

