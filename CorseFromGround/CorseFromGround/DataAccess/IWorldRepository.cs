using System.Linq;
using CouseFromGround.DataModels;
using System.Threading.Tasks;

namespace CorseFromGround.DataAccess
{
    public interface IWorldRepository
    {
        IQueryable<Trip> GetAllTrips();

        void AddTrip(Trip trip);

        Task<bool> SaveChangesAsync();

        Trip GetTripByName(string name);
    }
}