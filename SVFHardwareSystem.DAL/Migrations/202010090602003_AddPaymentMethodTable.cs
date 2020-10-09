namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentMethodTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PaymentMethodID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentMethods");
        }
    }
}
