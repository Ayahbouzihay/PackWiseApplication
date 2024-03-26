using PackWiseAPI.Data;
using PackWiseAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PackWiseAPI.Repositories;


namespace PackWiseAPI.Repositories

{
    public class TripCategoryService : ITripCategoryService
    {
        private readonly DbContextClass _dbContextClass;

        public TripCategoryService(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }
        //Ayah-mounina Bouzihay
        public async Task<List<TripCategory>> ExploreActivities(int CategoryID)
        {
            var param = new SqlParameter("@CategoryID", CategoryID);
            var exploreActivities = await Task.Run(() => _dbContextClass.TripCategory.FromSqlRaw("exec spExploreActivities @CategoryID", param).ToListAsync());
            return exploreActivities;
        }
        //

    }
}