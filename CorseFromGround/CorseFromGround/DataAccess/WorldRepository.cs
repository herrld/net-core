using CouseFromGround.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorseFromGround.DataAccess
{
    public class WorldRepository : IWorldRepository
    {
        public WorldRepository(WorldContext context)
        {
            this.context = context;
        }
        private WorldContext context;

        public IQueryable<Trip> GetAllTrips()
        {
            return this.context.Trips;
        }

        public Trip GetTripByName(string name)
        {
            return this.context.Trips
                .Include(t =>t.Stops)
                .FirstOrDefault(t => t.Name.Equals(name));
        }

        public void AddTrip(Trip trip)
        {
            this.context.Trips.Add(trip);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync()) > 0;
        }
    }
}
