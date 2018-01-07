namespace HTMLFileCleaner.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HTMLFileContentMigrations1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.W3SVCLogFile",
                c => new
                    {
                        W3SVCLogFileID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Time = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SourceSitename = c.String(),
                        SourceIP = c.String(),
                        CSMethod = c.String(),
                        CSUriStem = c.String(),
                        CSUriQuery = c.String(),
                        SPort = c.Int(nullable: false),
                        CsUsername = c.String(),
                        ClientIP = c.String(),
                        CsVersion = c.String(),
                        CsUserAgent = c.String(),
                        CsCookie = c.String(),
                        CsReferer = c.String(),
                        ScStatus = c.Int(nullable: false),
                        ScSubStatus = c.Int(nullable: false),
                        ScWin32Status = c.Int(nullable: false),
                        ScBytes = c.Int(nullable: false),
                        CsBytes = c.Int(nullable: false),
                        TimeTaken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.W3SVCLogFileID);
            
            CreateTable(
                "dbo.W3SVCLogFilesProcessed",
                c => new
                    {
                        W3SVCLogFilesProcessedID = c.Int(nullable: false, identity: true),
                        fileName = c.String(),
                        DateProcessed = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.W3SVCLogFilesProcessedID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.W3SVCLogFilesProcessed");
            DropTable("dbo.W3SVCLogFile");
        }
    }
}
