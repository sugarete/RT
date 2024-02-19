namespace RT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addresponse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatContexts", "Response", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatContexts", "Response");
        }
    }
}
