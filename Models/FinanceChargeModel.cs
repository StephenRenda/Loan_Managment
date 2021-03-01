using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace App.Models
{
    public class FinanceChargeModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public string LenderAllocation { get; set; }
        public string LenderDesc { get; set; }
        public float LenderAllocationAmt { get; set; }
        public float LenderLoanDiscFee { get; set; }
        public string BrokerAllocation { get; set; }
        public string BrokerDesc { get; set; }
        public float BrokerAllocationAmt { get; set; }
        public string OrigBrokerFee { get; set; }
        public string OrigBrokerDesc { get; set; }
        public float OrigBrokerFeeAmt { get; set; }
        public string GrossPoints { get; set; }
        public string GrossPointsDesc { get; set; }
        public float GrossPointsAmt { get; set; }
        public bool AnyAmtPaidNotDeducted { get; set; }
        public float AmtNotDeducted { get; set; }
        public float LenderYieldSpread { get; set; }
        public float BorrowerYieldSpread { get; set; }
        public float TotalCompRetained { get; set; }
        public string CreditorForTruth { get; set; }
        public char FundedByControlledFunds { get; set; }
        public bool LifeDisabilityInsIncl { get; set; }
        public float BalloonAmt { get; set; }
        public float AmtFinanced { get; set; }
        public bool AmtFinancedEst { get; set; }
        public float TotalPayments { get; set; }
        public bool TotalPaymentsEst { get; set; }
        public float AdjustmentsPaidBroker { get; set; }
        public float FinanceCharge { get; set; }
        public bool FinanceChargeEst { get; set; }
        public float AnnPercentRate { get; set; }
        public bool AnnPercentRateEst { get; set; }
        #endregion
    }
}
