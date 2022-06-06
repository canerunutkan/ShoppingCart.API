using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Controllers
{
    [ApiController]
    [Route("api/v1/shoppingcart")]
    public async Task<IActionResult> AddToCart([FromBody] Object request)
    {
        IQuerySender
        return OK(await _qu);
    }
}
