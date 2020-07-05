using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Rotativa.AspNetCore;
using WebApplication1.Models;

namespace DOAN.Controllers
{
    [Route("ThongKeSanPhamBanChay")]
    public class ThongKeSanPhamBanChayController : Controller
    {
        private readonly WEBContext _context;
        public ThongKeSanPhamBanChayController(WEBContext context)
        {
            _context = context;
        }
        public IActionResult ThongKeSanPhamBanChay()
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


        [Route("demo/{soluong}")]
        public IActionResult demo(int soluong)
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


            return new JsonResult(get);

        }
    }
}