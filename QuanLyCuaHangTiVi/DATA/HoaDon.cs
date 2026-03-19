using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public int ID { get; set; } // ID hóa đơn vẫn nên để int tự tăng cho dễ quản lý

        [Required]
        [StringLength(20)]
        public string MaNhanVien { get; set; } // Đổi từ NhanVienID (int) -> MaNhanVien (string)

        [Required]
        [StringLength(20)]
        public string MaKhachHang { get; set; } // Đổi từ KhachHangID (int) -> MaKhachHang (string)

        public DateTime NgayLap { get; set; } = DateTime.Now;
        public string? GhiChuHoaDon { get; set; }

        // Quan hệ
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

        [ForeignKey("MaKhachHang")]
        public virtual KhachHang KhachHang { get; set; } = null!;

        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; } = null!;
    }

    [NotMapped]
    public class DanhSachHoaDon
    {
        public int ID { get; set; }
        public string MaNhanVien { get; set; }
        public string HoTenNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string XemChiTiet { get; set; } = "Xem chi tiết";
    }
}
