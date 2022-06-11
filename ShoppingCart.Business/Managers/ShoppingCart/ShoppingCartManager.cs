using ShoppingCart.Business.Models.Requests;
using ShoppingCart.Data.Repositories.Couchbase;
using ShoppingCart.Data.Repositories.Couchbase.Entity;
using ShoppingCart.Data.Repositories.Couchbase.SoppingCartRepository;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Managers.ShoppingCart
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartManager(
            IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }


        public async Task<bool> AddToCart(AddToCartRequest request)
        {
            try
            {
                ShoppingCartItem item = new ShoppingCartItem()
                {
                    CustomerId = request.CustomerId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity

                };

                await _shoppingCartRepository.InsertAsync(item.CustomerId.ToString(), item);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return true;
        }
    }
}
