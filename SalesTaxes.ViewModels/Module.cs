using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Types;

namespace SalesTaxes.ViewModels
{
    public class Module : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IReceiptsViewModel,ReceiptsViewModel>();
        }
    }
}
