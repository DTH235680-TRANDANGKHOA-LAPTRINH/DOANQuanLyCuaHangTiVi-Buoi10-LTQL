using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    [Table("PhieuNhap")]
    public class PhieuNhap
    {
        [Key]
        [StringLength(20)]
        public string MaPhieuNhap { get; set; }

        public DateTime NgayNhap { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string NguoiGiaoHang { get; set; } // Ai giao hàng đến

        [StringLength(255)]
        public string GhiChu { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal TongTienNhap { get; set; }

        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
