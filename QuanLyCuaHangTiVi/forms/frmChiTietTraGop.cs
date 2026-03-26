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
    public partial class frmChiTietTraGop : Form
    {

        AppDbContext db = new AppDbContext();
        private string _maTraGop = "";
        public frmChiTietTraGop(string maTraGopTruyenVao)
        {
            InitializeComponent();
            _maTraGop = maTraGopTruyenVao;
        }

        private void frmChiTietTraGop_Load(object sender, EventArgs e)
        {
            lblTieuDe.Text = "LỊCH TRÌNH TRẢ GÓP - HỢP ĐỒNG: " + _maTraGop;
            LoadDanhSach();
        }
        private void LoadDanhSach()
        {
            var ds = db.ChiTietTraGops
                       .Where(ct => ct.MaTraGop == _maTraGop)
                       .OrderBy(ct => ct.KyThu) // Xếp từ tháng 1, 2, 3...
                       .ToList();

            dgvChiTiet.DataSource = ds;

            // Chỉnh lại UI cột cho chuyên nghiệp
            if (dgvChiTiet.Columns["TraGop"] != null) dgvChiTiet.Columns["TraGop"].Visible = false;
            if (dgvChiTiet.Columns["MaTraGop"] != null) dgvChiTiet.Columns["MaTraGop"].Visible = false;
            if (dgvChiTiet.Columns["ID"] != null) dgvChiTiet.Columns["ID"].Visible = false;

            dgvChiTiet.Columns["KyThu"].HeaderText = "Kỳ Thứ";
            dgvChiTiet.Columns["NgayCanDong"].HeaderText = "Ngày Phải Đóng";
            dgvChiTiet.Columns["SoTienGoc"].HeaderText = "Tiền Gốc";
            dgvChiTiet.Columns["SoTienLai"].HeaderText = "Tiền Lãi";
            dgvChiTiet.Columns["TongTienDong"].HeaderText = "TỔNG THU";
            dgvChiTiet.Columns["DaThanhToan"].HeaderText = "Đã Nộp Tiền?";

            // Định dạng ngày tháng và tiền tệ
            dgvChiTiet.Columns["NgayCanDong"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvChiTiet.Columns["SoTienGoc"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["SoTienLai"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["TongTienDong"].DefaultCellStyle.Format = "N0";
        }

        private void btnThuTien_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 kỳ (tháng) trên lưới để thu tiền!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID của dòng đang chọn trên DataGridView
            int idKyDong = (int)dgvChiTiet.CurrentRow.Cells["ID"].Value;
            var kyGop = db.ChiTietTraGops.Find(idKyDong);

            if (kyGop != null)
            {
                if (kyGop.DaThanhToan)
                {
                    MessageBox.Show("Kỳ này khách hàng ĐÃ ĐÓNG TIỀN rồi, không thể thu lần nữa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // Hỏi lại cho chắc
                DialogResult xacNhan = MessageBox.Show(
                    $"Xác nhận thu {kyGop.TongTienDong:N0} VNĐ cho kỳ số {kyGop.KyThu}?",
                    "Thu tiền",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (xacNhan == DialogResult.Yes)
                {
                    kyGop.DaThanhToan = true; // Bật cờ đã thanh toán
                    db.SaveChanges(); // Lưu vào SQL

                    MessageBox.Show("Đã thu tiền thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach(); // Refresh lại lưới
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
