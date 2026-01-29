using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [StringLength(20)]
        public string MaKhachHang { get; set; }

        [Required]
        [StringLength(100)]
        public string TenKhachHang { get; set; }

        public DateTime NgayThangNamSinh { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string CCCD { get; set; }

        // Quan hệ
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
