using System;

namespace BB_V1.Data
{
    public class ChiTietSuDung
    {
        public int ID_CPM { get; set; }

        public int ID_PKQ { get; set; }

        public Guid ID_TK { get; set; }

        public DateTime ThoiGianSuDung { get; set; }

        public float TheTichSuDung { get; set; }

        // tu bich mau nao

        public ChiTietChePhamMau ChiTietChePhamMau { get; set; }
        // ai lay
        public TaiKhoan TaiKhoan { get; set; }
    }
}