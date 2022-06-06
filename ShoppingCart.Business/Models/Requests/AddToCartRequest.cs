namespace ShoppingCart.Business.Models.Requests
{
    public class AddToCartRequest
    {
        public int CustomerId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
