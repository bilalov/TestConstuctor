namespace TestGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPermissionToTestTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Permissions", newName: "PermissionForTests");
            AddColumn("dbo.PermissionForTests", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PermissionForTests", "Type");
            RenameTable(name: "dbo.PermissionForTests", newName: "Permissions");
        }
    }
}
