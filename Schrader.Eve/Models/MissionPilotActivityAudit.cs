using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class MissionPilotActivityAudit
    {
        public long Id { get; set; }
        public virtual MissionPilot Pilot { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}