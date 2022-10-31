using System.Collections.Generic;

namespace BB_V1.Data
{
    public class BenhVien
    {
        public int ID_BV { get; set; }

        public string TenBV { get; set; }

        public string DC { get; set; }

        public List<TaiKhoan> TaiKhoans { get; set; }

        public List<PhieuYeuCau> PhieuYeuCaus { get; set; }
    }
}
