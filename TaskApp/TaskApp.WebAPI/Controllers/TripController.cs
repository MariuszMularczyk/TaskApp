using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskApp.Application;
using TaskApp.Data;
using TaskApp.Dictionaries;

namespace TaskApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {

        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpPost("add")]
        public ActionResult Add(TripAddVM model)
        {
            if (ModelState.IsValid)
            {
                _tripService.Add(model);
                return Ok();
            }
            return BadRequest("Validation error");

        }

        [HttpGet("getTrips")]
        public ActionResult<List<TripListDTO>> GetTrips()
        {
            return Ok(_tripService.GetTrips());
        }

        [HttpGet("getTripsByCountry/{countryId}")]
        public ActionResult<List<TripListDTO>> GetTripsByCountry(CountriesEnum countryId)
        {
            return Ok(_tripService.GetTripsByCountry(countryId));
        }

        [HttpGet("getTrip/{id}")]
        public ActionResult<TripDetailsVM> GetTrip(int id)
        {
            TripDetailsVM trip = _tripService.GetTrip(id);
            if (trip == null)
                return NotFound("Trip not found");
            return Ok(trip);
        }
        [HttpPost("edit")]
        public ActionResult Edit(TripEditVM model)
        {
            _tripService.Edit(model);
            return Ok();
        }

        [HttpDelete("deleteTrip/{id}")]
        public ActionResult Delete(int id)
        {
            _tripService.Delete(id);
            return Ok();
        }

        [HttpPost("tripRegister")]
        public ActionResult TripRegister(TripMailVM model)
        {
            _tripService.TripRegister(model);
            return Ok();
        }
        [HttpPost("tripUnregister")]
        public ActionResult TripUnregister(TripMailVM model)
        {
            _tripService.TripUnregister(model);
            return Ok();
        }
    }
}
