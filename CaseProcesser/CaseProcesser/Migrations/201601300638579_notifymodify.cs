namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notifymodify : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cases", "Environment_IsNotifying");
            //DropColumn("dbo.Activities", "IsNotifying");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "IsNotifying", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cases", "Environment_IsNotifying", c => c.Boolean(nullable: false));
        }
    }
}
