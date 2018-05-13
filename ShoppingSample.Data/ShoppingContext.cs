using ShoppingSample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ShoppingSample.Data
{
    public class ShoppingContext:IdentityDbContext<StoreUser>
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
