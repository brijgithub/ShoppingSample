using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using ShoppingSample.Data;
using ShoppingSample.DataAcessLayer;
using ShoppingSample.Entities;
using System;
using System.IO;

namespace ShoppingSample
{
    /// <summary>
    /// startup class
    /// </summary>
    public class Startup
    {
        #region Constructor
        /// <summary>
        /// startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }
        #endregion

        #region Properties
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        #endregion

        #region ConfigureServices
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser, IdentityRole>(cfg=>
               {
                   cfg.User.RequireUniqueEmail = true;
                
               })
                .AddEntityFrameworkStores<ShoppingContext>();
            services.AddDbContext<ShoppingContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ShoppingDatabase")));

            services.ConfigureApplicationCookie(op=>
            {
                op.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                op.LoginPath = "/Account/Login";
                
            } 
            );
            services.AddMvc().AddJsonOptions(P=>P.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore);
            services.AddTransient<ShoppingSeed>();
            services.AddScoped<IShoppingRepository, ShoppingRepository>();
            services.AddAutoMapper();
        }
        #endregion

        #region Configure
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "log-{Date}.txt"))
            .CreateLogger();
            loggerFactory.AddSerilog();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
        #endregion
    }
}
