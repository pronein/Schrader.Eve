namespace Schrader.Eve.Migrations
{
    using Schrader.Eve.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Schrader.Eve.Models.DbContexts.MissionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Schrader.Eve.Models.DbContexts.MiningRunDbContext";
        }

        protected override void Seed(Schrader.Eve.Models.DbContexts.MissionDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            DateTime mStart = DateTime.UtcNow.AddDays(-2);
            DateTime mEnd = mStart.AddHours(4.3);
            DateTime pMidEnd = mStart.AddHours(2);
            DateTime pMidStart = pMidEnd.AddHours(1.4);

            #region Missions
            Mission mission1 = new Mission
            {
                Id = 1,
                Site = "Average Permiter",
                System = "J214600",
                Type = MissionType.MiningRun,
                Status = MissionStatus.PaidOut,
                Designation = "Mining Run I"
            };

            context.Missions.AddOrUpdate(
                mr => mr.Id,
                mission1);
            #endregion

            #region Mission Activity Audits
            MissionActivityAudit mAudit1 = new MissionActivityAudit
            {
                Id = 1,
                Mission = mission1,
                StartTime = mStart,
                EndTime = mEnd
            };

            context.MissionActivityAudits.AddOrUpdate(
                maa => maa.Id,
                mAudit1);
            #endregion

            #region Eve Items
            EveItem tritanium = new EveItem
            {
                Id = 1,
                TypeId = 34,
                Name = "Tritanium",
                Volume = .01f
            };

            EveItem pyerite = new EveItem
            {
                Id = 2,
                TypeId = 35,
                Name = "Pyerite",
                Volume = .01f
            };

            EveItem veldspar = new EveItem
            {
                Id = 3,
                TypeId = 17471,
                Name = "Veldspar",
                Volume = .1f
            };

            EveItem scordite = new EveItem
            {
                Id = 4,
                TypeId = 17464,
                Name = "Scordite",
                Volume = .15f
            };

            EveItem retriever = new EveItem
            {
                Id = 5,
                TypeId = 17478,
                Name = "Retriever",
                Volume = 3750f
            };

            EveItem hulk = new EveItem
            {
                Id = 6,
                TypeId = 22544,
                Name = "Hulk",
                Volume = 3750f
            };

            context.EveItems.AddOrUpdate(
                ei => ei.TypeId,
                tritanium,
                pyerite,
                veldspar,
                scordite,
                retriever,
                hulk);
            #endregion

            #region Mission Ships
            MissionShip ship1 = new MissionShip
            {
                Id = 1,
                Item = retriever,
                Name = "Erotic Dancer I",
                Class = "Mining Barge"
            };

            MissionShip ship2 = new MissionShip
            {
                Id = 2,
                Item = hulk,
                Name = "Green Meanie",
                Class = "Exhumer"
            };

            context.MissionShips.AddOrUpdate(
                ms => ms.Id,
                ship1,
                ship2);
            #endregion

            #region Capsuleers
            Capsuleer magus = new Capsuleer
            {
                Id = 1,
                Name = "Magus Askold",
                CharacterId = "93948888"
            };

            Capsuleer prog = new Capsuleer
            {
                Id = 2,
                Name = "Prog Schrader",
                CharacterId = "92793628"
            };

            Capsuleer proganigod = new Capsuleer
            {
                Id = 3,
                Name = "Proganigod",
                CharacterId = "1916744720"
            };

            Capsuleer arya = new Capsuleer
            {
                Id = 4,
                Name = "Arya Schrader",
                CharacterId = "93437777"
            };

            Capsuleer adarr = new Capsuleer
            {
                Id = 5,
                Name = "Adarr Myraedri",
                CharacterId = "1481644377"
            };

            Capsuleer prentiss = new Capsuleer
            {
                Id = 6,
                Name = "Prentiss Gall",
                CharacterId = "93396050"
            };

            context.Capsuleers.AddOrUpdate(
                c => c.Id,
                magus,
                prog,
                proganigod,
                arya,
                adarr,
                prentiss);
            #endregion

            #region Mission Pilots
            MissionPilot pMagus = new MissionPilot
            {
                Id = 1,
                Mission = mission1,
                Pilot = magus,
                Role = CapsuleerRole.Miner,
                Ship = ship1
            };

            MissionPilot pProg = new MissionPilot
            {
                Id = 2,
                Mission = mission1,
                Pilot = prog,
                Role = CapsuleerRole.Miner,
                Ship = ship1
            };

            MissionPilot pProganigod = new MissionPilot
            {
                Id = 3,
                Mission = mission1,
                Pilot = proganigod,
                Role = CapsuleerRole.Miner,
                Ship = ship2
            };

            MissionPilot pArya = new MissionPilot
            {
                Id = 4,
                Mission = mission1,
                Pilot = arya,
                Role = CapsuleerRole.Miner,
                Ship = ship2
            };

            MissionPilot pAdarr = new MissionPilot
            {
                Id = 5,
                Mission = mission1,
                Pilot = adarr,
                Role = CapsuleerRole.Miner,
                Ship = ship1
            };

            MissionPilot pPrentiss = new MissionPilot
            {
                Id = 6,
                Mission = mission1,
                Pilot = prentiss,
                Role = CapsuleerRole.Guard,
                Ship = ship1
            };

            context.MissionPilots.AddOrUpdate(
                mp => mp.Id,
                pMagus,
                pProg,
                pProganigod,
                pArya,
                pAdarr,
                pPrentiss);
            #endregion

            #region Mission Pilot Activity Audits
            MissionPilotActivityAudit mpaa1 = new MissionPilotActivityAudit
            {
                Id = 1,
                Pilot = pMagus,
                StartTime = mStart,
                EndTime = mEnd
            };

            MissionPilotActivityAudit mpaa2 = new MissionPilotActivityAudit
            {
                Id = 2,
                Pilot = pProg,
                StartTime = mStart,
                EndTime = mEnd
            };

            MissionPilotActivityAudit mpaa3 = new MissionPilotActivityAudit
            {
                Id = 3,
                Pilot = pProganigod,
                StartTime = mStart,
                EndTime = mEnd
            };

            MissionPilotActivityAudit mpaa4 = new MissionPilotActivityAudit
            {
                Id = 4,
                Pilot = pArya,
                StartTime = mStart,
                EndTime = mEnd
            };

            MissionPilotActivityAudit mpaa5 = new MissionPilotActivityAudit
            {
                Id = 5,
                Pilot = pAdarr,
                StartTime = mStart,
                EndTime = pMidEnd
            };

            MissionPilotActivityAudit mpaa6 = new MissionPilotActivityAudit
            {
                Id = 6,
                Pilot = pAdarr,
                StartTime = pMidStart,
                EndTime = mEnd
            };

            MissionPilotActivityAudit mpaa7 = new MissionPilotActivityAudit
            {
                Id = 7,
                Pilot = pPrentiss,
                StartTime = pMidStart,
                EndTime = mEnd
            };

            context.MissionPilotActivityAudits.AddOrUpdate(
                mpaa => mpaa.Id,
                mpaa1,
                mpaa2,
                mpaa3,
                mpaa4,
                mpaa5,
                mpaa6,
                mpaa7);
            #endregion

            #region Mission Items
            MissionItem item1 = new MissionItem
            {
                Id = 1,
                Item = tritanium,
                Mission = mission1,
                Quantity = 6183761,
                Type = MissionItemType.Mineral
            };
            item1.Value = new IskValue { Id = 1, Item = item1, ActValue = 4.34m, EstValue = 4m, DateOfActValue = mStart, DateOfEstValue = mStart };

            MissionItem item2 = new MissionItem
            {
                Id = 2,
                Item = pyerite,
                Mission = mission1,
                Quantity = 1427992,
                Type = MissionItemType.Mineral
            };
            item2.Value = new IskValue { Id = 3, Item = item2, ActValue = 13.11m, EstValue = 13.40m, DateOfActValue = mStart, DateOfEstValue = mStart };

            MissionItem item3 = new MissionItem
            {
                Id = 3,
                Item = scordite,
                Mission = mission1,
                Quantity = 475666,
                Type = MissionItemType.Ore
            };
            item3.Value = new IskValue { Id = 5, Item = item3, ActValue = 22.01m, EstValue = 22m, DateOfActValue = mStart, DateOfEstValue = mStart };

            context.MissionItems.AddOrUpdate(
                mi => mi.Id,
                item1,
                item2,
                item3);
            #endregion
        }
    }
}
