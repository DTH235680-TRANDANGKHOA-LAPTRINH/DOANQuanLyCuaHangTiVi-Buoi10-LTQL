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
    public partial class frmDangNhap : Form
    {
        AppDbContext db = new AppDbContext();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim(); // Giả sử ô nhập tài khoản tên là txtTenDangNhap
            string password = txtMatKhau.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Truy vấn kiểm tra xem có khớp tài khoản và mật khẩu trong DB không
            // Lưu ý: Nếu ở FrmNhanVien bạn có mã hóa (hash) mật khẩu, thì ở đây bạn cũng phải mã hóa 'password' rồi mới so sánh
            var nv = db.NhanViens.FirstOrDefault(x => x.TenDangNhap == username && x.MatKhau == password);

            if (nv != null)
            {
                // Đăng nhập thành công -> Lưu thông tin vào class tĩnh
                TaiKhoanHienTai.NhanVienDangNhap = nv;

                MessageBox.Show("Đăng nhập thành công! Xin chào " + nv.HoTenNhanVien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}
