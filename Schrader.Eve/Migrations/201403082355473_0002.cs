namespace Schrader.Eve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MiningRunCapsuleers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        MiningRun_Id = c.Long(nullable: false),
                        Pilot_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MiningRuns", t => t.MiningRun_Id, cascadeDelete: true)
                .ForeignKey("dbo.Capsuleers", t => t.Pilot_Id, cascadeDelete: true)
                .Index(t => t.MiningRun_Id)
                .Index(t => t.Pilot_Id);
            
            CreateTable(
                "dbo.Capsuleers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CharacterId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MiningRunCapsuleers", "Pilot_Id", "dbo.Capsuleers");
            DropForeignKey("dbo.MiningRunCapsuleers", "MiningRun_Id", "dbo.MiningRuns");
            DropIndex("dbo.MiningRunCapsuleers", new[] { "Pilot_Id" });
            DropIndex("dbo.MiningRunCapsuleers", new[] { "MiningRun_Id" });
            DropTable("dbo.Capsuleers");
            DropTable("dbo.MiningRunCapsuleers");
        }
    }
}
