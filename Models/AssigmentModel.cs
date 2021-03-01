using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class AssignmentModel
    {
        #region Members
        [Key]   
        public Guid ID { get; set; }
        public virtual LoanModel Loan { get; set; }
        public bool IsMultipleLenderLoan { get; set; }
        public DateTime? DeedOfTrustDate { get; set; }
        public string InstrumentNumber { get; set; }    
        public int Book { get; set; }
        public int Page { get; set; }
        public string Signor1 { get; set; }
        public string Signor2 { get; set; }
        public virtual ICollection<TrusteeModel> Assignments { get; set; }
        public string TrustDeedVesting { get; set; }    
        public float AmmountAssigned { get; set; }
        public float PercAssigned { get; set; }
        #endregion


    }
}
