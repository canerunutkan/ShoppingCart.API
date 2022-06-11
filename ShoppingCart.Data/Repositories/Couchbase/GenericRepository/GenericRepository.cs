using Couchbase;
using Couchbase.KeyValue;
using ShoppingCart.Data.Repositories.Couchbase;
using ShoppingCart.Data.Repositories.Couchbase.Entity;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly IBucket Bucket;
        protected readonly ICluster Cluster;
        protected readonly ICouchbaseCollection Collection;
        public GenericRepository(IShoppingCartBucketProvider bucketProvider)
        {
            Bucket = bucketProvider.GetBucketAsync().GetAwaiter().GetResult();
            Collection = Bucket.DefaultCollection();
            Cluster = Bucket.Cluster;
        }
        public async Task<IGetResult> GetAsync(string id, GetOptions options = null)
        {
            return await Collection.GetAsync(id, options);
        }
        public async Task<IMutationResult> InsertAsync(string id, T content, InsertOptions options = null)
        {
            return await Collection.InsertAsync(id, content, options);
        }
        public async Task<IMutationResult> ReplaceAsync(string id, T content, ReplaceOptions options = null)
        {
            return await Collection.ReplaceAsync(id, content, options);
        }
        public async Task<IMutationResult> UpsertAsync(string id, T content, UpsertOptions options = null)
        {
            return await Collection.UpsertAsync(id, content, options);
        }
        public async Task RemoveAsync(string id, RemoveOptions options = null)
        {
            await Collection.RemoveAsync(id, options);
        }
        public async Task<IExistsResult> ExistsAsync(string id)
        {
            return await Collection.ExistsAsync(id);
        }
    }
}
