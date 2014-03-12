namespace Schrader.Eve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Capsuleers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CharacterId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EveItems",
                c => new
                    {
                        TypeId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Volume = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TypeId);
            
            CreateTable(
                "dbo.IskValues",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        EstValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfEstValue = c.DateTime(nullable: false),
                        DateOfActValue = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MissionItems", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MissionItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Item_TypeId = c.Long(nullable: false),
                        Mission_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EveItems", t => t.Item_TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Missions", t => t.Mission_Id, cascadeDelete: true)
                .Index(t => t.Item_TypeId)
                .Index(t => t.Mission_Id);
            
            CreateTable(
                "dbo.Missions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        System = c.String(),
                        Site = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MissionActivityAudits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Mission_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Missions", t => t.Mission_Id, cascadeDelete: true)
                .Index(t => t.Mission_Id);
            
            CreateTable(
                "dbo.MissionKills",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        KillmailId = c.Long(nullable: false),
                        Mission_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Missions", t => t.Mission_Id, cascadeDelete: true)
                .Index(t => t.Mission_Id);
            
            CreateTable(
                "dbo.MissionPilots",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        Mission_Id = c.Long(nullable: false),
                        Pilot_Id = c.Long(nullable: false),
                        Ship_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Missions", t => t.Mission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Capsuleers", t => t.Pilot_Id, cascadeDelete: true)
                .ForeignKey("dbo.MissionShips", t => t.Ship_Id, cascadeDelete: true)
                .Index(t => t.Mission_Id)
                .Index(t => t.Pilot_Id)
                .Index(t => t.Ship_Id);
            
            CreateTable(
                "dbo.MissionShips",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Item_TypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EveItems", t => t.Item_TypeId, cascadeDelete: true)
                .Index(t => t.Item_TypeId);
            
            CreateTable(
                "dbo.MissionPilotActivityAudits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Pilot_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MissionPilots", t => t.Pilot_Id, cascadeDelete: true)
                .Index(t => t.Pilot_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IskValues", "Id", "dbo.MissionItems");
            DropForeignKey("dbo.MissionItems", "Mission_Id", "dbo.Missions");
            DropForeignKey("dbo.MissionPilotActivityAudits", "Pilot_Id", "dbo.MissionPilots");
            DropForeignKey("dbo.MissionPilots", "Ship_Id", "dbo.MissionShips");
            DropForeignKey("dbo.MissionShips", "Item_TypeId", "dbo.EveItems");
            DropForeignKey("dbo.MissionPilots", "Pilot_Id", "dbo.Capsuleers");
            DropForeignKey("dbo.MissionPilots", "Mission_Id", "dbo.Missions");
            DropForeignKey("dbo.MissionKills", "Mission_Id", "dbo.Missions");
            DropForeignKey("dbo.MissionActivityAudits", "Mission_Id", "dbo.Missions");
            DropForeignKey("dbo.MissionItems", "Item_TypeId", "dbo.EveItems");
            DropIndex("dbo.IskValues", new[] { "Id" });
            DropIndex("dbo.MissionItems", new[] { "Mission_Id" });
            DropIndex("dbo.MissionPilotActivityAudits", new[] { "Pilot_Id" });
            DropIndex("dbo.MissionPilots", new[] { "Ship_Id" });
            DropIndex("dbo.MissionShips", new[] { "Item_TypeId" });
            DropIndex("dbo.MissionPilots", new[] { "Pilot_Id" });
            DropIndex("dbo.MissionPilots", new[] { "Mission_Id" });
            DropIndex("dbo.MissionKills", new[] { "Mission_Id" });
            DropIndex("dbo.MissionActivityAudits", new[] { "Mission_Id" });
            DropIndex("dbo.MissionItems", new[] { "Item_TypeId" });
            DropTable("dbo.MissionPilotActivityAudits");
            DropTable("dbo.MissionShips");
            DropTable("dbo.MissionPilots");
            DropTable("dbo.MissionKills");
            DropTable("dbo.MissionActivityAudits");
            DropTable("dbo.Missions");
            DropTable("dbo.MissionItems");
            DropTable("dbo.IskValues");
            DropTable("dbo.EveItems");
            DropTable("dbo.Capsuleers");
        }
    }
}
