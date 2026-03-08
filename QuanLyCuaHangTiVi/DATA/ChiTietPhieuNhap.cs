using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    [Table("ChiTietPhieuNhap")]
    public class ChiTietPhieuNhap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCTPN { get; set; }

        [StringLength(20)]
        public string MaPhieuNhap { get; set; }
        [ForeignKey("MaPhieuNhap")]
        public virtual PhieuNhap PhieuNhap { get; set; }

        [StringLength(20)]
        public string MaTiVi { get; set; }
        [ForeignKey("MaTiVi")]
        public virtual QuanLyTiVi QuanLyTiVi { get; set; }

        public int SoLuongNhap { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGiaNhap { get; set; }

        [NotMapped]
        public decimal ThanhTien
        {
            get { return SoLuongNhap * DonGiaNhap; }
        }

        [NotMapped]
        public DateTime? NgayNhap
        {
            // Lấy Ngày Nhập từ bảng cha (PhieuNhap) sang
            get { return PhieuNhap != null ? PhieuNhap.NgayNhap : (DateTime?)null; }
        }
    }
}
