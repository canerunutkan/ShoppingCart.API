using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Business.Managers.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Controllers
{
    [ApiController]
    [Route("api/v1/shoppingcart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IShoppingCartManager _manager;

        public ShoppingCartController(
            ILogger<ShoppingCartController> logger,
            IShoppingCartManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> AddToCart()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = null
            })
            .ToArray();
        }
    }
}
