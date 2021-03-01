using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class EscrowModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public String CompanyCode { get; set; }
        public String EscrowCompany { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String Phone { get; set; }
        public String Fax { get; set; }
        public String EscrowNumber { get; set; }
        public String EscrowOfficer { get; set; }
        public String PolicyType { get; set; }
        public float PolicyAmount { get; set; }
        public float PercentLoan { get; set; }
        public String SpecialEndorsements { get; set; }
        public DateTime ReportDate { get; set; }
        public String Exceptions { get; set; }
        public String ItemElimination { get; set; }
        #endregion
    }
}
