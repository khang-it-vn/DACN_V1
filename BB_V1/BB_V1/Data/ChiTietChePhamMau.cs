using System;
using System.Collections.Generic;

namespace BB_V1.Data
{
    public class ChiTietChePhamMau
    {
        public int ID_CPM { get; set; }

        public int ID_PKQ { get; set; }

        public DateTime NgayLuuKho { get; set; }

        public float TheTich { get; set; }

        //cho biết máu còn sử dụng được hay là không
        public bool TrangThaiSuDung { get; set; }

        // cha nos
        public PhieuKetQua PhieuKetQua { get; set; }

        public ChePhamMau ChePhamMau { get; set; }

        // Chi tiet su dung boi ai
        public List<ChiTietSuDung> ChiTietSuDungs { get; set; }
        // chi tiet xuat di boi ai

        public List<ChiTietXuat> ChiTietXuats { get; set; }
    }
}