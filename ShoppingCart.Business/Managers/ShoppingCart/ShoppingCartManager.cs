using Couchbase.KeyValue;
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
                //generate couchbase key and item
                string key = $"{request.CustomerId}-{request.ProductId}";

                ShoppingCartItem item = new ShoppingCartItem()
                {
                    CustomerId = request.CustomerId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity

                };

                //check if item exists
                IExistsResult existResult = await _shoppingCartRepository.ExistsAsync(key);

                //manage current item if exists
                if (existResult.Exists)
                {
                    IGetResult getResult = await _shoppingCartRepository.GetAsync(key);

                    ShoppingCartItem currentItem = getResult.ContentAs<ShoppingCartItem>();

                    item.Quantity += currentItem.Quantity;
                }

                //upsurt new or updated item to couschbase
                await _shoppingCartRepository.UpsertAsync(key, item);

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return true;
        }
    }
}
