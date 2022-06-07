using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repositories.Couchbase
{
    public class CouchbaseProvider : IBaseRepository
    {
        private readonly IBucket _bucket;

        public CouchbaseProvider(IBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucketAsync("default").GetAwaiter().GetResult();
        }

        public Task<bool> AddToCart(int request)
        {
            var key = Guid.NewGuid().ToString();
            _bucket.Collections.(key, user);
            return "Inserted user with ID: " + key;
        }
    }
}
