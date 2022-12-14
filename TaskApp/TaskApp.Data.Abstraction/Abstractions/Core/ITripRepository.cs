using TaskApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Dictionaries;

namespace TaskApp.Data
{
    public interface ITripRepository : IRepository<Trip>
    {
        List<TripListDTO> GetAll();
        List<TripListDTO> GetTripsByCountry(CountriesEnum country);
    }
}
