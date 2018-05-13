using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSample.Entities
{
/// <summary>
/// Product 
/// </summary>
  public class Product
  {
    #region Properties
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Category
    /// </summary>
    public string Category { get; set; }
    /// <summary>
    /// Size
    /// </summary>
    public string Size { get; set; }
    /// <summary>
    /// Price
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Title
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// ArtDescription
    /// </summary>
    public string ArtDescription { get; set; }
    /// <summary>
    /// ArtDating
    /// </summary>
    public string ArtDating { get; set; }
    /// <summary>
    /// ArtId
    /// </summary>
    public string ArtId { get; set; }
    /// <summary>
    /// Artist
    /// </summary>
    public string Artist { get; set; }
    /// <summary>
    /// ArtistBirthDate
    /// </summary>
    public DateTime ArtistBirthDate { get; set; }
    /// <summary>
    /// ArtistDeathDate
    /// </summary>
    public DateTime ArtistDeathDate { get; set; }
    /// <summary>
    /// ArtistNationality
    /// </summary>
    public string ArtistNationality { get; set; }
    #endregion
    }
}
