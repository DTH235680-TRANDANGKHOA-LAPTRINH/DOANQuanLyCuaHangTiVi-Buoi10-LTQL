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

        [StringLength(100)]
        public string NguoiGiaoHang { get; set; } // Ai giao hàng đến

        // BỔ SUNG CỘT NGÀY NHẬP VÀO ĐÂY
        public DateTime NgayNhap { get; set; }

        

        [StringLength(255)]
        public string GhiChu { get; set; }

     
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        // (Tùy chọn) Khởi tạo danh sách tránh lỗi NullReference
        public PhieuNhap()
        {
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }
    }
}
