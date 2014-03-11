using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class MiningRun
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public String System { get; set; }
        public String Site { get; set; }
        public MiningRunStatus Status { get; set; }

        public ICollection<MiningRunCapsuleer> Capsuleers { get; set; }
        public ICollection<MiningRunLineItem> LineItems { get; set; }

        public IEnumerable<MiningRunLineItem> OreResults { get { return LineItems.Where(x => x.Type == MiningRunItemType.Ore); } }
        public IEnumerable<MiningRunLineItem> MineralResults { get { return LineItems.Where(x => x.Type == MiningRunItemType.Mineral); } }
        public IEnumerable<MiningRunLineItem> Losses { get { return LineItems.Where(x => x.Type == MiningRunItemType.Loss); } }

        public MiningRun()
        {
            Capsuleers = new List<MiningRunCapsuleer>();
            LineItems = new List<MiningRunLineItem>();
        }
    }
}