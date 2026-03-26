using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangTiVi.Migrations
{
    /// <inheritdoc />
    public partial class TaoBangChiPhiVanHanh : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiPhiVanHanh");
        }
    }
}
