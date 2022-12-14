using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Dictionaries;

namespace TaskApp.Domain
{
    [Table("Trips")]
    public class Trip : Entity
    {
        public string Name { get; set; }
        public CountriesEnum Country { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfSeats { get; set; }
        public virtual List<Mail> Mails { get; set; }
    }
}
