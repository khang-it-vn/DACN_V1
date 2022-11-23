using Microsoft.EntityFrameworkCore.Migrations;

namespace BB_V1.Migrations
{
    public partial class updateAllowNullChiTietDiemHienMauCoDinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETDIEMHIENMAU_LOAITHETICH",
                table: "ChiTietDiaDiemHienMau");

            migrationBuilder.AlterColumn<int>(
                name: "ID_PKQ",
                table: "ChiTietDiaDiemHienMau",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID_LTT",
                table: "ChiTietDiaDiemHienMau",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETDIEMHIENMAU_LOAITHETICH",
                table: "ChiTietDiaDiemHienMau",
                column: "ID_LTT",
                principalTable: "LoaiTheTich",
                principalColumn: "ID_LTT",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETDIEMHIENMAU_LOAITHETICH",
                table: "ChiTietDiaDiemHienMau");

            migrationBuilder.AlterColumn<int>(
                name: "ID_PKQ",
                table: "ChiTietDiaDiemHienMau",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_LTT",
                table: "ChiTietDiaDiemHienMau",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETDIEMHIENMAU_LOAITHETICH",
                table: "ChiTietDiaDiemHienMau",
                column: "ID_LTT",
                principalTable: "LoaiTheTich",
                principalColumn: "ID_LTT",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
