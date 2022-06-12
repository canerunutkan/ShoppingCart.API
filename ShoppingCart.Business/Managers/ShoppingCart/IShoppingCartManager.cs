using ShoppingCart.Business.Managers.ShoppingCart.Models;
using ShoppingCart.Business.Models.Requests;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Managers.ShoppingCart
{
    public interface IShoppingCartManager
    {
        Task<AddShoppingCartOpResult> AddToCart(AddToCartRequest request);
    }
}
