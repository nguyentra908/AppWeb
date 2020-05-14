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
            return View("Login");
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

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Diachi,Sdt,Email")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(users);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }
        private bool UsersExists(int id)
        {
            return Context.Users.Any(e => e.Id == id);
        }

    }
}