namespace EquipmentStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LabourImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MimeType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Labours",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LabourImages", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MachineImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MimeType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        CuttingFrequency = c.String(),
                        MaximumPackageSize = c.String(),
                        PackageMaterial = c.String(),
                        MaxMoldingDepth = c.String(),
                        Voltage = c.String(),
                        Size = c.String(),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MachineImages", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.OutputImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MimeType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Outputs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OutputImages", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outputs", "Id", "dbo.OutputImages");
            DropForeignKey("dbo.Machines", "Id", "dbo.MachineImages");
            DropForeignKey("dbo.Labours", "Id", "dbo.LabourImages");
            DropIndex("dbo.Outputs", new[] { "Id" });
            DropIndex("dbo.Machines", new[] { "Id" });
            DropIndex("dbo.Labours", new[] { "Id" });
            DropTable("dbo.Outputs");
            DropTable("dbo.OutputImages");
            DropTable("dbo.Machines");
            DropTable("dbo.MachineImages");
            DropTable("dbo.Labours");
            DropTable("dbo.LabourImages");
        }
    }
}
