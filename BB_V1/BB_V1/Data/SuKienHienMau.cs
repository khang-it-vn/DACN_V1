using System;
using System.Collections.Generic;

namespace BB_V1.Data
{
    public class SuKienHienMau
    {
        public int ID_SK { get; set; }

        public string TenSK { get; set; }

        public string MoTa { get; set; }

        public DateTime ThoiGian_BD { get; set; }

        public DateTime ThoiGian_KT { get; set; }

        public string DCs { get; set; }

        public int TongSoLuongThamGia { get; set; }

        //
        public Guid ID_TK { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        //

        public List<ChiTietSuKien> ChiTietSuKiens { get; set; }
    }
}