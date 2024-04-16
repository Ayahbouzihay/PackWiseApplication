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
            var param = new SqlParameter("@CategoryID", categoryId);
            var activityNames = await _dbContextClass.TripCategory
                                        .FromSqlRaw("exec spExploreActivities @CategoryID", param)
                                        .Select(tc => tc.ActivityName)
                                        .ToListAsync();
            return activityNames;
        }
        //Ayden Pratt
        public async Task<List<TripCategory>> selectTrip(string CategoryName)
        {
          var param = new SqlParameter("@CategoryName", CategoryName);
          var selectTrip = await Task.Run(() => _dbContextClass.TripCategory.FromSqlRaw("EXECUTE selectTrip @CategoryName", param).ToListAsync());
          return selectTrip;
        }

        public async Task<List<TripCategory>> SelectTrip(string CategoryName)
        {
            var categoryNameParam = new SqlParameter("@CategoryName", CategoryName);

            var tripCategories = await _dbContextClass.TripCategory
                .FromSqlRaw("EXECUTE selectTrip @CategoryName", categoryNameParam)
                .ToListAsync();

            return tripCategories;
        }
    }
}