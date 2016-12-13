namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateAfterMerge : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Addresses", "IsDeleted", c => c.Boolean(false));
            this.AddColumn("dbo.Countries", "IsDeleted", c => c.Boolean(false));
            this.AddColumn("dbo.Products", "IsDeleted", c => c.Boolean(false));
            this.AddColumn("dbo.Storages", "IsDeleted", c => c.Boolean(false));
            this.AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(false));
            this.AddColumn("dbo.Properties", "IsDeleted", c => c.Boolean(false));
            this.AddColumn("dbo.Orders", "IsDeleted", c => c.Boolean(false));
            this.AddColumn("dbo.BasketProductIDs", "IsDeleted", c => c.Boolean(false));
            this.AddColumn("dbo.PropertyValues", "IsDeleted", c => c.Boolean(false));
        }

        public override void Down()
        {
            this.DropColumn("dbo.PropertyValues", "IsDeleted");
            this.DropColumn("dbo.BasketProductIDs", "IsDeleted");
            this.DropColumn("dbo.Orders", "IsDeleted");
            this.DropColumn("dbo.Properties", "IsDeleted");
            this.DropColumn("dbo.Users", "IsDeleted");
            this.DropColumn("dbo.Storages", "IsDeleted");
            this.DropColumn("dbo.Products", "IsDeleted");
            this.DropColumn("dbo.Countries", "IsDeleted");
            this.DropColumn("dbo.Addresses", "IsDeleted");
        }
    }
}