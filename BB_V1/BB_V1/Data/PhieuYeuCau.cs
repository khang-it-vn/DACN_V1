using System;
using System.Collections.Generic;

namespace BB_V1.Data
{
    public class PhieuYeuCau
    {
        public int ID_PYC { get; set; }

        public DateTime ThoiGianYeuCau { get; set; }

        // duoc yeu cau boi ai
        public Guid ID_TK { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        // yeu cau den benh vien
        public int ID_BV { get; set; }

        public BenhVien BenhVien { get; set; }

        // co nhieu chi tiet phieu yeu cau
        public List<ChiTietYeuCau> ChiTietYeuCaus { get; set; }

    }
}