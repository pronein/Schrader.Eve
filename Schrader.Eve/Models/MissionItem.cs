using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class MissionItem
    {
        public long Id { get; set; }

        public virtual EveItem Item { get; set; }
        public int Quantity { get; set; }

        public virtual Mission Mission { get; set; }
        public MissionItemType Type { get; set; }

        public virtual IskValue Value { get; set; }

        [Display(Name = "Estimated ISK")]
        [DisplayFormat(DataFormatString = IskValue.IskDisplayFormat)]
        public decimal TotalEstimatedIsk { get { return Quantity * Value.EstValue; } }
        [Display(Name = "Volume (m^3)")]
        [DisplayFormat(DataFormatString = EveItem.VolumeDisplayFormat)]
        public float TotalVolume { get { return Quantity * Item.Volume; } }
        [Display(Name = "Actual ISK")]
        [DisplayFormat(DataFormatString = IskValue.IskDisplayFormat)]
        public decimal TotalActualIsk { get { return Quantity * Value.ActValue; } }
    }
}