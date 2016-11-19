namespace TestGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTestTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "TestStatus_Id", "dbo.TestStatus");
            DropIndex("dbo.Tests", new[] { "TestStatus_Id" });
            DropColumn("dbo.Tests", "TestStatusId");
            RenameColumn(table: "dbo.Tests", name: "TestStatus_Id", newName: "TestStatusId");
            AlterColumn("dbo.Tests", "TestStatusId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tests", "TestStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Tests", "TestStatusId");
            AddForeignKey("dbo.Tests", "TestStatusId", "dbo.TestStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "TestStatusId", "dbo.TestStatus");
            DropIndex("dbo.Tests", new[] { "TestStatusId" });
            AlterColumn("dbo.Tests", "TestStatusId", c => c.Byte());
            AlterColumn("dbo.Tests", "TestStatusId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Tests", name: "TestStatusId", newName: "TestStatus_Id");
            AddColumn("dbo.Tests", "TestStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tests", "TestStatus_Id");
            AddForeignKey("dbo.Tests", "TestStatus_Id", "dbo.TestStatus", "Id");
        }
    }
}
