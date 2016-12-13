namespace PVT.Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update30112016 : DbMigration
    {
        public override void Up()
        {
            this.RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "CurrentCategoryId");
            this.RenameColumn(table: "dbo.Products", name: "StorageId", newName: "CurrentStorageId");
            this.RenameColumn(table: "dbo.Products", name: "UserId", newName: "CurrentUserId");
            this.RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_CurrentCategoryId");
            this.RenameIndex(table: "dbo.Products", name: "IX_StorageId", newName: "IX_CurrentStorageId");
            this.RenameIndex(table: "dbo.Products", name: "IX_UserId", newName: "IX_CurrentUserId");
        }
        
        public override void Down()
        {
            this.RenameIndex(table: "dbo.Products", name: "IX_CurrentUserId", newName: "IX_UserId");
            this.RenameIndex(table: "dbo.Products", name: "IX_CurrentStorageId", newName: "IX_StorageId");
            this.RenameIndex(table: "dbo.Products", name: "IX_CurrentCategoryId", newName: "IX_CategoryId");
            this.RenameColumn(table: "dbo.Products", name: "CurrentUserId", newName: "UserId");
            this.RenameColumn(table: "dbo.Products", name: "CurrentStorageId", newName: "StorageId");
            this.RenameColumn(table: "dbo.Products", name: "CurrentCategoryId", newName: "CategoryId");
        }
    }
}
