using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Models
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int product_price { get; set; }
        public string product_description { get; set; }
        public string product_image { get; set; }
        public int cat_id { get; set; }
        public Category Category { get; set; }
    }
}
