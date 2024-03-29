﻿// <auto-generated />
using System;
using BB_V1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BB_V1.Migrations
{
    [DbContext(typeof(DbBloodBank))]
    [Migration("20221110162332_editPKTableChiTietDiemHienMau")]
    partial class editPKTableChiTietDiemHienMau
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BB_V1.Data.BenhVien", b =>
                {
                    b.Property<int>("ID_BV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DC")
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TenBV")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID_BV");

                    b.ToTable("BenhVien");
                });

            modelBuilder.Entity("BB_V1.Data.ChePhamMau", b =>
                {
                    b.Property<int>("ID_CPM")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HSD")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenChePhamMau")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID_CPM");

                    b.ToTable("ChePhamMau");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietChePhamMau", b =>
                {
                    b.Property<int>("ID_CPM")
                        .HasColumnType("int");

                    b.Property<int>("ID_PKQ")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayLuuKho")
                        .HasColumnType("datetime2");

                    b.Property<float>("TheTich")
                        .HasColumnType("real");

                    b.Property<bool>("TrangThaiSuDung")
                        .HasColumnType("bit");

                    b.HasKey("ID_CPM", "ID_PKQ");

                    b.HasIndex("ID_PKQ");

                    b.ToTable("ChiTietChePhamMau");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietDiemHienMau", b =>
                {
                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ID_DC")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayHenHien")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ID_LTT")
                        .HasColumnType("int");

                    b.Property<int?>("ID_PKQ")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThaiHien")
                        .HasColumnType("bit");

                    b.HasKey("UID", "ID_DC", "NgayHenHien");

                    b.HasIndex("ID_DC");

                    b.HasIndex("ID_LTT");

                    b.HasIndex("ID_PKQ");

                    b.ToTable("ChiTietDiaDiemHienMau");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietSuDung", b =>
                {
                    b.Property<int>("ID_CPM")
                        .HasColumnType("int");

                    b.Property<int>("ID_PKQ")
                        .HasColumnType("int");

                    b.Property<Guid>("ID_TK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("TheTichSuDung")
                        .HasColumnType("real");

                    b.Property<DateTime>("ThoiGianSuDung")
                        .HasColumnType("datetime2");

                    b.HasKey("ID_CPM", "ID_PKQ", "ID_TK");

                    b.HasIndex("ID_TK");

                    b.ToTable("ChiTietSuDung");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietSuKien", b =>
                {
                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ID_SK")
                        .HasColumnType("int");

                    b.Property<int?>("ID_LTT")
                        .HasColumnType("int");

                    b.Property<int?>("ID_PKQ")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGian_DK")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TrangThaiHien")
                        .HasColumnType("bit");

                    b.HasKey("UID", "ID_SK");

                    b.HasIndex("ID_LTT");

                    b.HasIndex("ID_PKQ");

                    b.HasIndex("ID_SK");

                    b.ToTable("ChiTietSuKien");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietXuat", b =>
                {
                    b.Property<int>("ID_CPM")
                        .HasColumnType("int");

                    b.Property<int>("ID_LM")
                        .HasColumnType("int");

                    b.Property<int>("ID_PYC")
                        .HasColumnType("int");

                    b.Property<int>("ID_CPM_XUAT")
                        .HasColumnType("int");

                    b.Property<int>("ID_PKQ_XUAT")
                        .HasColumnType("int");

                    b.Property<Guid>("ID_TK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ThoiGianXuat")
                        .HasColumnType("datetime2");

                    b.HasKey("ID_CPM", "ID_LM", "ID_PYC", "ID_CPM_XUAT", "ID_PKQ_XUAT");

                    b.HasIndex("ID_TK");

                    b.HasIndex("ID_CPM_XUAT", "ID_PKQ_XUAT");

                    b.HasIndex("ID_CPM", "ID_PYC", "ID_LM");

                    b.ToTable("ChiTietXuat");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietYeuCau", b =>
                {
                    b.Property<int>("ID_PYC")
                        .HasColumnType("int");

                    b.Property<int>("ID_CPM")
                        .HasColumnType("int");

                    b.Property<int>("ID_LM")
                        .HasColumnType("int");

                    b.Property<float>("TheTich")
                        .HasColumnType("real");

                    b.HasKey("ID_PYC", "ID_CPM", "ID_LM");

                    b.HasIndex("ID_CPM");

                    b.HasIndex("ID_LM");

                    b.ToTable("ChiTietYeuCau");
                });

            modelBuilder.Entity("BB_V1.Data.DiemHienMauCoDinh", b =>
                {
                    b.Property<int>("ID_DC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DC")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("ID_TK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("SLNguoiThamGia")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGian_BD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGian_KT")
                        .HasColumnType("datetime2");

                    b.HasKey("ID_DC");

                    b.HasIndex("ID_TK");

                    b.ToTable("DiemHienMauCoDinh");
                });

            modelBuilder.Entity("BB_V1.Data.LoaiMau", b =>
                {
                    b.Property<int>("ID_LM")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoTa")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TenLoai")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID_LM");

                    b.ToTable("LoaiMau");
                });

            modelBuilder.Entity("BB_V1.Data.LoaiTaiKhoan", b =>
                {
                    b.Property<int>("ID_LTK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoTa")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TenLoai")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID_LTK");

                    b.ToTable("LoaiTaiKhoan");
                });

            modelBuilder.Entity("BB_V1.Data.LoaiTheTich", b =>
                {
                    b.Property<int>("ID_LTT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Diem")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TenLoai")
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID_LTT");

                    b.ToTable("LoaiTheTich");
                });

            modelBuilder.Entity("BB_V1.Data.NguoiHienMau", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DC")
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("HinhAnh")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("HoTen")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MatKhau")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SDT")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UID");

                    b.ToTable("NguoiHienMau");
                });

            modelBuilder.Entity("BB_V1.Data.PhieuKetQua", b =>
                {
                    b.Property<int>("ID_PKQ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChuanDoan")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FileKetQua")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ID_LM")
                        .HasColumnType("int");

                    b.Property<Guid>("ID_TK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ThoiGianCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TrangThaiBaoQuan")
                        .HasColumnType("bit");

                    b.HasKey("ID_PKQ");

                    b.HasIndex("ID_LM");

                    b.HasIndex("ID_TK");

                    b.ToTable("PhieuKetQua");
                });

            modelBuilder.Entity("BB_V1.Data.PhieuYeuCau", b =>
                {
                    b.Property<int>("ID_PYC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ID_BV")
                        .HasColumnType("int");

                    b.Property<Guid>("ID_TK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ThoiGianYeuCau")
                        .HasColumnType("datetime2");

                    b.HasKey("ID_PYC");

                    b.HasIndex("ID_BV");

                    b.HasIndex("ID_TK");

                    b.ToTable("PhieuYeuCau");
                });

            modelBuilder.Entity("BB_V1.Data.SuKienHienMau", b =>
                {
                    b.Property<int>("ID_SK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DCs")
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(300)");

                    b.Property<Guid>("ID_TK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasMaxLength(2000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("TenSK")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ThoiGian_BD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGian_KT")
                        .HasColumnType("datetime2");

                    b.Property<int>("TongSoLuongThamGia")
                        .HasColumnType("int");

                    b.HasKey("ID_SK");

                    b.HasIndex("ID_TK");

                    b.ToTable("SuKienHienMau");
                });

            modelBuilder.Entity("BB_V1.Data.TaiKhoan", b =>
                {
                    b.Property<Guid>("ID_TK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DC")
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ID_BV")
                        .HasColumnType("int");

                    b.Property<int>("ID_LTK")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("NgayCap")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID_TK");

                    b.HasIndex("ID_BV");

                    b.HasIndex("ID_LTK");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietChePhamMau", b =>
                {
                    b.HasOne("BB_V1.Data.ChePhamMau", "ChePhamMau")
                        .WithMany("ChiTietChePhamMaus")
                        .HasForeignKey("ID_CPM")
                        .HasConstraintName("FK_CHITIETCHEPHAMMAU_CHEPHAMMAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.PhieuKetQua", "PhieuKetQua")
                        .WithMany("ChiTietChePhamMaus")
                        .HasForeignKey("ID_PKQ")
                        .HasConstraintName("FK_PHIEUKETQUA_CHITIETCHEPHAMMAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChePhamMau");

                    b.Navigation("PhieuKetQua");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietDiemHienMau", b =>
                {
                    b.HasOne("BB_V1.Data.DiemHienMauCoDinh", "DiemHienMauCoDinh")
                        .WithMany("ChiTietDiemHienMaus")
                        .HasForeignKey("ID_DC")
                        .HasConstraintName("FK_CHITIETDIEMHIENMAU_DIACHICODINH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.LoaiTheTich", "LoaiTheTich")
                        .WithMany("ChiTietDiemHienMaus")
                        .HasForeignKey("ID_LTT")
                        .HasConstraintName("FK_CHITIETDIEMHIENMAU_LOAITHETICH");

                    b.HasOne("BB_V1.Data.PhieuKetQua", "PhieuKetQua")
                        .WithMany("ChiTietDiemHienMaus")
                        .HasForeignKey("ID_PKQ")
                        .HasConstraintName("FK_CHITIETDIEMHIENMAU_PHIEUKETQUA")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("BB_V1.Data.NguoiHienMau", "NguoiHienMau")
                        .WithMany("ChiTietDiemHienMaus")
                        .HasForeignKey("UID")
                        .HasConstraintName("FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiemHienMauCoDinh");

                    b.Navigation("LoaiTheTich");

                    b.Navigation("NguoiHienMau");

                    b.Navigation("PhieuKetQua");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietSuDung", b =>
                {
                    b.HasOne("BB_V1.Data.TaiKhoan", "TaiKhoan")
                        .WithMany("ChiTietSuDungs")
                        .HasForeignKey("ID_TK")
                        .HasConstraintName("FK_CHITIETSUDUNG_TAIKHOAN")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.ChiTietChePhamMau", "ChiTietChePhamMau")
                        .WithMany("ChiTietSuDungs")
                        .HasForeignKey("ID_CPM", "ID_PKQ")
                        .HasConstraintName("FK_CHITIETSUDUNG_CHITIETCHEPHAMMAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChiTietChePhamMau");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietSuKien", b =>
                {
                    b.HasOne("BB_V1.Data.LoaiTheTich", "LoaiTheTich")
                        .WithMany("ChiTietSuKiens")
                        .HasForeignKey("ID_LTT")
                        .HasConstraintName("FK_LOAITHETICH_CHITIETSUKIEN");

                    b.HasOne("BB_V1.Data.PhieuKetQua", "PhieuKetQua")
                        .WithMany("ChiTietSuKiens")
                        .HasForeignKey("ID_PKQ")
                        .HasConstraintName("FK_CHITIETSUKIEN_KETQUAMAU");

                    b.HasOne("BB_V1.Data.SuKienHienMau", "SuKienHienMau")
                        .WithMany("ChiTietSuKiens")
                        .HasForeignKey("ID_SK")
                        .HasConstraintName("FK_CHITIETSUKIEN_SUKIENHIENMAU")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.NguoiHienMau", "NguoiHienMau")
                        .WithMany("ChiTietSuKiens")
                        .HasForeignKey("UID")
                        .HasConstraintName("FK_NGUOIHIENMAU_CHITIETSUKIEN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiTheTich");

                    b.Navigation("NguoiHienMau");

                    b.Navigation("PhieuKetQua");

                    b.Navigation("SuKienHienMau");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietXuat", b =>
                {
                    b.HasOne("BB_V1.Data.TaiKhoan", "TaiKhoan")
                        .WithMany("ChiTietXuats")
                        .HasForeignKey("ID_TK")
                        .HasConstraintName("FK_TAIKHOAN_CHTIETXUAT")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.ChiTietChePhamMau", "ChiTietChePhamMau")
                        .WithMany("ChiTietXuats")
                        .HasForeignKey("ID_CPM_XUAT", "ID_PKQ_XUAT")
                        .HasConstraintName("FK_CHITIETXUAT_CHEPHAMMAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.ChiTietYeuCau", "ChiTietYeuCau")
                        .WithMany("ChiTietXuats")
                        .HasForeignKey("ID_CPM", "ID_PYC", "ID_LM")
                        .HasConstraintName("FK_CHITIETXUAT_CHITIETCHEPHAMMAU")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChiTietChePhamMau");

                    b.Navigation("ChiTietYeuCau");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietYeuCau", b =>
                {
                    b.HasOne("BB_V1.Data.ChePhamMau", "ChePhamMau")
                        .WithMany("ChiTietYeuCaus")
                        .HasForeignKey("ID_CPM")
                        .HasConstraintName("FK_CHITIETYEUCAU_CHEPHAMMAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.LoaiMau", "LoaiMau")
                        .WithMany("ChiTietYeuCaus")
                        .HasForeignKey("ID_LM")
                        .HasConstraintName("FK_LOAIMAU_CHITIETYEUCAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.PhieuYeuCau", "PhieuYeuCau")
                        .WithMany("ChiTietYeuCaus")
                        .HasForeignKey("ID_PYC")
                        .HasConstraintName("FK_CHITIETYEUCAU_PHIEUYEUCAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChePhamMau");

                    b.Navigation("LoaiMau");

                    b.Navigation("PhieuYeuCau");
                });

            modelBuilder.Entity("BB_V1.Data.DiemHienMauCoDinh", b =>
                {
                    b.HasOne("BB_V1.Data.TaiKhoan", "TaiKhoan")
                        .WithMany("DiemHienMauCoDinhs")
                        .HasForeignKey("ID_TK")
                        .HasConstraintName("FK_DIEMHIENMAUCODINH_TAIKHOAN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("BB_V1.Data.PhieuKetQua", b =>
                {
                    b.HasOne("BB_V1.Data.LoaiMau", "LoaiMau")
                        .WithMany("PhieuKetQuas")
                        .HasForeignKey("ID_LM")
                        .HasConstraintName("FK_PHIEUKETQUA_LOAIMAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.TaiKhoan", "TaiKhoan")
                        .WithMany("PhieuKetQuas")
                        .HasForeignKey("ID_TK")
                        .HasConstraintName("FK_PHIEUKETQUA_TAIKHOAN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiMau");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("BB_V1.Data.PhieuYeuCau", b =>
                {
                    b.HasOne("BB_V1.Data.BenhVien", "BenhVien")
                        .WithMany("PhieuYeuCaus")
                        .HasForeignKey("ID_BV")
                        .HasConstraintName("FK_PHIEUYEUCAU_BENHVIEN")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.TaiKhoan", "TaiKhoan")
                        .WithMany("PhieuYeuCaus")
                        .HasForeignKey("ID_TK")
                        .HasConstraintName("FK_PHIEUYEUCAU_TAIKHOAN")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BenhVien");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("BB_V1.Data.SuKienHienMau", b =>
                {
                    b.HasOne("BB_V1.Data.TaiKhoan", "TaiKhoan")
                        .WithMany("SuKienHienMaus")
                        .HasForeignKey("ID_TK")
                        .HasConstraintName("FK_SUKIENHIENMAU_TAIKHOAN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("BB_V1.Data.TaiKhoan", b =>
                {
                    b.HasOne("BB_V1.Data.BenhVien", "BenhVien")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("ID_BV")
                        .HasConstraintName("FK_TAIKHOAN_BENHVIEN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BB_V1.Data.LoaiTaiKhoan", "LoaiTaiKhoan")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("ID_LTK")
                        .HasConstraintName("FK_LOAITAIKHOAN_TAIKHOAN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BenhVien");

                    b.Navigation("LoaiTaiKhoan");
                });

            modelBuilder.Entity("BB_V1.Data.BenhVien", b =>
                {
                    b.Navigation("PhieuYeuCaus");

                    b.Navigation("TaiKhoans");
                });

            modelBuilder.Entity("BB_V1.Data.ChePhamMau", b =>
                {
                    b.Navigation("ChiTietChePhamMaus");

                    b.Navigation("ChiTietYeuCaus");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietChePhamMau", b =>
                {
                    b.Navigation("ChiTietSuDungs");

                    b.Navigation("ChiTietXuats");
                });

            modelBuilder.Entity("BB_V1.Data.ChiTietYeuCau", b =>
                {
                    b.Navigation("ChiTietXuats");
                });

            modelBuilder.Entity("BB_V1.Data.DiemHienMauCoDinh", b =>
                {
                    b.Navigation("ChiTietDiemHienMaus");
                });

            modelBuilder.Entity("BB_V1.Data.LoaiMau", b =>
                {
                    b.Navigation("ChiTietYeuCaus");

                    b.Navigation("PhieuKetQuas");
                });

            modelBuilder.Entity("BB_V1.Data.LoaiTaiKhoan", b =>
                {
                    b.Navigation("TaiKhoans");
                });

            modelBuilder.Entity("BB_V1.Data.LoaiTheTich", b =>
                {
                    b.Navigation("ChiTietDiemHienMaus");

                    b.Navigation("ChiTietSuKiens");
                });

            modelBuilder.Entity("BB_V1.Data.NguoiHienMau", b =>
                {
                    b.Navigation("ChiTietDiemHienMaus");

                    b.Navigation("ChiTietSuKiens");
                });

            modelBuilder.Entity("BB_V1.Data.PhieuKetQua", b =>
                {
                    b.Navigation("ChiTietChePhamMaus");

                    b.Navigation("ChiTietDiemHienMaus");

                    b.Navigation("ChiTietSuKiens");
                });

            modelBuilder.Entity("BB_V1.Data.PhieuYeuCau", b =>
                {
                    b.Navigation("ChiTietYeuCaus");
                });

            modelBuilder.Entity("BB_V1.Data.SuKienHienMau", b =>
                {
                    b.Navigation("ChiTietSuKiens");
                });

            modelBuilder.Entity("BB_V1.Data.TaiKhoan", b =>
                {
                    b.Navigation("ChiTietSuDungs");

                    b.Navigation("ChiTietXuats");

                    b.Navigation("DiemHienMauCoDinhs");

                    b.Navigation("PhieuKetQuas");

                    b.Navigation("PhieuYeuCaus");

                    b.Navigation("SuKienHienMaus");
                });
#pragma warning restore 612, 618
        }
    }
}
