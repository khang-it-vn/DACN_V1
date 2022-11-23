using System.Collections.Generic;

namespace BB_V1.Data
{
    public class Qua
    {
        public int ID_QUA { get; set; }

        public string TenQua { get; set; }
        public int Diem { get; set; }

        public string SoLuongTon { get; set; }

        public string pathHinhAnh { get; set; }


        // quan hệ quà do adminstrator tổ chức

        public int ID_ADMIN { get; set; }

        public Administrator Administrator { get; set; }

        public List<ChiTietDoiQua> ChiTietDoiQuas { get; set; }

    }
}
