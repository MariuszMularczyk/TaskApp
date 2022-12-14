using TaskApp.Application.Abstraction;
using TaskApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TaskApp.Data;
using TaskApp.Dictionaries;

namespace TaskApp.Application
{
    public interface ITripService : IService
    {
        void Add(TripAddVM model);
        List<TripListDTO> GetTrips();
        List<TripListDTO> GetTripsByCountry(CountriesEnum country);
        TripDetailsVM GetTrip(int id);
        void Edit(TripEditVM model);
        void Delete(int id);
        void TripRegister(TripMailVM model);
        void TripUnregister(TripMailVM model);
    }
}