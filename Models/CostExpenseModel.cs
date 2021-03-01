using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class CostExpenseModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public virtual DeductionModel BrokerDeductions1 { get; set; }
        public virtual DeductionModel BrokerDeductions2 { get; set; }
        public virtual DeductionModel OtherDeductions1 { get; set; }
        public virtual DeductionModel OtherDeductions2 { get; set; }
        public virtual DeductionModel BrokerPayments1 { get; set; }
        public virtual DeductionModel BrokerPayments2 { get; set; }
        public virtual DeductionModel OtherPayments1 { get; set; }
        public virtual DeductionModel OtherPayments2 { get; set; }
        #endregion
    }
}
