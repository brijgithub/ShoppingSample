using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingSample.Entities;
using ShoppingSample.Models;

namespace ShoppingSample.Controllers
{
    public class AccountController : Controller
    {
        #region Constructor
        /// <summary>
        /// initialises the properties
        /// </summary>
        /// <param name="Logger"></param>
        /// <param name="LoginManager"></param>
        /// <param name="UserManager"></param>
       
        public AccountController(ILogger<AccountController> Logger,SignInManager<StoreUser> LoginManager,UserManager<StoreUser> UserManager)
        {
            this.Logger = Logger;
            this.LoginManager = LoginManager;
            this.UserManager = UserManager;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Logger
        /// </summary>
        public ILogger Logger { get; }
        /// <summary>
        /// Login Manager
        /// </summary>
        public Microsoft.AspNetCore.Identity.SignInManager<StoreUser> LoginManager { get; }
        /// <summary>
        /// LoginManager
        /// </summary>
        public UserManager<StoreUser> UserManager { get; }
        #endregion

        #region Get Methods

        #region Login Get Method
        /// <summary>
        /// get method for login
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    RedirectToAction("Index", "Home");

                }
                return View();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;
            }
          
        }

        #endregion

        #region Register Get Method
        /// <summary>
        /// Register get method
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
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

        #region LogOut Get Method
        /// <summary>
        /// LogOut Get Method
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await LoginManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;
            }
            
        }
        #endregion

        #endregion

        #region Post Methods
        
        #region Login Post 
        /// <summary>
        /// method to login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await LoginManager.PasswordSignInAsync
                        (model.UserName, model.Password, model.RememberMe, false);
                   
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Shop", "Home");   
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login Failed ,Please provide valid credentials");
                    }
                }
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message);
                return null;
            }
            return View();
        }
        #endregion

        #region Register Post
        /// <summary>
        /// method to register
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindByNameAsync(model.UserName);

                    if (user == null)
                    {
                        user = new StoreUser()
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            UserName = model.UserName,
                            Email = model.UserEmail

                        };
                       
                        var result = await UserManager.CreateAsync(user, model.Password);

                        if (result == IdentityResult.Success)
                        {
                           
                            await UserManager.AddClaimAsync(user, new Claim("FullName", user.FirstName +" "+ user.LastName));
                            await LoginManager.SignInAsync(user,isPersistent:false);
                            return RedirectToAction("Shop", "Home");
                        }
                        else if(result != null && result.Errors!= null &&
                            result.Errors.Select(e=>e.Code == "DuplicateEmail").Single())
                        {
                            ModelState.AddModelError("", "Email already registered");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User already exists ,please create a different user name");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "User registration fails");
                this.Logger.LogError(ex.Message);
                return null;
            }
           
            return View();
        }

        #endregion

        #endregion 

    }
}