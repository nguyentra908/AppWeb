 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using WebApplication1.Models;

namespace DOAN.Controllers
{
    [Route("ThongKeKhachHangMuaNhieu")]
    public class ThongKeKhachHangMuaNhieuController : Controller
    {
        private readonly WEBContext _context;
        public ThongKeKhachHangMuaNhieuController(WEBContext context)
        {
            _context = context;
        }
        public IActionResult ThongKeKhachHangMuaNhieu()
        {
            return View();
        }


        [HttpPost]
        public IActionResult print(int soluong)
        {
            var get = _context.Chitiethoadon
             .Include(c => c.MahdNavigation)
             .Include(c => c.MaspNavigation)
             .ToLookup(c => c.Masp)
             .Select(std => new
             {
                 sl = std.Sum(c => c.Soluong),
                 tongtien = std.Sum(c => c.Thanhtien),
                 ma = std.Select(c => c.Masp).First(),
                 ten = std.Select(c => c.MaspNavigation.Tensp).First()
             }).OrderByDescending(c => c.sl).Take(soluong).ToList();
            ViewBag.get = get;
            return new ViewAsPdf();
        }


        [Route("demo/{khachhang}")]
        public IActionResult demo(int khachhang)
        {
            var get = _context.Hoadon
                       .Include(c => c.IdkhNavigation)                  
                       .ToLookup(c => c.Idkh)
                       .Select(std => new
                       {
                          
                           tongtien = std.Sum(c => c.Tongtien),
                           ma = std.Select(c => c.Idkh).First(),
                           ten = std.Select(c => c.IdkhNavigation.FullName).First()

                       }).OrderByDescending(c => c.tongtien).Take(khachhang).ToList();


            return new JsonResult(get);

        }
    }
}