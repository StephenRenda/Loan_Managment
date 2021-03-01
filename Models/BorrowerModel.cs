using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class BorrowerModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Title { get; set; }
        public String CompanyName { get; set; }
        public bool CompanyIsBorrower { get; set; }
        public DateTime DOB { get; set; }
        public String SSN { get; set; }
        public virtual PhoneModel PhoneNumber { get; set; }
        public virtual AddressModel Address { get; set; }
        #endregion
    }
}
