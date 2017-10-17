namespace EquipmentStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedextrainfofrommachineclass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Machines", "CuttingFrequency");
            DropColumn("dbo.Machines", "MaximumPackageSize");
            DropColumn("dbo.Machines", "PackageMaterial");
            DropColumn("dbo.Machines", "MaxMoldingDepth");
            DropColumn("dbo.Machines", "Voltage");
            DropColumn("dbo.Machines", "Size");
            DropColumn("dbo.Machines", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Machines", "Weight", c => c.Int(nullable: false));
            AddColumn("dbo.Machines", "Size", c => c.String());
            AddColumn("dbo.Machines", "Voltage", c => c.String());
            AddColumn("dbo.Machines", "MaxMoldingDepth", c => c.String());
            AddColumn("dbo.Machines", "PackageMaterial", c => c.String());
            AddColumn("dbo.Machines", "MaximumPackageSize", c => c.String());
            AddColumn("dbo.Machines", "CuttingFrequency", c => c.String());
        }
    }
}
