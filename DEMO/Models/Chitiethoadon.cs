using System;
using System.Collections.Generic;

namespace DEMO.Models
{
    public partial class Chitiethoadon
    {
        public int Mahd { get; set; }
        public int Masp { get; set; }
        public double? Thanhtien { get; set; }
        public int? Soluong { get; set; }
        public double? Gia { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Hoadon MahdNavigation { get; set; }
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
