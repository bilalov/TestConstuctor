namespace TestGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestForeignKeyToTestResultTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TestResults", "TestId");
            AddForeignKey("dbo.TestResults", "TestId", "dbo.Tests", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "TestId", "dbo.Tests");
            DropIndex("dbo.TestResults", new[] { "TestId" });
        }
    }
}
