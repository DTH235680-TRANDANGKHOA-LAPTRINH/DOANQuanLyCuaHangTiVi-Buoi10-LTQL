using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangTiVi.DATA
{
    [Table("TraGop")]
    public class TraGop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Đánh dấu cho DB tự động tăng số
        public int MaTraGop { get; set; }

        public int MaHoaDon { get; set; }

        [ForeignKey("MaHoaDon")]
        public virtual HoaDon HoaDon { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PhiPhuThuDinhKy { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal LaiSuat { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienTraTruoc { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienConNo { get; set; }

        public int KyHanTra { get; set; }

        public virtual ICollection<ChiTietTraGop> ChiTietTraGops { get; set; } = new List<ChiTietTraGop>();
    }
}

