using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSample.Models
{
    /// <summary>
    /// LoginViewModel
    /// </summary>
    public class LoginViewModel
    {
        #region Properties
        /// <summary>
        /// UserName
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// RememberMe
        /// </summary>
        public bool RememberMe { get; set; }
        #endregion
    }
}
