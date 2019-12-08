using SalesTaxes.Entities;
using SalesTaxes.Enums;

namespace SalesTaxes.Calculators
{
    public class SalesTaxCalculator : ISalesTaxCalculator
    {
        public void ApplyTaxes(IShoppingCartEntry shoppingCartEntry)
        {
            if (!(typeof(IBook).IsAssignableFrom(shoppingCartEntry.Product.GetType())
                || typeof(IMedicine).IsAssignableFrom(shoppingCartEntry.Product.GetType())
                || typeof(IFood).IsAssignableFrom(shoppingCartEntry.Product.GetType()))) // Exemptions list could be configured
            {
                decimal tax = TaxRounder.Round(shoppingCartEntry.Product.Price * shoppingCartEntry.Quantity * 0.1m);
                shoppingCartEntry.Taxes.Add(TaxType.SalesTax, tax);
            }
        }
    }
}
