namespace EquipmentStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OutputImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        MimeType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Outputs", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Outputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        ProductSubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductSubCategories", t => t.ProductSubCategoryId, cascadeDelete: true)
                .Index(t => t.ProductSubCategoryId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        MimeType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PumpCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pumps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        Characteristics = c.String(),
                        Heads = c.String(),
                        Tubes = c.String(),
                        Costs = c.String(),
                        Weight = c.Double(nullable: false),
                        PumpCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PumpCategories", t => t.PumpCategoryId, cascadeDelete: true)
                .Index(t => t.PumpCategoryId);
            
            CreateTable(
                "dbo.PumpImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        MimeType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pumps", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PumpImages", "Id", "dbo.Pumps");
            DropForeignKey("dbo.Pumps", "PumpCategoryId", "dbo.PumpCategories");
            DropForeignKey("dbo.Products", "ProductSubCategoryId", "dbo.ProductSubCategories");
            DropForeignKey("dbo.ProductImages", "Id", "dbo.Products");
            DropForeignKey("dbo.ProductSubCategories", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.OutputImages", "Id", "dbo.Outputs");
            DropIndex("dbo.PumpImages", new[] { "Id" });
            DropIndex("dbo.Pumps", new[] { "PumpCategoryId" });
            DropIndex("dbo.ProductImages", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "ProductSubCategoryId" });
            DropIndex("dbo.ProductSubCategories", new[] { "ProductCategoryId" });
            DropIndex("dbo.OutputImages", new[] { "Id" });
            DropTable("dbo.PumpImages");
            DropTable("dbo.Pumps");
            DropTable("dbo.PumpCategories");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.ProductSubCategories");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Outputs");
            DropTable("dbo.OutputImages");
        }
    }
}
