namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class config_add : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BagTypes", newName: "Types");
            AlterColumn("dbo.Orders", "Customer", c => c.String(maxLength: 100));
            AlterColumn("dbo.Types", "Title", c => c.String(maxLength: 20));
            AlterColumn("dbo.Materials", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Materials", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Types", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Customer", c => c.String(nullable: false));
            RenameTable(name: "dbo.Types", newName: "BagTypes");
        }
    }
}
