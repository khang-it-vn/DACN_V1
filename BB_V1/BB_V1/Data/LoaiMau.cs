using System.Collections.Generic;

namespace BB_V1.Data
{
    public class LoaiMau
    {
        public int ID_LM { get; set; }
        public string TenLoai { get; set; }

        public string MoTa { get; set; }

        // co nhieu mau
        public List<PhieuKetQua> PhieuKetQuas { get; set; }
        // duoc nhieu nguoi yeu cau
        public List<ChiTietYeuCau> ChiTietYeuCaus { get; set; }
    }
}