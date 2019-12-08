using SalesTaxes.Enums;
using SalesTaxes.ViewModels;

namespace SalesTaxes.Console
{
    public class ReceiptsController : IReceiptsController
    {
        readonly IReceiptsViewModel _viewModel;

        public ReceiptsController(IReceiptsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void DisplayReceipts()
        {
            _viewModel.GetReceipts();

            foreach (var receipt in _viewModel.Receipts)
            {
                foreach (var item in receipt.ShoppingCart.Items)
                    System.Console.WriteLine(item.Quantity + (item.Product.Origin == Origin.Foreign ? " Imported" : string.Empty) + " " + item.Product.Name + ": " + item.TaxTotal.ToString(string.Format("0.00")));
                System.Console.WriteLine("Sales Taxes: " + receipt.TaxTotal.ToString(string.Format("0.00")) + " Total: " + receipt.Total.ToString(string.Format("0.00")));
                System.Console.WriteLine();
            }
            System.Console.ReadKey();
        }
    }
}
