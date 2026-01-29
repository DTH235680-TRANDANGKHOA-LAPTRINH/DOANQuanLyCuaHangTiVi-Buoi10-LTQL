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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTiet { get; set; }

        // Khóa ngoại Hóa Đơn
        [StringLength(20)]
        public string MaHoaDon { get; set; }
        [ForeignKey("MaHoaDon")]
        public virtual HoaDon HoaDon { get; set; }

        // Khóa ngoại TiVi
        [StringLength(20)]
        public string MaTiVi { get; set; }
        [ForeignKey("MaTiVi")]
        public virtual QuanLyTiVi QuanLyTiVi { get; set; }

        public int SoLuongMua { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGia { get; set; }

        public double KhuyenMai { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal ThanhTien { get; set; }
    }
}
