using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class MissionPilot
    {
        public long Id { get; set; }

        public virtual Mission Mission { get; set; }

        public virtual Capsuleer Pilot { get; set; }
        public CapsuleerRole Role { get; set; }
        public virtual MissionShip Ship { get; set; }

        public virtual ICollection<MissionPilotActivityAudit> TimeAudits { get; set; }

        public MissionPilot()
        {
            TimeAudits = new List<MissionPilotActivityAudit>();
        }
    }
}