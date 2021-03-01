using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class LoanTrusteeModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public virtual LoanModel Loan { get; set; }
        public virtual TrusteeModel Trustee { get; set; }
        #endregion
    }
}