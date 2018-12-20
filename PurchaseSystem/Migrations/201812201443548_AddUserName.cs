namespace PurchaseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductMsts", "username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductMsts", "username");
        }
    }
}
