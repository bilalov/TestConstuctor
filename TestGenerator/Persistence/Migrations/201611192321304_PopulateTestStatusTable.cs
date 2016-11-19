namespace TestGenerator.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateTestStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TestStatus (Id, Name) VALUES (1, 'Опубликовано')");
            Sql("INSERT INTO TestStatus (Id, Name) VALUES (2, 'В черновике')");
            Sql("INSERT INTO TestStatus (Id, Name) VALUES (3, 'В ожидании публикации')");
            Sql("INSERT INTO TestStatus (Id, Name) VALUES (4, 'Завершено')");
            Sql("INSERT INTO TestStatus (Id, Name) VALUES (5, 'В архиве')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM TestStatus WHERE Id IN (1, 2, 3, 4, 5)");
        }
    }
}
