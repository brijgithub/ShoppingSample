using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSample.Entities
{
    /// <summary>
    /// Store User
    /// </summary>
    public class StoreUser:IdentityUser
    {
        #region 
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }
        #endregion
    }
}
