using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using ShoppingCart.Data.Repositories.Couchbase.Entity;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repositories.Couchbase
{
    public class CouchbaseProvider : ICouchbaseProvider
    {
        private readonly IBucketProvider _bucketProvider;
        private readonly IBucket _bucket;

        public CouchbaseProvider(IBucketProvider bucketProvider)
        {
            _bucketProvider = bucketProvider;
            _bucket = _bucketProvider.GetBucketAsync("shoppingcart").GetAwaiter().GetResult();
        }

        public async Task<bool> AddToCartAsync(ShoppingCartItem item)
        {
            string key = $"{item.CustomerId}-{item.ProductId}";
            await _bucket.DefaultCollection().InsertAsync(key, item);
            return true;
        }

    }
}
