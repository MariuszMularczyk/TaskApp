using TaskApp.Domain;
using TaskApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Dictionaries;

namespace TaskApp.Data
{
    public class TripRepository : Repository<Trip, MainDatabaseContext>, ITripRepository
    {
        public TripRepository(MainDatabaseContext context) : base(context)
        { }

        public List<TripListDTO> GetAll()
        {
            return Context.Trips.Select(x => new TripListDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                StartDate = x.StartDate,
                NumberOfSeats = x.NumberOfSeats,
            }).ToList();
        }
        public List<TripListDTO> GetTripsByCountry(CountriesEnum country)
        {
            return Context.Trips.Where(x => x.Country == country).Select(x => new TripListDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                StartDate = x.StartDate,
                NumberOfSeats = x.NumberOfSeats,
            }).ToList();
        }

    }
}
