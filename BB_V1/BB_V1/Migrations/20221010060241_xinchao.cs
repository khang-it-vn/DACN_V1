using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BB_V1.Migrations
{
    public partial class xinchao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenhVien",
                columns: table => new
                {
                    ID_BV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DC = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenhVien", x => x.ID_BV);
                });

            migrationBuilder.CreateTable(
                name: "ChePhamMau",
                columns: table => new
                {
                    ID_CPM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChePhamMau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HSD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChePhamMau", x => x.ID_CPM);
                });

            migrationBuilder.CreateTable(
                name: "LoaiMau",
                columns: table => new
                {
                    ID_LM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiMau", x => x.ID_LM);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTaiKhoan",
                columns: table => new
                {
                    ID_LTK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTaiKhoan", x => x.ID_LTK);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTheTich",
                columns: table => new
                {
                    ID_LTT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Diem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTheTich", x => x.ID_LTT);
                });

            migrationBuilder.CreateTable(
                name: "NguoiHienMau",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DC = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiHienMau", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    ID_TK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ID_BV = table.Column<int>(type: "int", nullable: false),
                    ID_LTK = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DC = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.ID_TK);
                    table.ForeignKey(
                        name: "FK_LOAITAIKHOAN_TAIKHOAN",
                        column: x => x.ID_LTK,
                        principalTable: "LoaiTaiKhoan",
                        principalColumn: "ID_LTK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAIKHOAN_BENHVIEN",
                        column: x => x.ID_BV,
                        principalTable: "BenhVien",
                        principalColumn: "ID_BV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiemHienMauCoDinh",
                columns: table => new
                {
                    ID_DC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ThoiGian_BD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGian_KT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_TK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemHienMauCoDinh", x => x.ID_DC);
                    table.ForeignKey(
                        name: "FK_DIEMHIENMAUCODINH_TAIKHOAN",
                        column: x => x.ID_TK,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID_TK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuKetQua",
                columns: table => new
                {
                    ID_PKQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileKetQua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThaiBaoQuan = table.Column<bool>(type: "bit", nullable: false),
                    ChuanDoan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_LM = table.Column<int>(type: "int", nullable: false),
                    ID_TK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuKetQua", x => x.ID_PKQ);
                    table.ForeignKey(
                        name: "FK_PHIEUKETQUA_LOAIMAU",
                        column: x => x.ID_LM,
                        principalTable: "LoaiMau",
                        principalColumn: "ID_LM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PHIEUKETQUA_TAIKHOAN",
                        column: x => x.ID_TK,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID_TK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuYeuCau",
                columns: table => new
                {
                    ID_PYC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianYeuCau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_TK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_BV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuYeuCau", x => x.ID_PYC);
                    table.ForeignKey(
                        name: "FK_PHIEUYEUCAU_BENHVIEN",
                        column: x => x.ID_BV,
                        principalTable: "BenhVien",
                        principalColumn: "ID_BV");
                    table.ForeignKey(
                        name: "FK_PHIEUYEUCAU_TAIKHOAN",
                        column: x => x.ID_TK,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID_TK");
                });

            migrationBuilder.CreateTable(
                name: "SuKienHienMau",
                columns: table => new
                {
                    ID_SK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSK = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ThoiGian_BD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGian_KT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DCs = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TongSoLuongThamGia = table.Column<int>(type: "int", nullable: false),
                    ID_TK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKienHienMau", x => x.ID_SK);
                    table.ForeignKey(
                        name: "FK_SUKIENHIENMAU_TAIKHOAN",
                        column: x => x.ID_TK,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID_TK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietChePhamMau",
                columns: table => new
                {
                    ID_CPM = table.Column<int>(type: "int", nullable: false),
                    ID_PKQ = table.Column<int>(type: "int", nullable: false),
                    NgayLuuKho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TheTich = table.Column<float>(type: "real", nullable: false),
                    TrangThaiSuDung = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietChePhamMau", x => new { x.ID_CPM, x.ID_PKQ });
                    table.ForeignKey(
                        name: "FK_CHITIETCHEPHAMMAU_CHEPHAMMAU",
                        column: x => x.ID_CPM,
                        principalTable: "ChePhamMau",
                        principalColumn: "ID_CPM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PHIEUKETQUA_CHITIETCHEPHAMMAU",
                        column: x => x.ID_PKQ,
                        principalTable: "PhieuKetQua",
                        principalColumn: "ID_PKQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDiaDiemHienMau",
                columns: table => new
                {
                    ID_DC = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayHenHien = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiHien = table.Column<bool>(type: "bit", nullable: false),
                    FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_LTT = table.Column<int>(type: "int", nullable: false),
                    ID_PKQ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDiaDiemHienMau", x => new { x.UID, x.ID_DC });
                    table.ForeignKey(
                        name: "FK_ChiTietDiaDiemHienMau_NguoiHienMau_FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                        column: x => x.FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU,
                        principalTable: "NguoiHienMau",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETDIEMHIENMAU_DIACHICODINH",
                        column: x => x.ID_DC,
                        principalTable: "DiemHienMauCoDinh",
                        principalColumn: "ID_DC",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETDIEMHIENMAU_LOAITHETICH",
                        column: x => x.ID_LTT,
                        principalTable: "LoaiTheTich",
                        principalColumn: "ID_LTT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETDIEMHIENMAU_PHIEUKETQUA",
                        column: x => x.ID_PKQ,
                        principalTable: "PhieuKetQua",
                        principalColumn: "ID_PKQ");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietYeuCau",
                columns: table => new
                {
                    ID_PYC = table.Column<int>(type: "int", nullable: false),
                    ID_CPM = table.Column<int>(type: "int", nullable: false),
                    ID_LM = table.Column<int>(type: "int", nullable: false),
                    TheTich = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietYeuCau", x => new { x.ID_PYC, x.ID_CPM, x.ID_LM });
                    table.ForeignKey(
                        name: "FK_CHITIETYEUCAU_CHEPHAMMAU",
                        column: x => x.ID_CPM,
                        principalTable: "ChePhamMau",
                        principalColumn: "ID_CPM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETYEUCAU_PHIEUYEUCAU",
                        column: x => x.ID_PYC,
                        principalTable: "PhieuYeuCau",
                        principalColumn: "ID_PYC",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOAIMAU_CHITIETYEUCAU",
                        column: x => x.ID_LM,
                        principalTable: "LoaiMau",
                        principalColumn: "ID_LM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSuKien",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_SK = table.Column<int>(type: "int", nullable: false),
                    TrangThaiHien = table.Column<bool>(type: "bit", nullable: false),
                    ThoiGian_DK = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_LTT = table.Column<int>(type: "int", nullable: false),
                    ID_PKQ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSuKien", x => new { x.UID, x.ID_SK });
                    table.ForeignKey(
                        name: "FK_CHITIETSUKIEN_KETQUAMAU",
                        column: x => x.ID_PKQ,
                        principalTable: "PhieuKetQua",
                        principalColumn: "ID_PKQ",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETSUKIEN_SUKIENHIENMAU",
                        column: x => x.ID_SK,
                        principalTable: "SuKienHienMau",
                        principalColumn: "ID_SK");
                    table.ForeignKey(
                        name: "FK_LOAITHETICH_CHITIETSUKIEN",
                        column: x => x.ID_LTT,
                        principalTable: "LoaiTheTich",
                        principalColumn: "ID_LTT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NGUOIHIENMAU_CHITIETSUKIEN",
                        column: x => x.UID,
                        principalTable: "NguoiHienMau",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSuDung",
                columns: table => new
                {
                    ID_CPM = table.Column<int>(type: "int", nullable: false),
                    ID_PKQ = table.Column<int>(type: "int", nullable: false),
                    ID_TK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThoiGianSuDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TheTichSuDung = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSuDung", x => new { x.ID_CPM, x.ID_PKQ, x.ID_TK });
                    table.ForeignKey(
                        name: "FK_CHITIETSUDUNG_CHITIETCHEPHAMMAU",
                        columns: x => new { x.ID_CPM, x.ID_PKQ },
                        principalTable: "ChiTietChePhamMau",
                        principalColumns: new[] { "ID_CPM", "ID_PKQ" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETSUDUNG_TAIKHOAN",
                        column: x => x.ID_TK,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID_TK");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietXuat",
                columns: table => new
                {
                    ID_CPM = table.Column<int>(type: "int", nullable: false),
                    ID_LM = table.Column<int>(type: "int", nullable: false),
                    ID_PYC = table.Column<int>(type: "int", nullable: false),
                    ID_CPM_XUAT = table.Column<int>(type: "int", nullable: false),
                    ID_PKQ_XUAT = table.Column<int>(type: "int", nullable: false),
                    ThoiGianXuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_TK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietXuat", x => new { x.ID_CPM, x.ID_LM, x.ID_PYC, x.ID_CPM_XUAT, x.ID_PKQ_XUAT });
                    table.ForeignKey(
                        name: "FK_CHITIETXUAT_CHEPHAMMAU",
                        columns: x => new { x.ID_CPM_XUAT, x.ID_PKQ_XUAT },
                        principalTable: "ChiTietChePhamMau",
                        principalColumns: new[] { "ID_CPM", "ID_PKQ" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETXUAT_CHITIETCHEPHAMMAU",
                        columns: x => new { x.ID_CPM, x.ID_PYC, x.ID_LM },
                        principalTable: "ChiTietYeuCau",
                        principalColumns: new[] { "ID_PYC", "ID_CPM", "ID_LM" });
                    table.ForeignKey(
                        name: "FK_TAIKHOAN_CHTIETXUAT",
                        column: x => x.ID_TK,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID_TK");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChePhamMau_ID_PKQ",
                table: "ChiTietChePhamMau",
                column: "ID_PKQ");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDiaDiemHienMau_FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU",
                table: "ChiTietDiaDiemHienMau",
                column: "FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDiaDiemHienMau_ID_DC",
                table: "ChiTietDiaDiemHienMau",
                column: "ID_DC");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDiaDiemHienMau_ID_LTT",
                table: "ChiTietDiaDiemHienMau",
                column: "ID_LTT");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDiaDiemHienMau_ID_PKQ",
                table: "ChiTietDiaDiemHienMau",
                column: "ID_PKQ");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSuDung_ID_TK",
                table: "ChiTietSuDung",
                column: "ID_TK");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSuKien_ID_LTT",
                table: "ChiTietSuKien",
                column: "ID_LTT");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSuKien_ID_PKQ",
                table: "ChiTietSuKien",
                column: "ID_PKQ");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSuKien_ID_SK",
                table: "ChiTietSuKien",
                column: "ID_SK");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietXuat_ID_CPM_ID_PYC_ID_LM",
                table: "ChiTietXuat",
                columns: new[] { "ID_CPM", "ID_PYC", "ID_LM" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietXuat_ID_CPM_XUAT_ID_PKQ_XUAT",
                table: "ChiTietXuat",
                columns: new[] { "ID_CPM_XUAT", "ID_PKQ_XUAT" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietXuat_ID_TK",
                table: "ChiTietXuat",
                column: "ID_TK");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietYeuCau_ID_CPM",
                table: "ChiTietYeuCau",
                column: "ID_CPM");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietYeuCau_ID_LM",
                table: "ChiTietYeuCau",
                column: "ID_LM");

            migrationBuilder.CreateIndex(
                name: "IX_DiemHienMauCoDinh_ID_TK",
                table: "DiemHienMauCoDinh",
                column: "ID_TK");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKetQua_ID_LM",
                table: "PhieuKetQua",
                column: "ID_LM");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKetQua_ID_TK",
                table: "PhieuKetQua",
                column: "ID_TK");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuYeuCau_ID_BV",
                table: "PhieuYeuCau",
                column: "ID_BV");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuYeuCau_ID_TK",
                table: "PhieuYeuCau",
                column: "ID_TK");

            migrationBuilder.CreateIndex(
                name: "IX_SuKienHienMau_ID_TK",
                table: "SuKienHienMau",
                column: "ID_TK");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_ID_BV",
                table: "TaiKhoan",
                column: "ID_BV");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_ID_LTK",
                table: "TaiKhoan",
                column: "ID_LTK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDiaDiemHienMau");

            migrationBuilder.DropTable(
                name: "ChiTietSuDung");

            migrationBuilder.DropTable(
                name: "ChiTietSuKien");

            migrationBuilder.DropTable(
                name: "ChiTietXuat");

            migrationBuilder.DropTable(
                name: "DiemHienMauCoDinh");

            migrationBuilder.DropTable(
                name: "SuKienHienMau");

            migrationBuilder.DropTable(
                name: "LoaiTheTich");

            migrationBuilder.DropTable(
                name: "NguoiHienMau");

            migrationBuilder.DropTable(
                name: "ChiTietChePhamMau");

            migrationBuilder.DropTable(
                name: "ChiTietYeuCau");

            migrationBuilder.DropTable(
                name: "PhieuKetQua");

            migrationBuilder.DropTable(
                name: "ChePhamMau");

            migrationBuilder.DropTable(
                name: "PhieuYeuCau");

            migrationBuilder.DropTable(
                name: "LoaiMau");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "LoaiTaiKhoan");

            migrationBuilder.DropTable(
                name: "BenhVien");
        }
    }
}
