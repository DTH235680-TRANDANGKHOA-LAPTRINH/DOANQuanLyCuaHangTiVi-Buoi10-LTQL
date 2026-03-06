using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangTiVi.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_MaNV",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhap_NhanVien_MaNV",
                table: "PhieuNhap");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhap_MaNV",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "MaNV",
                table: "PhieuNhap");

            migrationBuilder.RenameColumn(
                name: "NgayNhap",
                table: "QuanLyTiVi",
                newName: "NgayTao");

            migrationBuilder.RenameColumn(
                name: "MaNV",
                table: "HoaDon",
                newName: "MaNhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_MaNV",
                table: "HoaDon",
                newName: "IX_HoaDon_MaNhanVien");

            migrationBuilder.AlterColumn<decimal>(
                name: "LaiSuat",
                table: "TraGop",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "KyHanTra",
                table: "TraGop",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "KhuyenMai",
                table: "QuanLyTiVi",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "AnhMinhHoa",
                table: "QuanLyTiVi",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "PhieuNhap",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NguoiGiaoHang",
                table: "PhieuNhap",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NhanVienMaNhanVien",
                table: "PhieuNhap",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "KhuyenMai",
                table: "HoaDonChiTiet",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_NhanVienMaNhanVien",
                table: "PhieuNhap",
                column: "NhanVienMaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_MaNhanVien",
                table: "HoaDon",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhap_NhanVien_NhanVienMaNhanVien",
                table: "PhieuNhap",
                column: "NhanVienMaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_MaNhanVien",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhap_NhanVien_NhanVienMaNhanVien",
                table: "PhieuNhap");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhap_NhanVienMaNhanVien",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "AnhMinhHoa",
                table: "QuanLyTiVi");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "NguoiGiaoHang",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "NhanVienMaNhanVien",
                table: "PhieuNhap");

            migrationBuilder.RenameColumn(
                name: "NgayTao",
                table: "QuanLyTiVi",
                newName: "NgayNhap");

            migrationBuilder.RenameColumn(
                name: "MaNhanVien",
                table: "HoaDon",
                newName: "MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_MaNhanVien",
                table: "HoaDon",
                newName: "IX_HoaDon_MaNV");

            migrationBuilder.AlterColumn<double>(
                name: "LaiSuat",
                table: "TraGop",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "KyHanTra",
                table: "TraGop",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "KhuyenMai",
                table: "QuanLyTiVi",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "MaNV",
                table: "PhieuNhap",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "KhuyenMai",
                table: "HoaDonChiTiet",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaNV",
                table: "PhieuNhap",
                column: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_MaNV",
                table: "HoaDon",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhap_NhanVien_MaNV",
                table: "PhieuNhap",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
