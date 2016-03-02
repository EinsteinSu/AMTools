namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtodo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "InternalStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "InternalStatus");
        }
    }
}
