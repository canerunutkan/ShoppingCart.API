using ShoppingCart.Business.Models.Requests;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Managers.ShoppingCart
{
    public interface IShoppingCartManager
    {
        Task<bool> AddToCart(AddToCartRequest request);
    }
}
