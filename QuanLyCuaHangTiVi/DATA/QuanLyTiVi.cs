using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    public class QuanLyTiVi
    {
        [Key]
        [StringLength(20, ErrorMessage = "Mã quá dài!")]
        public string MaTiVi { get; set; }

        [StringLength(100)]
        public string TenTiVi { get; set; }

        [StringLength(100)]
        public string TenKhachHang { get; set; }

        public DateTime NgayThangNam { get; set; } = DateTime.Now;

        // --- SỬA LỖI DECIMAL Ở ĐÂY ---

        // (18, 0) nghĩa là: Tổng 18 số, lấy 0 số sau dấu phẩy (Vì tiền Việt Nam không dùng số lẻ hào/xu)
        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal KhuyenMai { get; set; }
    }
}
