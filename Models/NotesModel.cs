using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class NotesModel
    {
        #region Members
        [Key]
        public Guid ID { get; set; }
        public string NoteText { get; set; }
        public DateTime LastEditedOn { get; set; }
        virtual public UserModel LastEditedBy { get; set; }
        #endregion
    }
}
