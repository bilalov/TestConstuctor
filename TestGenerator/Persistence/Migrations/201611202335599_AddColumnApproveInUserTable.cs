namespace TestGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnApproveInUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsApproved");
        }
    }
}
