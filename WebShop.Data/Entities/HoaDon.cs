using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Data.Entities
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public DateTime NgayHD { get; set; }
        public decimal TongTien { get; set; }
        public int? IDKH { get; set; }
        public string GhiChu { get; set; }
        public string TinhTrang { get; set; }
    }
}
