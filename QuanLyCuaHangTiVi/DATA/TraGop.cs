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

        // ✅ SỬA: Xóa bỏ [StringLength(20)] vì kiểu int không dùng thuộc tính này
        public int MaHoaDon { get; set; }

        [ForeignKey("MaHoaDon")] // ✅ Nên thêm thuộc tính này để tường minh
        public virtual HoaDon HoaDon { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal LaiSuat { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienTraTruoc { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienConNo { get; set; }

        public int KyHanTra { get; set; }
    }
}
