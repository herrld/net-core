using AutoMapper;
using CorseFromGround.DataAccess;
using CorseFromGround.ViewModels;
using CouseFromGround.DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorseFromGround.Controllers.API
{
    [Route("api/trips")]
    public class TripsController : Controller
    {
        private IWorldRepository repo;

        public TripsController(IWorldRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // case for using action result
            // you can return request codes.
            //if (true) { return BadRequest("bad request"); }
            var records = this.repo.GetAllTrips();
            return Ok(Mapper.Map<IEnumerable<TripViewModel>>(records));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TripViewModel theTrip)
        {
            if(ModelState.IsValid)
            {
                var newTrip = Mapper.Map<Trip>(theTrip);
                this.repo.AddTrip(newTrip);
                if(await this.repo.SaveChangesAsync())
                {
                    return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
                }
            }
            return BadRequest("Failed to save the trip.");
        }
    }
}
