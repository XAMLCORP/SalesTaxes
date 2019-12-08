using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Entities;
using System;
using System.Collections.Generic;

namespace SalesTaxes.Repositories
{
    public class ShoppingCartsRepository : IShoppingCartsRepository
    {
        readonly IServiceProvider _container;
        readonly IProductsRepository _productsRepository;
        readonly Dictionary<Guid, IShoppingCart> _shoppingCarts = new Dictionary<Guid, IShoppingCart>();

        public ShoppingCartsRepository(IServiceProvider container, IProductsRepository productsRepository)
        {
            _container = container;
            _productsRepository = productsRepository;
            PopulateShoppingCarts();
        }

        private void PopulateShoppingCarts()
        {
            var productsRepository = _container.GetService<IProductsRepository>();
            var shoppingCart = _container.GetService<IShoppingCart>();
            shoppingCart.Id = Ids.ShoppingCartId;
            shoppingCart.AddProduct(productsRepository.GetProduct(Ids.DomesticProductId), 1);
            shoppingCart.AddProduct(productsRepository.GetProduct(Ids.ImportedProductId), 1);
            shoppingCart.AddProduct(productsRepository.GetProduct(Ids.ExemptDomesticProductId), 1);
            shoppingCart.AddProduct(productsRepository.GetProduct(Ids.ExemptImportedProductId), 1);
            _shoppingCarts.Add(Ids.ShoppingCartId, shoppingCart);
        }

        public IEnumerable<IShoppingCart> GetAllShoppingCarts()
        {
            return _shoppingCarts.Values;
        }

        public IShoppingCart GetShoppingCart(Guid id)
        {
            return _shoppingCarts[id];
        }
    }
}
