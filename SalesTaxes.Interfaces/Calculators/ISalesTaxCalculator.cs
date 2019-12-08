using SalesTaxes.Entities;

namespace SalesTaxes.Calculators
{
    public interface ISalesTaxCalculator
    {
        void ApplyTaxes(IShoppingCartEntry shoppingCartEntry);
    }
}
