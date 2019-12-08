using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using SalesTaxes.Entities;
using System;
using System.Collections.Generic;
using System.IO;

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


        /// <summary>
        /// In a real scenario, this would not exist and all queries would be against the real backing store or web service.
        /// </summary>
        private void PopulateShoppingCarts()
        {
            using (StreamReader reader = File.OpenText(@"./DataSource/ShoppingCarts.json"))
            {
                var json = reader.ReadToEnd();
                JObject jObject = JObject.Parse(json);
                foreach (var child in jObject.Children())
                {
                    JProperty property = (JProperty)child;
                    if (property.Name == "ShoppingCarts")
                    {
                        foreach (var root in property.Children())
                        {
                            foreach (var shoppingCartJson in root.Children())
                            {
                                var shoppingCart = _container.GetService<IShoppingCart>();
                                foreach (var propertyJson in shoppingCartJson.Children())
                                {
                                    JProperty cartProperty = (JProperty)propertyJson;
                                    if (cartProperty.Name == "Id")
                                    {
                                        shoppingCart.Id = Guid.Parse(cartProperty.Value.ToString());
                                        continue;
                                    }
                                    if (cartProperty.Name == "Products")
                                    {
                                        foreach (var productIdJson in cartProperty.Children())
                                        {
                                            JArray items = (JArray)productIdJson;
                                            for (int i = 0; i < items.Count; i++)
                                            {
                                                JValue productIdValue = (JValue)items[i];
                                                var productId = Guid.Parse(productIdValue.ToString());
                                                var product = _productsRepository.GetProduct(productId);
                                                shoppingCart.AddProduct(product, 1);
                                            }
                                        }
                                    }
                                    //JsonConvert.PopulateObject(productJson.ToString(), product);
                                    _shoppingCarts.Add(shoppingCart.Id, shoppingCart);
                                }
                            }
                        }
                    }
                }
            }
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
