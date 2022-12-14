using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain;

namespace TaskApp.Application
{
    public class TripConverter : ConverterBase
    {

        public Trip FromTripAddVM(TripAddVM model)
        {
            return new Trip()
            {
                Name = model.Name,
                Description = model.Description,
                Country = model.Country,
                StartDate = model.StartDate,
                NumberOfSeats = model.NumberOfSeats,
            };
        }
        public Trip FromTripEditVM(Trip trip, TripEditVM model)
        {
            trip.Name = model.Name;
            trip.Description = model.Description;
            trip.Country = model.Country;
            trip.StartDate = model.StartDate;
            trip.NumberOfSeats = model.NumberOfSeats;
            return trip;
        }
        public TripEditVM ToTripEditVM(Trip trip)
        {
            return new TripEditVM()
            {
                Id = trip.Id,
                Name = trip.Name,
                Description = trip.Description,
                Country = trip.Country,
                StartDate = trip.StartDate,
                NumberOfSeats = trip.NumberOfSeats,
            };
        }
        public TripDetailsVM ToTripDetailsVM(Trip trip)
        {
            TripDetailsVM details =  new TripDetailsVM()
            {
                Id = trip.Id,
                Name = trip.Name,
                Description = trip.Description,
                Country = trip.Country,
                StartDate = trip.StartDate,
                NumberOfSeats = trip.NumberOfSeats,
            };
            foreach(Mail mail in trip.Mails)
            {
                details.Mails.Add(new MailVM() { Id = mail.Id, eMail = mail.eMail});
            }
            
            return details;
        }
    }
}
