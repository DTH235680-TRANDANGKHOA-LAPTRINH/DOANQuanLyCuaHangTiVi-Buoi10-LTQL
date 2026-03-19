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
            ChuaDangNhap(); // Khóa hết các nút chức năng
            ThucHienDangNhap(); // Bật form đăng nhập
        }



        // --- 1. CÁC HÀM PHÂN QUYỀN (Bật/Tắt các Button) ---
        public void ChuaDangNhap()
        {
            // Mờ tất cả các nút trừ nút Đăng xuất / Thoát (tôi đoán là nút màu đỏ ở dưới cùng)
            btnQuanLyTiVi.Enabled = false;
            btnNhanVien.Enabled = false;
            btnKhachHang.Enabled = false;
            btnPhieuNhap.Enabled = false;
            btnCTPhieuNhap.Enabled = false;
            btnHoaDon.Enabled = false;
            btnTraGop.Enabled = false;
            btnTKChiPhi.Enabled = false;
            btnTKDoanhThu.Enabled = false;
            btnTroGiup.Enabled = false;

            this.Text = "Trang Chủ - Quản Lý TiVi | Chưa đăng nhập";
        }

        public void QuyenQuanLy()
        {
            // Quản lý được sử dụng TẤT CẢ các nút
            btnQuanLyTiVi.Enabled = true;
            btnNhanVien.Enabled = true;
            btnKhachHang.Enabled = true;
            btnPhieuNhap.Enabled = true;
            btnCTPhieuNhap.Enabled = true;
            btnHoaDon.Enabled = true; 
            btnTraGop.Enabled = true;
            btnTKChiPhi.Enabled = true;
            btnTKDoanhThu.Enabled = true;
            btnTroGiup.Enabled = true;

            this.Text = "Trang Chủ - Quản Lý TiVi | Quản lý: " + hoTenNguoiDung;
        }

        public void QuyenNhanVien()
        {
            // Nhân viên chỉ được thao tác Bán hàng (Hóa đơn, Khách hàng, xem TiVi)
            btnQuanLyTiVi.Enabled = true;
            btnKhachHang.Enabled = true;
            btnHoaDon.Enabled = true;
          
            btnTraGop.Enabled = true;
            btnTroGiup.Enabled = true;

            // KHÔNG cho phép Nhân viên thao tác quản trị, nhập kho và xem thống kê
            btnNhanVien.Enabled = false;
            btnPhieuNhap.Enabled = false;
            btnCTPhieuNhap.Enabled = false;
            btnTKChiPhi.Enabled = false;
            btnTKDoanhThu.Enabled = false;

            this.Text = "Trang Chủ - Quản Lý TiVi | Nhân viên: " + hoTenNguoiDung;
        }

        // --- 2. HÀM XỬ LÝ ĐĂNG NHẬP (Chuẩn theo sườn của thầy) ---
        private void ThucHienDangNhap()
        {
            // Bật Form đăng nhập lên
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new frmDangNhap();

            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                // 1. Lúc này Form Đăng Nhập đã kiểm tra CSDL xong và gán TaiKhoanHienTai rồi.
                // 2. Ta chỉ việc lấy thông tin từ TaiKhoanHienTai ra để dùng!
                var nv = TaiKhoanHienTai.NhanVienDangNhap;

                if (nv != null)
                {
                    hoTenNguoiDung = nv.HoTenNhanVien;

                    // Kiểm tra phân quyền dựa vào chức vụ
                    if (nv.QuyenHan == "Quản lý")
                    {
                        QuyenQuanLy();
                    }
                    else
                    {
                        QuyenNhanVien();
                    }
                }
            }
            else
            {
                // Bấm nút Hủy bỏ hoặc dấu X -> Thoát app luôn
                Application.Exit();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Đóng tất cả các form con đang hiển thị ở phần không gian trống bên phải
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            ChuaDangNhap(); // Trả về trạng thái khóa
            ThucHienDangNhap(); // Bật lại màn hình đăng nhậ
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

      



        // Hàm dùng chung để mở Form con lọt vào vùng trống
        private void MoFormCon<T>() where T : Form, new()
        {
            // Kiểm tra xem Form này đã mở chưa
            Form frm = this.MdiChildren.FirstOrDefault(f => f is T);
            if (frm == null)
            {
                frm = new T();
                frm.MdiParent = this; // Cho nó chui vào trong Form chính
                frm.Show();
            }
            else
            {
                frm.Activate(); // Nếu mở rồi thì hiện lên trên cùng
            }
        }
    }
}
