namespace TestGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestResultTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        TrueAnswers = c.Int(nullable: false),
                        AllAnswers = c.Int(nullable: false),
                        Evaluation = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TestResults", new[] { "UserId" });
            DropTable("dbo.TestResults");
        }
    }
}
