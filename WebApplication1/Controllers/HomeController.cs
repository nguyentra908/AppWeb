using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DOAN.Models;
using DOAN.Models.Helpers;
using Microsoft.AspNetCore.Http;
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
      
    
      
        public IActionResult GioHang()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            if (cart != null)
            {
           
                ViewBag.total = cart.Sum(item => item.sanpham.Gia * item.Quantity * item.sanpham.Giakhuyenmai);
            }
            else
            {
                ViewBag.total = 0;
            }
           



            return View();
        }
        public async Task<IActionResult> Buy(int? id)
        {

            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { sanpham = Context.Sanpham.Single(p => p.Masp.Equals(id)), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { sanpham = Context.Sanpham.Single(p => p.Masp.Equals(id)), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("GioHang");
        }
        [Route("remove/{id}")]
        public IActionResult Remove(int? id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("GioHang");

        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("GioHang");
        }
        private int isExist(int? id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].sanpham.Masp.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        //Chi tiết sản phẩm
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

        // Paah loại sản phẩm
        public async Task<IActionResult> LoaiSP(int? id)
        {

            List<Sanpham> hangs = Context.Sanpham.Where(p => p.Hang == id).ToList();
            return PartialView(hangs);
        }

        //Thanh toan

        public IActionResult ThanhToan()
        {

            return View();
        }

        //Dang ký
        // GET: Home/DangKy
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangKy([Bind("Id,FullName,Role,Diachi,Sdt,Email,Password,RememberToken,CreatedAt,UpdatedAt")] Users users)
        {
            if (ModelState.IsValid)
            {
                Context.Add(users);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(DangKy));
            }
            return View(users);
        }

        //Acount



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Users model)
        {
            if (ModelState.IsValid)
            {
                var userdetails = await Context.Users
                .SingleOrDefaultAsync(m => m.Email == model.Email && m.Password == model.Password);
                if (userdetails == null)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View("Index");
                }
                HttpContext.Session.SetString("Email", userdetails.Email);
                HttpContext.Session.SetString("ten", userdetails.FullName);
                HttpContext.Session.SetString("diachi", userdetails.Diachi);
                HttpContext.Session.SetString("sdt", userdetails.Sdt);

            }
            else
            {
                return View("Index");
            }
            return RedirectToAction("TrangChu", "Home");
        }
        [HttpPost]
        public async Task<ActionResult> Registration(Users model)
        {

            if (ModelState.IsValid)
            {
                Users user = new Users
                {
                    FullName = model.FullName,
                    Diachi = model.Diachi,
                    Email = model.Email,
                    Password = model.Password,
                    Sdt = model.Sdt

                };
                Context.Add(user);
                await Context.SaveChangesAsync();

            }
            else
            {
                return View("Registration");
            }
            return RedirectToAction("Login", "Account");
        }
        // registration Page load
        public IActionResult Registration()
        {
            ViewData["Message"] = "Registration Page";

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("TrangChu");
        }

        public void ValidationMessage(string key, string alert, string value)
        {
            try
            {
                TempData.Remove(key);
                TempData.Add(key, value);
                TempData.Add("alertType", alert);
            }
            catch
            {
                Debug.WriteLine("TempDataMessage Error");
            }

        }
        // update infomation user
        // GET: Users/Edit/5
        public async Task<IActionResult> TaiKhoan()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var users = await Context.Users.FindAsync(id);
            //if (users == null)
            //{
            //    return NotFound();
            //}
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
