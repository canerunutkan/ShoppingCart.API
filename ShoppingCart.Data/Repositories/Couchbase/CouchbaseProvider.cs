using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using ShoppingCart.Data.Repositories.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repositories.Couchbase
{
    public class CouchbaseProvider : ICouchbaseProvider
    {
        private readonly IBucket _bucket;

        public CouchbaseProvider(IBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucketAsync("default").GetAwaiter().GetResult();
        }

        public async Task<bool> AddToCartAsync(ShoppingCartItem item)
        {
            string key = $"{item.CustomerId}-{item.ProductId}";
            await _bucket.DefaultCollection().InsertAsync(key, item);
            return true;
        }
    }
}
