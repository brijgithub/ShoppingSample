using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSample.Models
{
    /// <summary>
    /// OrderViewModel
    /// </summary>
    public class OrderViewModel
    {
        #region Properties
        /// <summary>
        /// Orderid
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// OrderDate
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// OrderNumber
        /// </summary>
        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }
        /// <summary>
        /// Items
        /// </summary>
        public ICollection<OrderItemViewModel> Items { get; set; }

        #endregion
    }
}
