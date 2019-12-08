using SalesTaxes.Enums;
using System;

namespace SalesTaxes.Entities
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Origin Origin { get; set; } = Origin.Domestic;
        public decimal Price { get; set; }
    }
}
