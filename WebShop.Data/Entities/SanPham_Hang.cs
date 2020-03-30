using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Data.Entities
{
  public class SanPham_Hang
    {
        public int MaSP { get; set; }
        public SanPham SanPham { get; set; }
        public int MaHang { get; set; }
        public Hang Hang { get; set; }
    }
}
