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

        // Biến lưu tên file ảnh đang chọn
        string tenFileAnhHienTai = "";

        // ĐƯỜNG DẪN ẢNH: 
        string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "images\\");

        // KHO LƯU ẢNH TẠM: Giải pháp dứt điểm lỗi "Out of Memory" khi cuộn DataGridView nó sẽ lưu tạm ảnh vào RAM (Dictionary) và gọi ra dùng lại.
        Dictionary<string, Image> khoAnhTam = new Dictionary<string, Image>();
        private void BatTatChucNang(bool giaTri)//Dùng để khóa/mở khóa các control trên giao diện
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtMaTiVi.Enabled = giaTri;
            txtTenTiVi.Enabled = giaTri;
            cboHangSanXuat.Enabled = giaTri;
            dtpNgayTao.Enabled = giaTri;
            txtDonGiaBan.Enabled = giaTri;
            txtKhuyenMai.Enabled = giaTri;
            txtSoLuongTon.Enabled = giaTri;
            btnChonAnh.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
        }

        private void LoadComboBoxHang()
        {
            cboHangSanXuat.Items.Clear();
            cboHangSanXuat.Items.AddRange(new string[] { "Sony", "Samsung", "LG", "Toshiba", "Panasonic" });
        }

       
        // HÀM TẠO MÃ TỰ ĐỘNG
     
        private string TaoMaTiViTuDong()
        {
            // Lấy danh sách tất cả các Mã TiVi hiện có trong Database
            var danhSachMa = context.QuanLyTiVis.Select(x => x.MaTiVi).ToList();

            // Nếu chưa có tivi nào, trả về mã đầu tiên
            if (danhSachMa.Count == 0) return "TV001";

            int maxSo = 0;
            foreach (var ma in danhSachMa)
            {
                // Lọc lấy phần số từ chuỗi mã (Ví dụ: "TV012" -> "012")
                string soStr = new string(ma.Where(char.IsDigit).ToArray());

                // Chuyển phần số thành kiểu int và tìm số lớn nhất
                if (int.TryParse(soStr, out int so) && so > maxSo)
                {
                    maxSo = so;
                }
            }

            // Tăng số lớn nhất lên 1 và ghép lại với tiền tố "TV"
            // "D3" đảm bảo luôn có 3 chữ số (001, 002, ..., 015, ..., 100)
            return "TV" + (maxSo + 1).ToString("D3");
        }
        public frmQuanLyTiVi()
        {
            InitializeComponent();
        }

  
        private void frmQuanLyTiVi_Load(object sender, EventArgs e)
        {// Tạo thư mục images nếu nó chưa tồn tại để tránh lỗi
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            BatTatChucNang(false);
            LoadComboBoxHang();

            // ==========================================
            // CẬP NHẬT CHỖ NÀY: Sắp xếp danh sách TiVi
            // ==========================================
            var listTiVi = context.QuanLyTiVis
                                  .OrderBy(t => t.MaTiVi.Length)
                                  .ThenBy(t => t.MaTiVi)
                                  .ToList();
            // ==========================================

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = listTiVi;

            dgvDanhSachTiVi.AutoGenerateColumns = false;
            dgvDanhSachTiVi.DataSource = bindingSource;
            dgvDanhSachTiVi.RowTemplate.Height = 80;

            if (dgvDanhSachTiVi.Columns.Contains("Ma")) dgvDanhSachTiVi.Columns["Ma"].DataPropertyName = "MaTiVi";
            if (dgvDanhSachTiVi.Columns.Contains("Ten")) dgvDanhSachTiVi.Columns["Ten"].DataPropertyName = "TenTiVi";
            if (dgvDanhSachTiVi.Columns.Contains("Hang")) dgvDanhSachTiVi.Columns["Hang"].DataPropertyName = "HangSanXuat";
            if (dgvDanhSachTiVi.Columns.Contains("Nhap")) dgvDanhSachTiVi.Columns["Nhap"].DataPropertyName = "NgayTao";
            if (dgvDanhSachTiVi.Columns.Contains("Gia")) dgvDanhSachTiVi.Columns["Gia"].DataPropertyName = "GiaHienTai";
            if (dgvDanhSachTiVi.Columns.Contains("KM")) dgvDanhSachTiVi.Columns["KM"].DataPropertyName = "KhuyenMai";
            if (dgvDanhSachTiVi.Columns.Contains("SL")) dgvDanhSachTiVi.Columns["SL"].DataPropertyName = "SoLuongTon";
            if (dgvDanhSachTiVi.Columns.Contains("TrangThai")) dgvDanhSachTiVi.Columns["TrangThai"].DataPropertyName = "TrangThai";

            if (dgvDanhSachTiVi.Columns.Contains("AnhMinhHoa"))
                dgvDanhSachTiVi.Columns["AnhMinhHoa"].Visible = false;

            txtMaTiVi.DataBindings.Clear();
            txtTenTiVi.DataBindings.Clear();
            cboHangSanXuat.DataBindings.Clear();
            dtpNgayTao.DataBindings.Clear();
            txtDonGiaBan.DataBindings.Clear();
            txtKhuyenMai.DataBindings.Clear();
            txtSoLuongTon.DataBindings.Clear();
            // Map thêm 2 trường chưa có ở bài trước:
            txtGiaHienTai.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();

            txtMaTiVi.DataBindings.Add("Text", bindingSource, "MaTiVi", true, DataSourceUpdateMode.Never);
            txtTenTiVi.DataBindings.Add("Text", bindingSource, "TenTiVi", true, DataSourceUpdateMode.Never);
            cboHangSanXuat.DataBindings.Add("Text", bindingSource, "HangSanXuat", true, DataSourceUpdateMode.Never);
            dtpNgayTao.DataBindings.Add("Value", bindingSource, "NgayTao", true, DataSourceUpdateMode.Never);
            txtDonGiaBan.DataBindings.Add("Text", bindingSource, "DonGiaBan", true, DataSourceUpdateMode.Never);
            txtKhuyenMai.DataBindings.Add("Text", bindingSource, "KhuyenMai", true, DataSourceUpdateMode.Never);
            txtSoLuongTon.DataBindings.Add("Text", bindingSource, "SoLuongTon", true, DataSourceUpdateMode.Never);

            // Format "N0" cho giá hiển thị (định dạng tiền tệ)
            txtGiaHienTai.DataBindings.Add("Text", bindingSource, "GiaHienTai", true, DataSourceUpdateMode.Never, "", "N0");
            txtTrangThai.DataBindings.Add("Text", bindingSource, "TrangThai", true, DataSourceUpdateMode.Never);

            if (dgvDanhSachTiVi.Columns.Contains("CotHinhAnh"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvDanhSachTiVi.Columns["CotHinhAnh"];
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 80;
            }

            // --- GẮN SỰ KIỆN ---
            txtSoLuongTon.KeyPress += ChiNhapSo_KeyPress;
            txtDonGiaBan.KeyPress += ChiNhapSo_KeyPress;
            txtKhuyenMai.KeyPress += ChiNhapSo_KeyPress;

            txtDonGiaBan.TextChanged += CapNhatGia_TextChanged;
            txtKhuyenMai.TextChanged += CapNhatGia_TextChanged;

            txtMaTiVi.Leave += TxtMaTiVi_Leave;
        }
        private void frmQuanLyTiVi_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                // Khởi tạo lại db context để quét sạch cache cũ
                context = new AppDbContext();

                // Gọi lại hàm Load để kéo dữ liệu mới nhất và xếp đúng vị trí
                frmQuanLyTiVi_Load(sender, e);
            }
        }
        private void TxtMaTiVi_Leave(object sender, EventArgs e)
        {
            if (xuLyThem && !string.IsNullOrWhiteSpace(txtMaTiVi.Text) && txtMaTiVi.Enabled == true)
            {
                string maKiemTra = txtMaTiVi.Text.Trim();
                bool daTonTai = context.QuanLyTiVis.Any(x => x.MaTiVi == maKiemTra);

                if (daTonTai)
                {
                    MessageBox.Show($"Mã TiVi '{maKiemTra}' đã tồn tại! Vui lòng nhập một mã khác.", "Cảnh báo trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTiVi.Clear();
                    txtMaTiVi.Focus();
                }
            }
        }

        private void ChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Trường này chỉ được phép nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TinhGiaHienTai()
        {
            decimal donGia = 0;
            decimal khuyenMai = 0;

            decimal.TryParse(txtDonGiaBan.Text, out donGia);
            decimal.TryParse(txtKhuyenMai.Text, out khuyenMai);

            if (khuyenMai > 100)
            {
                MessageBox.Show("Khuyến mãi không được vượt quá 100%!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuyenMai.Text = "100";
                txtKhuyenMai.SelectionStart = txtKhuyenMai.Text.Length;
                khuyenMai = 100;
            }

            decimal giaHienTai = donGia - (donGia * khuyenMai / 100);

            // Hiển thị giá hiện tại lên Form
            txtGiaHienTai.Text = giaHienTai.ToString("N0");
        }

        private void CapNhatGia_TextChanged(object sender, EventArgs e)
        {
            TinhGiaHienTai();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            // GỌI HÀM SINH MÃ TỰ ĐỘNG VÀ KHÓA Ô TEXTBOX ĐỂ TRÁNH SỬA
            txtMaTiVi.Text = TaoMaTiViTuDong();
            txtMaTiVi.Enabled = false;

            txtTenTiVi.Clear();
            txtDonGiaBan.Clear();
            txtKhuyenMai.Clear();
            txtSoLuongTon.Clear();

            if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();
            picAnhMinhHoa.Image = null;
            tenFileAnhHienTai = "";
            txtTenTiVi.Focus();
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
                txtMaTiVi.Enabled = false; // Không cho sửa mã khi đang Sửa
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnXoa_Click(object sender, EventArgs e)
        {//Xóa Tivi khỏi Database. Đồng thời, code có xử lý rất kỹ: Xóa luôn file ảnh vật lý tương ứng trong thư mục images và dọn dẹp ảnh trong khoAnhTam để giải phóng bộ nhớ.
            if (dgvDanhSachTiVi.CurrentRow != null)
            {
                var tv = context.QuanLyTiVis.Find(txtMaTiVi.Text);
                if (tv != null && MessageBox.Show("Bạn có chắc chắn muốn xóa TiVi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string fileAnhCanXoa = tv.AnhMinhHoa;

                    context.QuanLyTiVis.Remove(tv);
                    context.SaveChanges();

                    try
                    {
                        string path = Path.Combine(imagesFolder, fileAnhCanXoa);
                        if (File.Exists(path))
                        {
                            if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();
                            picAnhMinhHoa.Image = null;

                            if (khoAnhTam.ContainsKey(fileAnhCanXoa))
                            {
                                khoAnhTam[fileAnhCanXoa]?.Dispose();
                                khoAnhTam.Remove(fileAnhCanXoa);
                            }

                            File.Delete(path);
                        }
                    }
                    catch { }

                    frmQuanLyTiVi_Load(sender, e);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTiVi.Text) || string.IsNullOrWhiteSpace(txtTenTiVi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên TiVi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (xuLyThem == true && string.IsNullOrEmpty(tenFileAnhHienTai))
            {
                MessageBox.Show("Bạn chưa chọn ảnh minh họa cho TiVi. Vui lòng chọn ảnh trước khi lưu!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnChonAnh.Focus();
                return;
            }

            try
            {
                decimal donGia = string.IsNullOrWhiteSpace(txtDonGiaBan.Text) ? 0 : decimal.Parse(txtDonGiaBan.Text);
                decimal km = string.IsNullOrWhiteSpace(txtKhuyenMai.Text) ? 0 : decimal.Parse(txtKhuyenMai.Text);
                int sl = string.IsNullOrWhiteSpace(txtSoLuongTon.Text) ? 0 : int.Parse(txtSoLuongTon.Text);

                if (xuLyThem)
                {
                    if (context.QuanLyTiVis.Any(x => x.MaTiVi == txtMaTiVi.Text))
                    {
                        MessageBox.Show("Mã TiVi đã tồn tại!"); return;
                    }

                    QuanLyTiVi tv = new QuanLyTiVi();
                    tv.MaTiVi = txtMaTiVi.Text;
                    tv.TenTiVi = txtTenTiVi.Text;
                    tv.HangSanXuat = cboHangSanXuat.Text;
                    tv.NgayTao = dtpNgayTao.Value;
                    tv.DonGiaBan = donGia;
                    tv.KhuyenMai = km;
                    tv.SoLuongTon = sl;
                    tv.AnhMinhHoa = tenFileAnhHienTai;

                    context.QuanLyTiVis.Add(tv);
                }
                else
                {
                    var tvSua = context.QuanLyTiVis.Find(txtMaTiVi.Text);
                    if (tvSua != null)
                    {
                        tvSua.TenTiVi = txtTenTiVi.Text;
                        tvSua.HangSanXuat = cboHangSanXuat.Text;
                        tvSua.DonGiaBan = donGia;
                        tvSua.KhuyenMai = km;
                        tvSua.SoLuongTon = sl;

                        if (!string.IsNullOrEmpty(tenFileAnhHienTai))
                        {
                            tvSua.AnhMinhHoa = tenFileAnhHienTai;
                        }
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tenFileAnhHienTai = "";
                frmQuanLyTiVi_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

       
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tenFileAnhHienTai = Path.GetFileName(openFile.FileName);
                    string duongDanDich = Path.Combine(imagesFolder, tenFileAnhHienTai);

                    if (openFile.FileName != duongDanDich)
                    {
                        File.Copy(openFile.FileName, duongDanDich, true);
                    }

                    if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();

                    using (Image imgTemp = Image.FromFile(duongDanDich))
                    {
                        picAnhMinhHoa.Image = new Bitmap(imgTemp);
                    }

                    if (khoAnhTam.ContainsKey(tenFileAnhHienTai))
                    {
                        khoAnhTam[tenFileAnhHienTai]?.Dispose();
                        using (Image imgTemp = Image.FromFile(duongDanDich))
                        {
                            khoAnhTam[tenFileAnhHienTai] = new Bitmap(imgTemp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chọn ảnh: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDanhSachTiVi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Hàm này chạy liên tục khi DataGridView vẽ các ô. Nó kiểm tra xem tên ảnh đã có trong khoAnhTam chưa. Nếu chưa thì đọc từ ổ cứng, nạp vào Dictionary.
            // Nếu có rồi thì lấy trực tiếp từ RAM ra để hiển thị. Đây là cách tối ưu hiệu suất cực kỳ quan trọng đối với thao tác hiển thị ảnh trên dạng lưới.
            if (dgvDanhSachTiVi.Columns[e.ColumnIndex].Name == "CotHinhAnh" && e.RowIndex >= 0)
            {
                var tv = dgvDanhSachTiVi.Rows[e.RowIndex].DataBoundItem as QuanLyTiVi;
                if (tv != null && !string.IsNullOrEmpty(tv.AnhMinhHoa))
                {
                    if (!khoAnhTam.ContainsKey(tv.AnhMinhHoa))
                    {
                        string path = Path.Combine(imagesFolder, tv.AnhMinhHoa);
                        if (File.Exists(path))
                        {
                            try
                            {
                                using (Image imgTemp = Image.FromFile(path))
                                {
                                    khoAnhTam[tv.AnhMinhHoa] = new Bitmap(imgTemp);
                                }
                            }
                            catch { khoAnhTam[tv.AnhMinhHoa] = null; }
                        }
                        else
                        {
                            khoAnhTam[tv.AnhMinhHoa] = null;
                        }
                    }

                    e.Value = khoAnhTam[tv.AnhMinhHoa];
                }
            }
        }

        private void dgvDanhSachTiVi_CellClick(object sender, DataGridViewCellEventArgs e)
        {//Khi click vào một dòng, nó sẽ tìm file ảnh tương ứng trong thư mục và hiển thị lên khung picAnhMinhHoa ở phần nhập liệu.
            if (e.RowIndex >= 0)
            {
                var tv = dgvDanhSachTiVi.Rows[e.RowIndex].DataBoundItem as QuanLyTiVi;
                if (tv != null && !string.IsNullOrEmpty(tv.AnhMinhHoa))
                {
                    try
                    {
                        string path = Path.Combine(imagesFolder, tv.AnhMinhHoa);

                        if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();

                        if (File.Exists(path))
                        {
                            using (Image imgTemp = Image.FromFile(path))
                            {
                                picAnhMinhHoa.Image = new Bitmap(imgTemp);
                            }
                        }
                        else
                        {
                            picAnhMinhHoa.Image = null;
                        }
                    }
                    catch { picAnhMinhHoa.Image = null; }
                }
            }
        }
    }
 }

    

