using System.Collections.Generic;

namespace BB_V1.Data
{
    public class ChiTietYeuCau
    {
        public int ID_PYC { get; set; }

        public float TheTich { get; set; }

        // che pham mau nao
        public int ID_CPM { get; set; }

        public ChePhamMau ChePhamMau { get; set; }

        // loai mau nao

        public int ID_LM { get; set; }
        public LoaiMau LoaiMau { get; set; }
        // yeu cau nao
        public PhieuYeuCau PhieuYeuCau { get; set; }
        public List<ChiTietXuat> ChiTietXuats { get; set; }
    }
}