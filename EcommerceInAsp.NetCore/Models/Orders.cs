using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Models
{
    public class Orders
    {
        [Key]
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public int customer_id { get; set; }
        public int status { get; set; }
        public Customer Customer { get; set; }
    }
}