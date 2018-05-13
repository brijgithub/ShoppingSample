using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingSample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSample.Data
{
    public class ShoppingRepository : IShoppingRepository
    {
        public ShoppingRepository(ShoppingContext cnxt,ILogger<ShoppingRepository> logger )
        {
            Cnxt = cnxt;
            Logger = logger;
        }

        public ShoppingContext Cnxt { get; }
        public ILogger<ShoppingRepository> Logger { get; }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return Cnxt.Products.OrderBy(p => p.Title).ToList();
            }
            catch(Exception ex)
            {
                Logger.LogError($"Unable to fetch products :{ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetAllProductByCategory(string Category)
        {
            try
            {
                return Cnxt.Products.Where(e => e.Category == Category).ToList();
            }
            catch(Exception ex)
            {
                Logger.LogError($"Failed to retrieve Products by Category :{ex}");
                return null;
            }
        }

        public bool SaveAll()
        {
            return Cnxt.SaveChanges() > 0;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return Cnxt.Orders.
                Include(e=>e.Items)
                .ThenInclude(d=>d.Product)
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            return Cnxt.Orders.
               Include(e => e.Items)
               .ThenInclude(d => d.Product).Where(e=>e.Id == id)
               .FirstOrDefault();
        }

        public void SaveEntity(object obj)
        {
            Cnxt.Add(obj);
        }
    }
}
