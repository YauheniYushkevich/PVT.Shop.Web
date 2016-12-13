namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Split : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        Postcode = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        HomeNumber = c.String(nullable: false),
                        ApartmentNumber = c.String(nullable: false),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            this.CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            this.CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            this.CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        StorageId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.StorageId)
                .Index(t => t.UserId);
            
            this.CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.String(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            this.CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                        Phone = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            this.CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            this.CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DeliveryType = c.Int(nullable: false),
                        Created = c.DateTime(precision: 7, storeType: "datetime2"),
                        Delivered = c.Boolean(nullable: false),
                        Delivery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Delivery_Id)
                .Index(t => t.Delivery_Id);
            
            this.CreateTable(
                "dbo.BasketProductIDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductCount = c.Int(nullable: false),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            this.CreateTable(
                "dbo.PropertyValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Property_Id);           
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.PropertyValues", "Property_Id", "dbo.Properties");
            this.DropForeignKey("dbo.PropertyValues", "Product_Id", "dbo.Products");
            this.DropForeignKey("dbo.Orders", "Delivery_Id", "dbo.Addresses");
            this.DropForeignKey("dbo.BasketProductIDs", "Order_Id", "dbo.Orders");
            this.DropForeignKey("dbo.Properties", "CategoryId", "dbo.Categories");
            this.DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            this.DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            this.DropForeignKey("dbo.Products", "StorageId", "dbo.Storages");
            this.DropForeignKey("dbo.Storages", "Address_Id", "dbo.Addresses");
            this.DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            this.DropForeignKey("dbo.Addresses", "Country_Id", "dbo.Countries");
            this.DropIndex("dbo.PropertyValues", new[] { "Property_Id" });
            this.DropIndex("dbo.PropertyValues", new[] { "Product_Id" });
            this.DropIndex("dbo.BasketProductIDs", new[] { "Order_Id" });
            this.DropIndex("dbo.Orders", new[] { "Delivery_Id" });
            this.DropIndex("dbo.Properties", new[] { "CategoryId" });
            this.DropIndex("dbo.Users", new[] { "Address_Id" });
            this.DropIndex("dbo.Storages", new[] { "Address_Id" });
            this.DropIndex("dbo.Products", new[] { "UserId" });
            this.DropIndex("dbo.Products", new[] { "StorageId" });
            this.DropIndex("dbo.Products", new[] { "CategoryId" });
            this.DropIndex("dbo.Addresses", new[] { "Country_Id" });
            this.DropTable("dbo.PropertyValues");
            this.DropTable("dbo.BasketProductIDs");
            this.DropTable("dbo.Orders");
            this.DropTable("dbo.Properties");
            this.DropTable("dbo.Users");
            this.DropTable("dbo.Storages");
            this.DropTable("dbo.Products");
            this.DropTable("dbo.Categories");
            this.DropTable("dbo.Countries");
            this.DropTable("dbo.Addresses");
        }
    }
}
