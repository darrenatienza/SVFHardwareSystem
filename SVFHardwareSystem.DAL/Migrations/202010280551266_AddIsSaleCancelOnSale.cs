namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSaleCancelOnSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "IsSaleCancel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "IsSaleCancel");
        }
    }
}
