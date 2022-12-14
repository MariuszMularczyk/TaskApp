using TaskApp.Dictionaries;
using TaskApp.Utils;
using TaskApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Data
{
    public class TripListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountriesEnum Country { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfSeats { get; set; }
    }
}

