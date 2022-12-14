
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using TaskApp.Dictionaries;

namespace TaskApp.Application
{
    public class TripAddVM
    {
        public string Name { get; set; }

        [EnumDataType(typeof(CountriesEnum))]
        public CountriesEnum Country { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfSeats { get; set; }
    }
}

