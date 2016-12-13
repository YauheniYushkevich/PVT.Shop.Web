namespace PVT.Shop.Infrastructure.Common
{
    public class DeliveryAttr
    {
        public int Id { get; set; }
        public string Adress { get; set; }

        public string Phone { get; set; }

        public DeliveryType DeliveryType { get; set; }

    }
}