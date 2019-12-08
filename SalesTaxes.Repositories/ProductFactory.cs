using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Entities;
using SalesTaxes.Enums;
using System;

namespace SalesTaxes.Repositories
{
    internal static class ProductFactory
    {
        public static IProduct GetNewProduct(ProductType productType, IServiceProvider container)
        {
            switch (productType)
            {
                case ProductType.Book:
                    return container.GetService<IBook>();
                case ProductType.Food:
                    return container.GetService<IFood>();
                case ProductType.Medicine:
                    return container.GetService<IMedicine>();
                default: // ProductType.Other
                    return container.GetService<IProduct>();
            }
        }
    }
}
