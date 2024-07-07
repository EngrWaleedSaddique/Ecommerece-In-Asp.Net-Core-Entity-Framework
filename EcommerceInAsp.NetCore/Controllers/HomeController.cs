using EcommerceInAsp.NetCore.Models;
using EcommerceInAsp.NetCore.ViewModel;
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
        public IActionResult Index()
        {
            ProductCart temp = new ProductCart();
            temp.Products= _context.tbl_Product.ToList();
            temp.Cart = _context.tbl_Cart.Where(x => x.cust_id == 1).ToList();
            int totalPrice = 0;
            temp.totalitems = _context.tbl_Cart.Count();
            foreach (var item in temp.Cart) {
                foreach (var product in temp.Products) {
                    if (item.prod_id == product.product_id)
                    {
                        totalPrice = totalPrice + product.product_price;
                    }
                }
                
            }
            temp.Total = totalPrice;
            return View(temp);
        }
        [HttpPost]
        public IActionResult addtoCart(Cart cart) {
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
            temp.Products = _context.tbl_Product.ToList();
            temp.Cart = _context.tbl_Cart.Where(x => x.cust_id == 1).ToList();
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
                    temp.status = 1;
                    _context.tbl_order.Add(temp);
                
            }
            _context.SaveChanges();
            Cart tempcart;
            foreach (var item in cart_items) {
                _context.tbl_Cart.Remove(item);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}