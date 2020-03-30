using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Data.Entities
{
    public class KhachHang
    {
        public int maKH { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        public string GhiChu { get; set; }
    }
}
