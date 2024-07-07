using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }
        public List<Product> Product { get; set; }

    }

}
