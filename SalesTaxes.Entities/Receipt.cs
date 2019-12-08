using System;

namespace SalesTaxes.Entities
{
    public class Receipt : IReceipt
    {
        public Guid Id { get; set; }
        public IShoppingCart ShoppingCart { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal Total { get; set; }
    }
}
