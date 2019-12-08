using System;

namespace SalesTaxes.Entities
{
    public interface IReceipt
    {
        Guid Id { get; set; }

        IShoppingCart ShoppingCart { get; set; }

        decimal TaxTotal { get; set; }

        decimal Total { get; set; }
    }
}
