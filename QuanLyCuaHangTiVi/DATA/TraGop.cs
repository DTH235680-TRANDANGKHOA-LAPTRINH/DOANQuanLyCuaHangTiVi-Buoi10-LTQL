using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    [Table("TraGop")]
    public class TraGop
    {
        [Key]
        [StringLength(20)]
        public string MaTraGop { get; set; }

        // Khóa ngoại Hóa Đơn
        [StringLength(20)]
        public string MaHoaDon { get; set; }
        [ForeignKey("MaHoaDon")]
        public virtual HoaDon HoaDon { get; set; }

        public double LaiSuat { get; set; } // % Lãi suất

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienTraTruoc { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienConNo { get; set; } // = (Tổng + Lãi) - Trả trước

        [StringLength(50)]
        public string KyHanTra { get; set; }
    }
}
