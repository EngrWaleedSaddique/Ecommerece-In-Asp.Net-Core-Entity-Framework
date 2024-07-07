using EcommerceInAsp.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.ViewModel
{
    public class ProductCart
    { 

        public List<Product> Products { get; set; }
        public List<Cart> Cart { get; set; }
        public int Total { get; set; }
        public int totalitems { get; set; }

    }
}