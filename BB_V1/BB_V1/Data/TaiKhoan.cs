using System;
using System.Collections.Generic;

namespace BB_V1.Data
{
    public class TaiKhoan: Person
    {
        public Guid ID_TK { get; set; } 

        public DateTime NgayCap { get; set; }

        public bool TrangThai { get; set; }

        //
        public int ID_BV { get; set; }

        public BenhVien BenhVien { get; set; }

        public int ID_LTK { get; set; }

        public LoaiTaiKhoan LoaiTaiKhoan { get; set; }


        // tao su kien hien mau nao
        public List<SuKienHienMau> SuKienHienMaus { get; set; }
        
        // thiet lap nhung dia diem hien mau nao
        public List<DiemHienMauCoDinh> DiemHienMauCoDinhs { get; set; }
        
        // da cong bo ket qua mau cho nhung ai
        public List<PhieuKetQua> PhieuKetQuas { get; set; }

        // da su dung nhung bich mau nao

        public List<ChiTietSuDung> ChiTietSuDungs { get; set; }

        //da co nhung yeu cau nau
        public List<PhieuYeuCau> PhieuYeuCaus { get; set; }

        //da xuat loai mau nao
        public List<ChiTietXuat> ChiTietXuats { get; set; }

    }
}