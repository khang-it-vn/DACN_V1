using Microsoft.EntityFrameworkCore.Migrations;

namespace BB_V1.Migrations
{
    public partial class updateAddColumnDiemNguoiHienMau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiemHienMau",
                table: "NguoiHienMau",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiemHienMau",
                table: "NguoiHienMau");
        }
    }
}
