using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class MissionKill
    {
        public long Id { get; set; }
        public long KillmailId { get; set; }
        public virtual Mission Mission { get; set; }
    }
}