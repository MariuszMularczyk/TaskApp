using TaskApp.Application.Abstraction;
using TaskApp.Data;
using TaskApp.Dictionaries;
using TaskApp.Domain;
using TaskApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Xml.Serialization;
using System.Net;
using TaskApp.Infrastructure.Core;
using TaskApp.Resources.Shared;

namespace TaskApp.Application
{
    public class TripService : ServiceBase, ITripService
    {

        public ITripRepository _tripRepository { get; set; }
        public IMailRepository _mailRepository { get; set; }
        public TripConverter _tripConverter { get; set; }

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public virtual void Add(TripAddVM model)
        {
            if(_tripRepository.Any(x => x.Name == model.Name))
                throw new AppException(ExeptionResource.NameDuplicated);
            _tripRepository.Add(_tripConverter.FromTripAddVM(model));
            _tripRepository.Save(); 
        }
        public virtual List<TripListDTO> GetTrips()
        {
            return _tripRepository.GetAll();
        }
        public virtual List<TripListDTO> GetTripsByCountry(CountriesEnum country)
        {
            return _tripRepository.GetTripsByCountry(country);
        }
        public virtual TripDetailsVM GetTrip(int id) {

            Trip trip = _tripRepository.GetSingle(x => x.Id == id);
            if (trip == null)
                return null;
            return _tripConverter.ToTripDetailsVM(trip);
        }
        public virtual void Edit(TripEditVM model)
        {
            if (_tripRepository.Any(x => x.Name == model.Name && x.Id != model.Id))
                throw new AppException(ExeptionResource.NameDuplicated);
            Trip trip = _tripRepository.GetSingle(x => x.Id == model.Id);
            if (trip == null)
            {
                throw new TripNotFoundException(ExeptionResource.TripNotFound);
            }
            _tripRepository.Edit(_tripConverter.FromTripEditVM(trip, model));
            _tripRepository.Save();
        }

        public virtual void Delete(int id)
        {
            Trip trip = _tripRepository.GetSingle(x => x.Id == id);
            if (trip == null)
            {
                throw new TripNotFoundException(ExeptionResource.TripNotFound);
            }
            _mailRepository.DeleteRange(trip.Mails);
            _tripRepository.Delete(trip);
            _tripRepository.Save();
        }

        public virtual void TripRegister(TripMailVM model)
        {
            Trip trip = _tripRepository.GetSingle(x => x.Id == model.TripId);
            if (trip == null)
            {
                throw new TripNotFoundException(ExeptionResource.TripNotFound);
            }
            if (trip.Mails.Any(x => x.eMail == model.Mail.ToLower()))
            {
                throw new AppException(ExeptionResource.ARegistered);
            }

            _mailRepository.Add(new Mail() { eMail = model.Mail.ToLower(), Trip = trip});
            _mailRepository.Save();
        }
        public virtual void TripUnregister(TripMailVM model)
        {
            Trip trip = _tripRepository.GetSingle(x => x.Id == model.TripId);
            if (trip == null)
            {
                throw new TripNotFoundException(ExeptionResource.TripNotFound);
            }
            Mail mail = trip.Mails.Where(x => x.eMail == model.Mail.ToLower()).FirstOrDefault();
            if (mail == null)
            {
                throw new AppException(ExeptionResource.MailNotFound);
            }

            _mailRepository.Delete(mail);
            _mailRepository.Save();
        }

    }
}
