namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Tag_Value", c => c.String());
            AddColumn("dbo.Cases", "Tag_Color", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "Tag_Color");
            DropColumn("dbo.Cases", "Tag_Value");
        }
    }
}
