namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cases", "IsNotifying");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cases", "IsNotifying", c => c.Boolean(nullable: false));
        }
    }
}
