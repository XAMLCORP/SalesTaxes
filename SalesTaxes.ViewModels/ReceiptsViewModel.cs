using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Calculators;
using SalesTaxes.Entities;
using SalesTaxes.Repositories;
using System;
using System.Collections.Generic;

namespace SalesTaxes.ViewModels
{
    public class ReceiptsViewModel : IReceiptsViewModel
    {
        readonly IServiceProvider _container;
        readonly IShoppingCartsRepository _shoppingCartsRepository;

        public ReceiptsViewModel(IServiceProvider container, IShoppingCartsRepository shoppingCartsRepository)
        {
            _container = container;
            _shoppingCartsRepository = shoppingCartsRepository;
        }

        public IList<IReceipt> Receipts { get; private set; } = new List<IReceipt>();

        public void GetReceipts()
        {
            var shoppingCarts = _shoppingCartsRepository.GetAllShoppingCarts();
            var receiptCalculator = _container.GetService<IReceiptCalculator>();
            foreach (var shoppingCart in shoppingCarts)
                Receipts.Add(receiptCalculator.CalculateReceipt(shoppingCart));
        }
    }
}
