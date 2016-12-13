using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PVT.Shop.Infrastructure.Services;

namespace PVT.Shop.Infrastructure.Common
{
    public class Basket : IBasketService
    {
        private List<BasketItem> _basketItems = new List<BasketItem>();
        public IEnumerable<BasketItem> BasketItems
        {
            get { return _basketItems; }
        }

        public void AddItem(Product product, int quantity)
        {
            BasketItem basketItem = _basketItems
                .Where(i => i.Product.Id == product.Id)
                .FirstOrDefault();
            if (basketItem == null)
            {
                _basketItems.Add(new BasketItem() { Product = product, Quantity = quantity });
            }
            else
            {
                basketItem.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            _basketItems.RemoveAll(i => i.Product.Id == product.Id);
        }

        public decimal GetItemsSum()
        {
            return _basketItems.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear()
        {
            _basketItems.Clear();
        }

    }
}
