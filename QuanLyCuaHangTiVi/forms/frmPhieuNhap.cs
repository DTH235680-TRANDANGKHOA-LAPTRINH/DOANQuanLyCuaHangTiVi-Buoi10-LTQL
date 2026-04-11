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

        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        // --- HÀM MỚI: TỰ ĐỘNG SINH MÃ PHIẾU NHẬP ---
        private string GenerateMaPhieuNhap()
        {
            var dsMaPN = context.PhieuNhaps.Select(k => k.MaPhieuNhap).ToList();
            if (dsMaPN.Count == 0) return "PN001";

            int maxId = 0;
            foreach (var ma in dsMaPN)
            {
                // Tìm các mã bắt đầu bằng "PN" và lấy số phía sau
                if (ma.StartsWith("PN") && ma.Length > 2)
                {
                    string soPhanDuoi = ma.Substring(2);
                    if (int.TryParse(soPhanDuoi, out int so))
                    {
                        if (so > maxId) maxId = so;
                    }
                }
            }
            return "PN" + (maxId + 1).ToString("D3");
        }

        // 2. Hàm Bật/Tắt chức năng
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            // ĐÃ THAY ĐỔI: Luôn khóa ô nhập mã vì mã đã được sinh tự động
            txtMaPhieuNhap.Enabled = false;

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

            // 3. Load dữ liệu và nạp vào BindingSource
            var listPhieu = context.PhieuNhaps.ToList();
            bindingSource.DataSource = listPhieu;

            // 4. Đổ dữ liệu vào DataGridView
            dgvPhieuNhap.AutoGenerateColumns = false;
            dgvPhieuNhap.DataSource = bindingSource;

            // Ánh xạ cột
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

            // GỌI HÀM TẠO MÃ TỰ ĐỘNG
            txtMaPhieuNhap.Text = GenerateMaPhieuNhap();

            txtNguoiGiaoHang.Clear();
            txtGhiChu.Clear();
            dtpNgayNhap.Value = DateTime.Now;

            txtNguoiGiaoHang.Focus(); // Bỏ qua txtMaPhieuNhap vì đã bị khóa
        }

        private void dgvChiTietPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {// Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtMaPhieuNhap.Text))
            {
                MessageBox.Show("Lỗi: Mã Phiếu Nhập trống. Hãy thử bấm Hủy và Thêm lại.");
                return;
            }

            try
            {
                if (xuLyThem) // Trường hợp Thêm mới
                {
                    var checkID = context.PhieuNhaps.Find(txtMaPhieuNhap.Text);
                    if (checkID != null)
                    {
                        // Đề phòng lỗi trùng, tự sinh mã mới nhất
                        txtMaPhieuNhap.Text = GenerateMaPhieuNhap();
                    }

                    PhieuNhap pn = new PhieuNhap();
                    pn.MaPhieuNhap = txtMaPhieuNhap.Text.Trim();
                    pn.NguoiGiaoHang = txtNguoiGiaoHang.Text;
                    pn.GhiChu = txtGhiChu.Text;
                    pn.NgayNhap = dtpNgayNhap.Value;

                    context.PhieuNhaps.Add(pn);
                }
                else // Trường hợp Sửa (RẤT GỌN VÌ KHÔNG ĐỔI MÃ)
                {
                    var pnSua = context.PhieuNhaps.Find(txtMaPhieuNhap.Text.Trim());
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
                // Ghi chú: txtMaPhieuNhap vẫn bị khóa theo hàm BatTatChucNang
                // Người dùng chỉ được sửa Người giao hàng, Ngày nhập, Ghi chú
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
                        MessageBox.Show("Không thể xóa phiếu nhập này vì nó đã có chi tiết phiếu nhập đi kèm.\nLỗi chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

       
    }
}
