namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalesTransactionDateToSales : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.POSTransactions", "SalesTransactionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.POSTransactions", "SalesTransactionDate");
        }
    }
}
