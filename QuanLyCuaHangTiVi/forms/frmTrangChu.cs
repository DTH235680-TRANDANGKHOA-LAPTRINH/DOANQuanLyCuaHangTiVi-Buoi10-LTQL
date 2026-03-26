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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();


        }
        AppDbContext db = new AppDbContext(); // Khởi tạo kết nối CSDL
        frmDangNhap dangNhap = null;
        string hoTenNguoiDung = "";

        // Các biến lưu Form con để tránh mở nhiều lần
        FrmNhanVien frmNV = null;
        // frmQuanLyTiVi frmTiVi = null; // Khai báo thêm các form khác ở đây...


        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            ChuaDangNhap(); // Khóa menu trước
            ThucHienDangNhap(); // Hiện bảng đăng nhập sau
        }
        private void ThucHienDangNhap()
        {
            using (frmDangNhap fLogin = new frmDangNhap())
            {
                // Nếu đăng nhập thành công (nhấn nút Đăng nhập và khớp DB)
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    var nv = TaiKhoanHienTai.NhanVienDangNhap;
                    if (nv != null)
                    {
                        if (nv.QuyenHan == "Quản lý") QuyenQuanLy(nv.HoTenNhanVien);
                        else QuyenNhanVien(nv.HoTenNhanVien);
                    }
                }
                else
                {
                    // Nếu bấm thoát hoặc hủy ở bảng đăng nhập -> Thoát ứng dụng
                    Application.Exit();
                }
            }
        }

        // --- PHÂN QUYỀN (Duyệt trong tableLayoutPanel1) ---
        private void SetMenuStatus(bool status)
        {
            // Trong hình bạn gửi, các nút nằm trong tableLayoutPanel1
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is Button btn)
                {
                    // Nút Đăng xuất không bao giờ bị khóa
                    if (btn.Name == "btnDangXuat") btn.Enabled = true;
                    else btn.Enabled = status;
                }
            }
        }

        public void ChuaDangNhap()
        {
            SetMenuStatus(false);
            lblTrangThai.Text = "Chưa đăng nhập";
        }

        public void QuyenQuanLy(string hoTen)
        {
            SetMenuStatus(true);
            lblTrangThai.Text = "Quản lý: " + hoTen;
            this.Text = "Trang Chủ - Quản Lý TiVi | Quản lý: " + hoTen;
        }

        public void QuyenNhanVien(string hoTen)
        {
            SetMenuStatus(true);
            // Khóa các chức năng của Quản lý
            btnNhanVien.Enabled = false;
            btnTKChiPhi.Enabled = false;
            btnTKDoanhThu.Enabled = false;
           

            lblTrangThai.Text = "Nhân viên: " + hoTen;
            this.Text = "Trang Chủ - Quản Lý TiVi | Nhân viên: " + hoTen;
        }

        // --- MỞ FORM CON TRONG PANEL ---
        private void MoFormCon<T>() where T : Form, new()
        {
            // Tìm xem form loại T đã được mở trong panelContent chưa
            Form frm = panelContent.Controls.OfType<T>().FirstOrDefault();

            if (frm == null)
            {
                frm = new T();
                frm.TopLevel = false;            // Cực kỳ quan trọng: Biến Form thành Control con
                frm.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền
                frm.Dock = DockStyle.Fill;       // Cho lấp đầy toàn bộ panelContent

                // Xóa các form cũ đang hiển thị để nhường chỗ cho form mới
                panelContent.Controls.Clear();

                // Thêm form mới vào panel và hiển thị
                panelContent.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                // Nếu form đã tồn tại trong panel, chỉ việc dọn dẹp các form khác và đưa nó lên đầu
                panelContent.Controls.Clear();
                panelContent.Controls.Add(frm);
                frm.Show();
            }
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Form child in MdiChildren) child.Close();
                TaiKhoanHienTai.NhanVienDangNhap = null;
                ChuaDangNhap();
                ThucHienDangNhap();
            }
        }

        private void btnQuanLyTiVi_Click(object sender, EventArgs e)
        {
            MoFormCon<frmQuanLyTiVi>(); // Thay frmTiVi bằng tên Form TiVi của bạn
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            MoFormCon<FrmNhanVien>();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            MoFormCon<frmKhachHang>();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            MoFormCon<frmPhieuNhap>();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            MoFormCon<frmHoaDon>();
        }

        private void btnCTPhieuNhap_Click(object sender, EventArgs e)
        {
            MoFormCon<frmChiTietPhieuNhap>();
        }

        private void btnTraGop_Click(object sender, EventArgs e)
        {
            MoFormCon<frmTraGop>();
        }

        private void btnTKChiPhi_Click(object sender, EventArgs e)
        {
            MoFormCon<frmThongkeChiPhi>();
        }

        private void btnTKDoanhThu_Click(object sender, EventArgs e)
        {
            MoFormCon<frmThongKeDoanhThu>();

        }
    }
}
