using SalesTaxes.Entities;
using System;
using System.Collections.Generic;

namespace SalesTaxes.Repositories
{
    public interface IShoppingCartsRepository
    {
        IEnumerable<IShoppingCart> GetAllShoppingCarts();

        IShoppingCart GetShoppingCart(Guid id);
    }
}
