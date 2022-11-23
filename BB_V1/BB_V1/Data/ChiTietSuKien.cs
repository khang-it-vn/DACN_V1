using System;

namespace BB_V1.Data
{
    public class ChiTietSuKien
    {
        public Guid UID { get; set; }

        public int ID_SK { get; set; }

        public bool TrangThaiHien { get; set; }

        public DateTime ThoiGian_DK { get; set; }

        //
        public SuKienHienMau SuKienHienMau { get; set; }

        public NguoiHienMau NguoiHienMau { get; set; }

        // the tich dang ky

        public int? ID_LTT { get; set; }

        public LoaiTheTich LoaiTheTich { get; set; }
        
        // ket qua mau
        public int? ID_PKQ { get; set; }

        public PhieuKetQua PhieuKetQua { get; set; }
    
    }
}