using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class IskValue
    {
        public const string IskDisplayFormat = "{0:N2} \u01B6";

        public long Id { get; set; }
        public decimal EstValue { get; set; }
        public decimal ActValue { get; set; }
        public DateTime DateOfEstValue { get; set; }
        public DateTime DateOfActValue { get; set; }
        public virtual MissionItem Item { get; set; }
    }
}