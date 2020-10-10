namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceOnTransactionProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionProducts", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionProducts", "Price");
        }
    }
}
