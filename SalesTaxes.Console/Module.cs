using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Types;

namespace SalesTaxes.Console
{
    public class Module : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IReceiptsController, ReceiptsController>();
        }
    }
}
