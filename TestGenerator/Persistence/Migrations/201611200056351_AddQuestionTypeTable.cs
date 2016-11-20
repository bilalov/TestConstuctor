namespace TestGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "QuestionTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Questions", "QuestionTypeId");
            AddForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Questions", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropColumn("dbo.Questions", "QuestionTypeId");
            DropTable("dbo.QuestionTypes");
        }
    }
}
