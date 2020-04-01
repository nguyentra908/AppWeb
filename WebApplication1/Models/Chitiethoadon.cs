using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Chitiethoadon
    {
        public int Mahd { get; set; }
        public int Masp { get; set; }
        public int? Thanhtien { get; set; }
        public int? Soluong { get; set; }
        public int? Gia { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Sanpham MaspNavigation { get; set; }
    }
}
