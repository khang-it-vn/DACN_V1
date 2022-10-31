using System;
using System.Collections.Generic;

namespace BB_V1.Data
{
    public class DiemHienMauCoDinh
    {
        public int ID_DC { get; set; }

        public string DC { get; set; }

        public string MoTa { get; set; }

        public DateTime ThoiGian_BD { get; set; }

        public DateTime ThoiGian_KT { get; set; }

        // tai khoan
        public Guid ID_TK { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        // chi tiet diem hien mau
        public List<ChiTietDiemHienMau> ChiTietDiemHienMaus { get; set; }
    }
}