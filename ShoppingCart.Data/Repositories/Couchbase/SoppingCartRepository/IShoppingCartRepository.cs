using System.Threading.Tasks;
using ShoppingCart.Data.Repositories.GenericRepository;
using ShoppingCart.Data.Repositories.Couchbase.Entity;

namespace ShoppingCart.Data.Repositories.Couchbase.SoppingCartRepository
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCartItem>
    {

    }
}
