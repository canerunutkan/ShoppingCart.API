using System.Threading.Tasks;

namespace ShoppingCart.Data.Repositories
{
    public interface IBaseRepository
    {
        Task<bool> AddToCart(int request);
    }
}
