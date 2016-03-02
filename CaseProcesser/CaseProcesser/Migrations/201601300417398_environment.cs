namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class environment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Environment_IsNotifying", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "Environment_IsNotifying");
        }
    }
}
