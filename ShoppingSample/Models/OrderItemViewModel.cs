using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSample.Models
{
    /// <summary>
    /// OrderItemViewModel
    /// </summary>
    public class OrderItemViewModel
    {
        #region Properties
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; } 
        /// <summary>
        /// Quantity
        /// </summary>
        [Required]
        public int Quantity { get; set; }
        /// <summary>
        /// Unit Price
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }
        #endregion

    }
}
