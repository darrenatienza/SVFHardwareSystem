namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveConstraintOfSupplierOnProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "SupplierID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Products", "SupplierID");
            AddForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers", "SupplierID");
        }
    }
}
