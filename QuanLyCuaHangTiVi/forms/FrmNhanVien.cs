using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangTiVi.DATA; // Đảm bảo dùng đúng namespace chứa Model


namespace QuanLyCuaHangTiVi.forms
{
    public partial class FrmNhanVien : Form
    {
        AppDbContext db = new AppDbContext();
        bool isThem = false;

        string tenFileAnhNV = ""; // Lưu tên file ảnh đang chọn

        public FrmNhanVien()
        {
            InitializeComponent();
        }
        // 2. Hàm điều khiển trạng thái các nút và ô nhập
        private void BatTatChucNang(bool dangThaoTac)
        {
            btnLuu.Enabled = dangThaoTac;
            btnHuyBo.Enabled = dangThaoTac;

            txtMaNhanVien.Enabled = dangThaoTac && isThem;
            txtHoTenNhanVien.Enabled = dangThaoTac;
            txtTenDangNhap.Enabled = dangThaoTac;
            txtMatKhau.Enabled = dangThaoTac;
            cboQuyenHan.Enabled = dangThaoTac;
            txtLuong.Enabled = dangThaoTac;
            dtpNgaySinh.Enabled = dangThaoTac; // Bật tắt ô ngày sinh

            btnThem.Enabled = !dangThaoTac;
            btnSua.Enabled = !dangThaoTac;
            btnXoa.Enabled = !dangThaoTac;
            btnThoat.Enabled = !dangThaoTac;
        }
        private void txtDonGiaBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            var danhSachNV = db.NhanViens.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachNV;

            dgvDanhSachNhanVien.AutoGenerateColumns = false;
            dgvDanhSachNhanVien.DataSource = bindingSource;
            dgvDanhSachNhanVien.RowTemplate.Height = 80;

            if (dgvDanhSachNhanVien.Columns.Contains("AnhChanDung"))
                dgvDanhSachNhanVien.Columns["AnhChanDung"].Visible = false;

            if (dgvDanhSachNhanVien.Columns.Contains("MaNhanVien")) dgvDanhSachNhanVien.Columns["MaNhanVien"].DataPropertyName = "MaNhanVien";
            if (dgvDanhSachNhanVien.Columns.Contains("HoTen")) dgvDanhSachNhanVien.Columns["HoTen"].DataPropertyName = "HoTenNhanVien";
            if (dgvDanhSachNhanVien.Columns.Contains("NgaySinh")) dgvDanhSachNhanVien.Columns["NgaySinh"].DataPropertyName = "NgaySinh"; // Cột ngày sinh trên lưới
            if (dgvDanhSachNhanVien.Columns.Contains("TenDangNhap")) dgvDanhSachNhanVien.Columns["TenDangNhap"].DataPropertyName = "TenDangNhap";
            if (dgvDanhSachNhanVien.Columns.Contains("QuyenHan")) dgvDanhSachNhanVien.Columns["QuyenHan"].DataPropertyName = "QuyenHan";
            if (dgvDanhSachNhanVien.Columns.Contains("CotLuong")) dgvDanhSachNhanVien.Columns["CotLuong"].DataPropertyName = "Luong";

            // --- DATABINDING ---
            txtMaNhanVien.DataBindings.Clear();
            txtHoTenNhanVien.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Clear();
            cboQuyenHan.DataBindings.Clear();
            txtLuong.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear(); // Xóa binding cũ

            txtMaNhanVien.DataBindings.Add("Text", bindingSource, "MaNhanVien", true, DataSourceUpdateMode.Never);
            txtHoTenNhanVien.DataBindings.Add("Text", bindingSource, "HoTenNhanVien", true, DataSourceUpdateMode.Never);
            txtTenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", true, DataSourceUpdateMode.Never);
            cboQuyenHan.DataBindings.Add("Text", bindingSource, "QuyenHan", true, DataSourceUpdateMode.Never);
            txtLuong.DataBindings.Add("Text", bindingSource, "Luong", true, DataSourceUpdateMode.Never);
            dtpNgaySinh.DataBindings.Add("Value", bindingSource, "NgaySinh", true, DataSourceUpdateMode.Never); // Bind ngày sinh

            txtMaNhanVien.Leave -= txtMaNhanVien_Leave;
            txtMaNhanVien.Leave += txtMaNhanVien_Leave;

            txtMatKhau.Clear();
        }
        private void txtMaNhanVien_Leave(object sender, EventArgs e)
        {
            // Chỉ kiểm tra khi đang ở chế độ THÊM và ô mã không để trống
            if (isThem && !string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                string maNhap = txtMaNhanVien.Text.Trim();

                // Truy vấn xem mã này đã tồn tại trong bảng NhanVien chưa
                bool trungMa = db.NhanViens.Any(x => x.MaNhanVien == maNhap);

                if (trungMa)
                {
                    MessageBox.Show($"Mã nhân viên '{maNhap}' đã tồn tại! Vui lòng chọn mã khác.",
                                    "Cảnh báo trùng mã",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    txtMaNhanVien.Clear(); // Xóa nội dung đã nhập
                    txtMaNhanVien.Focus(); // Đưa con trỏ quay lại ô Mã
                }
            }
        }
        private void ChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            BatTatChucNang(true);

            txtMaNhanVien.Clear();
            txtHoTenNhanVien.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.SelectedIndex = -1;
            txtLuong.Clear();

            // Mặc định nhân viên mới là 18 tuổi
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18);

            txtMaNhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                MessageBox.Show("Chưa chọn nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isThem = false;
            BatTatChucNang(true);
            txtMatKhau.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên: " + txtHoTenNhanVien.Text + "?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var nvXoa = db.NhanViens.Find(txtMaNhanVien.Text);
                    if (nvXoa != null)
                    {
                        db.NhanViens.Remove(nvXoa);
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        FrmNhanVien_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (có thể do nhân viên đã lập hóa đơn/phiếu nhập): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtHoTenNhanVien.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenNhanVien.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Đăng Nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            // --- KIỂM TRA ĐỦ 18 TUỔI ---
            int tuoi = DateTime.Now.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value.Date > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 18)
            {
                MessageBox.Show("Nhân viên phải từ đủ 18 tuổi trở lên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgaySinh.Focus();
                return;
            }

            decimal luongNV = 0;
            if (!string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                string tienLuong = txtLuong.Text.Replace(",", "").Replace(".", "");
                if (!decimal.TryParse(tienLuong, out luongNV))
                {
                    MessageBox.Show("Vui lòng nhập lương là một con số hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLuong.Focus();
                    return;
                }
            }

            try
            {
                if (isThem)
                {
                    var checkID = db.NhanViens.Find(txtMaNhanVien.Text);
                    if (checkID != null)
                    {
                        MessageBox.Show("Mã nhân viên này đã tồn tại!", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        MessageBox.Show("Nhân viên mới cần phải có mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMatKhau.Focus();
                        return;
                    }

                    NhanVien nv = new NhanVien();
                    nv.MaNhanVien = txtMaNhanVien.Text.Trim();
                    nv.HoTenNhanVien = txtHoTenNhanVien.Text.Trim();
                    nv.TenDangNhap = txtTenDangNhap.Text.Trim();
                    nv.MatKhau = txtMatKhau.Text;
                    nv.QuyenHan = cboQuyenHan.Text;
                    nv.NgaySinh = dtpNgaySinh.Value; // Lưu Ngày Sinh
                    nv.Luong = luongNV;
                    nv.AnhChanDung = tenFileAnhNV;

                    db.NhanViens.Add(nv);
                }
                else
                {
                    var nvSua = db.NhanViens.Find(txtMaNhanVien.Text);
                    if (nvSua != null)
                    {
                        nvSua.HoTenNhanVien = txtHoTenNhanVien.Text.Trim();
                        nvSua.TenDangNhap = txtTenDangNhap.Text.Trim();
                        nvSua.QuyenHan = cboQuyenHan.Text;
                        nvSua.NgaySinh = dtpNgaySinh.Value; // Cập nhật Ngày Sinh
                        nvSua.Luong = luongNV;

                        if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        {
                            nvSua.MatKhau = txtMatKhau.Text;
                        }

                        if (!string.IsNullOrEmpty(tenFileAnhNV))
                        {
                            nvSua.AnhChanDung = tenFileAnhNV;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu nhân viên để cập nhật!");
                        return;
                    }
                }

                db.SaveChanges();
                MessageBox.Show("Đã lưu thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tenFileAnhNV = "";
                FrmNhanVien_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Load lại dữ liệu ban đầu
            FrmNhanVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Ảnh|*.jpg;*.jpeg;*.png";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                    string thuMucAnh = Path.Combine(projectDir, "images");

                    if (!Directory.Exists(thuMucAnh)) Directory.CreateDirectory(thuMucAnh);

                    tenFileAnhNV = Path.GetFileName(openFile.FileName);
                    string duongDanDich = Path.Combine(thuMucAnh, tenFileAnhNV);
                    File.Copy(openFile.FileName, duongDanDich, true);

                    if (picAnhNhanVien.Image != null) picAnhNhanVien.Image.Dispose();
                    picAnhNhanVien.Image = Image.FromFile(duongDanDich);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xử lý ảnh: " + ex.Message); }
            }
        }

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var nv = dgvDanhSachNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVien;
                if (nv != null && !string.IsNullOrEmpty(nv.AnhChanDung))
                {
                    try
                    {
                        string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                        string path = Path.Combine(projectDir, "Images", nv.AnhChanDung);

                        if (picAnhNhanVien.Image != null) picAnhNhanVien.Image.Dispose();
                        if (File.Exists(path)) picAnhNhanVien.Image = Image.FromFile(path);
                        else picAnhNhanVien.Image = null;
                    }
                    catch { picAnhNhanVien.Image = null; }
                }
            }
        }

        private void dgvDanhSachNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSachNhanVien.Columns[e.ColumnIndex].Name == "CotHinhAnh" && e.RowIndex >= 0)
            {
                var nv = dgvDanhSachNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVien;

                if (nv != null && !string.IsNullOrEmpty(nv.AnhChanDung))
                {
                    try
                    {
                        string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                        string path = Path.Combine(projectDir, "Images", nv.AnhChanDung);

                        if (File.Exists(path))
                        {
                            byte[] bytes = File.ReadAllBytes(path);
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                e.Value = Image.FromStream(ms);
                            }
                        }
                    }
                    catch
                    {
                        e.Value = null;
                    }
                }
            }
        }

        
    }
}
