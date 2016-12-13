namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.ModelConfiguration;
    using Infrastructure.Common;

    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.DeliveryType).IsRequired();
        //    this.Property(p => p.DateAdded).IsOptional().HasColumnName("Created").HasColumnType("datetime2");
        }
    }
}