namespace Schrader.Eve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MiningRunLineItems", "MiningRun_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.MiningRunLineItems", "MiningRun_Id");
            AddForeignKey("dbo.MiningRunLineItems", "MiningRun_Id", "dbo.MiningRuns", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MiningRunLineItems", "MiningRun_Id", "dbo.MiningRuns");
            DropIndex("dbo.MiningRunLineItems", new[] { "MiningRun_Id" });
            DropColumn("dbo.MiningRunLineItems", "MiningRun_Id");
        }
    }
}
