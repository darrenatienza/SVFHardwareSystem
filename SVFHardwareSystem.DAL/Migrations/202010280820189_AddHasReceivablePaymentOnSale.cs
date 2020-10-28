namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasReceivablePaymentOnSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "HasReceivablePayment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "HasReceivablePayment");
        }
    }
}
