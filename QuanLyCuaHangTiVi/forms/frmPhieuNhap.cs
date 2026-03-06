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
        AppDbContext context = new AppDbContext();
        bool xuLyThem = false;
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            // true: Đang thao tác Thêm/Sửa (Hiện Lưu/Hủy)
            // false: Đang xem bình thường (Hiện Thêm/Sửa/Xóa)

            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            // Bật tắt phần Master (Thông tin phiếu)
            txtMaPhieuNhap.Enabled = giaTri;
            dtpNgayNhap.Enabled = giaTri;
            txtNguoiGiaoHang.Enabled = giaTri;
            txtGhiChu.Enabled = giaTri;

            // Bật tắt phần Detail (Lưới chi tiết)
            dgvChiTietPhieuNhap.Enabled = giaTri;

            // Các nút chức năng chính
            btnThem.Enabled = !giaTri;
            // Với Form Phiếu Nhập, nút Sửa/Xóa thường xử lý phức tạp hơn (liên quan tồn kho)
            // Nên tạm thời mình để nó hoạt động theo logic bật tắt chung
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
        }

        // Dọn dẹp form để nhập mới
        private void ResetForm()
        {
            txtMaPhieuNhap.Clear();
            txtNguoiGiaoHang.Clear();
            txtGhiChu.Clear();
            txtTongTienNhap.Text = "0";
            dtpNgayNhap.Value = DateTime.Now;
            dgvChiTietPhieuNhap.Rows.Clear();
        }

        // Nạp danh sách TiVi vào cột ComboBox trên DataGridView
        private void LoadComboBoxTiViVaoLuoi()
        {
            try
            {
                // Giả sử cột ComboBox của bạn tên là colMaTiVi (hoặc colTenTiVi)
                var colTiVi = (DataGridViewComboBoxColumn)dgvChiTietPhieuNhap.Columns["colMaTiVi"];
                colTiVi.DataSource = context.QuanLyTiVis.ToList();
                colTiVi.DisplayMember = "TenTiVi"; // Chữ hiện lên cho người dùng chọn
                colTiVi.ValueMember = "MaTiVi";    // Giá trị ngầm bên dưới để lưu Database
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa cấu hình cột ComboBox TiVi trên lưới: " + ex.Message);
            }
        }

        // Tính thành tiền cho 1 dòng
        private void TinhTienMotDong(int rowIndex)
        {
            try
            {
                var cellSoLuong = dgvChiTietPhieuNhap.Rows[rowIndex].Cells["colSoLuong"].Value;
                var cellDonGia = dgvChiTietPhieuNhap.Rows[rowIndex].Cells["colDonGia"].Value;

                int soLuong = cellSoLuong != null ? Convert.ToInt32(cellSoLuong) : 0;
                decimal donGia = cellDonGia != null ? Convert.ToDecimal(cellDonGia) : 0;

                dgvChiTietPhieuNhap.Rows[rowIndex].Cells["colThanhTien"].Value = soLuong * donGia;
            }
            catch { dgvChiTietPhieuNhap.Rows[rowIndex].Cells["colThanhTien"].Value = 0; }
        }

        // Tính tổng tiền cả phiếu đưa lên TextBox
        private void TinhTongTienPhiieu()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                if (row.Cells["colThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["colThanhTien"].Value);
                }
            }
            txtTongTienNhap.Text = tongTien.ToString("N0");
        }

        

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadComboBoxTiViVaoLuoi();
            BatTatChucNang(false); // Vừa vào form thì khóa hết, bắt phải bấm Thêm mới cho nhập
            txtTongTienNhap.ReadOnly = true; // Luôn khóa ô tổng tiền
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            ResetForm();
            txtMaPhieuNhap.Focus();
        }

        private void dgvChiTietPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                (dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name == "colSoLuong" ||
                 dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name == "colDonGia"))
            {
                TinhTienMotDong(e.RowIndex);
                TinhTongTienPhiieu();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {// Kiểm tra ràng buộc
            if (string.IsNullOrWhiteSpace(txtMaPhieuNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Phiếu Nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvChiTietPhieuNhap.Rows.Count == 0 || (dgvChiTietPhieuNhap.Rows.Count == 1 && dgvChiTietPhieuNhap.Rows[0].IsNewRow))
            {
                MessageBox.Show("Chưa có mặt hàng nào trong phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (xuLyThem)
                {
                    // Kiểm tra trùng mã phiếu nhập
                    if (context.PhieuNhaps.Any(p => p.MaPhieuNhap == txtMaPhieuNhap.Text.Trim()))
                    {
                        MessageBox.Show("Mã Phiếu Nhập này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 1. TẠO PHIẾU NHẬP
                    PhieuNhap pn = new PhieuNhap();
                    pn.MaPhieuNhap = txtMaPhieuNhap.Text.Trim();
                    pn.NgayNhap = dtpNgayNhap.Value;
                    pn.NguoiGiaoHang = txtNguoiGiaoHang.Text.Trim();
                    pn.GhiChu = txtGhiChu.Text.Trim();
                    string tienChuoi = txtTongTienNhap.Text.Replace(",", "").Replace(".", "");
                    pn.TongTienNhap = string.IsNullOrEmpty(tienChuoi) ? 0 : Convert.ToDecimal(tienChuoi);

                    context.PhieuNhaps.Add(pn);

                    // 2. TẠO CHI TIẾT PHIẾU NHẬP
                    foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                    {
                        if (row.IsNewRow) continue; // Bỏ qua dòng trống

                        ChiTietPhieuNhap ct = new ChiTietPhieuNhap();
                        ct.MaPhieuNhap = pn.MaPhieuNhap;
                        // Lấy Value từ cột ComboBox
                        ct.MaTiVi = row.Cells["colMaTiVi"].Value?.ToString();
                        ct.SoLuongNhap = Convert.ToInt32(row.Cells["colSoLuong"].Value ?? 0);
                        ct.DonGiaNhap = Convert.ToDecimal(row.Cells["colDonGia"].Value ?? 0);
                       

                        context.ChiTietPhieuNhaps.Add(ct);

                        // TIPS: Thường ở đây người ta sẽ viết thêm code CỘNG SỐ LƯỢNG TỒN vào bảng QuanLyTiVi
                    }
                }
                else
                {
                    // Phần code Cập nhật (Sửa) phiếu nhập - Thường rất phức tạp vì phải cộng trừ lại tồn kho
                    // Tạm thời để trống hoặc báo lỗi nếu chưa làm tới
                    MessageBox.Show("Chức năng sửa phiếu nhập đang được hoàn thiện!", "Thông báo");
                    return;
                }

                // 3. LƯU DATABASE
                context.SaveChanges();
                MessageBox.Show("Lưu Phiếu Nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trả form về trạng thái ban đầu
                BatTatChucNang(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            ResetForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTietPhieuNhap_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

        }
    }
}
