using Couchbase;
using Microsoft.Extensions.Logging;
using ShoppingCart.API.Controllers;
using ShoppingCart.Business.Managers.ShoppingCart;
using ShoppingCart.Business.Models.Requests;
using ShoppingCart.Business.Models.Responses;
using ShoppingCart.Data.Repositories.Couchbase.SoppingCartRepository;
using ShoppingCart.Data.Repositories.Couchbase.SoppingCartRepository.BucketProvider;
using System;
using Xunit;

namespace UnitTests
{
    public class ShoppingCartControllerUnitTests
    {
        [Fact]
        public async void AddToCartUnitTest()
        {
            //arrange
            //ILoggerFactory factory = new LoggerFactory();
            //ILogger<ShoppingCartController> logger = new Logger<ShoppingCartController>(factory);

            //IShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository(bucketProvider);
            //IShoppingCartManager manager = new ShoppingCartManager(shoppingCartRepository);

            //var controller = new ShoppingCartController(logger, manager);

            ////act
            //AddToCartRequest request = new AddToCartRequest();
            //AddToCartResponse callResult = await controller.AddToCart(request);


            ////assert
            //Assert.True(callResult.IsSuccess);
        }
    }
}
