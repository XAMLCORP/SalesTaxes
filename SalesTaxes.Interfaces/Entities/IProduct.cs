using SalesTaxes.Enums;
using System;

namespace SalesTaxes.Entities
{
    /// <summary>
    /// Represents a product in the product catalog
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Product Identifier
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Product's Originating place of manufacture
        /// </summary>
        Origin Origin { get; set; }

        /// <summary>
        /// Price of the Product
        /// </summary>
        decimal Price { get; set; }

        /// <summary>
        /// The type of the product
        /// </summary>
        //ProductType ProductType { get; set; }
    }
}
