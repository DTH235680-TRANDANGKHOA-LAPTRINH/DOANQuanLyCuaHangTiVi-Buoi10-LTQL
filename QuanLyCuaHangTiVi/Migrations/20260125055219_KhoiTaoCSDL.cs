using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangTiVi.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTaoCSDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuanLyTiVi",
                columns: table => new
                {
                    MaTiVi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenTiVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayThangNam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    KhuyenMai = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyTiVi", x => x.MaTiVi);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuanLyTiVi");
        }
    }
}
