namespace Schrader.Eve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MiningRunLineItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ImageId = c.Long(nullable: false),
                        Quantity = c.Long(nullable: false),
                        Type = c.Int(nullable: false),
                        EstimatedIskPer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VolumePer = c.Single(nullable: false),
                        ActualIskPer = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MiningRuns",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        System = c.String(),
                        Site = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MiningRuns");
            DropTable("dbo.MiningRunLineItems");
        }
    }
}
