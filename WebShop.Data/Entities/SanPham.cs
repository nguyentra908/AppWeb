using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Data.Entities
{
    public class SanPham
    {

        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int Hang { get; set; }
        public string MoTa { get; set; }
        public DateTime NamSX { get; set; }
        public decimal Gia { get; set; }
        public decimal GiaKhuyenMai { get; set; }
        public string AnhDaiDien { get; set; }
        public string ManHinh { get; set; }
        public string CameraTruoc { get; set; }
        public string CameraSau { get; set; }
        public string Ram { get; set; }
        public string boNho { get; set; }
        public string cpu { get; set; }
        public string gpu { get; set; }
        public string pin { get; set; }
        public string os { get; set; }
        public string sim { get; set; }
        public List<SanPham_Hang> SanPham_Hang { get; set; }
    }
}
