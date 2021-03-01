using App.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class NoteModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public bool LateFee { get; set; }
        public int LateChargeDays { get; set; }
        public float LateChargeMinimum { get; set; }
        public float LateChargePercentage { get; set; }
        public float ReturnCheckPercentage { get; set; }
        public float ReturnCheckMinFee { get; set; }
        public float ReturnCheckMaxFee { get; set; }
        public bool PrepaymentPenalty { get; set; }
        public bool SubjectToMinCharge { get; set; }
        public float MinCharge { get; set; }
        public float BankruptcyAdminFee { get; set; }
        public bool RefundIfPaidOff { get; set; }
        public bool Assumable { get; set; }
        public bool NoIncomeDocumentation { get; set; }
        #endregion
    }
}
