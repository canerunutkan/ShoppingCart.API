using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ShoppingCart.API.Controllers;
using ShoppingCart.Business.Managers.ShoppingCart;
using ShoppingCart.Business.Managers.ShoppingCart.Helpers;
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
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IShoppingCartManager _manager;

        public ShoppingCartControllerUnitTests()
        {
            var services = new ServiceCollection();

            //add services
            var options = new ClusterOptions
            {
                QueryTimeout = TimeSpan.FromSeconds(10)
            };

            services.AddCouchbase(options =>
            {
                options.ConnectionString = "couchbase://127.0.0.1";
                options.Password = "password";
                options.UserName = "Administrator";

            }).AddCouchbaseBucket<IShoppingCartBucketProvider>("shoppingcart-bucket");

            services.AddSingleton<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddSingleton<IShoppingCartManager, ShoppingCartManager>();
            services.AddSingleton(typeof(ILogger<ShoppingCartController>), typeof(NullLogger<ShoppingCartController>));
            services.AddSingleton(typeof(ILoggerFactory), typeof(NullLoggerFactory));
            services.AddSingleton<IShoppingCartValidations, ShoppingCartValidations>();


            //build providers
            var serviceProvider = services.BuildServiceProvider();

            //get dependincies
            _manager = serviceProvider.GetService<IShoppingCartManager>();
            _logger = serviceProvider.GetService<ILogger<ShoppingCartController>>();
        }

        [Fact]
        public async void AddToCartUnitTest()
        {
            //arrange
            var controller = new ShoppingCartController(_logger, _manager);

            //act
            AddToCartRequest request = new AddToCartRequest();
            AddToCartResponse callResult = await controller.AddToCart(request);


            //assert
            Assert.True(callResult.IsSuccess);
        }
    }
}
