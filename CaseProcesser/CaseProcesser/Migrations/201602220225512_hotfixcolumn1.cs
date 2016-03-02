namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotfixcolumn1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cases", "Hotfix_Versions");
            DropColumn("dbo.Cases", "Hotfix_EtaTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cases", "Hotfix_EtaTime", c => c.String(maxLength: 20));
            AddColumn("dbo.Cases", "Hotfix_Versions", c => c.String(maxLength: 20));
        }
    }
}
