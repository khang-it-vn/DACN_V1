using System;
using System.Collections.Generic;

namespace BB_V1.Data
{
    public class Administrator
    {
        public int ID_ADMIN { get; set; }
        public string HoTen { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Dc { get; set; }

        public DateTime DOB { get; set; }

        public int GioiTinh { get; set; }

        public bool TrangThaiHoatDong { get; set; }

        public List<Qua> Quas { get; set; } 
    }
}
