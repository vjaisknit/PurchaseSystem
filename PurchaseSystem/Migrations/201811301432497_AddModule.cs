namespace PurchaseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModuleMsts",
                c => new
                    {
                        pk_moduleid = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        ModuleDesc = c.String(),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        AreaName = c.String(),
                        ImgUrl = c.String(),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pk_moduleid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModuleMsts");
        }
    }
}
