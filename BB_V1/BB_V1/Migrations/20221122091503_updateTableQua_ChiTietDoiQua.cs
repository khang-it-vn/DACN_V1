using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BB_V1.Migrations
{
    public partial class updateTableQua_ChiTietDoiQua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GioiTinh",
                table: "TaiKhoan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GioiTinh",
                table: "NguoiHienMau",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    ID_ADMIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Dc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    TrangThaiHoatDong = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.ID_ADMIN);
                });

            migrationBuilder.CreateTable(
                name: "Qua",
                columns: table => new
                {
                    ID_QUA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Diem = table.Column<int>(type: "int", nullable: false),
                    SoLuongTon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pathHinhAnh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ID_ADMIN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qua", x => x.ID_QUA);
                    table.ForeignKey(
                        name: "FK_ADMINISTRATOR_QUA",
                        column: x => x.ID_ADMIN,
                        principalTable: "Administrator",
                        principalColumn: "ID_ADMIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDoiQua",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_QUA = table.Column<int>(type: "int", nullable: false),
                    ThoiGianDoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDiemLucDoi = table.Column<int>(type: "int", nullable: false),
                    SoLuongDoi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDoiQua", x => new { x.UID, x.ID_QUA, x.ThoiGianDoi });
                    table.ForeignKey(
                        name: "FK_NGUOIHIENMAU_CHITIETDOIQUAS",
                        column: x => x.UID,
                        principalTable: "NguoiHienMau",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QUA_CHITIETDOIQUAS",
                        column: x => x.ID_QUA,
                        principalTable: "Qua",
                        principalColumn: "ID_QUA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDoiQua_ID_QUA",
                table: "ChiTietDoiQua",
                column: "ID_QUA");

            migrationBuilder.CreateIndex(
                name: "IX_Qua_ID_ADMIN",
                table: "Qua",
                column: "ID_ADMIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDoiQua");

            migrationBuilder.DropTable(
                name: "Qua");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "NguoiHienMau");
        }
    }
}
