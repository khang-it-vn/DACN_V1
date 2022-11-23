using System;
using System.Collections.Generic;

namespace BB_V1.Data
{
    public class NguoiHienMau : Person
    {
        public Guid UID { get; set; }

        public string HoTen { get; set; }

        public string HinhAnh { get; set; }

        public int DiemHienMau { get; set; }

        public List<ChiTietSuKien> ChiTietSuKiens { get; set; }
        public List<ChiTietDiemHienMau> ChiTietDiemHienMaus { get; set; }

        public List<ChiTietDoiQua> ChiTietDoiQuas { get; set; }
    }
}
