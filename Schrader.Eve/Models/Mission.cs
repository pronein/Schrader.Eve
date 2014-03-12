using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class Mission
    {
        public long Id { get; set; }
        public MissionType Type { get; set; }
        public String System { get; set; }
        public String Site { get; set; }
        public MissionStatus Status { get; set; }
        // Mining Run I, Mining Run II, etc.
        public string Designation { get; set; }

        public virtual ICollection<MissionPilot> Pilots { get; set; }
        public virtual ICollection<MissionItem> LineItems { get; set; }
        public virtual ICollection<MissionKill> Kills { get; set; }
        public virtual ICollection<MissionActivityAudit> ActivityAudits { get; set; }

        public IEnumerable<MissionItem> OreResults { get { return LineItems.Where(x => x.Type == MissionItemType.Ore); } }
        public IEnumerable<MissionItem> MineralResults { get { return LineItems.Where(x => x.Type == MissionItemType.Mineral); } }
        public IEnumerable<MissionItem> Losses { get { return LineItems.Where(x => x.Type == MissionItemType.Loss); } }

        public DateTime StartTime { get { return //DateTime.Now; } }
            ActivityAudits.Count() > 0 ? ActivityAudits
            .OrderBy(x => x.StartTime)
            .First().StartTime : DateTime.MinValue; } }
        public int PilotCount { get { return Pilots.Count; } }

        public Mission()
        {
            Pilots = new List<MissionPilot>();
            LineItems = new List<MissionItem>();
            Kills = new List<MissionKill>();
            ActivityAudits = new List<MissionActivityAudit>();
        }
    }
}