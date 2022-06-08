namespace ShoppingCart.Data.Repositories.Models
{
    public class ShoppingCartItem
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
