namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bagets", "Type_ID", "dbo.BagTypes");
            DropIndex("dbo.Bagets", new[] { "Type_ID" });
            AlterColumn("dbo.Bagets", "Type_ID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Bagets", "Type_ID");
            AddForeignKey("dbo.Bagets", "Type_ID", "dbo.BagTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bagets", "Type_ID", "dbo.BagTypes");
            DropIndex("dbo.Bagets", new[] { "Type_ID" });
            AlterColumn("dbo.Bagets", "Type_ID", c => c.Guid());
            CreateIndex("dbo.Bagets", "Type_ID");
            AddForeignKey("dbo.Bagets", "Type_ID", "dbo.BagTypes", "ID");
        }
    }
}
