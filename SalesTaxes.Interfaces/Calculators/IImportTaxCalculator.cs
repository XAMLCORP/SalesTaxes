using SalesTaxes.Entities;

namespace SalesTaxes.Calculators
{
    public interface IImportTaxCalculator
    {
        void ApplyTaxes(IShoppingCartEntry shoppingCartEntry);
    }
}
