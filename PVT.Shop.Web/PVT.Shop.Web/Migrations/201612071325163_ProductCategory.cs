namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ProductCategory : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Categories", "Icon", c => c.String());
            this.AddColumn("dbo.Products", "Display", c => c.Boolean(false));
            this.AlterColumn("dbo.Products", "Image", c => c.String(false));
        }
        
        public override void Down()
        {
            this.AlterColumn("dbo.Products", "Image", c => c.String());
            this.DropColumn("dbo.Products", "Display");
            this.DropColumn("dbo.Categories", "Icon");
        }
    }
}
