using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models
{
    public class MiningRunLineItem
    {
        public long Id { get; set; }
        public MiningRun MiningRun { get; set; }

        [Display(Name="Item")]
        public string Name { get; set; }
        /// <summary>
        /// This is the same as the TypeID used in all Eve Official Databases
        /// </summary>
        public long ImageId { get; set; }
        [Display(Name="Qty")]
        public long Quantity { get; set; }
        public MiningRunItemType Type { get; set; }
        public decimal EstimatedIskPer { get; set; }
        public float VolumePer { get; set; }
        public decimal ActualIskPer { get; set; }

        [Display(Name="Estimated ISK")]
        [DisplayFormat(DataFormatString="{0:N2} \u01B6")]
        public decimal TotalEstimatedIsk { get { return Quantity * EstimatedIskPer; } }
        [Display(Name="Volume (m^3)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float TotalVolume { get { return Quantity * VolumePer; } }
        [Display(Name="Actual ISK")]
        [DisplayFormat(DataFormatString = "{0:N2} \u01B6")]
        public decimal TotalActualIsk { get { return Quantity * ActualIskPer; } }
    }
}