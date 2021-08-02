namespace ToDoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "User_Username", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "User_Username" });
            AlterColumn("dbo.Tasks", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "User_Username", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Tasks", "User_Username");
            AddForeignKey("dbo.Tasks", "User_Username", "dbo.Users", "Username", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "User_Username", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "User_Username" });
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Tasks", "User_Username", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tasks", "Text", c => c.String());
            CreateIndex("dbo.Tasks", "User_Username");
            AddForeignKey("dbo.Tasks", "User_Username", "dbo.Users", "Username");
        }
    }
}
