using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Business.Managers.ShoppingCart;
using ShoppingCart.Business.Models.Requests;
using ShoppingCart.Business.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Controllers
{
    [ApiController]
    [Route("Api/V1/ShoppingCart")]
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

        [HttpPost("AddToCart")]
        public AddToCartResponse AddToCart(AddToCartRequest request)
        {
            return new AddToCartResponse();
        }
    }
}
