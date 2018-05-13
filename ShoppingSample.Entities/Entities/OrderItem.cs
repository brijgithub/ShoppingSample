namespace ShoppingSample.Entities
{
   /// <summary>
   /// Order Item
   /// </summary>
  public class OrderItem
  {
    #region Properties
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Product
    /// </summary>
    public Product Product { get; set; }
    /// <summary>
    /// Quantity
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// Unitprice
    /// </summary>
    public decimal UnitPrice { get; set; }
    /// <summary>
    /// Order
    /// </summary>
    public Order Order { get; set; }
    #endregion
    }
}