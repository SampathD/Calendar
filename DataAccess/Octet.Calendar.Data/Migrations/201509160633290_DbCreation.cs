namespace Octet.Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Icon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CalendarSubscribs",
                c => new
                    {
                        CalendarRefId = c.Int(nullable: false),
                        SubscriberRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CalendarRefId, t.SubscriberRefId })
                .ForeignKey("dbo.Calendars", t => t.CalendarRefId, cascadeDelete: true)
                .ForeignKey("dbo.Subscribers", t => t.SubscriberRefId, cascadeDelete: true)
                .Index(t => t.CalendarRefId)
                .Index(t => t.SubscriberRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalendarSubscribs", "SubscriberRefId", "dbo.Subscribers");
            DropForeignKey("dbo.CalendarSubscribs", "CalendarRefId", "dbo.Calendars");
            DropIndex("dbo.CalendarSubscribs", new[] { "SubscriberRefId" });
            DropIndex("dbo.CalendarSubscribs", new[] { "CalendarRefId" });
            DropTable("dbo.CalendarSubscribs");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Calendars");
        }
    }
}
