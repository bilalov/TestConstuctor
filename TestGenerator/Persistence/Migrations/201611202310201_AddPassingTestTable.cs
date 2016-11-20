namespace TestGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPassingTestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passings",
                c => new
                    {
                        TestId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TestId, t.UserId })
                .ForeignKey("dbo.Tests", t => t.TestId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TestId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Passings", "TestId", "dbo.Tests");
            DropIndex("dbo.Passings", new[] { "UserId" });
            DropIndex("dbo.Passings", new[] { "TestId" });
            DropTable("dbo.Passings");
        }
    }
}
