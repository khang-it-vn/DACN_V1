using System.Collections.Generic;

namespace BB_V1.Data
{
    public class LoaiTaiKhoan
    {
        public int ID_LTK { get; set; }

        public string TenLoai { get; set; }

        public string MoTa { get; set; }

        public List<TaiKhoan> TaiKhoans { get; set; }
    }
}
