namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexportedcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Exported", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "Exported");
        }
    }
}
