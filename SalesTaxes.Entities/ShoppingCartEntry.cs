using SalesTaxes.Enums;
using System.Collections.Generic;

namespace SalesTaxes.Entities
{
    public class ShoppingCartEntry : IShoppingCartEntry
    {
        public int Quantity { get; set; } = 1;

        public IProduct Product { get; set; }

        public IDictionary<TaxType, decimal> Taxes { get; private set; } = new Dictionary<TaxType, decimal>();

        public decimal TaxTotal 
        { 
            get
            {
                var taxTotal = Quantity * Product.Price;
                foreach (var tax in Taxes)
                    taxTotal += tax.Value;
                return taxTotal;
            }
        }
    }
}
