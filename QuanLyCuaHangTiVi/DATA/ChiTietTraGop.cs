using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    [Table("ChiTietTraGop")]
    public class ChiTietTraGop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int TraGopID { get; set; } // SỬA: Đổi MaTraGop thành TraGopID

        [ForeignKey("TraGopID")]
      //  public virtual TraGop TraGop { get; set; } = null!;

        public int MaTraGop { get; set; }
        public int KyThu { get; set; }
        public DateTime NgayCanDong { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienGoc { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienLai { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal TongTienDong { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienDaDong { get; set; } = 0;

        public DateTime? NgayThucDong { get; set; }

        [StringLength(100)]
        public string? NguoiNopTien { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienPhat { get; set; } = 0;

        [NotMapped]
        public string TrangThai
        {
            get
            {
                if (SoTienDaDong == 0) return "Chưa đóng";

                decimal tienCanThu = TongTienDong + SoTienPhat;
                if (SoTienDaDong < tienCanThu) return $"Đóng thiếu {tienCanThu - SoTienDaDong:N0}";
                if (SoTienDaDong > tienCanThu) return $"Đóng dư {SoTienDaDong - tienCanThu:N0}";

                return "Đã đóng đủ";
            }
        }
    }
}
