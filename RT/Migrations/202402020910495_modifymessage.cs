namespace RT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifymessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatContexts", "FromUserName", c => c.String(nullable: false));
            DropColumn("dbo.ChatContexts", "FromUserID");
            DropColumn("dbo.ChatContexts", "ToUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChatContexts", "ToUserID", c => c.Int(nullable: false));
            AddColumn("dbo.ChatContexts", "FromUserID", c => c.Int(nullable: false));
            DropColumn("dbo.ChatContexts", "FromUserName");
        }
    }
}
