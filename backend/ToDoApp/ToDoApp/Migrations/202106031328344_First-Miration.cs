namespace ToDoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMiration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Text = c.String(nullable: false, maxLength: 128),
                        IsCompleted = c.Boolean(nullable: false),
                        User_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Text)
                .ForeignKey("dbo.Users", t => t.User_Username)
                .Index(t => t.User_Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "User_Username", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "User_Username" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
