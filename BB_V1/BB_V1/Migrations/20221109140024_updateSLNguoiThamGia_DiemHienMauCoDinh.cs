using Microsoft.EntityFrameworkCore.Migrations;

namespace BB_V1.Migrations
{
    public partial class updateSLNguoiThamGia_DiemHienMauCoDinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SLNguoiThamGia",
                table: "DiemHienMauCoDinh",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SLNguoiThamGia",
                table: "DiemHienMauCoDinh");
        }
    }
}
