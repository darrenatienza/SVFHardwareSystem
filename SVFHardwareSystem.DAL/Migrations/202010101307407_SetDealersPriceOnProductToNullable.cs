namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDealersPriceOnProductToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DealersPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DealersPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
