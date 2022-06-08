using Couchbase.Extensions.DependencyInjection;

namespace ShoppingCart.Data.Repositories.Couchbase
{
    public interface IShoppingCartBucketProvider : INamedBucketProvider
    {
        public new string BucketName => "shoppingcart";
    }
}
