using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //  WEBContext db = new WEBContext();
        private WEBContext Context;

        [ActivatorUtilitiesConstructor]
        public HomeController(WEBContext _context)
        {
            this.Context = _context;
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult _Layout()
        {

            return View();
        }

        public IActionResult TrangChu()
        {


            List<Sanpham> hangs = Context.Sanpham.ToList();
          
            return PartialView(hangs);

        }
        public IActionResult DangNhap()
        {

            return View();
        }
        public IActionResult TaiKhoan()
        {

            return View();
        }

        public async Task<IActionResult> GioHang(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await Context.Sanpham
                .Include(h => h.HangNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return PartialView(sanpham);
        }

        public async Task<IActionResult> ChiTietSanPham(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
           
            var sanpham = await Context.Sanpham
                .Include(h => h.HangNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return PartialView(sanpham);
        }

        // Loai San Pham
        public async Task<IActionResult> LoaiSP(int? id)
        {

            List<Sanpham> hangs = Context.Sanpham.Where(p => p.Hang == id).ToList();
            return PartialView(hangs);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
