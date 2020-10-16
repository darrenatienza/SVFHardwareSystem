namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSIDROnPurchase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "SIDR", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "SIDR");
        }
    }
}
