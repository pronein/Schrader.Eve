using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models.DbContexts
{
    public class MiningRunDbContext : DbContext
    {
        public DbSet<MiningRun> MiningRuns { get; set; }
        public DbSet<MiningRunLineItem> MiningRunLineItems { get; set; }
        public DbSet<MiningRunCapsuleer> Capsuleers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // MiningRunLineItems
            modelBuilder.Entity<MiningRunLineItem>().HasRequired(x => x.MiningRun);
            
            // MiningRunPilotLineItems
            modelBuilder.Entity<MiningRunCapsuleer>().HasRequired(x => x.MiningRun);
            modelBuilder.Entity<MiningRunCapsuleer>().HasRequired(x => x.Pilot);
        }
    }
}