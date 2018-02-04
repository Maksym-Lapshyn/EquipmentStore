namespace EquipmentStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shitcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pumps", "Heads4", c => c.String());
            AddColumn("dbo.Pumps", "Tubes4", c => c.String());
            AddColumn("dbo.Pumps", "Costs4", c => c.String());
            AddColumn("dbo.Pumps", "Weight4", c => c.Double(nullable: false));
            AddColumn("dbo.Pumps", "Heads2", c => c.String());
            AddColumn("dbo.Pumps", "Tubes2", c => c.String());
            AddColumn("dbo.Pumps", "Costs2", c => c.String());
            AddColumn("dbo.Pumps", "Weight2", c => c.Double(nullable: false));
            AddColumn("dbo.Pumps", "Heads3", c => c.String());
            AddColumn("dbo.Pumps", "Tubes3", c => c.String());
            AddColumn("dbo.Pumps", "Costs3", c => c.String());
            AddColumn("dbo.Pumps", "Weight3", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pumps", "Weight3");
            DropColumn("dbo.Pumps", "Costs3");
            DropColumn("dbo.Pumps", "Tubes3");
            DropColumn("dbo.Pumps", "Heads3");
            DropColumn("dbo.Pumps", "Weight2");
            DropColumn("dbo.Pumps", "Costs2");
            DropColumn("dbo.Pumps", "Tubes2");
            DropColumn("dbo.Pumps", "Heads2");
            DropColumn("dbo.Pumps", "Weight4");
            DropColumn("dbo.Pumps", "Costs4");
            DropColumn("dbo.Pumps", "Tubes4");
            DropColumn("dbo.Pumps", "Heads4");
        }
    }
}
