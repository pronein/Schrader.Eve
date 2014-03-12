using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schrader.Eve.Models
{
    public class MissionShip
    {
        public long Id { get; set; }
        public virtual EveItem Item { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
    }
}
