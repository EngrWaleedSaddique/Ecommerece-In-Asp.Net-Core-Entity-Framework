using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Models
{
    public class Feedback
    {
        [Key]
        public int feedback_id { get; set; }
        public int user_name { get; set; }
        public int user_message { get; set; }

    }
}
