namespace RT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChatContexts", "FromUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.ChatContexts", "ToUserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChatContexts", "ToUserID", c => c.String(nullable: false));
            AlterColumn("dbo.ChatContexts", "FromUserID", c => c.String(nullable: false));
        }
    }
}
