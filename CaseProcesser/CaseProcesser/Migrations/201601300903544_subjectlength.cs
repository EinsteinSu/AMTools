namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subjectlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cases", "Subject", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cases", "Subject", c => c.String(maxLength: 100));
        }
    }
}
