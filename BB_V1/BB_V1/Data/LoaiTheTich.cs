using System.Collections.Generic;

namespace BB_V1.Data
{
    public class LoaiTheTich
    {
        public int ID_LTT { get; set; }

        public string TenLoai { get; set; }

        public string MoTa { get; set; }

        public int Diem { get; set; }

        //
        public List<ChiTietSuKien> ChiTietSuKiens { get; set; }

        public List<ChiTietDiemHienMau> ChiTietDiemHienMaus { get; set; }
    }
}