using ShoppingCart.Data.Repositories.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repositories
{
    public interface IBaseRepository
    {
        Task<bool> AddToCartAsync(ShoppingCartItem item);
    }
}
