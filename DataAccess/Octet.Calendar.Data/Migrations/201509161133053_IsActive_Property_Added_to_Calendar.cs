namespace Octet.Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActive_Property_Added_to_Calendar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calendars", "IsActive");
        }
    }
}
