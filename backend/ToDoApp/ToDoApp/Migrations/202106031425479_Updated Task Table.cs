namespace ToDoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTaskTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tasks");
            AddColumn("dbo.Tasks", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Tasks", "Text", c => c.String());
            AddPrimaryKey("dbo.Tasks", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Tasks");
            AlterColumn("dbo.Tasks", "Text", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Tasks", "Id");
            AddPrimaryKey("dbo.Tasks", "Text");
        }
    }
}
