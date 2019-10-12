namespace PurchaseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductListForBill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductListForBills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.Int(nullable: false),
                        fk_custId = c.Int(nullable: false),
                        Fk_ProductId = c.Int(nullable: false),
                        productQuantity = c.Double(nullable: false),
                        price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductListForBills");
        }
    }
}
