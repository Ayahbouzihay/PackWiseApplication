using System.Threading.Tasks;
using PackWiseAPI.Entities;

namespace PackWiseAPI.Repositories
{
    public interface ITripCategoryService
    {
        public Task<List<TripCategory>> ExploreActivities(int CategoryID);

        public Task<List<TripCategory>> selectTrip(string CategoryName);
    }
}
