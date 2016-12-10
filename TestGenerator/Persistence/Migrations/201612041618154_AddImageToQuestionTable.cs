namespace TestGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToQuestionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Image");
        }
    }
}
