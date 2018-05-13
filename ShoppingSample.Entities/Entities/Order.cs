using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSample.Entities
{
  /// <summary>
  /// Order
  /// </summary>
  public class Order
  {
    #region Properties
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Order Date
    /// </summary>
    public DateTime OrderDate { get; set; }
    /// <summary>
    /// OrderNumber
    /// </summary>
    public string OrderNumber { get; set; }
    /// <summary>
    /// Items
    /// </summary>
    public ICollection<OrderItem> Items { get; set; }
    /// <summary>
    /// User
    /// </summary>
    public StoreUser User { get; set; }
    #endregion 
    }
}
