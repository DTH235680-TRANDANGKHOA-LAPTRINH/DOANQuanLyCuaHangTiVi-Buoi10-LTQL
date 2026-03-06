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
        [StringLength(20)]
        public string MaHoaDon { get; set; }

        // Khóa ngoại Khách Hàng
        [StringLength(20)]
        public string MaKhachHang { get; set; }
        [ForeignKey("MaKhachHang")]
        public virtual KhachHang KhachHang { get; set; }

        // Khóa ngoại Nhân Viên
        [StringLength(20)]
        public string MaNhanVien { get; set; }

        // SỬA Ở ĐÂY: Đổi "MaNV" thành "MaNhanVien" cho khớp với biến phía trên
        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        public DateTime NgayLapHoaDon { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string LoaiThanhToan { get; set; } // Tiền mặt / Trả góp

        // decimal(18, 0) rất chuẩn nếu cửa hàng của bạn chỉ tính tiền Việt (VND)
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TongTienHoaDon { get; set; }

        // Quan hệ
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual ICollection<TraGop> TraGops { get; set; }
    }
}
