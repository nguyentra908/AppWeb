using System;
using System.Collections.Generic;

namespace WebShop.Models
{
    public partial class Magiamgia
    {
        public int Magiamgia1 { get; set; }
        public int Masp { get; set; }
        public int Phantram { get; set; }

        public virtual Sanpham MaspNavigation { get; set; }
    }
}
