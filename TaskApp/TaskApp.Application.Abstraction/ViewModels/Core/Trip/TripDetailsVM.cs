using TaskApp.Dictionaries;
using TaskApp.Resources.Shared;
using TaskApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Application
{
    public class TripDetailsVM
    {
        public TripDetailsVM()
        {
            Mails = new List<MailVM>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public CountriesEnum Country { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfSeats { get; set; }
        public List<MailVM> Mails { get; set; }
    }
}
