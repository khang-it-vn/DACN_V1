using System;

namespace BB_V1.Data
{
    public abstract class Person
    {
        public string Username { get; set; }

        public string MatKhau { get; set; }

        public string  SDT { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; } 
        
        public bool GioiTinh { get; set; }

        public String DC { get; set; }
    }
}
