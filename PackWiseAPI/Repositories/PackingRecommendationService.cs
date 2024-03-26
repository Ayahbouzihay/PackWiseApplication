using PackWiseAPI.Data;
using PackWiseAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace PackWiseAPI.Repositories
{
    public class PackingRecommendationService : IPackingRecommendationService
    {
        private readonly DbContextClass _dbContextClass;

        public PackingRecommendationService(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public async Task<List<PackingRecommendation>> InputTripDates(DateTime Date)
        {
            var param = new SqlParameter("@Date", Date);
            var date = await Task.Run(() => _dbContextClass.PackingRecommendation.FromSqlRaw("exec spInputTripDates @Date", param).ToListAsync());
            return date;
        }
    }
}
