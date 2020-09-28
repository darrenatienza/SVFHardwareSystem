namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantityToReplaceAndCancelOnTransactionProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionProducts", "QuantityToReplace", c => c.Int(nullable: false));
            AddColumn("dbo.TransactionProducts", "QuantityToCancel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionProducts", "QuantityToCancel");
            DropColumn("dbo.TransactionProducts", "QuantityToReplace");
        }
    }
}
