using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    [Table("QuanLyTiVi")]
    public class QuanLyTiVi
    {
        [Key]
        [StringLength(20, ErrorMessage = "Mã TiVi không được quá 20 ký tự")]
        public string MaTiVi { get; set; }

        [Required]// bắt buộc nhập không được bỏ trống
        [StringLength(100)]
        public string TenTiVi { get; set; }

        [StringLength(50)]
        public string HangSanXuat { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18, 0)")]//18 chữ số và 0 thập phân
        public decimal DonGiaBan { get; set; }

        [Column(TypeName = "decimal(18, 2)")]//18 chữ số và 2 thập phân vd:10.58%
        public decimal KhuyenMai { get; set; } // % khuyến mãi

        public int SoLuongTon { get; set; }

        [StringLength(255)]
        public string AnhMinhHoa { get; set; }

        // --- Logic hiển thị (Không lưu vào database - NotMapped) ---
        [NotMapped]//đừng tạo cột cho thuộc tính này trong cơ sở dữ liệu
        public string TrangThai
        {
            get
            {
                if (SoLuongTon == 0) return "Hết hàng";
                if (SoLuongTon > 0 && SoLuongTon < 5) return "Sắp hết";
                return "Còn hàng";
            }
        }


        // --- Thêm logic tính Giá Hiện Tại ---
        [NotMapped]
        public decimal GiaHienTai
        {
            get
            {
                return DonGiaBan - (DonGiaBan * KhuyenMai / 100);
            }
        }

        // Quan hệ
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }// kết nối 1 vs nhiều vd: 1 tivi có thể xuất hiện trên nhiều chi tiết hóa đơn
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
