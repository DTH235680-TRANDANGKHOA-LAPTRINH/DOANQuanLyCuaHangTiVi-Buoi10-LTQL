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
using QuanLyCuaHangTiVi.DATA; // Namespace chứa AppDbContext và class KhachHang
namespace QuanLyCuaHangTiVi.forms
{
    public partial class frmKhachHang : Form
    {
        // 1. Khai báo Context và biến cờ
        AppDbContext db = new AppDbContext();
        bool isThem = false; // true = Đang thêm, false = Đang sửa

        // 2. Hàm điều khiển trạng thái các nút và ô nhập
        private void BatTatChucNang(bool dangThaoTac)
        {
            // dangThaoTac = true: Đang nhập liệu (Hiện Lưu/Hủy)
            // dangThaoTac = false: Đang xem (Hiện Thêm/Sửa/Xóa)

            btnLuu.Enabled = dangThaoTac;
            btnHuyBo.Enabled = dangThaoTac;

            // Các ô nhập liệu
            txtMaKhachHang.Enabled = dangThaoTac;
            txtTenKhachHang.Enabled = dangThaoTac;
            txtSoDienThoai.Enabled = dangThaoTac;
            txtCCCD.Enabled = dangThaoTac;
            txtDiaChi.Enabled = dangThaoTac;
            dtpNgayThangNamSinh.Enabled = dangThaoTac;

            // Các nút chức năng chính
            btnThem.Enabled = !dangThaoTac;
            btnSua.Enabled = !dangThaoTac;
            btnXoa.Enabled = !dangThaoTac;
            btnThoat.Enabled = !dangThaoTac;
        }
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            // Tải dữ liệu từ CSDL
            var danhSachKH = db.KhachHangs.ToList();

            // Tạo BindingSource
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachKH;

            // Gán dữ liệu cho DataGridView
            dgvDanhSachKhachHang.AutoGenerateColumns = false;
            dgvDanhSachKhachHang.DataSource = bindingSource;

            // --- CẤU HÌNH CỘT CHO LƯỚI ---
            // (Bạn nhớ kiểm tra Property Name của các cột trong Design nhé)
            if (dgvDanhSachKhachHang.Columns.Contains("Ma")) dgvDanhSachKhachHang.Columns["Ma"].DataPropertyName = "MaKhachHang";
            if (dgvDanhSachKhachHang.Columns.Contains("Ten")) dgvDanhSachKhachHang.Columns["Ten"].DataPropertyName = "TenKhachHang";
            if (dgvDanhSachKhachHang.Columns.Contains("SDT")) dgvDanhSachKhachHang.Columns["SDT"].DataPropertyName = "SoDienThoai";
            if (dgvDanhSachKhachHang.Columns.Contains("NgaySinh")) dgvDanhSachKhachHang.Columns["NgaySinh"].DataPropertyName = "NgayThangNamSinh";
            if (dgvDanhSachKhachHang.Columns.Contains("CCCD")) dgvDanhSachKhachHang.Columns["CCCD"].DataPropertyName = "CCCD";
            if (dgvDanhSachKhachHang.Columns.Contains("DiaChi")) dgvDanhSachKhachHang.Columns["DiaChi"].DataPropertyName = "DiaChi";

            // --- DATABINDING (Tự đổ dữ liệu vào TextBox) ---
            txtMaKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Clear();
            txtCCCD.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            dtpNgayThangNamSinh.DataBindings.Clear();

            // Lưu ý: Tên property phải KHỚP CHÍNH XÁC trong class KhachHang bạn gửi
            txtMaKhachHang.DataBindings.Add("Text", bindingSource, "MaKhachHang", true, DataSourceUpdateMode.Never);
            txtTenKhachHang.DataBindings.Add("Text", bindingSource, "TenKhachHang", true, DataSourceUpdateMode.Never);
            txtSoDienThoai.DataBindings.Add("Text", bindingSource, "SoDienThoai", true, DataSourceUpdateMode.Never);
            txtCCCD.DataBindings.Add("Text", bindingSource, "CCCD", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", true, DataSourceUpdateMode.Never);
            dtpNgayThangNamSinh.DataBindings.Add("Value", bindingSource, "NgayThangNamSinh", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            BatTatChucNang(true);

            // Xóa trắng để nhập mới
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtCCCD.Clear();
            txtDiaChi.Clear();
            dtpNgayThangNamSinh.Value = DateTime.Now;

            txtMaKhachHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhachHang.Text))
            {
                MessageBox.Show("Chưa chọn khách hàng để sửa!");
                return;
            }

            isThem = false;
            BatTatChucNang(true);
            // Khi sửa thì KHÔNG ĐƯỢC sửa Mã Khách Hàng (Khóa lại)
            txtMaKhachHang.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhachHang.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng: " + txtTenKhachHang.Text + "?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var khXoa = db.KhachHangs.Find(txtMaKhachHang.Text);
                    if (khXoa != null)
                    {
                        db.KhachHangs.Remove(khXoa);
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        frmKhachHang_Load(sender, e); // Tải lại dữ liệu
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (có thể do khách hàng đã có hóa đơn): " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Khách Hàng");
                txtMaKhachHang.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Khách Hàng");
                txtTenKhachHang.Focus();
                return;
            }

            try
            {
                if (isThem)
                {
                    // --- THÊM MỚI ---
                    // Kiểm tra trùng mã
                    var checkID = db.KhachHangs.Find(txtMaKhachHang.Text);
                    if (checkID != null)
                    {
                        MessageBox.Show("Mã khách hàng này đã tồn tại!");
                        return;
                    }

                    KhachHang kh = new KhachHang();
                    kh.MaKhachHang = txtMaKhachHang.Text;
                    kh.TenKhachHang = txtTenKhachHang.Text;
                    kh.SoDienThoai = txtSoDienThoai.Text;
                    kh.CCCD = txtCCCD.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    kh.NgayThangNamSinh = dtpNgayThangNamSinh.Value;

                    db.KhachHangs.Add(kh);
                }
                else
                {
                    // --- SỬA ---
                    var khSua = db.KhachHangs.Find(txtMaKhachHang.Text);
                    if (khSua == null)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để sửa!");
                        return;
                    }

                    khSua.TenKhachHang = txtTenKhachHang.Text;
                    khSua.SoDienThoai = txtSoDienThoai.Text;
                    khSua.CCCD = txtCCCD.Text;
                    khSua.DiaChi = txtDiaChi.Text;
                    khSua.NgayThangNamSinh = dtpNgayThangNamSinh.Value;

                    // Context tự động theo dõi thay đổi nên không cần hàm Update
                }

                db.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!");

                // Reset lại form
                frmKhachHang_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Hủy thao tác bằng cách load lại dữ liệu ban đầu
            frmKhachHang_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
