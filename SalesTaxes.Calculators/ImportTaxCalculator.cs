using SalesTaxes.Entities;
using SalesTaxes.Enums;

namespace SalesTaxes.Calculators
{
    public class ImportTaxCalculator : IImportTaxCalculator
    {
        public void ApplyTaxes(IShoppingCartEntry shoppingCartEntry)
        {
            if (shoppingCartEntry.Product.Origin == Origin.Foreign)
            {
                decimal tax = TaxRounder.Round(shoppingCartEntry.Product.Price * shoppingCartEntry.Quantity * 0.05m);
                shoppingCartEntry.Taxes.Add(TaxType.ImportDuty, tax);
            }
        }
    }
}
