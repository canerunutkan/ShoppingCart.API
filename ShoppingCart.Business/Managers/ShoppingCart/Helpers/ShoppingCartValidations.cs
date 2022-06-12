using ShoppingCart.Data.Repositories.Couchbase.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Managers.ShoppingCart.Helpers
{
    public class ShoppingCartValidations : IShoppingCartValidations
    {
        public async Task<ValidationResult> Validate(ShoppingCartItem item)
        {
            ValidationResult result = new ValidationResult()
            {
                IsSuccess = true,
                Message = "Operation Succeed"
            };

            if (!await CheckStocks(item.Quantity))
            {
                result.IsSuccess = false;
                result.Message = "There is not enough stocks for operation!";
            }

            if (!await CheckQuantity(item.Quantity))
            {
                result.IsSuccess = false;
                result.Message = "Max quantitiy reached for product!";
            }

            return result;
        }

        private async Task<bool> CheckStocks(int quantity)
        {
            //burada stock servise gidilir ve async kontroller yapılır
            if (quantity > 20)
                return false;

            return true;
        }

        private async Task<bool> CheckQuantity(int quantity)
        {
            if (quantity > 10)
                return false;

            return true;
        }
    }

    public class ValidationResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
