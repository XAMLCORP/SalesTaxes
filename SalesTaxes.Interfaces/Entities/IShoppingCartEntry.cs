using SalesTaxes.Enums;
using System.Collections.Generic;

namespace SalesTaxes.Entities
{
    public interface IShoppingCartEntry
    {
        int Quantity { get; set; }
        IProduct Product { get; set; }
        IDictionary<TaxType, decimal> Taxes { get; }
        decimal TaxTotal { get; }
    }
}