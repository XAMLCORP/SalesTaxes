using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace SalesTaxes.Entities
{
    public class ShoppingCart : IShoppingCart
    {
        readonly IServiceProvider _container;
        readonly Dictionary<Guid, IShoppingCartEntry> _products = new Dictionary<Guid, IShoppingCartEntry>();
        public ShoppingCart(IServiceProvider container)
        {
            _container = container;
        }

        public Guid Id { get; set; }

        public IEnumerable<IShoppingCartEntry> Items 
        { 
            get { return _products.Values; }
        }

        public IShoppingCartEntry GetItem(Guid id)
        {
            return _products[id];
        }

        public void AddProduct(IProduct product, int quantity = 1)
        {
            if (quantity == 0)
                throw new ArgumentException("Quantity must be greater than 0");
            if (_products.ContainsKey(product.Id))
            {
                _products[product.Id].Quantity += quantity;
                return;
            }
            var entry = _container.GetService<IShoppingCartEntry>();
            entry.Product = product;
            entry.Quantity = quantity;
            _products.Add(product.Id, entry);
        }
    }
}
