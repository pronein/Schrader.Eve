namespace Schrader.Eve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _0003 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MissionItems", "Item_TypeId", "dbo.EveItems");
            DropForeignKey("dbo.MissionShips", "Item_TypeId", "dbo.EveItems");
            DropIndex("dbo.MissionItems", new[] { "Item_TypeId" });
            DropIndex("dbo.MissionShips", new[] { "Item_TypeId" });
            RenameColumn(table: "dbo.MissionItems", name: "Item_TypeId", newName: "Item_Id");
            RenameColumn(table: "dbo.MissionShips", name: "Item_TypeId", newName: "Item_Id");

            DropPrimaryKey("dbo.EveItems");
            DropColumn("dbo.EveItems", "TypeId");
            AddColumn("dbo.EveItems", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.EveItems", "TypeId", c => c.Long(nullable: false));
            AddColumn("dbo.MissionShips", "Class", c => c.String());
            AddColumn("dbo.MissionShips", "Type", c => c.String());
            AddPrimaryKey("dbo.EveItems", "Id");
            CreateIndex("dbo.MissionItems", "Item_Id");
            CreateIndex("dbo.MissionShips", "Item_Id");
            AddForeignKey("dbo.MissionItems", "Item_Id", "dbo.EveItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MissionShips", "Item_Id", "dbo.EveItems", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.MissionShips", "Item_Id", "dbo.EveItems");
            DropForeignKey("dbo.MissionItems", "Item_Id", "dbo.EveItems");
            DropIndex("dbo.MissionShips", new[] { "Item_Id" });
            DropIndex("dbo.MissionItems", new[] { "Item_Id" });
            DropPrimaryKey("dbo.EveItems");
            DropColumn("dbo.EveItems", "Id");
            AlterColumn("dbo.EveItems", "TypeId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.EveItems", "TypeId");
            DropColumn("dbo.MissionShips", "Type");
            DropColumn("dbo.MissionShips", "Class");
            RenameColumn(table: "dbo.MissionShips", name: "Item_Id", newName: "Item_TypeId");
            RenameColumn(table: "dbo.MissionItems", name: "Item_Id", newName: "Item_TypeId");
            CreateIndex("dbo.MissionShips", "Item_TypeId");
            CreateIndex("dbo.MissionItems", "Item_TypeId");
            AddForeignKey("dbo.MissionShips", "Item_TypeId", "dbo.EveItems", "TypeId", cascadeDelete: true);
            AddForeignKey("dbo.MissionItems", "Item_TypeId", "dbo.EveItems", "TypeId", cascadeDelete: true);
        }
    }
}
