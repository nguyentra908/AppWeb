using System;
using System.Collections.Generic;

namespace WebShop.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadon = new HashSet<Hoadon>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Ghichu { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Hoadon> Hoadon { get; set; }
    }
}
