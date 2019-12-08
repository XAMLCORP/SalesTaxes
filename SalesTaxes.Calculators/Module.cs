using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Types;

namespace SalesTaxes.Calculators
{
    public class Module : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISalesTaxCalculator, SalesTaxCalculator>();
            serviceCollection.AddSingleton<IImportTaxCalculator, ImportTaxCalculator>();
            serviceCollection.AddSingleton<IReceiptCalculator, ReceiptCalculator>();
        }
    }
}
