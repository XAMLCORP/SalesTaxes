using SalesTaxes.Entities;
using System.Collections.Generic;

namespace SalesTaxes.ViewModels
{
    public interface IReceiptsViewModel
    {
        void GetReceipts();

        IList<IReceipt> Receipts { get; }
    }
}
