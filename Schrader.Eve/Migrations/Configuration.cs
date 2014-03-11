namespace Schrader.Eve.Migrations
{
    using Schrader.Eve.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Schrader.Eve.Models.DbContexts.MiningRunDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Schrader.Eve.Models.DbContexts.MiningRunDbContext";
        }

        protected override void Seed(Schrader.Eve.Models.DbContexts.MiningRunDbContext context)
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

            context.MiningRuns.AddOrUpdate(
                mr => mr.Id,
                new MiningRun { Id = 1, Date = DateTime.Today, Site = "Average Perimiter", Status = MiningRunStatus.InProgress, System = "J214600" }
                );
        }
    }
}
