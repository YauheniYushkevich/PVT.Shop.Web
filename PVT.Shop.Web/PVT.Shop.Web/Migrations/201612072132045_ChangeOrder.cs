namespace PVT.Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrder : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "Created", newName: "DateAdded");
            AddColumn("dbo.Orders", "UserName", c => c.String());
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Orders", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DateAdded", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Orders", "PhoneNumber");
            DropColumn("dbo.Orders", "UserName");
            RenameColumn(table: "dbo.Orders", name: "DateAdded", newName: "Created");
        }
    }
}
