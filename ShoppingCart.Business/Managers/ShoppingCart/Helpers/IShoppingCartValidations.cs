using ShoppingCart.Data.Repositories.Couchbase.Entity;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Managers.ShoppingCart.Helpers
{
    public interface IShoppingCartValidations
    {
        Task<ValidationResult> Validate(ShoppingCartItem item);
    }
}
