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

        // KHO LƯU ẢNH TẠM: Giải pháp dứt điểm lỗi "Out of Memory" khi cuộn DataGridView
        Dictionary<string, Image> khoAnhTam = new Dictionary<string, Image>();

        private void BatTatChucNang(bool giaTri)
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
        public frmQuanLyTiVi()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmQuanLyTiVi_Load(object sender, EventArgs e)
        {
            // Tạo thư mục images nếu nó chưa tồn tại để tránh lỗi
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            BatTatChucNang(false);
            LoadComboBoxHang();

            var listTiVi = context.QuanLyTiVis.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = listTiVi;

            dgvDanhSachTiVi.AutoGenerateColumns = false;
            dgvDanhSachTiVi.DataSource = bindingSource;
            dgvDanhSachTiVi.RowTemplate.Height = 80;

            if (dgvDanhSachTiVi.Columns.Contains("Ma")) dgvDanhSachTiVi.Columns["Ma"].DataPropertyName = "MaTiVi";
            if (dgvDanhSachTiVi.Columns.Contains("Ten")) dgvDanhSachTiVi.Columns["Ten"].DataPropertyName = "TenTiVi";
            if (dgvDanhSachTiVi.Columns.Contains("Hang")) dgvDanhSachTiVi.Columns["Hang"].DataPropertyName = "HangSanXuat";
            if (dgvDanhSachTiVi.Columns.Contains("Nhap")) dgvDanhSachTiVi.Columns["Nhap"].DataPropertyName = "NgayTao";
            if (dgvDanhSachTiVi.Columns.Contains("Gia")) dgvDanhSachTiVi.Columns["Gia"].DataPropertyName = "DonGiaBan";
            if (dgvDanhSachTiVi.Columns.Contains("KM")) dgvDanhSachTiVi.Columns["KM"].DataPropertyName = "KhuyenMai";
            if (dgvDanhSachTiVi.Columns.Contains("SL")) dgvDanhSachTiVi.Columns["SL"].DataPropertyName = "SoLuongTon";

            if (dgvDanhSachTiVi.Columns.Contains("AnhMinhHoa"))
                dgvDanhSachTiVi.Columns["AnhMinhHoa"].Visible = false;

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
           
            if (dgvDanhSachTiVi.Columns.Contains("CotHinhAnh"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvDanhSachTiVi.Columns["CotHinhAnh"];
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; // Thu nhỏ ảnh vừa ô
                imgCol.Width = 80; // Bạn có thể chỉnh độ rộng cột tại đây
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            txtMaTiVi.Clear();
            txtTenTiVi.Clear();
            txtDonGiaBan.Clear();
            txtKhuyenMai.Clear();
            txtSoLuongTon.Clear();

            if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();
            picAnhMinhHoa.Image = null;
            tenFileAnhHienTai = "";
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
                    string fileAnhCanXoa = tv.AnhMinhHoa;

                    context.QuanLyTiVis.Remove(tv);
                    context.SaveChanges();

                    try
                    {
                        // Dùng imagesFolder
                        string path = Path.Combine(imagesFolder, fileAnhCanXoa);
                        if (File.Exists(path))
                        {
                            if (picAnhMinhHoa.Image != null) picAnhMinhHoa.Image.Dispose();
                            picAnhMinhHoa.Image = null;

                            // Xóa luôn trong kho tạm để dọn dẹp RAM
                            if (khoAnhTam.ContainsKey(fileAnhCanXoa))
                            {
                                khoAnhTam[fileAnhCanXoa]?.Dispose();
                                khoAnhTam.Remove(fileAnhCanXoa);
                            }

                            File.Delete(path);
                        }
                    }
                    catch { /* Bỏ qua nếu file đang bị khóa bởi tiến trình khác */ }

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
                MessageBox.Show("Bạn chưa chọn ảnh minh họa cho TiVi. Vui lòng chọn ảnh trước khi lưu!", "Yêu cầu chọn ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnChonAnh.Focus();
                return;
            }

            try
            {
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
                    tv.DonGiaBan = decimal.Parse(txtDonGiaBan.Text);
                    tv.KhuyenMai = decimal.Parse(txtKhuyenMai.Text);
                    tv.SoLuongTon = int.Parse(txtSoLuongTon.Text);
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
                        tvSua.DonGiaBan = decimal.Parse(txtDonGiaBan.Text);
                        tvSua.SoLuongTon = int.Parse(txtSoLuongTon.Text);

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

                    // Cập nhật lại kho tạm nếu người dùng chọn đè ảnh mới trùng tên ảnh cũ
                    if (khoAnhTam.ContainsKey(tenFileAnhHienTai))
                    {
                        khoAnhTam[tenFileAnhHienTai]?.Dispose(); // Dọn ảnh cũ trong cache
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
            if (dgvDanhSachTiVi.Columns[e.ColumnIndex].Name == "CotHinhAnh" && e.RowIndex >= 0)
            {
                var tv = dgvDanhSachTiVi.Rows[e.RowIndex].DataBoundItem as QuanLyTiVi;
                if (tv != null && !string.IsNullOrEmpty(tv.AnhMinhHoa))
                {
                    // Lấy ảnh từ cache (khoAnhTam)
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
        {
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

    

