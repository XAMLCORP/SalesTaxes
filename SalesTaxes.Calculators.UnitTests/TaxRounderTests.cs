using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesTaxes.Calculators.UnitTests
{
    [TestClass]
    public class TaxRounderTests
    {
        [TestMethod]
        public void Rounding0()
        {
            var value = 11.00m;
            var output = TaxRounder.Round(value);
            Assert.AreEqual(11.00m, output);
        }

        [TestMethod]
        public void RoundingFraction()
        {
            var value = 11.005m;
            var output = TaxRounder.Round(value);
            Assert.AreEqual(11.05m, output);
        }

        [TestMethod]
        public void Rounding5()
        {
            var value = 11.05m;
            var output = TaxRounder.Round(value);
            Assert.AreEqual(11.05m, output);
        }

        [TestMethod]
        public void RoundUp()
        {
            var value = 11.01m;
            var output = TaxRounder.Round(value);
            Assert.AreEqual(11.05m, output);
        }
    }
}
