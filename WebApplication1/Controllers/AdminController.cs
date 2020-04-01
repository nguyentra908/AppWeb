using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;

namespace DOAN.Controllers
{
    public class AdminController : Controller
    {
        //WEBContext db = new WEBContext();
        private WEBContext Context;

        [ActivatorUtilitiesConstructor]
        public AdminController(WEBContext _context)
        {
            this.Context = _context;
        }
        public IActionResult MasterAD()
        {
            return View();
        }
        public IActionResult TrangChuAD()
        {
            return View();
        }
        public IActionResult DonHangAD()
        {
            List<Hoadon> hoadons = Context.Hoadon.ToList();
            return View(hoadons);
        }

        public IActionResult SanPhamAD()
        {
            List<Sanpham> sanphams = Context.Sanpham.ToList();
            return View(sanphams);
        }

        public IActionResult NhaSanXuatAD()
        {
            List<Hang> hangs = Context.Hang.ToList();
            return View(hangs);
        }

        public IActionResult ReportAD()
        {            
            return View();
        }
    }
}