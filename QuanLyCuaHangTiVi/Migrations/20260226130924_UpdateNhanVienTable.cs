using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangTiVi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNhanVienTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoTen",
                table: "NhanVien",
                newName: "HoTenNhanVien");

            migrationBuilder.RenameColumn(
                name: "MaNV",
                table: "NhanVien",
                newName: "MaNhanVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoTenNhanVien",
                table: "NhanVien",
                newName: "HoTen");

            migrationBuilder.RenameColumn(
                name: "MaNhanVien",
                table: "NhanVien",
                newName: "MaNV");
        }
    }
}
