namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MyCategories", newName: "Categories");
            RenameTable(name: "dbo.Providings", newName: "ProviderProducts");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            RenameColumn(table: "dbo.ProviderProducts", name: "Product", newName: "Product_ProductId");
            RenameColumn(table: "dbo.ProviderProducts", name: "Provider", newName: "Provider_Id");
            RenameIndex(table: "dbo.ProviderProducts", name: "IX_Provider", newName: "IX_Provider_Id");
            RenameIndex(table: "dbo.ProviderProducts", name: "IX_Product", newName: "IX_Product_ProductId");
            DropPrimaryKey("dbo.Factures");
            DropPrimaryKey("dbo.ProviderProducts");
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "DateProd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            AlterColumn("dbo.Providers", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Clients", "DateNaissance", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Factures", "DateAchat", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Factures", new[] { "DateAchat", "ProductId", "ClientId" });
            AddPrimaryKey("dbo.ProviderProducts", new[] { "Provider_Id", "Product_ProductId" });
            CreateIndex("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "IsBiological");
            DropColumn("dbo.Products", "IsChemical");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IsChemical", c => c.Int());
            AddColumn("dbo.Products", "IsBiological", c => c.Int());
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropPrimaryKey("dbo.ProviderProducts");
            DropPrimaryKey("dbo.Factures");
            AlterColumn("dbo.Factures", "DateAchat", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Clients", "DateNaissance", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Providers", "DateCreated", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "DateProd", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Products", "Discriminator");
            AddPrimaryKey("dbo.ProviderProducts", new[] { "Product", "Provider" });
            AddPrimaryKey("dbo.Factures", new[] { "DateAchat", "ProductId", "ClientId" });
            RenameIndex(table: "dbo.ProviderProducts", name: "IX_Product_ProductId", newName: "IX_Product");
            RenameIndex(table: "dbo.ProviderProducts", name: "IX_Provider_Id", newName: "IX_Provider");
            RenameColumn(table: "dbo.ProviderProducts", name: "Provider_Id", newName: "Provider");
            RenameColumn(table: "dbo.ProviderProducts", name: "Product_ProductId", newName: "Product");
            CreateIndex("dbo.Products", "CategoryId");
            RenameTable(name: "dbo.ProviderProducts", newName: "Providings");
            RenameTable(name: "dbo.Categories", newName: "MyCategories");
        }
    }
}
