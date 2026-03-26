using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    
        [Table("ChiPhiVanHanh")]
        public class ChiPhiVanHanh
        {
            [Key]
            public int ID { get; set; }

            public int Thang { get; set; }
            public int Nam { get; set; }

            [Column(TypeName = "decimal(18, 0)")]
            public decimal TienDien { get; set; }

            [Column(TypeName = "decimal(18, 0)")]
            public decimal TienNuoc { get; set; }

            [Column(TypeName = "decimal(18, 0)")]
            public decimal TienMatBang { get; set; }

            [Column(TypeName = "decimal(18, 0)")]
            public decimal TienBaoTri { get; set; }

            // Bạn có thể viết thêm 1 property tính tổng nếu muốn dùng nhanh trên giao diện
            [NotMapped] // Khai báo NotMapped để EF không tạo cột này trong Database
            public decimal TongChiPhiVanHanh
            {
                get { return TienDien + TienNuoc + TienMatBang + TienBaoTri; }
            }
        }
    }

