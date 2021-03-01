using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class PhoneModel {
        [Key]
        public Guid PhoneID { get; set; }
        public String Phone { get; set; }
    }
}
