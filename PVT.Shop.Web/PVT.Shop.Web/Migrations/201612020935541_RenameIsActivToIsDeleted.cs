namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameIsActivToIsDeleted : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            this.DropColumn("dbo.Categories", "IsActive");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.Categories", "IsActive", c => c.Boolean(nullable: false));
            this.DropColumn("dbo.Categories", "IsDeleted");
        }
    }
}
