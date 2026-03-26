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
        public int ID { get; set; } // Khóa chính tự tăng

        [Required]
        [StringLength(20)]
        public string MaTraGop { get; set; } // Khóa ngoại liên kết với hợp đồng Trả Góp gốc

        [ForeignKey("MaTraGop")]
        public virtual TraGop TraGop { get; set; } = null!;

        public int KyThu { get; set; } // Kỳ thứ mấy (1, 2, 3...)
        public DateTime NgayCanDong { get; set; } // Hạn chót phải đóng của kỳ này

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienGoc { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTienLai { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal TongTienDong { get; set; }

        // Cực kỳ quan trọng: Để đánh dấu khách đã đem tiền tới đóng cho tháng này chưa
        public bool DaThanhToan { get; set; } = false;
    }
}
