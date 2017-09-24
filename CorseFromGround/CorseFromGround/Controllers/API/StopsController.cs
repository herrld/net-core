using AutoMapper;
using CorseFromGround.DataAccess;
using CorseFromGround.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorseFromGround.Controllers.API
{
    [Route("api/trips/{tripName}/stops")]
    public class StopsController : Controller
    {
        private IWorldRepository repo;
        private ILogger<StopsController> logger;

        public StopsController(IWorldRepository repo, ILogger<StopsController> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string tripName)
        {
            try
            {
                var trip = this.repo.GetTripByName(tripName);
                return Ok(Mapper.Map<IEnumerable<StopViewModel>>(trip.Stops.OrderBy(s=>s.Order).ToList()));
            }
            catch(Exception ex)
            {
                logger.LogError("failed to get stops", ex);
            }
            return BadRequest("Failed to get stops");
        }
    }
}
