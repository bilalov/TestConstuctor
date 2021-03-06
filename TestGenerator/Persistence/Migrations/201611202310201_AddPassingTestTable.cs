namespace TestGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPassingTestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permissions",
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
            DropForeignKey("dbo.Permissions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permissions", "TestId", "dbo.Tests");
            DropIndex("dbo.Permissions", new[] { "UserId" });
            DropIndex("dbo.Permissions", new[] { "TestId" });
            DropTable("dbo.Permissions");
        }
    }
}
