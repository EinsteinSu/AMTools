namespace CaseProcesser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        CaseId = c.Int(nullable: false, identity: true),
                        CRNumber = c.String(maxLength: 7),
                        AMVersion = c.String(),
                        Subject = c.String(maxLength: 100),
                        Description = c.String(),
                        Environment_ExchangeVersion = c.String(),
                        Environment_MApi = c.String(),
                        Environment_OSVersion = c.String(),
                        Environment_Description = c.String(),
                        Component = c.String(maxLength: 20),
                        Status = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Owner = c.String(maxLength: 10),
                        BacklogId = c.String(maxLength: 7),
                        Location = c.Int(),
                        IsNotifying = c.Boolean(false)
                    })
                .PrimaryKey(t => t.CaseId);

            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        ActiveDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Case_CaseId = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Cases", t => t.Case_CaseId)
                .Index(t => t.Case_CaseId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Activities", "Case_CaseId", "dbo.Cases");
            DropIndex("dbo.Activities", new[] { "Case_CaseId" });
            DropTable("dbo.Activities");
            DropTable("dbo.Cases");
        }
    }
}
