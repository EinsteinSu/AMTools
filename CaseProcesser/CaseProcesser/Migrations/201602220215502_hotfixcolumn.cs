namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotfixcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Hotfix_Versions", c => c.String(maxLength: 20));
            AddColumn("dbo.Cases", "Hotfix_EtaTime", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "Hotfix_EtaTime");
            DropColumn("dbo.Cases", "Hotfix_Versions");
        }
    }
}
