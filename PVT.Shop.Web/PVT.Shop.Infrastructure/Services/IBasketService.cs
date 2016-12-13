using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PVT.Shop.Infrastructure.Common;

namespace PVT.Shop.Infrastructure.Services
{
    public interface IBasketService
    {
        IEnumerable<BasketItem> BasketItems { get; }

        void AddItem(Product product, int quantity);
        void Clear();
        decimal GetItemsSum();
        void RemoveItem(Product product);
    }
}
