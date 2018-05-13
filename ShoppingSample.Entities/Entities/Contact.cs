using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSample.Entities
{
  /// <summary>
  /// Contact
  /// </summary>  
  public class Contact
  {
    #region Properties
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// FirstName
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// LastName
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Subject
    /// </summary>
    public string Subject { get; set; }
    /// <summary>
    /// Message
    /// </summary>
    public string Message { get; set; }
    #endregion
    }
}
