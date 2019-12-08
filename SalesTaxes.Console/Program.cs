using Microsoft.Extensions.DependencyInjection;

namespace SalesTaxes.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrapper.Bootstrap();
            var controller = container.GetService<IReceiptsController>();
            controller.DisplayReceipts();
        }
    }
}
