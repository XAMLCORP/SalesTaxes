using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SalesTaxes.Entities;
using SalesTaxes.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalesTaxes.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        readonly IServiceProvider _container;
        readonly Dictionary<Guid, IProduct> _products = new Dictionary<Guid, IProduct>(); // Local cache of products read from datastore
        public ProductsRepository(IServiceProvider container)
        {
            _container = container;
            PopulateProducts();
        }

        private void PopulateProducts()
        {
            using (StreamReader reader = File.OpenText(@"./DataSource/Products.json"))
            {
                var json = reader.ReadToEnd();
                JObject productsDocument = JObject.Parse(json);
                foreach (var child in productsDocument.Children())
                {
                    JProperty childProperty = (JProperty)child;
                    if (childProperty.Name == "Products")
                        foreach (var rootElement in childProperty.Children())
                        {
                            foreach (var productJson in rootElement.Children())
                            {
                                var type = (ProductType)((JObject)productJson).Value<int>("ProductType");
                                var product = ProductFactory.GetNewProduct(type, _container);
                                JsonConvert.PopulateObject(productJson.ToString(), product);
                                _products.Add(product.Id, product);
                            }
                        }
                }
            }
        }

        public IEnumerable<IProduct> GetAllProducts()
        {            
            return _products.Values;
        }

        public IProduct GetProduct(Guid productId)
        {
            return _products[productId];
        }
    }
}
