using System.Collections.Generic;
using ShoppingSample.Data.Entities;

namespace ShoppingSample.Data
{
    public interface IShoppingRepository
    {
        ShoppingContext Cnxt { get; }

        IEnumerable<Product> GetAllProductByCategory(string Category);
        IEnumerable<Product> GetAllProducts();

        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);

        void SaveEntity(object obj);
        bool SaveAll();
    }
}