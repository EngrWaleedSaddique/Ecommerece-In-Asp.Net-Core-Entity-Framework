using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Models
{
    public class Customer
    {   [Key]
        public int customer_id { get; set; }
        [Required]
        public string customer_name { get; set; }
        [Required]
        public string customer_phone { get; set; }
        [Required]
        public string customer_email { get; set; }
        [Required]
        public string customer_password { get; set; }
        [Required]
        public string customer_id_gender { get; set; }
        [Required]
        public string customer_country { get; set; }
        [Required]
        public string customer_id_city { get; set; }
        [Required]
        public string customer_address { get; set; }
        public string customer_image { get; set; }
        public List<Orders> Order { get; set; }
    }
}
