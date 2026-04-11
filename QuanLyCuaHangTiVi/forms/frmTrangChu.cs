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


        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            ChuaDangNhap(); // Khóa menu trước
            ThucHienDangNhap();
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
                        // Lấy quyền hạn, loại bỏ khoảng trắng thừa để so sánh cho chính xác
                        string quyen = nv.QuyenHan != null ? nv.QuyenHan.Trim() : "";

                        // --- PHÂN QUYỀN THEO 4 MỨC ---
                        if (quyen == "Quản lý")
                        {
                            QuyenQuanLy(nv.HoTenNhanVien);
                        }
                        else if (quyen == "Nhân viên trả góp")
                        {
                            QuyenNhanVienTraGop(nv.HoTenNhanVien);
                        }
                        else if (quyen == "Nhân viên nhập hàng")
                        {
                            QuyenNhanVienNhapHang(nv.HoTenNhanVien);
                        }
                        else
                        {
                            // Mặc định là quyền nhân viên thường
                            QuyenNhanVien(nv.HoTenNhanVien);
                        }
                    }
                }
                else
                {
                    // Nếu bấm thoát hoặc hủy ở bảng đăng nhập -> Thoát ứng dụng
                    Application.Exit();
                }
            }
        }
        // --- HÀM SET TRẠNG THÁI MENU (Duyệt trong flowLayoutPanelMenu) ---
        private void SetMenuStatus(bool status)
        {
            // Duyệt qua tất cả các control trong flowLayoutPanelMenu
            // Lưu ý: Nút Đăng Xuất đã được đẩy ra ngoài nên không bị ẩn theo
            foreach (Control ctrl in flowLayoutPanelMenu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Visible = status; // Ẩn hoặc hiện các nút khác theo status
                }
            }
        }
        // --- CÁC HÀM CẤP QUYỀN ---
        public void ChuaDangNhap()
        {
            SetMenuStatus(false);
            lblTrangThai.Text = "Chưa đăng nhập";
        }

        public void QuyenQuanLy(string hoTen)
        {
            SetMenuStatus(true); // Mở hiển thị toàn bộ
            lblTrangThai.Text = "Quản lý: " + hoTen;
            this.Text = "Trang Chủ - Quản Lý TiVi | Quản lý: " + hoTen;
        }

        public void QuyenNhanVien(string hoTen)
        {
            SetMenuStatus(false); // Ẩn toàn bộ trước

            // 1. Nhân viên chỉ lập hóa đơn (Chỉ hiện các nút được phép)
            btnHoaDon.Visible = true;
            btnKhachHang.Visible = true;
            // btnQuanLyTiVi.Visible = true; // Bỏ comment nếu muốn nhân viên xem thông tin Tivi

            lblTrangThai.Text = "Nhân viên: " + hoTen;
            this.Text = "Trang Chủ - Quản Lý TiVi | Nhân viên: " + hoTen;
        }

        public void QuyenNhanVienTraGop(string hoTen)
        {
            SetMenuStatus(false); // Ẩn toàn bộ trước

            // 2. Nhân viên trả góp chỉ được lập hóa đơn và trả góp
            btnKhachHang.Visible = true;
            btnHoaDon.Visible = true;
            btnTraGop.Visible = true;

            lblTrangThai.Text = "NV Trả góp: " + hoTen;
            this.Text = "Trang Chủ - Quản Lý TiVi | NV Trả góp: " + hoTen;
        }

        public void QuyenNhanVienNhapHang(string hoTen)
        {
            SetMenuStatus(false); // Ẩn toàn bộ trước

            // 3. Nhân viên nhập hàng chỉ được sử dụng phiếu nhập và chi tiết phiếu nhập
            btnPhieuNhap.Visible = true;
            btnCTPhieuNhap.Visible = true;

            lblTrangThai.Text = "NV Nhập hàng: " + hoTen;
            this.Text = "Trang Chủ - Quản Lý TiVi | NV Nhập hàng: " + hoTen;
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
                // Dọn dẹp form hiện tại
                panelContent.Controls.Clear();
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

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            MoFormCon<FrmBaoCao>();
        }
    }
}
