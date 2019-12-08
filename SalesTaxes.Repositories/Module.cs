using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Types;

namespace SalesTaxes.Repositories
{
    public class Module : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IProductsRepository, ProductsRepository>();
            serviceCollection.AddSingleton<IShoppingCartsRepository, ShoppingCartsRepository>();
        }
    }
}
