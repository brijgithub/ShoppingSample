using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingSample.Data;
using ShoppingSample.DataAcessLayer;
using ShoppingSample.Entities;

namespace ShoppingSample.Controllers
{
    /// <summary>
    /// Created Product Controller for learning  webapi
    /// </summary>
    [Route("api/[Controller]")]
    public class ProductController : Controller

    {
        #region Constructor
        /// <summary>
        /// ProductController
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="log"></param>
        public ProductController(IShoppingRepository rep,ILogger<ProductController> log)
        {
            Rep = rep;
            Log = log;
        }
        #endregion

        #region Properties
        /// <summary>
        /// IShoppingRepository
        /// </summary>
        public IShoppingRepository Rep { get; }
        /// <summary>
        /// ILogger
        /// </summary>
        public ILogger Log { get; }
        #endregion

        #region Get
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
               return  Ok(Rep.GetAllProducts());

            }
            catch(Exception ex)
            {
                Log.LogError($"Failed to retrive products:{ex}");
               return  BadRequest("Failed to retrieve products");
            }

           
        }
        #endregion
    }
}