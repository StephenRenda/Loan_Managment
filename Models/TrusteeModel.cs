using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class TrusteeModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public virtual List<LoanTrusteeModel> LoanTrustees { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Mailto { get; set; }
        #endregion
    }
}
