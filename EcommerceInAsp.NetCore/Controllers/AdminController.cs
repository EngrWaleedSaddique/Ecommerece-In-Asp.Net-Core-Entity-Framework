using EcommerceInAsp.NetCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Controllers
{
    public class AdminController : Controller
    {
        private mycontext _context;
        private IWebHostEnvironment _env;
        public AdminController(mycontext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
            var adminid=HttpContext.Session.GetString("admin_session");
            var row = _context.tbl_admin.Where(x => x.admin_id == int.Parse(adminid)).ToList();
            return View(row);
        }
        [HttpPost]
        public IActionResult Profile(Admin admin)
        {
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
        public IActionResult ChangeProfileImage(IFormFile admin_image,Admin admin) {
            string ImagePath = Path.Combine(_env.WebRootPath, "admin_image", admin_image.FileName);
            FileStream fs = new FileStream(ImagePath,FileMode.Create);
            admin_image.CopyTo(fs);
            admin.admin_image = admin_image.FileName;

            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("profile");
        }
        public IActionResult fetchCustomer() {
            var customer = _context.tbl_Customer.ToList();
            return View(customer);
        }
        public IActionResult CustomerDetails(int id) {
            var customer=_context.tbl_Customer.FirstOrDefault(x => x.customer_id == id);
            return View(customer);
        }
        public IActionResult updateCustomer(int id) {
            return View(_context.tbl_Customer.Find(id));
        }
        [HttpPost]
        public IActionResult updateCustomer(Customer customer,IFormFile customer_image)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "customer_image", customer_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            customer_image.CopyTo(fs);
            customer.customer_image = customer_image.FileName;
            _context.tbl_Customer.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("fetchCustomer");
        }
        public IActionResult deletePermission(int id) {
            var customer = _context.tbl_Customer.Find(id);
            return View(_context.tbl_Customer.FirstOrDefault(x => x.customer_id == id));
        }
        public IActionResult deleteCustomer(int id) {
            var customer = _context.tbl_Customer.Find(id);
            _context.tbl_Customer.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("fetchCustomer");
        }
    }
}
