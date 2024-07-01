using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceInAsp.NetCore.Models
{
    public class mycontext:DbContext
    {
        public mycontext(DbContextOptions<mycontext> options):base(options)
        {

        }
        public DbSet<Admin> tbl_admin { get; set; }
        public DbSet<Customer> tbl_Customer { get; set; }
        public DbSet<Category> tbl_Category { get; set; }
        public DbSet<Product> tbl_Product { get; set; }
        public DbSet<Product> tbl_Cart { get; set; }
        public DbSet<Feedback> tbl_Feedback { get; set; }
        public DbSet<Faqs> tbl_Faqs { get; set; }
        



    }
}
