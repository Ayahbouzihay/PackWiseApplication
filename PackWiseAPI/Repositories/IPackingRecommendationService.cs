using PackWiseAPI.Entities;
using System.Threading.Tasks;


namespace PackWiseAPI.Repositories
{
    public interface IPackingRecommendationService
    {
        public Task<List<PackingRecommendation>> InputTripDates(DateTime date);
    }
}
