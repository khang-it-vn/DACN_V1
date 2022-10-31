using Microsoft.EntityFrameworkCore;

namespace BB_V1.Data
{
    public class DbBloodBank : DbContext
    {
        public DbBloodBank(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<NguoiHienMau> NguoiHienMaus { get; set; }   
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<BenhVien> BenhViens { get; set; }
        public DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }
        public DbSet<SuKienHienMau> SuKienHienMaus { get; set; }
        public DbSet<ChiTietSuKien> ChiTietSuKiens { get; set; }
        public DbSet<LoaiTheTich> LoaiTheTichs { get; set; }
        public DbSet<PhieuKetQua> PhieuKetQuas { get; set; }
        public DbSet<LoaiMau> LoaiMaus { get; set; }
        public DbSet<ChePhamMau> ChePhamMaus { get; set; }
        public DbSet<ChiTietChePhamMau> ChiTietChePhamMaus { get; set; }
        public DbSet<ChiTietSuDung> ChiTietSuDungs { get; set; }
        public DbSet<PhieuYeuCau> PhieuYeuCaus { get; set; }
        public DbSet<ChiTietYeuCau> ChiTietYeuCaus { get; set; }
        public DbSet<ChiTietXuat> ChiTietXuats { get; set; }
        public DbSet<DiemHienMauCoDinh> DiemHienMauCoDinhs { get; set; }
        public DbSet<ChiTietDiemHienMau> ChiTietDiemHienMaus { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiHienMau>(nguoihienmau =>
            {
                nguoihienmau.ToTable("NguoiHienMau");
                nguoihienmau.HasKey(nhm => new { nhm.UID });
                nguoihienmau.Property(nhm => nhm.HoTen).HasMaxLength(50).IsUnicode();
                nguoihienmau.Property(nhm => nhm.Username).HasMaxLength(50);
                nguoihienmau.Property(nhm => nhm.MatKhau).HasMaxLength(200);
                nguoihienmau.Property(nhm => nhm.SDT).HasMaxLength(13);
                nguoihienmau.Property(nhm => nhm.Email).HasMaxLength(150);
                nguoihienmau.Property(nhm => nhm.HinhAnh).HasMaxLength(150);
                nguoihienmau.Property(nhm => nhm.DC).HasMaxLength(150).IsUnicode();

            });

            modelBuilder.Entity<LoaiTheTich>(loaithetich =>
            {
                loaithetich.ToTable("LoaiTheTich");
                loaithetich.HasKey(ltt => new { ltt.ID_LTT });
                loaithetich.Property(ltt => ltt.TenLoai).HasMaxLength(150).IsUnicode();
                loaithetich.Property(ltt => ltt.MoTa).HasMaxLength(500).IsUnicode();
            });

            modelBuilder.Entity<LoaiMau>(loaimau =>
            {
                loaimau.ToTable("LoaiMau");
                loaimau.HasKey(lm => new { lm.ID_LM });
                loaimau.Property(l => l.TenLoai).HasMaxLength(100).IsUnicode();
                loaimau.Property(l => l.MoTa).HasMaxLength(500).IsUnicode();
            });

            modelBuilder.Entity<ChePhamMau>(chephammau =>
            {
                chephammau.ToTable("ChePhamMau");
                chephammau.HasKey(cpm => cpm.ID_CPM);
                chephammau.Property(cpm => cpm.TenChePhamMau).HasMaxLength(100).IsUnicode(true);
                chephammau.Property(cpm => cpm.MoTa).HasMaxLength(100).IsUnicode();

            });

            modelBuilder.Entity<LoaiTaiKhoan>(loaitaikhoan =>
            {
                loaitaikhoan.ToTable("LoaiTaiKhoan");
                loaitaikhoan.HasKey(ltk => ltk.ID_LTK);
                loaitaikhoan.Property(ltk => ltk.TenLoai).HasMaxLength(100).IsUnicode();
                loaitaikhoan.Property(ltk => ltk.MoTa).HasMaxLength(500).IsUnicode();
            });

            modelBuilder.Entity<BenhVien>(benhvien =>
            {
                benhvien.ToTable("BenhVien");
                benhvien.HasKey(bv => bv.ID_BV);
                benhvien.Property (bv => bv.TenBV).HasMaxLength(100).IsUnicode();
                benhvien.Property (bv => bv.DC).HasMaxLength(150).IsUnicode();
            });

            // config_TaiKhoan
            modelBuilder.Entity<TaiKhoan>(taikhoan =>
            {
                taikhoan.ToTable("TaiKhoan");
                taikhoan.HasKey(tk => tk.ID_TK);
                taikhoan.Property(tk => tk.Username).HasMaxLength(50);
                taikhoan.Property(tk => tk.MatKhau).HasMaxLength(200);
                taikhoan.Property(tk => tk.SDT).HasMaxLength(13);
                taikhoan.Property(tk => tk.Email).HasMaxLength(150);
                taikhoan.Property(tk => tk.DC).HasMaxLength(150).IsUnicode();

                // thuoc benh vien
                taikhoan.HasOne(tk => tk.BenhVien)
                .WithMany(tk => tk.TaiKhoans)
                .HasForeignKey(tk => tk.ID_BV)
                .HasConstraintName("FK_TAIKHOAN_BENHVIEN");
                // thuoc loai tai khoan
                taikhoan.HasOne(tk => tk.LoaiTaiKhoan)
                .WithMany(tk => tk.TaiKhoans)
                .HasForeignKey(tk => tk.ID_LTK)
                .HasConstraintName("FK_LOAITAIKHOAN_TAIKHOAN");

            });

            //su kien hien mau
            modelBuilder.Entity<SuKienHienMau>(sukienhienmau =>
            {
                sukienhienmau.ToTable("SuKienHienMau");
                sukienhienmau.HasKey(sk => sk.ID_SK);
                sukienhienmau.Property(sk => sk.TenSK).HasMaxLength(100).IsUnicode();
                sukienhienmau.Property(sk => sk.MoTa).HasMaxLength(2000).IsUnicode(true);
                sukienhienmau.Property(sk => sk.DCs).HasMaxLength(300).IsUnicode();

                // do bac si to chuc
                sukienhienmau.HasOne(sk => sk.TaiKhoan)
                .WithMany(sk => sk.SuKienHienMaus)
                .HasForeignKey(sk => sk.ID_TK)
                .HasConstraintName("FK_SUKIENHIENMAU_TAIKHOAN");
            });

            // dia diem hien mau co dinh
            modelBuilder.Entity<DiemHienMauCoDinh>(diemhienmaucodinh =>
            {
                diemhienmaucodinh.ToTable("DiemHienMauCoDinh");
                diemhienmaucodinh.HasKey(dhm => dhm.ID_DC);
                diemhienmaucodinh.Property(dhm => dhm.DC).HasMaxLength(100).IsUnicode();
                diemhienmaucodinh.Property(dhm => dhm.MoTa).HasMaxLength(500).IsUnicode();

                // do ai tao ra
                diemhienmaucodinh.HasOne(dhm => dhm.TaiKhoan)
                .WithMany(dhm => dhm.DiemHienMauCoDinhs)
                .HasForeignKey(dhm => dhm.ID_TK)
                .HasConstraintName("FK_DIEMHIENMAUCODINH_TAIKHOAN");
            });

            //chi tiet su kien hien mau
            modelBuilder.Entity<ChiTietSuKien>(chitietsukien =>
            {
                chitietsukien.ToTable("ChiTietSuKien");
                chitietsukien.HasKey(ct => new { ct.UID, ct.ID_SK });

                // do ai dang ky
                chitietsukien.HasOne(ct => ct.NguoiHienMau)
                .WithMany(ct => ct.ChiTietSuKiens)
                .HasForeignKey(ct => ct.UID)
                .HasConstraintName("FK_NGUOIHIENMAU_CHITIETSUKIEN");

                // dang ky su kien nao
                chitietsukien.HasOne(ct => ct.SuKienHienMau)
                .WithMany(ct => ct.ChiTietSuKiens)
                .HasForeignKey(ct => ct.ID_SK)
                .HasConstraintName("FK_CHITIETSUKIEN_SUKIENHIENMAU").OnDelete(DeleteBehavior.NoAction);

                // dang ky loai the tich nao
                chitietsukien.HasOne(ct => ct.LoaiTheTich)
                .WithMany(ct => ct.ChiTietSuKiens)
                .HasForeignKey(ct => ct.ID_LTT)
                .HasConstraintName("FK_LOAITHETICH_CHITIETSUKIEN");

                //Co ket qua mau
                chitietsukien.HasOne(ct => ct.PhieuKetQua)
                .WithMany(ct => ct.ChiTietSuKiens)
                .HasForeignKey(ct => ct.ID_PKQ)
                .HasConstraintName("FK_CHITIETSUKIEN_KETQUAMAU");
                
            });

            modelBuilder.Entity<ChiTietDiemHienMau>(ctddhm =>
            {
                ctddhm.ToTable("ChiTietDiaDiemHienMau");
                ctddhm.HasKey(ct => new { ct.UID, ct.ID_DC });

                //duoc dang ky boi ai
                ctddhm.HasOne(ct => ct.NguoiHienMau)
                .WithMany(ct => ct.ChiTietDiemHienMaus)
                .HasForeignKey(ct => ct.UID)
                .HasForeignKey("FK_CHITIETDIEMHIENMAU_NGUOIHIENMAU");

                // dang ky diem hine mau nao
                ctddhm.HasOne(ct => ct.DiemHienMauCoDinh)
                .WithMany(ct => ct.ChiTietDiemHienMaus)
                .HasForeignKey(ct => ct.ID_DC)
                .HasConstraintName("FK_CHITIETDIEMHIENMAU_DIACHICODINH");


                // Dang ky loai the tich nao
                ctddhm.HasOne(ct => ct.LoaiTheTich)
                .WithMany(ct => ct.ChiTietDiemHienMaus)
                .HasForeignKey(ct => ct.ID_LTT)
                .HasConstraintName("FK_CHITIETDIEMHIENMAU_LOAITHETICH");

                // co ket qua mau
                ctddhm.HasOne(ct => ct.PhieuKetQua)
                .WithMany(ct => ct.ChiTietDiemHienMaus)
                .HasForeignKey(ct => ct.ID_PKQ)
                .HasConstraintName("FK_CHITIETDIEMHIENMAU_PHIEUKETQUA").OnDelete(DeleteBehavior.NoAction);
            });

            //Phieu ket qua
            modelBuilder.Entity<PhieuKetQua>(phieuketqua =>
            {
                phieuketqua.ToTable("PhieuKetQua");
                phieuketqua.HasKey(pkq => pkq.ID_PKQ);
                phieuketqua.Property(pkq => pkq.FileKetQua).HasMaxLength(100);
                phieuketqua.Property(pkq => pkq.ChuanDoan).HasMaxLength(500).IsUnicode();

                //do ai cap nhat
                phieuketqua.HasOne(pkq => pkq.TaiKhoan)
                .WithMany(pkq => pkq.PhieuKetQuas)
                .HasForeignKey(pkq => pkq.ID_TK)
                .HasConstraintName("FK_PHIEUKETQUA_TAIKHOAN");

                // thuoc loai mau nao
                phieuketqua.HasOne(pkq => pkq.LoaiMau)
                .WithMany(pkq => pkq.PhieuKetQuas)
                .HasForeignKey(pkq => pkq.ID_LM)
                .HasConstraintName("FK_PHIEUKETQUA_LOAIMAU");

            });

            // phieu yeu cau
            modelBuilder.Entity<PhieuYeuCau>(phieuyeucau =>
            {
                phieuyeucau.ToTable("PhieuYeuCau");
                phieuyeucau.HasKey(pyc => pyc.ID_PYC);

                //do ai tao ra
                phieuyeucau.HasOne(pyc => pyc.TaiKhoan)
                .WithMany(pyc => pyc.PhieuYeuCaus)
                .HasForeignKey(pyc => pyc.ID_TK).OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_PHIEUYEUCAU_TAIKHOAN");
                // yeu cau gui den ai
                phieuyeucau.HasOne(pyc => pyc.BenhVien)
                .WithMany(pyc => pyc.PhieuYeuCaus).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(pyc => pyc.ID_BV).HasConstraintName("FK_PHIEUYEUCAU_BENHVIEN");
            });

            // chi tiet che pham mau
            modelBuilder.Entity<ChiTietChePhamMau>(chitietchephammau =>
            {
                chitietchephammau.ToTable("ChiTietChePhamMau");
                chitietchephammau.HasKey(ct => new {ct.ID_CPM, ct.ID_PKQ});

                //mau nao
                chitietchephammau.HasOne(ct => ct.PhieuKetQua)
                .WithMany(ct => ct.ChiTietChePhamMaus)
                .HasForeignKey(ct => ct.ID_PKQ)
                .HasConstraintName("FK_PHIEUKETQUA_CHITIETCHEPHAMMAU");

                // thuoc che pham mau nao

                chitietchephammau.HasOne(ct => ct.ChePhamMau)
                .WithMany(ct => ct.ChiTietChePhamMaus)
                .HasForeignKey(ct => ct.ID_CPM)
                .HasConstraintName("FK_CHITIETCHEPHAMMAU_CHEPHAMMAU");
                
            });

            // chi tiet su dung
            modelBuilder.Entity<ChiTietSuDung>(chittietsudung => {
                chittietsudung.ToTable("ChiTietSuDung");
                chittietsudung.HasKey(ct => new { ct.ID_CPM, ct.ID_PKQ, ct.ID_TK });

                // su dung tui mau nao
                chittietsudung.HasOne(ct => ct.ChiTietChePhamMau)
                .WithMany(ct => ct.ChiTietSuDungs)
                .HasForeignKey(ct => new { ct.ID_CPM, ct.ID_PKQ })
                .HasConstraintName("FK_CHITIETSUDUNG_CHITIETCHEPHAMMAU");

                // do ai su dung
                chittietsudung.HasOne(ct => ct.TaiKhoan)
                .WithMany(ct => ct.ChiTietSuDungs)
                .HasForeignKey(ct => ct.ID_TK)
                .HasConstraintName("FK_CHITIETSUDUNG_TAIKHOAN").OnDelete(DeleteBehavior.NoAction);
                
            });

            modelBuilder.Entity<ChiTietYeuCau>(chitietyeucau =>
            {
                chitietyeucau.ToTable("ChiTietYeuCau");
                chitietyeucau.HasKey(ct => new { ct.ID_PYC, ct.ID_CPM, ct.ID_LM });

                chitietyeucau.HasOne(ct => ct.PhieuYeuCau)
                .WithMany(ct => ct.ChiTietYeuCaus)
                .HasForeignKey(ct => ct.ID_PYC)
                .HasConstraintName("FK_CHITIETYEUCAU_PHIEUYEUCAU");

                chitietyeucau.HasOne(ct => ct.ChePhamMau)
                .WithMany(ct => ct.ChiTietYeuCaus)
                .HasForeignKey(ct => ct.ID_CPM)
                .HasConstraintName("FK_CHITIETYEUCAU_CHEPHAMMAU");

                chitietyeucau.HasOne(ct => ct.LoaiMau)
                .WithMany(ct => ct.ChiTietYeuCaus)
                .HasForeignKey(ct => ct.ID_LM)
                .HasConstraintName("FK_LOAIMAU_CHITIETYEUCAU");

            });

            modelBuilder.Entity<ChiTietXuat>(ct =>
            {
                ct.ToTable("ChiTietXuat");
                ct.HasKey(c => new { c.ID_CPM, c.ID_LM, c.ID_PYC, c.ID_CPM_XUAT, c.ID_PKQ_XUAT});
                // che pham mau nao
                ct.HasOne(c => c.ChiTietChePhamMau)
                 .WithMany(c => c.ChiTietXuats)
                 .HasForeignKey(c => new { c.ID_CPM_XUAT, c.ID_PKQ_XUAT })
                 .HasConstraintName("FK_CHITIETXUAT_CHEPHAMMAU");
                // phieu yeu cau nao
                ct.HasOne(c => c.ChiTietYeuCau)
                .WithMany(c => c.ChiTietXuats)
                .HasForeignKey(c => new { c.ID_CPM, c.ID_PYC, c.ID_LM})
                .HasConstraintName("FK_CHITIETXUAT_CHITIETCHEPHAMMAU").OnDelete(DeleteBehavior.NoAction);

                // do ai xuat
                ct.HasOne(c => c.TaiKhoan)
                .WithMany(c => c.ChiTietXuats)
                .HasForeignKey(c => c.ID_TK)
                .HasConstraintName("FK_TAIKHOAN_CHTIETXUAT").OnDelete(DeleteBehavior.NoAction);
            });


        }
    }
}
