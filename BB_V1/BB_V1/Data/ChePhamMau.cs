using System.Collections.Generic;

namespace BB_V1.Data
{
    public class ChePhamMau
    {
        public int ID_CPM { get; set; }

        public string TenChePhamMau { get; set; }
        public string MoTa { get; set; }
        public int HSD { get; set; }
        //co nhieu yeu cau
        public List<ChiTietYeuCau> ChiTietYeuCaus { get; set; }
        // co nhieu trong che pham mau

        public List<ChiTietChePhamMau> ChiTietChePhamMaus { get; set; }
    }
}
