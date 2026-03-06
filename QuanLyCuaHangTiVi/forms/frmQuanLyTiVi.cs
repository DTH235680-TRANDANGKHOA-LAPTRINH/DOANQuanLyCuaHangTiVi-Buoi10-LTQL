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
using QuanLyCuaHangTiVi.DATA;
using System.IO;
namespace QuanLyCuaHangTiVi.forms
{
    public partial class frmQuanLyTiVi : Form
    {


        // 1. Khởi tạo Context và biến toàn cục
        AppDbContext context = new AppDbContext();
        bool xuLyThem = false;
        // 2. Hàm Bật/Tắt các nút và ô nhập
        //Biến lưu đường dẫn ảnh khi chọn
        // Đảm bảo biến này nằm ở ngoài các hàm
        string tenFileAnhHienTai = "";

        private void BatTatChucNang(bool giaTri)
        {
            // true: Đang nhập liệu (Hiện Lưu/Hủy)
            // false: Đang xem (Hiện Thêm/Sửa/Xóa)

            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            // Các ô nhập liệu
            txtMaTiVi.Enabled = giaTri;
            txtTenTiVi.Enabled = giaTri;
            cboHangSanXuat.Enabled = giaTri;
            dtpNgayTao.Enabled = giaTri;
            txtDonGiaBan.Enabled = giaTri;
            txtKhuyenMai.Enabled = giaTri;
            txtSoLuongTon.Enabled = giaTri;
            btnChonAnh.Enabled = giaTri;

            // Các nút chức năng
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
        }
        // Hàm phụ để nạp ComboBox
        private void LoadComboBoxHang()
        {
            cboHangSanXuat.Items.Clear();
            cboHangSanXuat.Items.AddRange(new string[] { "Sony", "Samsung", "LG", "Toshiba", "Panasonic" });
        }
        public frmQuanLyTiVi()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmQuanLyTiVi_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadComboBoxHang(); // Nạp dữ liệu cho ComboBox trước

            // 1. Load dữ liệu từ DB
            var listTiVi = context.QuanLyTiVis.ToList();

            // 2. Tạo BindingSource (Cầu nối dữ liệu)
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = listTiVi;

            // 3. Cấu hình DataGridView
            dgvDanhSachTiVi.AutoGenerateColumns = false;
            dgvDanhSachTiVi.DataSource = bindingSource;
            dgvDanhSachTiVi.RowTemplate.Height = 80;

            // Ánh xạ cột
            if (dgvDanhSachTiVi.Columns.Contains("Ma")) dgvDanhSachTiVi.Columns["Ma"].DataPropertyName = "MaTiVi";
            if (dgvDanhSachTiVi.Columns.Contains("Ten")) dgvDanhSachTiVi.Columns["Ten"].DataPropertyName = "TenTiVi";
            if (dgvDanhSachTiVi.Columns.Contains("Hang")) dgvDanhSachTiVi.Columns["Hang"].DataPropertyName = "HangSanXuat";
            if (dgvDanhSachTiVi.Columns.Contains("Nhap")) dgvDanhSachTiVi.Columns["Nhap"].DataPropertyName = "NgayTao";
            if (dgvDanhSachTiVi.Columns.Contains("Gia")) dgvDanhSachTiVi.Columns["Gia"].DataPropertyName = "DonGiaBan";
            if (dgvDanhSachTiVi.Columns.Contains("KM")) dgvDanhSachTiVi.Columns["KM"].DataPropertyName = "KhuyenMai";
            if (dgvDanhSachTiVi.Columns.Contains("SL")) dgvDanhSachTiVi.Columns["SL"].DataPropertyName = "SoLuongTon";

            // Ẩn cột chữ AnhMinhHoa nếu nó tự hiện ra
            if (dgvDanhSachTiVi.Columns.Contains("AnhMinhHoa"))
                dgvDanhSachTiVi.Columns["AnhMinhHoa"].Visible = false;

            // Binding dữ liệu
            txtMaTiVi.DataBindings.Clear();
            txtTenTiVi.DataBindings.Clear();
            cboHangSanXuat.DataBindings.Clear();
            dtpNgayTao.DataBindings.Clear();
            txtDonGiaBan.DataBindings.Clear();
            txtKhuyenMai.DataBindings.Clear();
            txtSoLuongTon.DataBindings.Clear();

