using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class KHACHHANGController : Controller
    {

        //customer
        public IActionResult Index()
        {
            return View("index");
        }
        public IActionResult Footer()
        {
            return View("footer");
        }

       
        public IActionResult Master()
        {
            return View("trangchu");
        }

        public IActionResult TrangChu()
        {
            return View("trangchu");
        }
        public IActionResult DangNhap()
        {
            return View("dangnhap");
        }
        public IActionResult GioHang()
        {
            return View("giohang");
        }

        public IActionResult TaiKhoan()
        {
            return View("taikhoan");
        }

        public IActionResult ChiTietSanPham()
        {
            return View("chitietsanpham");
        }

        public IActionResult SanPhamMoi1()
        {
            return View("sanphamNew1");
        }
        public IActionResult SanPhamMoi2()
        {
            return View("sanphamNew2");
        }
        public IActionResult vvv()
        {
            return View("vvv");
        }

    }
}