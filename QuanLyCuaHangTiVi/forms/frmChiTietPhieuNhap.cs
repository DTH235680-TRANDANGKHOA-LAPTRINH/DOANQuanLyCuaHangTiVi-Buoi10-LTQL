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
        AppDbContext context = new AppDbContext();
        bool xuLyThem = false;
        BindingSource bindingSource = new BindingSource();

        public frmChiTietPhieuNhap()
        {
            InitializeComponent();
        }

        // 2. Hàm Bật/Tắt các nút và ô nhập
        private void BatTatChucNang(bool giaTri)
        {
            // true: Đang nhập liệu (Hiện Lưu/Hủy)
            // false: Đang xem (Hiện Thêm/Sửa/Xóa)
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            // Các ô nhập liệu
            cboMaPhieuNhap.Enabled = giaTri;
            cboMaTiVi.Enabled = giaTri;
            txtSoLuong.Enabled = giaTri;
            txtDonGiaNhap.Enabled = giaTri;

            // Khóa cứng các ô không được phép sửa
            txtMaCTPN.Enabled = false;
            txtThanhTien.Enabled = false;

            // Các nút chức năng
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
        }

        // Hàm phụ nạp dữ liệu cho ComboBox
        private void LoadComboBox()
        {
            // Nạp Phiếu Nhập
            cboMaPhieuNhap.DataSource = context.PhieuNhaps.ToList();
            cboMaPhieuNhap.DisplayMember = "MaPhieuNhap";
            cboMaPhieuNhap.ValueMember = "MaPhieuNhap";

            // Nạp TiVi
            cboMaTiVi.DataSource = context.QuanLyTiVis.ToList();
            cboMaTiVi.DisplayMember = "TenTiVi";
            cboMaTiVi.ValueMember = "MaTiVi";
        }
        private void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadComboBox();

            // 1. Load dữ liệu từ DB
            var listCTPN = context.ChiTietPhieuNhaps.ToList();

            // 2. Tạo BindingSource
            bindingSource.DataSource = listCTPN;

            // 3. Cấu hình DataGridView
            dgvChiTietPhieuNhap.AutoGenerateColumns = false;
            dgvChiTietPhieuNhap.DataSource = bindingSource;

            // Ánh xạ cột trên lưới (Bạn hãy đổi tên cột trong ngoặc kép cho khớp với Name của cột ngoài Design)
            if (dgvChiTietPhieuNhap.Columns.Contains("colMaCTPN")) dgvChiTietPhieuNhap.Columns["colMaCTPN"].DataPropertyName = "MaCTPN";
            if (dgvChiTietPhieuNhap.Columns.Contains("colMaPhieuNhap")) dgvChiTietPhieuNhap.Columns["colMaPhieuNhap"].DataPropertyName = "MaPhieuNhap";
            if (dgvChiTietPhieuNhap.Columns.Contains("colMaTiVi")) dgvChiTietPhieuNhap.Columns["colMaTiVi"].DataPropertyName = "MaTiVi";
            if (dgvChiTietPhieuNhap.Columns.Contains("colSoLuong")) dgvChiTietPhieuNhap.Columns["colSoLuong"].DataPropertyName = "SoLuongNhap";
            if (dgvChiTietPhieuNhap.Columns.Contains("colDonGia")) dgvChiTietPhieuNhap.Columns["colDonGia"].DataPropertyName = "DonGiaNhap";

            // 4. Binding dữ liệu vào Textbox/ComboBox
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            // Xóa trắng để nhập mới
            txtMaCTPN.Clear();
            txtSoLuong.Clear();
            txtDonGiaNhap.Clear();
            txtThanhTien.Clear();

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
            if (dgvChiTietPhieuNhap.CurrentRow != null)
            {
                int maCT = int.Parse(txtMaCTPN.Text);
                var ct = context.ChiTietPhieuNhaps.Find(maCT);

                if (ct != null && MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết phiếu nhập này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    context.ChiTietPhieuNhaps.Remove(ct);
                    context.SaveChanges();
                    frmChiTietPhieuNhap_Load(sender, e); // Tải lại form
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
            // Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtDonGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Số lượng và Đơn giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (xuLyThem)
                {
                    ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                    ctpn.MaPhieuNhap = cboMaPhieuNhap.SelectedValue.ToString();
                    ctpn.MaTiVi = cboMaTiVi.SelectedValue.ToString();
                    ctpn.SoLuongNhap = int.Parse(txtSoLuong.Text);
                    ctpn.DonGiaNhap = decimal.Parse(txtDonGiaNhap.Text);

                    context.ChiTietPhieuNhaps.Add(ctpn);
                    // BỔ SUNG: CỘNG THÊM SỐ LƯỢNG VÀO KHO TIVI
                    var tivi = context.QuanLyTiVis.Find(ctpn.MaTiVi);
                    if (tivi != null)
                    {
                        tivi.SoLuongTon += ctpn.SoLuongNhap; // Cộng dồn số lượng
                    }
                }
                else
                {
                    int maCTPN = int.Parse(txtMaCTPN.Text);
                    var ctSua = context.ChiTietPhieuNhaps.Find(maCTPN);
                    if (ctSua != null)
                    {
                        ctSua.MaPhieuNhap = cboMaPhieuNhap.SelectedValue.ToString();
                        ctSua.MaTiVi = cboMaTiVi.SelectedValue.ToString();
                        ctSua.SoLuongNhap = int.Parse(txtSoLuong.Text);
                        ctSua.DonGiaNhap = decimal.Parse(txtDonGiaNhap.Text);
                        var tivi = context.QuanLyTiVis.Find(ctSua.MaTiVi);
                        if (tivi != null)
                        {
                            // Công thức: Lấy số tồn hiện tại - đi số nhập cũ + số nhập mới
                            int soLuongMoi = int.Parse(txtSoLuong.Text);
                            tivi.SoLuongTon = tivi.SoLuongTon - ctSua.SoLuongNhap + soLuongMoi;
                        }
                        ctSua.MaPhieuNhap = cboMaPhieuNhap.SelectedValue.ToString();
                        ctSua.MaTiVi = cboMaTiVi.SelectedValue.ToString();
                        ctSua.SoLuongNhap = int.Parse(txtSoLuong.Text);
                        ctSua.DonGiaNhap = decimal.Parse(txtDonGiaNhap.Text);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmChiTietPhieuNhap_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        private void dgvChiTietPhieuNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Đảm bảo bạn đặt Name của cột Thành Tiền trên lưới là "colThanhTien"
            if (dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name == "colThanhTien" && e.RowIndex >= 0)
            {
                var ct = dgvChiTietPhieuNhap.Rows[e.RowIndex].DataBoundItem as ChiTietPhieuNhap;
                if (ct != null)
                {
                    e.Value = (ct.SoLuongNhap * ct.DonGiaNhap).ToString("N0");
                }
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            // Copy đoạn này bỏ vào
            if (int.TryParse(txtSoLuong.Text, out int sl) && decimal.TryParse(txtDonGiaNhap.Text, out decimal dg))
            {
                txtThanhTien.Text = (sl * dg).ToString("N0");
            }
            else
            {
                txtThanhTien.Text = "0";
            }
        }
    }
}
