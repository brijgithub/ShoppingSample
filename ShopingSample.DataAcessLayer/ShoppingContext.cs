using ShoppingSample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ShoppingSample.DataAcessLayer
{
    /// <summary>
    /// Shopping context class
    /// </summary>
    public class ShoppingContext:IdentityDbContext<StoreUser>
    {
        #region Constructor
        /// <summary>
        /// ShoppingContext
        /// </summary>
        /// <param name="options"></param>
        public ShoppingContext(DbContextOptions<ShoppingContext> options):base(options)
        {

        }
        #endregion

        #region Dbset
        /// <summary>
        /// Products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Orders
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Contacts
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }
        #endregion 
    }
}
