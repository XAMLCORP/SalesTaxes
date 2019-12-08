using SalesTaxes.Entities;

namespace SalesTaxes.Calculators
{
    public interface IReceiptCalculator
    {
        IReceipt CalculateReceipt(IShoppingCart shoppingCart);
    }
}
