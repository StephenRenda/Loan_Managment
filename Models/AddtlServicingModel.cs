using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class AddtlServicingModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public float ServicingAmount { get; set; }
        public float ServicingPercent { get; set; }
        public string ServicingPer { get; set; }
        public string ServicingPayable { get; set; }
        public bool Assume100Investment { get; set; }
        public float LateChargeSplit { get; set; }
        public float PrepaySplit { get; set; }
        public bool DifferentialOnly { get; set; }
        public float LPDInterestRate { get; set; }
        public string AdditionalProvisions { get; set; }
        public bool BehalfOfAnother { get; set; }
        public bool PrincipalAsBorrower { get; set; }
        public bool FundingAPortion { get; set; }
        public string MoreThanOneExpl { get; set; }
        public string BExplanation { get; set; }
        public string BrokerNotAgentRelation { get; set; }
        #endregion
    }
}
