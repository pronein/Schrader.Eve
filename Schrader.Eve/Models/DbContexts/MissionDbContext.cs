using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models.DbContexts
{
    public class MissionDbContext : DbContext
    {
        public DbSet<Capsuleer> Capsuleers { get; set; }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionActivityAudit> MissionActivityAudits { get; set; }

        public DbSet<MissionKill> MissionKills { get; set; }
        public DbSet<MissionItem> MissionItems { get; set; }

        public DbSet<MissionShip> MissionShips { get; set; }
        public DbSet<MissionPilot> MissionPilots { get; set; }
        public DbSet<MissionPilotActivityAudit> MissionPilotActivityAudits { get; set; }
        
        public DbSet<EveItem> EveItems { get; set; }
        public DbSet<IskValue> IskValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // MissionActivityAudits
            modelBuilder.Entity<MissionActivityAudit>()
                .HasRequired(x => x.Mission);

            // MissionKills
            modelBuilder.Entity<MissionKill>()
                .HasRequired(x => x.Mission);

            // MissionItems
            modelBuilder.Entity<MissionItem>()
                .HasRequired(x => x.Mission);
            modelBuilder.Entity<MissionItem>()
                .HasRequired(x => x.Item);

            // MissionShips
            modelBuilder.Entity<MissionShip>()
                .HasRequired(x => x.Item);

            // MissionPilots
            modelBuilder.Entity<MissionPilot>()
                .HasRequired(x => x.Mission);
            modelBuilder.Entity<MissionPilot>()
                .HasRequired(x => x.Pilot);
            modelBuilder.Entity<MissionPilot>()
                .HasRequired(x => x.Ship);

            // MissionPilotActivityAudit
            modelBuilder.Entity<MissionPilotActivityAudit>()
                .HasRequired(x => x.Pilot);

            // EveItems
            modelBuilder.Entity<EveItem>()
                .HasKey(x => x.Id);

            // EstimatedIskValues
            modelBuilder.Entity<IskValue>()
                .HasRequired(x => x.Item);
        }
    }
}