namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Categories", "IsActive", c => c.Boolean(nullable: false));
            this.AddColumn("dbo.Categories", "IsSheet", c => c.Boolean(nullable: false));
            this.AddColumn("dbo.Categories", "Parent_Id", c => c.Int());
            this.CreateIndex("dbo.Categories", "Parent_Id");
            this.AddForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            this.DropIndex("dbo.Categories", new[] { "Parent_Id" });
            this.DropColumn("dbo.Categories", "Parent_Id");
            this.DropColumn("dbo.Categories", "IsSheet");
            this.DropColumn("dbo.Categories", "IsActive");
        }
    }
}
