using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BB_V1.Migrations
{
    public partial class updateFK_ChiTietDiemHienMau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDiaDiemHienMau_NguoiHienMau_FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                table: "ChiTietDiaDiemHienMau");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDiaDiemHienMau_FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                table: "ChiTietDiaDiemHienMau");

            migrationBuilder.DropColumn(
                name: "FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                table: "ChiTietDiaDiemHienMau");

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                table: "ChiTietDiaDiemHienMau",
                column: "UID",
                principalTable: "NguoiHienMau",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                table: "ChiTietDiaDiemHienMau");

            migrationBuilder.AddColumn<Guid>(
                name: "FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                table: "ChiTietDiaDiemHienMau",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDiaDiemHienMau_FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                table: "ChiTietDiaDiemHienMau",
                column: "FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDiaDiemHienMau_NguoiHienMau_FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                table: "ChiTietDiaDiemHienMau",
                column: "FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                principalTable: "NguoiHienMau",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
