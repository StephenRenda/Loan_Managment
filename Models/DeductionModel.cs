using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class DeductionModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public String Desc { get; set; }
        public int RESPA { get; set; }
        public float Amount { get; set; }
        public bool PPF { get; set; }
        public bool EST { get; set; }
        public bool POE { get; set; }
        public bool NET { get; set; }
        public bool SEC32 { get; set; }
        public String RE882M { get; set; }
        #endregion
    }
}
