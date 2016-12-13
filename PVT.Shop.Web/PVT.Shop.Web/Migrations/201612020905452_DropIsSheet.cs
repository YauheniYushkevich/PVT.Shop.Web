namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class DropIsSheet : DbMigration
    {
        public override void Up()
        {
            this.DropColumn("dbo.Categories", "IsSheet");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.Categories", "IsSheet", c => c.Boolean(nullable: false));
        }
    }
}
