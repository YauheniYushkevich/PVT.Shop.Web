using System.Collections.Generic;
using System;

namespace PVT.Shop.Infrastructure.Common
{
    public enum DeliveryType
    {
        Сourier,
        Self
    }
    public class Order : BaseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Address Delivery { get; set; }

        public DeliveryType DeliveryType { get; set; }

        public virtual List<BasketProductID> BasketProductID { get; set; }

        public double TotalCost { get; }

        public DateTime DateAdded { get; set; }

        public bool Delivered { get; set; }

    }
}



