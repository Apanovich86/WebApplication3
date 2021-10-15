namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plans", "Deadline", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plans", "Deadline", c => c.DateTime(nullable: false));
        }
    }
}
