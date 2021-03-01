using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class PropertyModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public bool Subject { get; set; }
        public bool UnincorporatedArea{ get; set; }
        public string APN { get; set; }
        public String ConstructionType { get; set; }
        public String ConstructionDescription { get; set; }
        public String LegalDescription { get; set; }
        public float? FireInsurancePolicyAmt { get; set; }
        public float? AnnualInsurancePremiumAmt { get; set; }
        public String LossPayableClause { get; set; }
        public virtual AddressModel Address { get; set; }
        public virtual AddressModel FireInsuranceAddress { get; set; }
        #endregion
    }
}
