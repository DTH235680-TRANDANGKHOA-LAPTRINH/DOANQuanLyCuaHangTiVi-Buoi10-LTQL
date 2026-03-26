using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    public class AppDbContext : DbContext
    {
        // Khai báo danh sách các bảng (Tên biến đặt số nhiều)
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<QuanLyTiVi> QuanLyTiVis { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<TraGop> TraGops { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<ChiPhiVanHanh> ChiPhiVanHanhs { get; set; }
        public DbSet<ChiTietTraGop> ChiTietTraGops { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Best Practice: Kiểm tra xem optionsBuilder đã được cấu hình từ trước chưa
            if (!optionsBuilder.IsConfigured)
            {
                // Chuỗi kết nối đến SQL Server Express (Máy local)
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=QuanLyCuaHangTiVi;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
