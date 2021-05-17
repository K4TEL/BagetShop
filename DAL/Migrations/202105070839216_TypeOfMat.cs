namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeOfMat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Materials", "Type_ID", "dbo.BagTypes");
            DropIndex("dbo.Materials", new[] { "Type_ID" });
            AlterColumn("dbo.Materials", "Type_ID", c => c.Guid(nullable: true, defaultValue: null));
            CreateIndex("dbo.Materials", "Type_ID");
            AddForeignKey("dbo.Materials", "Type_ID", "dbo.BagTypes", "ID", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Materials", "Type_ID", "dbo.BagTypes");
            DropIndex("dbo.Materials", new[] { "Type_ID" });
            AlterColumn("dbo.Materials", "Type_ID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Materials", "Type_ID");
            AddForeignKey("dbo.Materials", "Type_ID", "dbo.BagTypes", "ID", cascadeDelete: true);
        }
    }
}
