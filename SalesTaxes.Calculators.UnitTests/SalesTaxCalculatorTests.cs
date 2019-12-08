using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxes.Entities;
using SalesTaxes.Enums;
using SalesTaxes.Repositories;
using System;

namespace SalesTaxes.Calculators.UnitTests
{
    [TestClass]
    public class SalesTaxCalculatorTests
    {
        readonly IServiceProvider _container;
        readonly IShoppingCart _shoppingCart;
        readonly ISalesTaxCalculator _salesTaxCalculator;
        readonly IImportTaxCalculator _importTaxCalculator;

        public SalesTaxCalculatorTests()
        {
            _container = Bootstrapper.Bootstrap();
            var shoppingCartsRepository = _container.GetService<IShoppingCartsRepository>();
            _shoppingCart = shoppingCartsRepository.GetShoppingCart(Ids.ShoppingCartId);
            _importTaxCalculator = _container.GetService<IImportTaxCalculator>();
            _salesTaxCalculator = _container.GetService<ISalesTaxCalculator>();
        }

        [TestMethod]
        public void IsImportTaxCalculatedForImportedProduct()
        {
            var item = _shoppingCart.GetItem(Ids.ImportedProductId);
            _importTaxCalculator.ApplyTaxes(item);
            var calculatedTax = item.Taxes[TaxType.ImportDuty];
            Assert.AreEqual(0.5m, calculatedTax);
        }

        [TestMethod]
        public void IsImportTaxNotCalculatedForDomesticProduct()
        {
            var item = _shoppingCart.GetItem(Ids.DomesticProductId);
            _importTaxCalculator.ApplyTaxes(item);
            Assert.IsFalse(item.Taxes.ContainsKey(TaxType.ImportDuty));
        }

        [TestMethod]
        public void IsSalesTaxCalculatedForRegularProduct()
        {
            var item = _shoppingCart.GetItem(Ids.DomesticProductId);
            _salesTaxCalculator.ApplyTaxes(item);
            var calculatedTax = item.Taxes[TaxType.SalesTax];
            Assert.AreEqual(1m, calculatedTax);
        }

        [TestMethod]
        public void IsSalesTaxNotCalculatedForExemptDomesticProduct()
        {
            var item = _shoppingCart.GetItem(Ids.ExemptDomesticProductId);
            _salesTaxCalculator.ApplyTaxes(item);
            Assert.IsFalse(item.Taxes.ContainsKey(TaxType.SalesTax));
        }

        [TestMethod]
        public void IsSalesTaxCalculatedForRegularImportedProduct()
        {
            var item = _shoppingCart.GetItem(Ids.ImportedProductId);
            _salesTaxCalculator.ApplyTaxes(item);
            var calculatedTax = item.Taxes[TaxType.SalesTax];
            Assert.AreEqual(1m, calculatedTax);
        }

        [TestMethod]
        public void IsSalesTaxNotCalculatedForExemptImportedProduct()
        {
            var item = _shoppingCart.GetItem(Ids.ExemptImportedProductId);
            _salesTaxCalculator.ApplyTaxes(item);
            Assert.IsFalse(item.Taxes.ContainsKey(TaxType.SalesTax));
        }
    }
}
