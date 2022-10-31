using System;

namespace BB_V1.Data
{
    public class ChiTietXuat
    {
        public int ID_CPM { get; set; }

        public int ID_LM { get; set; }

        public int ID_PYC { get; set; }

        public DateTime ThoiGianXuat { get; set; }

        // duoc xuat boi ai

        public Guid ID_TK { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        //xuat che pham mau nao
        public int ID_CPM_XUAT { get; set; }

        public int ID_PKQ_XUAT { get; set; }
        public ChiTietChePhamMau ChiTietChePhamMau { get; set; }
        public ChiTietYeuCau ChiTietYeuCau { get; set; }
    }
}