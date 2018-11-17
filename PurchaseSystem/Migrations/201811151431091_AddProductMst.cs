namespace PurchaseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductMst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductMsts",
                c => new
                    {
                        pk_ProductId = c.Int(nullable: false, identity: true),
                        fk_prodtypeid = c.Int(nullable: false),
                        ProductName = c.String(),
                        oriPrice = c.Double(nullable: false),
                        sellingUpToPrice = c.Double(nullable: false),
                        productQuantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.pk_ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductMsts");
        }
    }
}
