namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsForReturnToSupplierAfterReplaceCancelOnTransactionProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionProducts", "IsForReturnToSupplierAfterReplace", c => c.Boolean(nullable: false));
            AddColumn("dbo.TransactionProducts", "IsForReturnToSupplierAfterCancel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionProducts", "IsForReturnToSupplierAfterCancel");
            DropColumn("dbo.TransactionProducts", "IsForReturnToSupplierAfterReplace");
        }
    }
}
