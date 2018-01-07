namespace HTMLFileCleaner.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HTMLFileContentMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentItems",
                c => new
                    {
                        ContentItemID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ContentType = c.Int(nullable: false),
                        HTMLContent_HTMLContentID = c.Int(),
                    })
                .PrimaryKey(t => t.ContentItemID)
                .ForeignKey("dbo.HTMLContent", t => t.HTMLContent_HTMLContentID)
                .Index(t => t.HTMLContent_HTMLContentID);
            
            CreateTable(
                "dbo.HTMLContent",
                c => new
                    {
                        HTMLContentID = c.Int(nullable: false, identity: true),
                        DisplayOrder = c.Int(nullable: false),
                        MainTitle = c.String(),
                        SecondaryTitle = c.String(),
                        ContentArea = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HTMLContentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentItems", "HTMLContent_HTMLContentID", "dbo.HTMLContent");
            DropIndex("dbo.ContentItems", new[] { "HTMLContent_HTMLContentID" });
            DropTable("dbo.HTMLContent");
            DropTable("dbo.ContentItems");
        }
    }
}
