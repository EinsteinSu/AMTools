namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Customer", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "Customer");
        }
    }
}
