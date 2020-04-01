using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {

            List<Hang> hangs = Context.Hang.ToList();
            return View(hangs);
        }

        public IActionResult Master()
        {
            return View();
        }
        public IActionResult TrangChu()
        {
            List<Hang> hangs = Context.Hang.ToList();
            return View(hangs);
        }
        public IActionResult DangNhap()
        {
            List<Hang> hangs = Context.Hang.ToList();
            return View(hangs);
        }
        public IActionResult TaiKhoan()
        {
            List<Hang> hangs = Context.Hang.ToList();
            return View(hangs);
        }

        public IActionResult GioHang()
        {
            List<Hang> hangs = Context.Hang.ToList();
            return View(hangs);
        }

        public IActionResult ChiTietSanPham()
        {
            List<Hang> hangs = Context.Hang.ToList();
            return View(hangs);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
