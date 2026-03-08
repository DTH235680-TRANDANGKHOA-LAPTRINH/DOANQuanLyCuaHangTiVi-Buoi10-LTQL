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
    public partial class frmPhieuNhap : Form
    {
        // 1. Khởi tạo Context và biến toàn cục giống mẫu TiVi
        AppDbContext context = new AppDbContext();
        bool xuLyThem = false;
        BindingSource bindingSource = new BindingSource();
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        // 2. Hàm Bật/Tắt chức năng giống hệt frmQuanLyTiVi
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtMaPhieuNhap.Enabled = giaTri;
            txtNguoiGiaoHang.Enabled = giaTri;
            txtGhiChu.Enabled = giaTri;

            // Bật tắt ô chọn Ngày Nhập
            dtpNgayNhap.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
        }




        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            // 3. Load dữ liệu và nạp vào BindingSource
            var listPhieu = context.PhieuNhaps.ToList();
            bindingSource.DataSource = listPhieu;

            // 4. Đổ dữ liệu vào DataGridView (Dưới nút bấm)
            dgvPhieuNhap.AutoGenerateColumns = false;
            dgvPhieuNhap.DataSource = bindingSource;

            // Ánh xạ cột (MaPN, GhiChu, NguoiGiao phải trùng tên cột thiết kế)
            if (dgvPhieuNhap.Columns.Contains("MaPN")) dgvPhieuNhap.Columns["MaPN"].DataPropertyName = "MaPhieuNhap";
            if (dgvPhieuNhap.Columns.Contains("NgayNhap")) dgvPhieuNhap.Columns["NgayNhap"].DataPropertyName = "NgayNhap";
            if (dgvPhieuNhap.Columns.Contains("GhiChu")) dgvPhieuNhap.Columns["GhiChu"].DataPropertyName = "GhiChu";
            if (dgvPhieuNhap.Columns.Contains("NguoiGiao")) dgvPhieuNhap.Columns["NguoiGiao"].DataPropertyName = "NguoiGiaoHang";

            txtMaPhieuNhap.DataBindings.Clear();
            txtNguoiGiaoHang.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            dtpNgayNhap.DataBindings.Clear();

            // Binding dữ liệu mới
            txtMaPhieuNhap.DataBindings.Add("Text", bindingSource, "MaPhieuNhap", true, DataSourceUpdateMode.Never);
            txtNguoiGiaoHang.DataBindings.Add("Text", bindingSource, "NguoiGiaoHang", true, DataSourceUpdateMode.Never);
            txtGhiChu.DataBindings.Add("Text", bindingSource, "GhiChu", true, DataSourceUpdateMode.Never);
            dtpNgayNhap.DataBindings.Add("Value", bindingSource, "NgayNhap", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            txtMaPhieuNhap.Clear();
            txtNguoiGiaoHang.Clear();
            txtGhiChu.Clear();
            dtpNgayNhap.Value = DateTime.Now;
            txtMaPhieuNhap.Focus();
        }

        private void dgvChiTietPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {// Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtMaPhieuNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Phiếu!");
                return;
            }

            try
            {
                if (xuLyThem) // Trường hợp Thêm mới
                {
                    if (context.PhieuNhaps.Any(x => x.MaPhieuNhap == txtMaPhieuNhap.Text))
                    {
                        MessageBox.Show("Mã phiếu này đã tồn tại!");
                        return;
                    }

                    PhieuNhap pn = new PhieuNhap();
                    pn.MaPhieuNhap = txtMaPhieuNhap.Text;
                    pn.NguoiGiaoHang = txtNguoiGiaoHang.Text;
                    pn.GhiChu = txtGhiChu.Text;
                    pn.NgayNhap = dtpNgayNhap.Value;

                    context.PhieuNhaps.Add(pn);
                }
                else // Trường hợp Sửa
                {
                    var pnSua = context.PhieuNhaps.Find(txtMaPhieuNhap.Text);
                    if (pnSua != null)
                    {
                        pnSua.NguoiGiaoHang = txtNguoiGiaoHang.Text;
                        pnSua.GhiChu = txtGhiChu.Text;
                        pnSua.NgayNhap = dtpNgayNhap.Value;
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Đã lưu dữ liệu thành công!");
                frmPhieuNhap_Load(sender, e); // Load lại để cập nhật lưới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmPhieuNhap_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTietPhieuNhap_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null)
            {
                xuLyThem = false;
                BatTatChucNang(true);
                txtMaPhieuNhap.Enabled = false; // Không cho sửa khóa chính
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null)
            {
                string maPN = txtMaPhieuNhap.Text;
                DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa Phiếu Nhập '{maPN}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        var pn = context.PhieuNhaps.Find(maPN);
                        if (pn != null)
                        {
                            context.PhieuNhaps.Remove(pn);
                            context.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmPhieuNhap_Load(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa phiếu nhập này vì có thể nó đã có chi tiết phiếu nhập đi kèm.\nLỗi chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
