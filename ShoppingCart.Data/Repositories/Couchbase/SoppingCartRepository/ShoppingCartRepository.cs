using ShoppingCart.Data.Repositories.Couchbase.Entity;
using ShoppingCart.Data.Repositories.GenericRepository;

namespace ShoppingCart.Data.Repositories.Couchbase.SoppingCartRepository
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCartItem>, IShoppingCartRepository
    {
        public ShoppingCartRepository(IShoppingCartBucketProvider bucketProvider) : base(bucketProvider)
        {

        }
    }
}
