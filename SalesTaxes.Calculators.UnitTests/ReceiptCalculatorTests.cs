using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxes.Entities;
using SalesTaxes.Repositories;
using System;

namespace SalesTaxes.Calculators.UnitTests
{
    [TestClass]
    public class ReceiptCalculatorTests
    {
        readonly IServiceProvider _container;
        readonly IReceipt _receipt;

        public ReceiptCalculatorTests()
        {
            _container = Bootstrapper.Bootstrap();
            var shoppingCartsRepository = _container.GetService<IShoppingCartsRepository>();
            var shoppingCart = shoppingCartsRepository.GetShoppingCart(Ids.ShoppingCartId);
            var receiptCalculator = _container.GetService<IReceiptCalculator>();
            _receipt = receiptCalculator.CalculateReceipt(shoppingCart);
        }

        [TestMethod]
        public void DoesReceiptAddUp()
        {
            Assert.AreEqual(43m, _receipt.Total);
        }

        [TestMethod]
        public void DoTaxesAddUp()
        {
            Assert.AreEqual(3m, _receipt.TaxTotal);
        }
    }
}
