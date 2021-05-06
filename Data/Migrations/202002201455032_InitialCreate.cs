namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 200),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        imageName = c.String(),
                        DateProd = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CategoryId = c.Int(nullable: false),
                        Herbs = c.String(),
                        LabName = c.String(),
                        City = c.String(),
                        StreetAddress = c.String(),
                        IsBiological = c.Int(),
                        IsChemical = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.MyCategories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Providings",
                c => new
                    {
                        Product = c.Int(nullable: false),
                        Provider = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product, t.Provider })
                .ForeignKey("dbo.Products", t => t.Product, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.Provider, cascadeDelete: true)
                .Index(t => t.Product)
                .Index(t => t.Provider);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Providings", "Provider", "dbo.Providers");
            DropForeignKey("dbo.Providings", "Product", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.MyCategories");
            DropIndex("dbo.Providings", new[] { "Provider" });
            DropIndex("dbo.Providings", new[] { "Product" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Providings");
            DropTable("dbo.Providers");
            DropTable("dbo.Products");
            DropTable("dbo.MyCategories");
        }
    }
}
