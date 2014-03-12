using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class EveItem
    { 
        public const string VolumeDisplayFormat = "{0:N2}";

        public long Id { get; set; }
        public long TypeId { get; set; }
        public string Name { get; set; }
        public float Volume { get; set; }
    }
}