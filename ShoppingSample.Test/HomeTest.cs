using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShoppingSample.Controllers;
using ShoppingSample.DataAcessLayer;
using ShoppingSample.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShoppingSample.Test
{
    public class HomeTest
    {
        [Fact]
        public void GetAllProducts()
        {
            var productList = new List<Product>();

            productList.Add(new Product
            {
                Id = 1,
                ArtId = "123",
                ArtDescription = "test",
                Artist = "Picasso",
                ArtistBirthDate = DateTime.Now,
                ArtistNationality = "Indian",
                ArtistDeathDate = DateTime.Now,
                ArtDating="Test",
                Price=123,
                Size="20",
                Title="Test",
                Category="Test"
            }
            );
       
            var mockProducts = new Mock<IShoppingRepository>();
            var iLogger = new Mock<ILogger<HomeController>>();
            var userManager = new Mock<UserManager<StoreUser>>();
            mockProducts.Setup(e => e.GetAllProducts()).Returns(productList);

            var homeController = new HomeController(mockProducts.Object,userManager.Object,iLogger.Object);

            var result = homeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);


        }
    }
}
