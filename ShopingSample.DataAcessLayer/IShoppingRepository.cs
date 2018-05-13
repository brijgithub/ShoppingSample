using System.Collections.Generic;
using ShoppingSample.Entities;

namespace ShoppingSample.DataAcessLayer
{
    /// <summary>
    /// IShoppingRepository
    /// </summary>
    public interface IShoppingRepository
    {
        #region Properties
        /// <summary>
        /// ShoppingContext
        /// </summary>
        ShoppingContext Cnxt { get; }
        #endregion

        #region Methods

        #region GetAllProductByCategory
        /// <summary>
        /// GetAllProductByCategory
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        IEnumerable<Product> GetAllProductByCategory(string Category);
        #endregion

        #region GetAllProducts
        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetAllProducts();
        #endregion

        #region GetAllOrders
        /// <summary>
        /// GetAllOrders
        /// </summary>
        /// <returns></returns>
        IEnumerable<Order> GetAllOrders();
        #endregion

        #region GetOrderById
        /// <summary>
        /// GetOrderById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order GetOrderById(int id);
        #endregion

        #region GetProductById
        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProductById(int id);
        #endregion

        #region SaveEntity
        /// <summary>
        /// SaveEntity
        /// </summary>
        /// <param name="obj"></param>
        void SaveEntity(object obj);
        #endregion

        #region SaveAll
        /// <summary>
        /// SaveAll
        /// </summary>
        /// <returns></returns>
        bool SaveAll();
        #endregion

        #endregion
    }
}