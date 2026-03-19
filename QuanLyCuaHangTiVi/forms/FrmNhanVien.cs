using System;
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
            // dangThaoTac = true: Đang nhập liệu (Hiện Lưu/Hủy)
            // dangThaoTac = false: Đang xem (Hiện Thêm/Sửa/Xóa)

            btnLuu.Enabled = dangThaoTac;
            btnHuyBo.Enabled = dangThaoTac;

            // Các ô nhập liệu (Riêng mã nhân viên chỉ được nhập khi Thêm)
            txtMaNhanVien.Enabled = dangThaoTac && isThem;
            txtHoTenNhanVien.Enabled = dangThaoTac;
            txtTenDangNhap.Enabled = dangThaoTac;
            txtMatKhau.Enabled = dangThaoTac;
            cboQuyenHan.Enabled = dangThaoTac;
            txtLuong.Enabled = dangThaoTac;

            // Các nút chức năng chính
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

            // Tải dữ liệu từ CSDL
            var danhSachNV = db.NhanViens.ToList();

            // Tạo BindingSource
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachNV;

            // Gán dữ liệu cho DataGridView
            dgvDanhSachNhanVien.AutoGenerateColumns = false;
            dgvDanhSachNhanVien.DataSource = bindingSource;

            // Chỉnh chiều cao dòng giống bên TiVi
            dgvDanhSachNhanVien.RowTemplate.Height = 80;

            // Nếu bạn muốn ẩn cột văn bản "AnhChanDung" tự động hiện ra
            if (dgvDanhSachNhanVien.Columns.Contains("AnhChanDung"))
                dgvDanhSachNhanVien.Columns["AnhChanDung"].Visible = false;

            // --- CẤU HÌNH CỘT CHO LƯỚI ---
            // (Bạn nhớ kiểm tra Property Name của các cột trong giao diện Design nhé)
            if (dgvDanhSachNhanVien.Columns.Contains("MaNhanVien")) dgvDanhSachNhanVien.Columns["MaNhanVien"].DataPropertyName = "MaNhanVien";
            if (dgvDanhSachNhanVien.Columns.Contains("HoTen")) dgvDanhSachNhanVien.Columns["HoTen"].DataPropertyName = "HoTenNhanVien";
            if (dgvDanhSachNhanVien.Columns.Contains("TenDangNhap")) dgvDanhSachNhanVien.Columns["TenDangNhap"].DataPropertyName = "TenDangNhap";
            if (dgvDanhSachNhanVien.Columns.Contains("QuyenHan")) dgvDanhSachNhanVien.Columns["QuyenHan"].DataPropertyName = "QuyenHan";
            if (dgvDanhSachNhanVien.Columns.Contains("CotLuong")) dgvDanhSachNhanVien.Columns["CotLuong"].DataPropertyName = "Luong";
            // Không map cột Mật Khẩu để tránh lộ mã băm (hash) lên lưới

            // --- DATABINDING (Tự đổ dữ liệu vào TextBox) ---
            txtMaNhanVien.DataBindings.Clear();
            txtHoTenNhanVien.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Clear();
            cboQuyenHan.DataBindings.Clear();
            txtLuong.DataBindings.Clear();

            txtMaNhanVien.DataBindings.Add("Text", bindingSource, "MaNhanVien", true, DataSourceUpdateMode.Never);
            txtHoTenNhanVien.DataBindings.Add("Text", bindingSource, "HoTenNhanVien", true, DataSourceUpdateMode.Never);
            txtTenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", true, DataSourceUpdateMode.Never);
            cboQuyenHan.DataBindings.Add("Text", bindingSource, "QuyenHan", true, DataSourceUpdateMode.Never);
            txtLuong.DataBindings.Add("Text", bindingSource, "Luong", true, DataSourceUpdateMode.Never);

            // Cố tình làm rỗng ô mật khẩu khi click vào các dòng (vì nó đã mã hóa, hiển thị ra cũng không đọc được)
            txtMatKhau.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            BatTatChucNang(true);

            // Xóa trắng để nhập mới
            txtMaNhanVien.Clear();
            txtHoTenNhanVien.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.SelectedIndex = -1;
            txtLuong.Clear();

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
                        FrmNhanVien_Load(sender, e); // Tải lại dữ liệu
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
            // 1. Kiểm tra các trường dữ liệu bắt buộc (Validation)
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

    // --- KIỂM TRA DỮ LIỆU LƯƠNG ---
    decimal luongNV = 0;
    if (!string.IsNullOrWhiteSpace(txtLuong.Text))
    {
        // Xóa dấu phẩy/chấm nếu người dùng có nhập định dạng tiền tệ (VD: 15,000,000 -> 15000000)
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
        if (isThem) // TRƯỜNG HỢP THÊM MỚI
        {
            // Kiểm tra trùng mã ID trước khi thêm
            var checkID = db.NhanViens.Find(txtMaNhanVien.Text);
            if (checkID != null)
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại!", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bắt buộc nhập mật khẩu khi tạo tài khoản mới
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Nhân viên mới cần phải có mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // Tạo đối tượng nhân viên mới
            NhanVien nv = new NhanVien();
            nv.MaNhanVien = txtMaNhanVien.Text.Trim();
            nv.HoTenNhanVien = txtHoTenNhanVien.Text.Trim();
            nv.TenDangNhap = txtTenDangNhap.Text.Trim();
            nv.MatKhau = txtMatKhau.Text;
            nv.QuyenHan = cboQuyenHan.Text;
            
            // LƯU LƯƠNG NHÂN VIÊN
            nv.Luong = luongNV; 

            // LƯU TÊN ẢNH: Gán tên file ảnh đã chọn vào cột trong DB
            nv.AnhChanDung = tenFileAnhNV;

            db.NhanViens.Add(nv);
        }
        else // TRƯỜNG HỢP SỬA (UPDATE)
        {
            var nvSua = db.NhanViens.Find(txtMaNhanVien.Text);
            if (nvSua != null)
            {
                nvSua.HoTenNhanVien = txtHoTenNhanVien.Text.Trim();
                nvSua.TenDangNhap = txtTenDangNhap.Text.Trim();
                nvSua.QuyenHan = cboQuyenHan.Text;
                
                // CẬP NHẬT LƯƠNG NHÂN VIÊN
                nvSua.Luong = luongNV;

                // Nếu người dùng có nhập mật khẩu mới thì mới cập nhật
                if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    nvSua.MatKhau = txtMatKhau.Text;
                }

                // CẬP NHẬT ẢNH: Chỉ cập nhật nếu người dùng có chọn ảnh mới
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

        // Lưu tất cả thay đổi xuống Database
        db.SaveChanges();
        MessageBox.Show("Đã lưu thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Reset trạng thái Form
        tenFileAnhNV = ""; // Reset biến tạm sau khi lưu xong
        FrmNhanVien_Load(sender, e); // Tải lại danh sách lên lưới
    }
    catch (Exception ex)
    {
        // Hiển thị chi tiết lỗi nếu có (lỗi DB, lỗi kết nối...)
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
                    // Đường dẫn "nhảy" ngược ra thư mục Images của Solution Explorer
                    string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                    string thuMucAnh = Path.Combine(projectDir, "images");

                    if (!Directory.Exists(thuMucAnh)) Directory.CreateDirectory(thuMucAnh);

                    // Lấy tên file và copy vào thư mục Images
                    tenFileAnhNV = Path.GetFileName(openFile.FileName);
                    string duongDanDich = Path.Combine(thuMucAnh, tenFileAnhNV);
                    File.Copy(openFile.FileName, duongDanDich, true);

                    // Hiển thị ảnh lên Form để xem trước
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
            // Kiểm tra đúng tên cột "CotHinhAnh" mà bạn đã đặt trong Design
            if (dgvDanhSachNhanVien.Columns[e.ColumnIndex].Name == "CotHinhAnh" && e.RowIndex >= 0)
            {
                // Lấy đối tượng nhân viên của dòng hiện tại
                var nv = dgvDanhSachNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVien;

                if (nv != null && !string.IsNullOrEmpty(nv.AnhChanDung))
                {
                    try
                    {
                        // Đường dẫn trỏ vào folder Images trong Solution (giống code TiVi của bạn)
                        string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                        string path = Path.Combine(projectDir, "Images", nv.AnhChanDung);

                        if (File.Exists(path))
                        {
                            // Dùng MemoryStream để tránh chiếm dụng file (giống hệt bên TiVi)
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
