using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingSample.DataAcessLayer;
using ShoppingSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSample.DataAcessLayer
{
    /// <summary>
    /// Shopping repository
    /// </summary>
    public class ShoppingRepository : IShoppingRepository
    {
        #region Constructor
        /// <summary>
        /// ShoppingRepository
        /// </summary>
        /// <param name="cnxt"></param>
        /// <param name="logger"></param>
        public ShoppingRepository(ShoppingContext cnxt,ILogger<ShoppingRepository> logger )
        {
            Cnxt = cnxt;
            Logger = logger;
        }
        #endregion

        #region Properties
        /// <summary>
        /// ShoppingContext
        /// </summary>
        public ShoppingContext Cnxt { get; }
        /// <summary>
        /// ILogger<ShoppingRepository>
        /// </summary>
        public ILogger<ShoppingRepository> Logger { get; }
        #endregion

        #region Methods

        #region GetAllProducts
        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
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
        #endregion

        #region GetAllProductByCategory
        /// <summary>
        /// GetAllProductByCategory
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
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
        #endregion

        #region SaveAll
        /// <summary>
        /// SaveAll
        /// </summary>
        /// <returns></returns>
        public bool SaveAll()
        {
            return Cnxt.SaveChanges() > 0;
        }
        #endregion

        #region GetAllOrders
        /// <summary>
        /// GetAllOrders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> GetAllOrders()
        {
            return Cnxt.Orders.
                Include(e=>e.Items)
                .ThenInclude(d=>d.Product)
                .ToList();
        }
        #endregion

        #region GetOrderById
        /// <summary>
        /// GetOrderById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrderById(int id)
        {
            return Cnxt.Orders.
               Include(e => e.Items)
               .ThenInclude(d => d.Product).Where(e=>e.Id == id)
               .FirstOrDefault();
        }
        #endregion

        #region GetProductById
        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            return Cnxt.Products.Where(e => e.Id == id).FirstOrDefault();
        }
        #endregion

        #region SaveEntity
        /// <summary>
        /// SaveEntity
        /// </summary>
        /// <param name="obj"></param>
        public void SaveEntity(object obj)
        {
            Cnxt.Add(obj);
        }
        #endregion

        #endregion
    }
}
