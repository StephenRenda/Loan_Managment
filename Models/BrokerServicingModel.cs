using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class BrokerServicingModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public string BrokerCompany { get; set; }
        public virtual AddressModel BrokerAddress { get; set; }
        public string BrokerEmail { get; set; }
        public virtual PhoneModel BrokerPhone { get; set; }
        public string DRELicense { get; set; }
        public string CFLLicense { get; set; }
        public string NMLSID { get; set; }
        public float BrokerFee { get; set; }
        public bool AdditionalComp { get; set; }
        public float CompensationAmt { get; set; }
        public string BorrowerRepName { get; set; }
        public string BorrowerRepDRE { get; set; }
        public string BorrowerRepNMLS { get; set; }
        public string LenderRepName { get; set; }
        public string LenderRepDRE { get; set; }
        public string LenderRepNMLS { get; set; }
        public string ServicingCompany { get; set; }
        public virtual AddressModel ServicingAddress { get; set; }
        public virtual PhoneModel ServicingPhone { get; set; }
        #endregion
    }
}
