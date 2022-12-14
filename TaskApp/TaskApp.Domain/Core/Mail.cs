using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Dictionaries;

namespace TaskApp.Domain
{
    [Table("Mails")]
    public class Mail : Entity
    {
        public string eMail { get; set; }
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
