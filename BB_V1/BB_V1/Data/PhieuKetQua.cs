using System;
using System.Collections.Generic;

namespace BB_V1.Data
{
    public class PhieuKetQua
    {
        public int ID_PKQ { get; set; }

        public string FileKetQua { get; set; }

        // mau co du yeu cau de bao quan khong
        public bool TrangThaiBaoQuan { get; set; }

        public string ChuanDoan { get; set; }

        public DateTime ThoiGianCapNhat { get; set; }

        // thuoc loai mau nao

        public int ID_LM { get; set; }

        public LoaiMau LoaiMau { get; set; }

        // do ai cap nhat

        public Guid ID_TK { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        //danh sach ai dang ky

        public List<ChiTietSuKien> ChiTietSuKiens { get; set; }

        public List<ChiTietDiemHienMau> ChiTietDiemHienMaus { get; set; }

        public List<ChiTietChePhamMau> ChiTietChePhamMaus { get; set; }
    }
}