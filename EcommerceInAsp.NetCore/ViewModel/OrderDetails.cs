using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.ViewModel
{
    public class OrderDetails
    {
        public int cust_id { get; set; }
        public string CustomerName { get; set; }
        public int no_of_Products { get; set; }

    }
}
