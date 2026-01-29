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

        [Required]
        [StringLength(100)]
        public string TenTiVi { get; set; }

        [StringLength(50)]
        public string HangSanXuat { get; set; }

        public DateTime NgayNhap { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGiaBan { get; set; }

        public double KhuyenMai { get; set; } // % hoặc số tiền

        public int SoLuongTon { get; set; }

        

        // --- Logic hiển thị (Không lưu vào database - NotMapped) ---
        [NotMapped]
        public string TrangThai
        {
            get
            {
                if (SoLuongTon == 0) return "Hết hàng";
                if (SoLuongTon > 0 && SoLuongTon < 5) return "Sắp hết";
                return "Còn hàng";
            }
        }

        // Quan hệ
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
