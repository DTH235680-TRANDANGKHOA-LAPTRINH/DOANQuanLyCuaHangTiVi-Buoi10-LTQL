using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangTiVi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiPhiVanHanh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    TienDien = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TienNuoc = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TienMatBang = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TienBaoTri = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiPhiVanHanh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayThangNamSinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoTenNhanVien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuyenHan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnhChanDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Luong = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "QuanLyTiVi",
                columns: table => new
                {
                    MaTiVi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenTiVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HangSanXuat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonGiaBan = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    KhuyenMai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    AnhMinhHoa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyTiVi", x => x.MaTiVi);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChuHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NguoiGiaoHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NhanVienMaNhanVien = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhap", x => x.MaPhieuNhap);
                    table.ForeignKey(
                        name: "FK_PhieuNhap_NhanVien_NhanVienMaNhanVien",
                        column: x => x.NhanVienMaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonID = table.Column<int>(type: "int", nullable: false),
                    MaTiVi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoLuongBan = table.Column<int>(type: "int", nullable: false),
                    DonGiaBan = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    KhuyenMai = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDon_HoaDonID",
                        column: x => x.HoaDonID,
                        principalTable: "HoaDon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_QuanLyTiVi_MaTiVi",
                        column: x => x.MaTiVi,
                        principalTable: "QuanLyTiVi",
                        principalColumn: "MaTiVi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraGop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<int>(type: "int", nullable: false),
                    PhiPhuThuDinhKy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LaiSuat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoTienTraTruoc = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SoTienConNo = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    KyHanTra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraGop", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TraGop_HoaDon_MaHoaDon",
                        column: x => x.MaHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhap",
                columns: table => new
                {
                    MaCTPN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaTiVi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoLuongNhap = table.Column<int>(type: "int", nullable: false),
                    DonGiaNhap = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhap", x => x.MaCTPN);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_PhieuNhap_MaPhieuNhap",
                        column: x => x.MaPhieuNhap,
                        principalTable: "PhieuNhap",
                        principalColumn: "MaPhieuNhap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_QuanLyTiVi_MaTiVi",
                        column: x => x.MaTiVi,
                        principalTable: "QuanLyTiVi",
                        principalColumn: "MaTiVi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietTraGop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraGopID = table.Column<int>(type: "int", nullable: false),
                    MaTraGop = table.Column<int>(type: "int", nullable: false),
                    KyThu = table.Column<int>(type: "int", nullable: false),
                    NgayCanDong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTienGoc = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SoTienLai = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TongTienDong = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SoTienDaDong = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    NgayThucDong = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiNopTien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoTienPhat = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietTraGop", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietTraGop_TraGop_TraGopID",
                        column: x => x.TraGopID,
                        principalTable: "TraGop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_MaPhieuNhap",
                table: "ChiTietPhieuNhap",
                column: "MaPhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_MaTiVi",
                table: "ChiTietPhieuNhap",
                column: "MaTiVi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietTraGop_TraGopID",
                table: "ChiTietTraGop",
                column: "TraGopID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKhachHang",
                table: "HoaDon",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaNhanVien",
                table: "HoaDon",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_HoaDonID",
                table: "HoaDonChiTiet",
                column: "HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_MaTiVi",
                table: "HoaDonChiTiet",
                column: "MaTiVi");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_NhanVienMaNhanVien",
                table: "PhieuNhap",
                column: "NhanVienMaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_TraGop_MaHoaDon",
                table: "TraGop",
                column: "MaHoaDon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiPhiVanHanh");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhap");

            migrationBuilder.DropTable(
                name: "ChiTietTraGop");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "TraGop");

            migrationBuilder.DropTable(
                name: "QuanLyTiVi");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");
        }
    }
}
