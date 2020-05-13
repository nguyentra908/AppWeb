using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;

namespace DOAN.Controllers
{
    public class AccountController : Controller
    {
        private WEBContext Context;

        [ActivatorUtilitiesConstructor]
        public AccountController(WEBContext _context)
        {
            this.Context = _context;
        }
        public IActionResult Index()
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
                HttpContext.Session.SetString("userId", userdetails.Email);

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
                    Diachi=model.Diachi,
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
            return RedirectToAction("Index", "Account");
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
            return View("Index");
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
        // registration Page load
      
    }
}