using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Entities;
using System;

namespace SalesTaxes.Calculators
{
    public class ReceiptCalculator : IReceiptCalculator
    {
        readonly IServiceProvider _container;

        public ReceiptCalculator(IServiceProvider container)
        {
            _container = container;
        }

        public IReceipt CalculateReceipt(IShoppingCart shoppingCart)
        {
            var receipt = _container.GetService<IReceipt>();
            receipt.ShoppingCart = shoppingCart;

            var salesTaxCalculator = _container.GetService<ISalesTaxCalculator>();
            var importTaxCalculator = _container.GetService<IImportTaxCalculator>();

            foreach(var item in shoppingCart.Items)
            {
                salesTaxCalculator.ApplyTaxes(item);
                importTaxCalculator.ApplyTaxes(item);
            }
            CalculateTotals(receipt);

            return receipt;
        }

        private void CalculateTotals(IReceipt receipt)
        {
            var productTotal = 0m;
            var taxTotal = 0m;
            foreach (var item in receipt.ShoppingCart.Items)
            {
                productTotal += item.Product.Price * item.Quantity;
                foreach(var tax in item.Taxes)
                    taxTotal += tax.Value;
            }            
            receipt.Total = productTotal + taxTotal;
            receipt.TaxTotal = receipt.Total - productTotal;
        }
    }
}
