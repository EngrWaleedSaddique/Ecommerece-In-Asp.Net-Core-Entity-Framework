using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Models
{
    public class Cart
    {
        [Key]
        public int cart_id { get; set; }
        public int prod_id { get; set; }
        public int cust_id { get; set; }
        public int product_quantity { get; set; }
        public int cart_status { get; set; }
        public string user_id { get; set; }

    }
}
