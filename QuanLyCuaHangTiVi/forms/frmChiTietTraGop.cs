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
        private int _maTraGop;
        public frmChiTietTraGop(int maTraGop)
        {
            InitializeComponent();
            _maTraGop = maTraGop;

        }

        private void frmChiTietTraGop_Load(object sender, EventArgs e)
        {
            lblTieuDe.Text = "LỊCH TRÌNH TRẢ GÓP SỐ: " + _maTraGop.ToString();
            dtpNgayNop.Value = DateTime.Now;
            LoadDanhSach();
            txtSoTienNop.KeyPress += ChiNhapSo_KeyPress;
            txtSoTienNop.TextChanged += txtSoTienNop_TextChanged;
        }

        private void LoadDanhSach()
        {
            // Dòng này bây giờ sẽ không còn báo lỗi đỏ (CS0019) nữa vì cả 2 đều là int
            var ds = db.ChiTietTraGops.Where(ct => ct.MaTraGop == _maTraGop).OrderBy(ct => ct.KyThu).ToList();
            dgvChiTiet.DataSource = ds;

            if (dgvChiTiet.Columns["TraGop"] != null) dgvChiTiet.Columns["TraGop"].Visible = false;
            if (dgvChiTiet.Columns["MaTraGop"] != null) dgvChiTiet.Columns["MaTraGop"].Visible = false;
            if (dgvChiTiet.Columns["ID"] != null) dgvChiTiet.Columns["ID"].Visible = false;

            dgvChiTiet.Columns["KyThu"].HeaderText = "Kỳ";
            dgvChiTiet.Columns["NgayCanDong"].HeaderText = "Hạn Chót";
            dgvChiTiet.Columns["TongTienDong"].HeaderText = "Cần Thu (Gốc+Lãi)";
            dgvChiTiet.Columns["SoTienPhat"].HeaderText = "Tiền Phạt";
            dgvChiTiet.Columns["SoTienDaDong"].HeaderText = "Thực Tế Khách Đưa";
            dgvChiTiet.Columns["NgayThucDong"].HeaderText = "Ngày Khách Nộp";
            dgvChiTiet.Columns["NguoiNopTien"].HeaderText = "Ai Đi Nộp?";
            dgvChiTiet.Columns["TrangThai"].HeaderText = "Tình Trạng";

            dgvChiTiet.Columns["TongTienDong"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["SoTienDaDong"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["SoTienPhat"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["NgayCanDong"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvChiTiet.Columns["NgayThucDong"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private void ChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím Backspace (xóa ngược) và các phím số từ 0-9
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn phím không cho gõ vào
                MessageBox.Show("Số tiền nộp chỉ được phép nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSoTienNop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSoTienNop.Text)) return;

                // Xóa dấu phẩy cũ, chuyển sang số rồi định dạng lại thành chuỗi có dấu phẩy
                decimal value = decimal.Parse(txtSoTienNop.Text.Replace(",", ""));
                txtSoTienNop.Text = value.ToString("N0");

                // Đưa con trỏ chuột về cuối dòng sau khi định dạng
                txtSoTienNop.SelectionStart = txtSoTienNop.Text.Length;
            }
            catch { }
        }
        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChiTiet.Rows[e.RowIndex].DataBoundItem is ChiTietTraGop row)
            {
                decimal tienCanThu = row.TongTienDong + row.SoTienPhat;

                // 1. Nếu ĐÃ ĐÓNG ĐỦ (hoặc dư) -> Xanh lá
                if (row.SoTienDaDong >= tienCanThu)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                // 2. Nếu CÒN THIẾU và ĐÃ QUÁ HẠN -> Đỏ (Bất kể trước đó có đóng mớ nào hay chưa)
                else if (DateTime.Now.Date >= row.NgayCanDong.Date)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.White;
                }
                // 3. Nếu CÒN THIẾU nhưng VẪN TRONG HẠN -> Vàng
                else if (row.SoTienDaDong > 0 && row.SoTienDaDong < tienCanThu)
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                }
            }
        }
        private void btnThuTien_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (!decimal.TryParse(txtSoTienNop.Text.Replace(",", ""), out decimal soTienKhachDua) || soTienKhachDua <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền khách nộp hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng click chọn Kỳ (Tháng) mà khách muốn nộp tiền trên danh sách!", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy ra kỳ mà nhân viên đang click chuột vào
            var kyDangChon = dgvChiTiet.CurrentRow.DataBoundItem as ChiTietTraGop;
            DateTime ngayKhachNop = dtpNgayNop.Value.Date;
            string nguoiNop = string.IsNullOrWhiteSpace(txtNguoiNop.Text) ? "Chủ hợp đồng" : txtNguoiNop.Text;

            decimal soTienDu = soTienKhachDua;

            // =====================================================================
            // BƯỚC 1: ƯU TIÊN ĐẮP TIỀN VÀO KỲ ĐANG ĐƯỢC CHỌN TRÊN LƯỚI TRƯỚC
            // =====================================================================

            // Tính tiền phạt (nếu có) cho kỳ đang chọn
            if (ngayKhachNop > kyDangChon.NgayCanDong.Date && kyDangChon.SoTienDaDong < (kyDangChon.TongTienDong + kyDangChon.SoTienPhat))
            {
                int soNgayTre = (ngayKhachNop - kyDangChon.NgayCanDong.Date).Days;
                kyDangChon.SoTienPhat = soNgayTre * 10000;
            }

            decimal tienCanThuKyNay = (kyDangChon.TongTienDong + kyDangChon.SoTienPhat) - kyDangChon.SoTienDaDong;

            if (tienCanThuKyNay > 0)
            {
                // Rót tiền vào kỳ này (đổ tối đa bằng số tiền kỳ này cần)
                decimal tienDapVao = Math.Min(soTienDu, tienCanThuKyNay);
                kyDangChon.SoTienDaDong += tienDapVao;
                kyDangChon.NgayThucDong = ngayKhachNop;
                kyDangChon.NguoiNopTien = nguoiNop;

                // Trừ đi số tiền đã đập vào. Nếu khách nộp thiếu, soTienDu sẽ về 0.
                soTienDu -= tienDapVao;
            }

            // =====================================================================
            // BƯỚC 2: NẾU KỲ VỪA CHỌN ĐÃ ĐÓNG ĐỦ MÀ KHÁCH VẪN ĐƯA DƯ TIỀN
            // Mang phần dư đi quét TẤT CẢ các kỳ (ưu tiên từ kỳ 1 trở đi) để trả nợ
            // =====================================================================
            if (soTienDu > 0)
            {
                // Lấy tất cả các kỳ khác kỳ đang chọn, sắp xếp từ kỳ 1 đến kỳ cuối
                var cacKyKhac = db.ChiTietTraGops
                                  .Where(ct => ct.MaTraGop == _maTraGop && ct.KyThu != kyDangChon.KyThu)
                                  .OrderBy(ct => ct.KyThu)
                                  .ToList();

                foreach (var kyGop in cacKyKhac)
                {
                    if (soTienDu <= 0) break; // Hết tiền dư thì dừng

                    // Tính tiền phạt cho kỳ này (nếu có)
                    if (ngayKhachNop > kyGop.NgayCanDong.Date && kyGop.SoTienDaDong < (kyGop.TongTienDong + kyGop.SoTienPhat))
                    {
                        int soNgayTre = (ngayKhachNop - kyGop.NgayCanDong.Date).Days;
                        kyGop.SoTienPhat = soNgayTre * 10000;
                    }

                    decimal canThu = (kyGop.TongTienDong + kyGop.SoTienPhat) - kyGop.SoTienDaDong;

                    // Nếu kỳ này đóng đủ rồi thì bỏ qua sang kỳ tiếp
                    if (canThu <= 0) continue;

                    // Lấy phần tiền dư rót vào kỳ này
                    decimal tienDapVao = Math.Min(soTienDu, canThu);
                    kyGop.SoTienDaDong += tienDapVao;
                    kyGop.NgayThucDong = ngayKhachNop;
                    kyGop.NguoiNopTien = nguoiNop;

                    soTienDu -= tienDapVao;
                }
            }

            // =====================================================================
            // BƯỚC 3: QUÉT SẠCH SẼ MỌI KỲ MÀ VẪN CÒN DƯ TIỀN (Khách trả trước hạn)
            // Đẩy hết tiền thừa vào kỳ cuối cùng
            // =====================================================================
            if (soTienDu > 0)
            {
                var kyCuoi = db.ChiTietTraGops
                               .Where(ct => ct.MaTraGop == _maTraGop)
                               .OrderByDescending(ct => ct.KyThu)
                               .FirstOrDefault();
                if (kyCuoi != null)
                {
                    kyCuoi.SoTienDaDong += soTienDu;
                    kyCuoi.NgayThucDong = ngayKhachNop;
                    kyCuoi.NguoiNopTien = nguoiNop;
                }
                MessageBox.Show($"Khách thanh toán dư {soTienDu:N0} VNĐ.\nTiền thừa được cộng dồn vào kỳ cuối cùng!", "Lưu ý");
            }

            // 4. Lưu Database
            db.SaveChanges();
            MessageBox.Show("Thu tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDanhSach();
            txtSoTienNop.Clear();
            txtNguoiNop.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
