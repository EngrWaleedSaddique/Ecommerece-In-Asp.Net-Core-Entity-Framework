using EcommerceInAsp.NetCore.Models;
using EcommerceInAsp.NetCore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Controllers
{
    public class HomeController : Controller
    {
        private mycontext _context;
        public HomeController(mycontext context)
        {
            _context = context;
        }
        public IActionResult Index(int? search_category,string? search)
        {
            ProductCart temp = new ProductCart();
            if (search_category == null)
            {
                temp.Products = _context.tbl_Product.ToList();
            }
            else
            if(search_category!=null && search==null)
            {
                temp.Products = _context.tbl_Product.Where(x => x.cat_id == Convert.ToUInt32(search_category)).ToList();
            }
            if (search != null) {
                
                    temp.Products = _context.tbl_Product.Where(x => x.product_name.ToLower().Contains(search.ToLower())
                                                  || x.product_description.ToLower().Contains(search.ToLower())).ToList();
                
            }
            
            temp.customer_id = HttpContext.Session.GetString("user_id");
            temp.Cart = _context.tbl_Cart.Where(x => x.cust_id == Convert.ToInt32(temp.customer_id)).ToList();
            int totalPrice = 0;
            temp.totalitems = _context.tbl_Cart.Where(x => x.cust_id == Convert.ToInt32(temp.customer_id)).Count();
            temp.Categories = _context.tbl_Category.ToList();
            
            foreach (var item in temp.Cart) {
                foreach (var product in temp.Products) {
                    if (item.prod_id == product.product_id)
                    {
                        totalPrice = totalPrice + product.product_price;
                    }
                }
                
            }
            //Code to set cookie to uniquely identify user
            if (Request.Cookies["UserID"] == null)
            {
                string user_id = Guid.NewGuid().ToString();
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("UserID", user_id);
            }
            temp.Total = totalPrice;
            return View(temp);
        }
        [HttpPost]
        public IActionResult addtoCart(Cart cart) {
            cart.user_id = Request.Cookies["UserId"];
            int alreadyExistingProduct=0;
            var cart_items = _context.tbl_Cart.ToList();
            foreach (var item in cart_items) {
                if (item.prod_id == cart.prod_id && item.cust_id==cart.cust_id) {
                    alreadyExistingProduct++;
                }
            }
            if (alreadyExistingProduct == 0)
            {

                _context.tbl_Cart.Add(cart);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return RedirectToAction("index");
            }
        }
        public IActionResult ViewCart() {
            ProductCart temp = new ProductCart();
            string customer_id = HttpContext.Session.GetString("user_id");
            temp.customer_id = customer_id;
            temp.Products = _context.tbl_Product.ToList();
            temp.Cart = _context.tbl_Cart.Where(x => x.cust_id == Convert.ToInt32(customer_id)).ToList();
            temp.totalitems = _context.tbl_Cart.Count();
            int totalPrice = 0;
            foreach (var item in temp.Cart)
            {
                foreach (var product in temp.Products)
                {
                    if (item.prod_id == product.product_id)
                    {
                        totalPrice = totalPrice + product.product_price;
                    }
                }

            }
            temp.Total = totalPrice;
            return View(temp);
        }
       
        public IActionResult RemoveProductCart(int id) {
            var temp=_context.tbl_Cart.Find(id);
            _context.Remove(temp);
            _context.SaveChanges();
            return RedirectToAction("ViewCart");
        }
        [HttpPost]
        public IActionResult Order(int cust_id) {
            var cart_items=_context.tbl_Cart.Where(x=>x.cust_id==cust_id);
            Orders temp;
            foreach (var item in cart_items) {
                
                    temp = new Orders();
                    temp.product_id = item.prod_id;
                    temp.quantity = item.product_quantity;
                    temp.customer_id = item.cust_id;
                    temp.status = 0;
                    _context.tbl_order.Add(temp);
                
            }
            _context.SaveChanges();
            foreach (var item in cart_items) {
                _context.tbl_Cart.Remove(item);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Customer cust) {
            var row=_context.tbl_Customer.Where(x => x.customer_email == cust.customer_email).FirstOrDefault();
            if (row != null && row.customer_password == cust.customer_password)
            {
                HttpContext.Session.SetString("user_id", row.customer_id.ToString());
                return RedirectToAction("Index");
            }
            else {
                ViewBag.ErrorMessage = "Email or Password is Invalid";
                return RedirectToAction("Login");
            }

        }
        public IActionResult Register() {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Customer cust) {
            _context.tbl_Customer.Add(cust);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}