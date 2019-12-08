using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Entities;
using SalesTaxes.Enums;
using System;
using System.Collections.Generic;

namespace SalesTaxes.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        readonly IServiceProvider _container;
        readonly Dictionary<Guid, IProduct> _products = new Dictionary<Guid, IProduct>();
        public ProductsRepository(IServiceProvider container)
        {
            _container = container;
            PopulateProducts();
        }

        private void PopulateProducts()
        {
            var domesticProduct = _container.GetService<IProduct>();
            domesticProduct.Id = Ids.DomesticProductId;
            domesticProduct.Name = "Domestic Product";
            domesticProduct.Origin = Origin.Domestic;
            domesticProduct.Price = 10;
            _products.Add(Ids.DomesticProductId, domesticProduct);

            var importedProduct = _container.GetService<IProduct>();
            importedProduct.Id = Ids.ImportedProductId;
            importedProduct.Name = "Imported Product";
            importedProduct.Origin = Origin.Foreign;
            importedProduct.Price = 10;
            _products.Add(Ids.ImportedProductId, importedProduct);

            var exemptDomesticProduct = _container.GetService<IBook>();
            exemptDomesticProduct.Id = Ids.ExemptDomesticProductId;
            exemptDomesticProduct.Name = "Exempt Domestic Product";
            exemptDomesticProduct.Origin = Origin.Domestic;
            exemptDomesticProduct.Price = 10;
            _products.Add(Ids.ExemptDomesticProductId, exemptDomesticProduct);

            var exemptImportedProduct = _container.GetService<IBook>();
            exemptImportedProduct.Id = Ids.ExemptImportedProductId;
            exemptImportedProduct.Name = "Exempt Imported Product";
            exemptImportedProduct.Origin = Origin.Foreign;
            exemptImportedProduct.Price = 10;
            _products.Add(Ids.ExemptImportedProductId, exemptImportedProduct);
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
