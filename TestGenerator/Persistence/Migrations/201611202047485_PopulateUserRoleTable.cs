namespace TestGenerator.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateUserRoleTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES (1, 'Пользователь')");
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES (2, 'Оператор')");
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES (3, 'Администратор')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM AspNetRoles WHERE Id IN (1, 2, 3)");
        }
    }
}
