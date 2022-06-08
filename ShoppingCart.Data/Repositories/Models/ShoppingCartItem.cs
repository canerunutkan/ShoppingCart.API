﻿namespace ShoppingCart.Data.Repositories.Models
{
    public class ShoppingCartItem : BaseEntity
    {
        public override string Type => "ShoppingCartItem";

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
