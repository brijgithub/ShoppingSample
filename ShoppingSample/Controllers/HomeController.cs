using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingSample.Data;
using ShoppingSample.DataAcessLayer;
using ShoppingSample.Entities;
using ShoppingSample.Models;

namespace ShoppingSample.Controllers
{
    public class HomeController : Controller
    {

        #region Constructor
        /// <summary>
        /// initialises
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="UserManager"></param>
        public HomeController(IShoppingRepository rep,UserManager<StoreUser> UserManager,ILogger<HomeController> logger)
        {
            this.rep = rep;
            this.UserManager = UserManager;
            this.Logger = logger;
        }
        #endregion

        #region Properties
        /// <summary>
        /// IShoppingRepository
        /// </summary>
        private readonly IShoppingRepository rep;
        /// <summary>
        /// User Manager
        /// </summary>
        public UserManager<StoreUser> UserManager { get; }
        /// <summary>
        /// ILogger<HomeController>
        /// </summary>
        public ILogger<HomeController> Logger { get; }
        #endregion

        #region GetMethods

        #region Index Get
        /// <summary>
        /// index method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;
            }
            
        }
        #endregion

        #region About Get
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;
            }
            
        }
        #endregion

        #region Contact
        /// <summary>
        /// contact get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Contact()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;
            }

        }
        #endregion

        #region Shop Get
        /// <summary>
        /// shop post method
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Shop()
        {
            try
            {
                var result = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(rep.GetAllProducts());
                return View(result);
            }


            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;
            }


        }
        #endregion

        #region Error
        /// <summary>
        /// contact get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Error()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;
            }

        }
        #endregion

        #endregion

        #region PostMethods

        #region Contact Post
        /// <summary>
        /// contact method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Contact( ContactViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contact = Mapper.Map<ContactViewModel, Contact>(model);
                    rep.SaveEntity(contact);
                    rep.SaveAll();
                    ViewBag.UserMessage = "Thanks for contacting us ,we will get back to you shortly";
                }
                return View();
            }
            catch(Exception ex)
            {
               this.Logger.LogError(ex.Message);
                return null;
            }

           
        }
        #endregion

        #region Shop Post
        /// <summary>
        /// Shop post method
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Shop(string searchString)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchString))
                {

                    
                    var result = rep.GetAllProducts().Where
                       (e => (e.Artist != null && (e.Artist.ToLower().Contains(searchString.ToLower())
                       || e.Artist.ToLower().StartsWith(searchString.ToLower()) || e.Artist.ToLower().EndsWith(searchString.ToLower()))) ||
                        (e.ArtDescription != null && (e.ArtDescription.ToLower().Contains(searchString.ToLower())||
                        e.ArtDescription.ToLower().StartsWith(searchString.ToLower())|| e.ArtDescription.ToLower().EndsWith(searchString.ToLower())))
                          || (e.Title != null && (e.Title.ToLower().Contains(searchString.ToLower())||
                          e.Title.ToLower().StartsWith(searchString.ToLower())||e.Title.ToLower().EndsWith(searchString.ToLower())))
                       );

                    if (result != null && result.Count() > 0)
                    {
                        return View(Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(result));
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Sorry no results found !";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Sorry no results found !";
                    return RedirectToAction("Index", "Home");
                }

            }
            
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;
            }

}
        #endregion

        #region Purchase Post
        /// <summary>
        /// Purchase post
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost,ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult>  Purchase(int productId)
        {
            try
            {
                var product =rep.GetProductById(productId);
                var user = await UserManager.GetUserAsync(HttpContext.User);
                var Order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = Guid.NewGuid().ToString(),
                    User = user,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product =product,
                            Quantity=1,
                            UnitPrice = product.Price

                        }

                    }
                };

                rep.SaveEntity(Order);
                rep.SaveAll();
                return View();

            }

            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;

            }

        }
        #endregion


        #endregion


    }
}
