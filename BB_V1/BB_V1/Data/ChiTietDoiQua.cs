using System;

namespace BB_V1.Data
{
    public class ChiTietDoiQua
    {
        public Guid UID { get; set; }
        public int ID_QUA { get; set; }

        public int SoDiemLucDoi {  get; set; }

        public int SoLuongDoi { get; set; }

        public DateTime ThoiGianDoi { get; set; }

        public NguoiHienMau NguoiHienMau { get; set; }

        public Qua Qua { get; set; }
    }
}
