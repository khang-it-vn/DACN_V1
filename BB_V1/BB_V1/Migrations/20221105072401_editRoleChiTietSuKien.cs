using Microsoft.EntityFrameworkCore.Migrations;

namespace BB_V1.Migrations
{
    public partial class editRoleChiTietSuKien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETSUKIEN_KETQUAMAU",
                table: "ChiTietSuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_LOAITHETICH_CHITIETSUKIEN",
                table: "ChiTietSuKien");

            migrationBuilder.AlterColumn<int>(
                name: "ID_PKQ",
                table: "ChiTietSuKien",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID_LTT",
                table: "ChiTietSuKien",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETSUKIEN_KETQUAMAU",
                table: "ChiTietSuKien",
                column: "ID_PKQ",
                principalTable: "PhieuKetQua",
                principalColumn: "ID_PKQ",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LOAITHETICH_CHITIETSUKIEN",
                table: "ChiTietSuKien",
                column: "ID_LTT",
                principalTable: "LoaiTheTich",
                principalColumn: "ID_LTT",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETSUKIEN_KETQUAMAU",
                table: "ChiTietSuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_LOAITHETICH_CHITIETSUKIEN",
                table: "ChiTietSuKien");

            migrationBuilder.AlterColumn<int>(
                name: "ID_PKQ",
                table: "ChiTietSuKien",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_LTT",
                table: "ChiTietSuKien",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETSUKIEN_KETQUAMAU",
                table: "ChiTietSuKien",
                column: "ID_PKQ",
                principalTable: "PhieuKetQua",
                principalColumn: "ID_PKQ",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LOAITHETICH_CHITIETSUKIEN",
                table: "ChiTietSuKien",
                column: "ID_LTT",
                principalTable: "LoaiTheTich",
                principalColumn: "ID_LTT",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
