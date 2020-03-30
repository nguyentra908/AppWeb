using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Data.Entities
{
    public class Hang
    {
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public List<SanPham_Hang> SanPham_Hang { get; set; }
    }
}
