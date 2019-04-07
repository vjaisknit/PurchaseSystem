namespace PurchaseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerMsts",
                c => new
                    {
                        pk_Custid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        MobNo = c.String(),
                    })
                .PrimaryKey(t => t.pk_Custid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerMsts");
        }
    }
}
