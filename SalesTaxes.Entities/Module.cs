using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Types;

namespace SalesTaxes.Entities
{
    public class Module : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProduct,Product>();
            serviceCollection.AddTransient<IBook, Book>();
            serviceCollection.AddTransient<IFood, Food>();
            serviceCollection.AddTransient<IMedicine, Medecine>();
            serviceCollection.AddTransient<IShoppingCart, ShoppingCart>();
            serviceCollection.AddTransient<IShoppingCartEntry, ShoppingCartEntry>();
            serviceCollection.AddTransient<IReceipt, Receipt>();
        }
    }
}
