using Couchbase.Extensions.DependencyInjection;
using ShoppingCart.Data.Repositories.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repositories.Couchbase
{
    public interface ICouchbaseProvider
    {
        Task<bool> AddToCartAsync(ShoppingCartItem item);
    }
}
