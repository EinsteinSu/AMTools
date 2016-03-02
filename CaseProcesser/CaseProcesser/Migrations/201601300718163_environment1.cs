namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class environment1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Environment_SqlServerVersion", c => c.String());
            AlterColumn("dbo.Cases", "Owner", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cases", "Owner", c => c.String(maxLength: 10));
            DropColumn("dbo.Cases", "Environment_SqlServerVersion");
        }
    }
}
