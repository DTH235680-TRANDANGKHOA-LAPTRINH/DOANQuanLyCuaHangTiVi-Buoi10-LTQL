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
        // Khai báo bảng duy nhất
        public DbSet<QuanLyTiVi> QuanLyTiVi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=QuanLyCuaHangTiVi;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
