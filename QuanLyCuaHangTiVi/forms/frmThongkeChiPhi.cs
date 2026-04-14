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
    public partial class frmThongkeChiPhi : Form
    {
        public frmThongkeChiPhi()
        {
            InitializeComponent();
        }
        // Khởi tạo DbContext
        AppDbContext db = new AppDbContext();

        // Biến lưu ID của chi phí vận hành để phục vụ chức năng Sửa
        int chiPhiID_HienTai = 0;
        private void frmThongkeChiPhi_Load(object sender, EventArgs e)
        {// Mặc định gán Tháng/Năm hiện tại
            nudThang.Value = DateTime.Now.Month;
            nudNam.Value = DateTime.Now.Year;

            // Khóa các ô TextBox hiển thị Tổng (Chỉ xem, không nhập tay)
            txtTongTienNhap.ReadOnly = true;
            txtTongLuong.ReadOnly = true;
            txtTongChiPhiVanHanh.ReadOnly = true;
            txtTongChiPhi.ReadOnly = true;

            // Load số liệu mặc định ban đầu
            LamMoiOChiPhi();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;

            try
            {
                // --- PHẦN 1: THỐNG KÊ CHI PHÍ NHẬP HÀNG ---
                var queryNhap = db.ChiTietPhieuNhaps
                                  .Where(ct => ct.PhieuNhap != null && ct.PhieuNhap.NgayNhap.Year == nam);

                if (thang > 0)
                    queryNhap = queryNhap.Where(ct => ct.PhieuNhap.NgayNhap.Month == thang);

                var dsNhapHang = queryNhap.Select(ct => new
                {
                    ID = ct.MaCTPN,
                    MaPhieuNhap = ct.MaPhieuNhap,
                    TenTiVi = ct.QuanLyTiVi.TenTiVi,
                    HangSanXuat = ct.QuanLyTiVi.HangSanXuat,
                    NgayNhapHang = ct.PhieuNhap.NgayNhap,
                    DonGiaNhap = ct.DonGiaNhap,
                    SoLuong = ct.SoLuongNhap,
                    ThanhTien = ct.DonGiaNhap * ct.SoLuongNhap
                }).ToList();

                dgvChiPhiNhapHang.AutoGenerateColumns = false;
                dgvChiPhiNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvChiPhiNhapHang.DataSource = dsNhapHang;
                dgvChiPhiNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                decimal tongNhap = dsNhapHang.Any() ? dsNhapHang.Sum(x => x.ThanhTien) : 0;
                txtTongTienNhap.Text = tongNhap.ToString("N0") + " VNĐ";

                // --- PHẦN 2: THỐNG KÊ CHI PHÍ LƯƠNG NHÂN VIÊN ---
                var dsNhanVien = db.NhanViens.Select(nv => new
                {
                    nv.MaNhanVien,
                    nv.HoTenNhanVien,
                    nv.QuyenHan,
                    nv.Luong
                }).ToList();

                dgvChiPhiLuongNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvChiPhiLuongNhanVien.DataSource = dsNhanVien;
                dgvChiPhiLuongNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                decimal tongLuongMotThang = dsNhanVien.Any() ? dsNhanVien.Sum(x => (decimal?)x.Luong ?? 0) : 0;
                decimal tongLuong = 0;

                if (thang == 0) // Xem cả năm
                {
                    if (nam < DateTime.Now.Year)
                        tongLuong = tongLuongMotThang * 12;
                    else if (nam == DateTime.Now.Year)
                        tongLuong = tongLuongMotThang * DateTime.Now.Month;
                    else
                        tongLuong = 0;
                }
                else // Xem từng tháng
                {
                    tongLuong = tongLuongMotThang;
                }
                txtTongLuong.Text = tongLuong.ToString("N0") + " VNĐ";

                // --- PHẦN 3: THỐNG KÊ CHI PHÍ VẬN HÀNH ---
                decimal tongVanHanh = 0;
                if (thang > 0)
                {
                    btnLuu.Enabled = true;
                    btnSua.Enabled = true;
                    var chiPhiThang = db.ChiPhiVanHanhs.FirstOrDefault(cp => cp.Thang == thang && cp.Nam == nam);
                    if (chiPhiThang != null)
                    {
                        chiPhiID_HienTai = chiPhiThang.ID;
                        txtTienDien.Text = chiPhiThang.TienDien.ToString("G29");
                        txtTienNuoc.Text = chiPhiThang.TienNuoc.ToString("G29");
                        txtTienMatBang.Text = chiPhiThang.TienMatBang.ToString("G29");
                        txtTienBaoTri.Text = chiPhiThang.TienBaoTri.ToString("G29");
                        tongVanHanh = chiPhiThang.TongChiPhiVanHanh;
                    }
                    else
                    {
                        chiPhiID_HienTai = 0;
                        LamMoiOChiPhi();
                        tongVanHanh = 2800000;
                    }
                }
                else
                {
                    btnLuu.Enabled = false;
                    btnSua.Enabled = false;
                    var dsChiPhiNam = db.ChiPhiVanHanhs.Where(cp => cp.Nam == nam).ToList();
                    if (dsChiPhiNam.Any())
                    {
                        txtTienDien.Text = dsChiPhiNam.Sum(x => x.TienDien).ToString("N0");
                        txtTienNuoc.Text = dsChiPhiNam.Sum(x => x.TienNuoc).ToString("N0");
                        txtTienMatBang.Text = dsChiPhiNam.Sum(x => x.TienMatBang).ToString("N0");
                        txtTienBaoTri.Text = dsChiPhiNam.Sum(x => x.TienBaoTri).ToString("N0");
                        tongVanHanh = dsChiPhiNam.Sum(x => x.TongChiPhiVanHanh);
                    }
                    else
                    {
                        LamMoiOChiPhi();
                        tongVanHanh = 0;
                    }
                }
                txtTongChiPhiVanHanh.Text = tongVanHanh.ToString("N0") + " VNĐ";

                // --- PHẦN 4: TỔNG TẤT CẢ ---
                decimal tongCongTatCa = tongNhap + tongLuong + tongVanHanh;
                txtTongChiPhi.Text = tongCongTatCa.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (chiPhiID_HienTai == 0)
            {
                MessageBox.Show("Dữ liệu tháng này chưa tồn tại để sửa. Hãy nhấn 'Lưu' để tạo mới!", "Thông báo");
                return;
            }

            try
            {
                var cpSua = db.ChiPhiVanHanhs.Find(chiPhiID_HienTai);
                if (cpSua != null)
                {
                    cpSua.TienDien = decimal.Parse(txtTienDien.Text);
                    cpSua.TienNuoc = decimal.Parse(txtTienNuoc.Text);
                    cpSua.TienMatBang = decimal.Parse(txtTienMatBang.Text);
                    cpSua.TienBaoTri = decimal.Parse(txtTienBaoTri.Text);

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    btnThongKe.PerformClick();
                }
            }
            catch { MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi"); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiOChiPhi();

        }
        private void LamMoiOChiPhi()
        {
            txtTienMatBang.Text = "2000000";
            txtTienDien.Text = "500000";
            txtTienNuoc.Text = "200000";
            txtTienBaoTri.Text = "100000";
            txtTongChiPhiVanHanh.Text = "2,800,000 VNĐ";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;

            if (thang == 0) return; // Không lưu được cho "Cả năm"

            try
            {
                var cpLuu = db.ChiPhiVanHanhs.FirstOrDefault(x => x.Thang == thang && x.Nam == nam);

                if (cpLuu != null)
                {
                    // Đã có -> Cập nhật
                    cpLuu.TienDien = decimal.Parse(txtTienDien.Text);
                    cpLuu.TienNuoc = decimal.Parse(txtTienNuoc.Text);
                    cpLuu.TienMatBang = decimal.Parse(txtTienMatBang.Text);
                    cpLuu.TienBaoTri = decimal.Parse(txtTienBaoTri.Text);
                }
                else
                {
                    // Chưa có -> Thêm mới
                    ChiPhiVanHanh cpMoi = new ChiPhiVanHanh
                    {
                        Thang = thang,
                        Nam = nam,
                        TienDien = decimal.Parse(txtTienDien.Text),
                        TienNuoc = decimal.Parse(txtTienNuoc.Text),
                        TienMatBang = decimal.Parse(txtTienMatBang.Text),
                        TienBaoTri = decimal.Parse(txtTienBaoTri.Text)
                    };
                    db.ChiPhiVanHanhs.Add(cpMoi);
                }

                db.SaveChanges();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Thông báo");
                btnThongKe.PerformClick();
            }
            catch { MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi"); }
        }

        private void dgvChiPhiNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
