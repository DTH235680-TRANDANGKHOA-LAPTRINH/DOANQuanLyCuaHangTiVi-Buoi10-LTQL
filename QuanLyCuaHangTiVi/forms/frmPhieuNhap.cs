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
        // 1. Khởi tạo Context và biến toàn cục
        AppDbContext context = new AppDbContext();
        bool xuLyThem = false;
        BindingSource bindingSource = new BindingSource();

        // BIẾN MỚI THÊM: Dùng để lưu mã cũ khi sửa và ErrorProvider báo lỗi
        string maPhieuNhapCu = "";
        ErrorProvider errorProvider = new ErrorProvider();
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        // 2. Hàm Bật/Tắt chức năng giống hệt frmQuanLyTiVi
        // 2. Hàm Bật/Tắt chức năng
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtMaPhieuNhap.Enabled = giaTri;
            txtNguoiGiaoHang.Enabled = giaTri;
            txtGhiChu.Enabled = giaTri;
            dtpNgayNhap.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
        }




        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            errorProvider.Clear(); // Xóa mọi cảnh báo lỗi trên form nếu có

            // 3. Load dữ liệu và nạp vào BindingSource
            var listPhieu = context.PhieuNhaps.ToList();
            bindingSource.DataSource = listPhieu;

            // 4. Đổ dữ liệu vào DataGridView
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
            errorProvider.Clear();

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
                    // Đề phòng trường hợp lỗi mạng/nhấn đúp, ta vẫn check cứng lại 1 lần nữa
                    if (context.PhieuNhaps.Any(x => x.MaPhieuNhap == txtMaPhieuNhap.Text))
                    {
                        MessageBox.Show("Mã phiếu này đã tồn tại!");
                        return;
                    }

                    PhieuNhap pn = new PhieuNhap();
                    pn.MaPhieuNhap = txtMaPhieuNhap.Text.Trim();
                    pn.NguoiGiaoHang = txtNguoiGiaoHang.Text;
                    pn.GhiChu = txtGhiChu.Text;
                    pn.NgayNhap = dtpNgayNhap.Value;

                    context.PhieuNhaps.Add(pn);
                }
                else // Trường hợp Sửa
                {
                    string maMoi = txtMaPhieuNhap.Text.Trim();

                    if (maMoi == maPhieuNhapCu)
                    {
                        // Nếu mã không thay đổi, cập nhật bình thường
                        var pnSua = context.PhieuNhaps.Find(maPhieuNhapCu);
                        if (pnSua != null)
                        {
                            pnSua.NguoiGiaoHang = txtNguoiGiaoHang.Text;
                            pnSua.GhiChu = txtGhiChu.Text;
                            pnSua.NgayNhap = dtpNgayNhap.Value;
                        }
                    }
                    else
                    {
                        // Nếu mã ĐÃ BỊ THAY ĐỔI, cần tạo mới record và xóa cái cũ đi
                        var pnCu = context.PhieuNhaps.Find(maPhieuNhapCu);
                        if (pnCu != null)
                        {
                            // 1. Thêm record với dữ liệu mới
                            PhieuNhap pnMoi = new PhieuNhap();
                            pnMoi.MaPhieuNhap = maMoi;
                            pnMoi.NguoiGiaoHang = txtNguoiGiaoHang.Text;
                            pnMoi.GhiChu = txtGhiChu.Text;
                            pnMoi.NgayNhap = dtpNgayNhap.Value;
                            context.PhieuNhaps.Add(pnMoi);

                            // 2. Xóa record cũ đi
                            context.PhieuNhaps.Remove(pnCu);
                        }
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
            errorProvider.Clear();
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
                errorProvider.Clear();

                // Mở khóa để cho phép sửa đổi Mã Phiếu Nhập
                txtMaPhieuNhap.Enabled = true;

                // Lưu lại mã phiếu nhập hiện tại trước khi bị người dùng gõ sửa
                maPhieuNhapCu = txtMaPhieuNhap.Text.Trim();
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

        private void txtMaPhieuNhap_TextChanged(object sender, EventArgs e)
        {

            string maNhapVao = txtMaPhieuNhap.Text.Trim();

            // Nếu để trống thì không báo lỗi trùng, nhưng khi bấm Lưu vẫn sẽ bị chặn lại
            if (string.IsNullOrWhiteSpace(maNhapVao))
            {
                errorProvider.Clear();
                btnLuu.Enabled = true;
                return;
            }

            bool isDuplicate = false;

            if (xuLyThem)
            {
                // Thêm mới: Chỉ cần tìm có mã nào trong DB giống chữ vừa gõ không
                isDuplicate = context.PhieuNhaps.Any(x => x.MaPhieuNhap == maNhapVao);
            }
            else
            {
                // Sửa: Tìm xem có trùng không, nhưng phải LOẠI TRỪ mã cũ của chính nó
                isDuplicate = context.PhieuNhaps.Any(x => x.MaPhieuNhap == maNhapVao && x.MaPhieuNhap != maPhieuNhapCu);
            }

            if (isDuplicate)
            {
                // Báo lỗi bằng dấu chấm than đỏ và khóa nút Lưu ngay lập tức
                errorProvider.SetError(txtMaPhieuNhap, "Mã phiếu nhập này đã tồn tại! Vui lòng nhập mã khác.");
                btnLuu.Enabled = false;
            }
            else
            {
                // Tắt báo lỗi và mở nút Lưu
                errorProvider.Clear();
                btnLuu.Enabled = true;
            }
        }
    }
}
