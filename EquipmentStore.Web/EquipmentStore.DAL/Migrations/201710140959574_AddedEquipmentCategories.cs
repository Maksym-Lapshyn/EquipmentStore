namespace EquipmentStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEquipmentCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machines", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Machines", "Category");
        }
    }
}
