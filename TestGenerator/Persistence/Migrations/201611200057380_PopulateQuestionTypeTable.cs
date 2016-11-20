namespace TestGenerator.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateQuestionTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO QuestionTypes (Id, Name) VALUES (1, 'Выбрать ответ')");
            Sql("INSERT INTO QuestionTypes (Id, Name) VALUES (2, 'Написать ответ')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM QuestionTypes WHERE Id IN (1, 2,)");
        }
    }
}
