using Microsoft.EntityFrameworkCore.Migrations;

namespace BB_V1.Migrations
{
    public partial class editPKTableChiTietDiemHienMau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDiaDiemHienMau",
                table: "ChiTietDiaDiemHienMau");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDiaDiemHienMau",
                table: "ChiTietDiaDiemHienMau",
                columns: new[] { "UID", "ID_DC", "NgayHenHien" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDiaDiemHienMau",
                table: "ChiTietDiaDiemHienMau");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDiaDiemHienMau",
                table: "ChiTietDiaDiemHienMau",
                columns: new[] { "UID", "ID_DC" });
        }
    }
}
