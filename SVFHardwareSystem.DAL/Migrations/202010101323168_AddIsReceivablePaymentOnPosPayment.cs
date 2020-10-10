namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsReceivablePaymentOnPosPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.POSPayments", "IsReceivablePayment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.POSPayments", "IsReceivablePayment");
        }
    }
}
