using EcommerceInAsp.NetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Controllers
{
    public class AdminController : Controller
    {
        private mycontext _context;
        public AdminController(mycontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string admin_session = HttpContext.Session.GetString("admin_session");
            if (admin_session != null)
            {
                return View();
            }
            else {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string adminEmail, string adminPassword)
        {
            var row = _context.tbl_admin.FirstOrDefault(x => x.admin_email == adminEmail);
            if (row != null && row.admin_password == adminPassword)
            {
                HttpContext.Session.SetString("admin_session", row.admin_id.ToString());
                return RedirectToAction("Index");
            }
            else {
                ViewBag.message = "Incorrect Username or Password";
                return View();
            }
            
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("login");
        }
        public IActionResult Profile() {
            return View();
        }
    }
}