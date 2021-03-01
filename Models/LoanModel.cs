using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class LoanModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public String LoanNumber { get; set; }
        public virtual BorrowerModel Borrower { get; set; }
        public virtual ICollection<LoanTrusteeModel> LoanTrustees { get; set; }
        public String Name { get; set; }
        public String CompanyName { get; set; }
        public int Stage { get; set; }
        public float PrincipalAmt { get; set; }
        public float IntRate { get; set; }
        public float IntRateLender { get; set; }
        public int PaymentsPerPeriod { get; set; }
        public int TotalPaymentsInPeriods { get; set; }
        public int PaymentsCollectedInAdvance { get; set; }
        public int PaymentAmortizationPeriod { get; set; }
        public DateTime IntRateLockDate { get; set; }
        public float RegPaymentAmt { get; set; }
        public DateTime MaturityDate { get; set; }
        public float LoanPoints { get; set; }
        public float TotalLoanFee { get; set; }
        virtual public NotesModel TextNotes { get; set; }
        public DateTime CreatedOn { get; set; }
        virtual public UserModel CreatedBy { get; set; }
        public DateTime LastChangedOn { get; set; }
        virtual public UserModel LastChangedBy { get; set; }
        virtual public BrokerServicingModel BrokerRef { get; set; }
        virtual public NoteModel NoteRef { get; set; }
        virtual public AddtlServicingModel AddtlRef { get; set; }
        virtual public CostExpenseModel CostRef { get; set; }
        virtual public EscrowModel Escrow { get; set; }
        virtual public PropertyModel Property { get; set; }
        #endregion
    }
}
