using System;

namespace BB_V1.Data
{
    public class ChiTietDiemHienMau
    {
        public int ID_DC { get; set; }

        public Guid UID { get; set; }

        public DateTime NgayHenHien { get; set; }

        public bool TrangThaiHien { get; set; }

        // n - n
        public NguoiHienMau NguoiHienMau { get; set; }

        public DiemHienMauCoDinh DiemHienMauCoDinh { get; set; }

        // loai the tich
        public int ID_LTT { get; set; }
        public LoaiTheTich LoaiTheTich { get; set; }

        // ket qua

        public int ID_PKQ { get; set; }

        public PhieuKetQua PhieuKetQua { get; set; }
    }
}