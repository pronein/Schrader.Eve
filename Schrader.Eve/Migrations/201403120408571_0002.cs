namespace Schrader.Eve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Missions", "Designation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Missions", "Designation");
        }
    }
}
