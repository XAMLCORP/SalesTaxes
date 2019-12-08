using SalesTaxes.Entities;
using System;
using System.Collections.Generic;

namespace SalesTaxes.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<IProduct> GetAllProducts();
        IProduct GetProduct(Guid productId);
    }
}
