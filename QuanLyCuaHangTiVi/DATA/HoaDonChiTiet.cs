using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    [Table("HoaDonChiTiet")]
    public class HoaDonChiTiet
    {
        [Key]
        public int ID { get; set; }

        public int HoaDonID { get; set; }

        [Required]
        [StringLength(20)]
        public string MaTiVi { get; set; } // Đổi từ int -> string

        public int SoLuongBan { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGiaBan { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? KhuyenMai { get; set; }

        // Quan hệ khóa ngoại
        [ForeignKey("HoaDonID")]
        public virtual HoaDon HoaDon { get; set; } = null!;

        [ForeignKey("MaTiVi")]
        public virtual QuanLyTiVi QuanLyTiVi { get; set; } = null!;
    }

    [NotMapped]
    public class DanhSachHoaDonChiTiet
    {
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public string MaTiVi { get; set; }
        public string TenTiVi { get; set; }
        public int SoLuongBan { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal KhuyenMai { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
