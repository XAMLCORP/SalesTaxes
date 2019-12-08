using Microsoft.Extensions.DependencyInjection;

namespace SalesTaxes.Types
{
    public interface IModule
    {
        void RegisterTypes(IServiceCollection serviceCollection);
    }
}
