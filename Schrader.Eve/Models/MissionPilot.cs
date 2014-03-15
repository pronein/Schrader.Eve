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

        public double TotalHoursInMision
        {
            get
            {
                double totalHours = 0f;
                foreach(MissionPilotActivityAudit audit in TimeAudits)
                {
                    DateTime endTime = audit.EndTime == DateTime.MinValue ? DateTime.Now : audit.EndTime;
                    totalHours += (endTime - audit.StartTime).TotalHours;
                }

                return totalHours;
            }
        }

        public MissionPilot()
        {
            TimeAudits = new List<MissionPilotActivityAudit>();
        }
    }
}