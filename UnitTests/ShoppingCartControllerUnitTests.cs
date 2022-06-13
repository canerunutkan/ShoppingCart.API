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

        /// <summary>
        /// if product count is 0 in the request, than we must get 0 product error response.
        /// </summary>
        [Fact]
        public async void AddToCart_With_0_Product_Count_Test()
        {
            //arrange
            var controller = new ShoppingCartController(_logger, _manager);

            //act
            AddToCartRequest request = new AddToCartRequest()
            {
                CustomerId = 1,
                ProductId = 1,
                Quantity = 0
            };
            AddToCartResponse callResult = await controller.AddToCart(request);


            //assert
            Assert.Equal("Product count can not be less then 1!", callResult.Message);
        }

        /// <summary>
        /// Try to add quantity over stock
        /// </summary>
        [Fact]
        public async void AddToCart_With_Over_Stock_Test()
        {
            //arrange
            var controller = new ShoppingCartController(_logger, _manager);

            //act
            AddToCartRequest request = new AddToCartRequest()
            {
                CustomerId = 1,
                ProductId = 1,
                Quantity = 1000000000
            };
            AddToCartResponse callResult = await controller.AddToCart(request);


            //assert
            Assert.Equal("There is not enough stocks for operation!", callResult.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async void AddToCart_Add_With_No_Problem()
        {
            //arrange
            var controller = new ShoppingCartController(_logger, _manager);

            //alert: bu testin tam doðru olmasý için burada sepetin içerisindeki ürünlerin silindiði varyýlmýþtýr

            //act
            AddToCartRequest request = new AddToCartRequest()
            {
                CustomerId = 10,
                ProductId = 1,
                Quantity = 1
            };
            AddToCartResponse callResult = await controller.AddToCart(request);


            //assert
            Assert.True(callResult.IsSuccess);
        }
    }
}
