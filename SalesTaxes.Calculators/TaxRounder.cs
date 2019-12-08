using System;

namespace SalesTaxes.Calculators
{
    public static class TaxRounder
    {
        public static decimal Round(decimal value)
        {
            return Math.Ceiling(value * 20) / 20;
        }
    }
}
