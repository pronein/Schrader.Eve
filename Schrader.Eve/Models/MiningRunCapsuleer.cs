using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class MiningRunCapsuleer
    {
        public long Id { get; set; }

        public MiningRun MiningRun { get; set; }

        public Capsuleer Pilot { get; set; }
        public CapsuleerRole Role { get; set; }
    }
}