            txtMaTiVi.DataBindings.Add("Text", bindingSource, "MaTiVi", true, DataSourceUpdateMode.Never);
            txtTenTiVi.DataBindings.Add("Text", bindingSource, "TenTiVi", true, DataSourceUpdateMode.Never);
            cboHangSanXuat.DataBindings.Add("Text", bindingSource, "HangSanXuat", true, DataSourceUpdateMode.Never);
            dtpNgayTao.DataBindings.Add("Value", bindingSource, "NgayTao", true, DataSourceUpdateMode.Never);
            txtDonGiaBan.DataBindings.Add("Text", bindingSource, "DonGiaBan", true, DataSourceUpdateMode.Never);
            txtKhuyenMai.DataBindings.Add("Text", bindingSource, "KhuyenMai", true, DataSourceUpdateMode.Never);
            txtSoLuongTon.DataBindings.Add("Text", bindingSource, "SoLuongTon", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            // Xóa trắng các ô nhập
            txtMaTiVi.Clear();
            txtTenTiVi.Clear();
            txtDonGiaBan.Clear();
            txtKhuyenMai.Clear();
            txtSoLuongTon.Clear();

            // Xóa ảnh cũ trên giao diện và reset biến lưu tên file
            if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();
            picAnhMinhHoa.Image = null;
            tenFileAnhHienTai = ""; // Bắt buộc người dùng phải nhấn chọn ảnh lại
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Tải lại form để hủy bỏ thao tác
            frmQuanLyTiVi_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachTiVi.CurrentRow != null)
            {
                xuLyThem = false;
                BatTatChucNang(true);
                txtMaTiVi.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachTiVi.CurrentRow != null)
            {
                var tv = context.QuanLyTiVis.Find(txtMaTiVi.Text);
                if (tv != null && MessageBox.Show("Bạn có chắc chắn muốn xóa TiVi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string fileAnhCanXoa = tv.AnhMinhHoa; // Lưu tên file lại trước khi xóa record

                    context.QuanLyTiVis.Remove(tv);
                    context.SaveChanges();

                    // Xóa file ảnh vật lý nếu nó tồn tại
                    try
                    {
                        string path = Path.Combine(Application.StartupPath, "Images", fileAnhCanXoa);
                        if (File.Exists(path))
                        {
                            // Giải phóng ảnh đang hiển thị trên PictureBox nếu đó là ảnh sắp xóa
                            if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();
                            picAnhMinhHoa.Image = null;

                            File.Delete(path);
                        }
                    }
                    catch { /* Bỏ qua nếu file đang bị khóa bởi tiến trình khác */ }

                    frmQuanLyTiVi_Load(sender, e);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {// 1. Kiểm tra các trường văn bản cơ bản
            if (string.IsNullOrWhiteSpace(txtMaTiVi.Text) || string.IsNullOrWhiteSpace(txtTenTiVi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên TiVi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. BẮT BUỘC CHỌN ẢNH: Kiểm tra biến lưu tên file ảnh
            if (string.IsNullOrEmpty(tenFileAnhHienTai))
            {
                MessageBox.Show("Bạn chưa chọn ảnh minh họa cho TiVi. Vui lòng chọn ảnh trước khi lưu!", "Yêu cầu chọn ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnChonAnh.Focus(); // Trỏ chuột vào nút chọn ảnh để nhắc người dùng
                return; // Dừng hàm tại đây, không cho lưu xuống Database
            }

            try
            {
                if (xuLyThem)
                {
                    // Kiểm tra trùng mã
                    if (context.QuanLyTiVis.Any(x => x.MaTiVi == txtMaTiVi.Text))
                    {
                        MessageBox.Show("Mã TiVi đã tồn tại!"); return;
                    }

                    QuanLyTiVi tv = new QuanLyTiVi();
                    tv.MaTiVi = txtMaTiVi.Text;
                    tv.TenTiVi = txtTenTiVi.Text;
                    tv.HangSanXuat = cboHangSanXuat.Text;
                    tv.NgayTao = dtpNgayTao.Value;
                    tv.DonGiaBan = decimal.Parse(txtDonGiaBan.Text);
                    tv.KhuyenMai = decimal.Parse(txtKhuyenMai.Text);
                    tv.SoLuongTon = int.Parse(txtSoLuongTon.Text);

                    // Gán tên file ảnh đã chọn chắc chắn không null nhờ lệnh kiểm tra ở trên
                    tv.AnhMinhHoa = tenFileAnhHienTai;

                    context.QuanLyTiVis.Add(tv);
                }
                else // Trường hợp Sửa
                {
                    var tvSua = context.QuanLyTiVis.Find(txtMaTiVi.Text);
                    if (tvSua != null)
                    {
                        tvSua.TenTiVi = txtTenTiVi.Text;
                        tvSua.HangSanXuat = cboHangSanXuat.Text;
                        tvSua.DonGiaBan = decimal.Parse(txtDonGiaBan.Text);
                        tvSua.SoLuongTon = int.Parse(txtSoLuongTon.Text);

                        // Nếu sửa mà chọn ảnh mới thì cập nhật, không thì giữ ảnh cũ (tùy bạn muốn bắt buộc chọn mới hay không)
                        if (!string.IsNullOrEmpty(tenFileAnhHienTai))
                        {
                            tvSua.AnhMinhHoa = tenFileAnhHienTai;
                        }
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tenFileAnhHienTai = ""; // Reset biến sau khi hoàn tất
                frmQuanLyTiVi_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. Tìm đường dẫn gốc của Project (đi ngược từ bin/Debug lên)
                    string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

                    // 2. Trỏ trực tiếp vào thư mục Images nằm trong Solution
                    string thuMucAnh = Path.Combine(projectDir, "images");

                    // 3. Tạo thư mục nếu chưa có
                    if (!Directory.Exists(thuMucAnh)) Directory.CreateDirectory(thuMucAnh);
                    if (!Directory.Exists(thuMucAnh)) Directory.CreateDirectory(thuMucAnh);

                    // LẤY TÊN FILE GÁN VÀO BIẾN DÙNG CHUNG
                    tenFileAnhHienTai = Path.GetFileName(openFile.FileName);
                    string duongDanDich = Path.Combine(thuMucAnh, tenFileAnhHienTai);

                    File.Copy(openFile.FileName, duongDanDich, true);

                    // Hiển thị lên PictureBox
                    if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();
                    picAnhMinhHoa.Image = Image.FromFile(duongDanDich);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi chọn ảnh: " + ex.Message); }
            }
        }

        private void dgvDanhSachTiVi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSachTiVi.Columns[e.ColumnIndex].Name == "CotHinhAnh" && e.RowIndex >= 0)
            {
                var tv = dgvDanhSachTiVi.Rows[e.RowIndex].DataBoundItem as QuanLyTiVi;
                if (tv != null && !string.IsNullOrEmpty(tv.AnhMinhHoa))
                {
                    string path = Path.Combine(Application.StartupPath, "Images", tv.AnhMinhHoa);
                    if (File.Exists(path))
                    {
                        try
                        {
                            // Dùng MemoryStream để tránh chiếm dụng file khi DataGridView load liên tục
                            byte[] bytes = File.ReadAllBytes(path);
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                e.Value = Image.FromStream(ms);
                            }
                        }
                        catch { e.Value = null; }
                    }
                }
            }
        }

        private void dgvDanhSachTiVi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var tv = dgvDanhSachTiVi.Rows[e.RowIndex].DataBoundItem as QuanLyTiVi;
                if (tv != null && !string.IsNullOrEmpty(tv.AnhMinhHoa))
                {
                    try
                    {
                        string path = Path.Combine(Application.StartupPath, "Images", tv.AnhMinhHoa);
                        if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();
                        if (File.Exists(path)) picAnhMinhHoa.Image = Image.FromFile(path);
                        else picAnhMinhHoa.Image = null;
                    }
                    catch { picAnhMinhHoa.Image = null; }
                }
            }
        }
    }
}
    

