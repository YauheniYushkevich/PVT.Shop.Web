namespace PVT.Shop.Infrastructure.Common
{
    public class BasketProductID : BaseModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductCount { get; set; }

        public decimal TotalCost { get; set; }

        public decimal Discount { get; set; }

    }
}
