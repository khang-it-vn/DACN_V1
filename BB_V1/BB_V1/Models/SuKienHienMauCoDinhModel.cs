using System;

namespace BB_V1.Models
{
    public class SuKienHienMauCoDinhModel
    {
        public int ID_DC{ get; set; }
        public int ID_LTT { get; set; }

        public Guid UID { get; set; }

        public DateTime NgayHenHien { get; set; }
    }
}
