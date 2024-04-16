using PackWiseAPI.Entities;

namespace PackWiseAPI.Repositories
{
    public interface IExploreActivities
    {
        Task<List<Activity>> GetExploreActivities(int categoryID);
    }

}
