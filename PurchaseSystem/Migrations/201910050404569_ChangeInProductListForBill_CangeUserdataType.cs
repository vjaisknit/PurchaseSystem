namespace PurchaseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInProductListForBill_CangeUserdataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductListForBills", "username", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductListForBills", "username", c => c.Int(nullable: false));
        }
    }
}
