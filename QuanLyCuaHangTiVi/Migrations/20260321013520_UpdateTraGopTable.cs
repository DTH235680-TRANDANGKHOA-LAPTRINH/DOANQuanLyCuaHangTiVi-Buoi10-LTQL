using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangTiVi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTraGopTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietTraGop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTraGop = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KyThu = table.Column<int>(type: "int", nullable: false),
                    NgayCanDong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTienGoc = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SoTienLai = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TongTienDong = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    DaThanhToan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietTraGop", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietTraGop_TraGop_MaTraGop",
                        column: x => x.MaTraGop,
                        principalTable: "TraGop",
                        principalColumn: "MaTraGop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietTraGop_MaTraGop",
                table: "ChiTietTraGop",
                column: "MaTraGop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietTraGop");
        }
    }
}
