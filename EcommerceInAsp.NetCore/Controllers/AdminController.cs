using EcommerceInAsp.NetCore.Models;
using EcommerceInAsp.NetCore.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult fetchCategory() {

            return View(_context.tbl_Category.ToList());
        }
        public IActionResult addCategory() {
            return View();
        }
        [HttpPost]
        public IActionResult addCategory(Category cat) {
            _context.tbl_Category.Add(cat);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }
        public IActionResult updateCategory(int id) {
            var category = _context.tbl_Category.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult updateCategory(Category cat)
        {
            _context.tbl_Category.Update(cat);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }
        public IActionResult deletePermissionCategory(int id)
        {

            return View(_context.tbl_Category.FirstOrDefault(x => x.category_id == id));
        }
        public IActionResult deleteCategory(int id) {
            var category = _context.tbl_Category.Find(id);
            _context.tbl_Category.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }
        public IActionResult fetchProduct() {
            return View(_context.tbl_Product.ToList());
        }
        public IActionResult addProduct() {
            List<Category> categories = _context.tbl_Category.ToList();
            ViewData["category"] = categories;
            return View();
        }
        [HttpPost]
        public IActionResult addProduct(Product prod,IFormFile product_image) {
            string imageName = Path.GetFileName(product_image.FileName);
            string ImagePath = Path.Combine(_env.WebRootPath,"product_image",imageName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            product_image.CopyTo(fs);
            prod.product_image = imageName;
            _context.tbl_Product.Add(prod);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }
        public IActionResult ProductDetails(int id)
        {
            var product = _context.tbl_Product.Include(x=>x.Category).FirstOrDefault(x => x.product_id == id);
            return View(product);
        }
        public IActionResult deletePermissionProduct(int id)
        {

            return View(_context.tbl_Product.FirstOrDefault(x => x.product_id == id));
        }
        public IActionResult deleteProduct(int id)
        {
            var product = _context.tbl_Product.Find(id);
            _context.tbl_Product.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }
        public IActionResult updateProduct(int id)
        {
            List<Category> categories = _context.tbl_Category.ToList();
            ViewData["category"] = categories;
            var product = _context.tbl_Product.Find(id);
            ViewBag.selectedCategoryId = product.cat_id;
            return View(product);
        }
        [HttpPost]
        public IActionResult updateProduct(Product prod)
        {
            _context.tbl_Product.Update(prod);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }
        public IActionResult ChangeProductImage(IFormFile product_image, Product product)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "product_image", product_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            product_image.CopyTo(fs);
            product.product_image = product_image.FileName;

            _context.tbl_Product.Update(product);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }
        public IActionResult ShowOrders() {
           
            var orders=_context.tbl_order.ToList();
            OrderDetails temp = new OrderDetails();
            _context.tbl_Customer.Find();
            foreach (var item in orders) {
                      
            }
            return View(orders);
        }
        public IActionResult OrderDetails(int cust_id) {
            var details=_context.tbl_order.Where(x => x.customer_id == cust_id);
            return View(details);
        }
    }
}