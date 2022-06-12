using Couchbase.KeyValue;
using ShoppingCart.Business.Managers.ShoppingCart.Helpers;
using ShoppingCart.Business.Managers.ShoppingCart.Models;
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
        private readonly IShoppingCartValidations _validator;

        public ShoppingCartManager(
            IShoppingCartRepository shoppingCartRepository,
            IShoppingCartValidations validator)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _validator = validator;
        }


        public async Task<AddShoppingCartOpResult> AddToCart(AddToCartRequest request)
        {
            AddShoppingCartOpResult result = new AddShoppingCartOpResult();

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

                ValidationResult validationResult = await _validator.Validate(item);

                if (validationResult.IsSuccess)
                {
                    //upsurt new or updated item to couschbase
                    await _shoppingCartRepository.UpsertAsync(key, item);
                }

                result.IsSuccess = validationResult.IsSuccess;
                result.Message = validationResult.Message;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"AddToCart failed! Ex: {ex.Message}, Stack: {ex.StackTrace}";
            }


            return result;
        }
    }
}
