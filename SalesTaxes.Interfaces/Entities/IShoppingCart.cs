using System;
using System.Collections.Generic;

namespace SalesTaxes.Entities
{
    public interface IShoppingCart
    {
        Guid Id { get; set; }
        IEnumerable<IShoppingCartEntry> Items { get; }
        void AddProduct(IProduct product, int quantity);
        IShoppingCartEntry GetItem(Guid id);
    }
}
