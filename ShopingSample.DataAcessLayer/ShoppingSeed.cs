using ShoppingSample.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace ShoppingSample.DataAcessLayer
{
    /// <summary>
    /// class to load initial data in database
    /// </summary>
    public class ShoppingSeed
    {

        #region Constructor
        /// <summary>
        /// ShoppingSeed
        /// </summary>
        /// <param name="cntx"></param>
        /// <param name="env"></param>
        /// <param name="userManager"></param>
        public ShoppingSeed(ShoppingContext cntx,IHostingEnvironment env,UserManager<StoreUser> userManager)
        {
            Cntx = cntx;
            Env = env;
            UserManager = userManager;
        }
        #endregion

        #region Properties
        /// <summary>
        /// ShoppingContext
        /// </summary>
        public ShoppingContext Cntx { get; }
        /// <summary>
        /// IHostingEnvironment
        /// </summary>
        public IHostingEnvironment Env { get; }
        /// <summary>
        ///  UserManager<StoreUser>
        /// </summary>
        public UserManager<StoreUser> UserManager { get; }
        #endregion

        #region Method
        /// <summary>
        /// Seed
        /// </summary>
        /// <returns></returns>
        public async Task Seed()
        {
            Cntx.Database.EnsureCreated();

            var user = await UserManager.FindByEmailAsync("ap.brijesh@gmail.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName="Brijesh",
                    LastName="Achipilakool",
                    UserName="ap.brijesh@gmail.com",
                    Email="ap.brijesh@gmail.com"

                };
                var result = await UserManager.CreateAsync(user, "P@ssw0rd!");

                if(result!= IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
            }

            if (!Cntx.Products.Any())
            {
            string filePath = Path.Combine(Env.ContentRootPath, "Data/art.json");
            var json = File.ReadAllText(filePath);
            var Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                Cntx.Products.AddRange(Products);

                var Order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "12345",
                    User = user,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = Products.First(),
                            Quantity=5,
                            UnitPrice =Products.First().Price

                        }

                    }
                };

                Cntx.Orders.Add(Order);
                Cntx.SaveChanges();
           }
        }
        #endregion

        
    }
}
