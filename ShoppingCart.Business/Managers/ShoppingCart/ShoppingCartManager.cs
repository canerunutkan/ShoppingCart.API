using ShoppingCart.Business.Models.Requests;
using ShoppingCart.Data.Repositories.Couchbase;
using ShoppingCart.Data.Repositories.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Managers.ShoppingCart
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly ICouchbaseProvider _iCouchbaseProvider;

        public ShoppingCartManager(
            ICouchbaseProvider iCouchbaseProvider)
        {
            _iCouchbaseProvider = iCouchbaseProvider;
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
                await _iCouchbaseProvider.AddToCartAsync(item);
            }
            catch (System.Exception ex)
            {

                throw;
            }


            return true;
        }
    }
}
