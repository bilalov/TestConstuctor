using Microsoft.AspNet.Identity;
using TestGenerator.Core.Models;

namespace TestGenerator.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddRootAdmin : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO  AspNetUsers (Id, NickName, Email, UserName) VALUES (5, 'Андрей Билалов', 'bilalov-a@list.ru', 'bilalov-a@list.ru')");
            Sql("INSERT INTO  AspNetUserRoles (UserId, RoleId) VALUES (5, 1)");
            Sql("INSERT INTO  AspNetUserRoles (UserId, RoleId) VALUES (5, 2)");
            Sql("INSERT INTO  AspNetUserRoles (UserId, RoleId) VALUES (5, 3)");
           
        }
        
        public override void Down()
        {
            Sql("DELETE FROM AspNetUserRoles WHERE UserId IN (5)");
            Sql("DELETE FROM AspNetUsers WHERE Id IN (5)");
           ;
        }
    }
}
