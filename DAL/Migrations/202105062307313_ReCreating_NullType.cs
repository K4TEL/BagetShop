namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReCreating_NullType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bagets",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Amount = c.Int(nullable: true),
                        Width = c.Double(nullable: true),
                        Lenght = c.Double(nullable: true),
                        Order_ID = c.Guid(nullable: false),
                        Type_ID = c.Guid(nullable: true),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.Order_ID, cascadeDelete: true)
                .ForeignKey("dbo.BagTypes", t => t.Type_ID, cascadeDelete: false)
                .Index(t => t.Order_ID)
                .Index(t => t.Type_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Customer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BagTypes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Amount = c.Double(nullable: false),
                        Name = c.String(nullable: false),
                        Storage = c.Boolean(nullable: false),
                        Unit = c.Int(nullable: false),
                        Type_ID = c.Guid(nullable: true),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BagTypes", t => t.Type_ID, cascadeDelete: true)
                .Index(t => t.Type_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bagets", "Type_ID", "dbo.BagTypes");
            DropForeignKey("dbo.Materials", "Type_ID", "dbo.BagTypes");
            DropForeignKey("dbo.Bagets", "Order_ID", "dbo.Orders");
            DropIndex("dbo.Materials", new[] { "Type_ID" });
            DropIndex("dbo.Bagets", new[] { "Type_ID" });
            DropIndex("dbo.Bagets", new[] { "Order_ID" });
            DropTable("dbo.Materials");
            DropTable("dbo.BagTypes");
            DropTable("dbo.Orders");
            DropTable("dbo.Bagets");
        }
    }
}
