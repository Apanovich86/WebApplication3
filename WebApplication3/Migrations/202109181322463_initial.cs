namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "UserId");
        }
    }
}
