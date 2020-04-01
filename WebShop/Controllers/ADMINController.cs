using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebShop.Controllers
{
    public class ADMINController : Controller
    {
        //admin
        public IActionResult MasterAD()
        {
            return View("masterAD");
        }

        public IActionResult DonHangAD()
        {
            
            return View("DonHangAD");
        }
        public IActionResult SanPhamAD()
        {
            return View("sanphamAD");
        }

        public IActionResult TrangChuAD()
        {
            return View("trangchuAD");
        }

        public IActionResult nsxAD()
        {
            return View("nsxAD");
        }

        public IActionResult ReportAD()
        {
            return View("reportAD");
        }
    }
}