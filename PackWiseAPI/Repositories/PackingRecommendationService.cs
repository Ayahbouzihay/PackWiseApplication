using PackWiseAPI.Data;
using PackWiseAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;


namespace PackWiseAPI.Repositories
{
    public class PackingRecommendationService : IPackingRecommendationService
    {
        private readonly DbContextClass _dbContext;

        public PackingRecommendationService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        //Ayah-mounina Bouzihay get Packing Recommendation
        public async Task<List<PackingRecommendation>> getPackingRecommendations(int travelerId, DateTime Date)
        {
            var travelerIdParam = new SqlParameter("@TravelerID", travelerId);
            var DateParam = new SqlParameter("@Date", Date);
            var packingRecommendations = await _dbContext.PackingRecommendation
                .FromSqlRaw("EXECUTE spViewPackingRecommendations @TravelerID, @Date", travelerIdParam, DateParam)
                .ToListAsync();
        
            return packingRecommendations;
        }

        public async Task<List<PackingRecommendation>> GetPackingRecommendations(int travelerId, DateTime Date)
        {
                var travelerIdParam = new SqlParameter("@TravelerID", travelerId);
                var DateParam = new SqlParameter("@Date", Date);
                var packingRecommendations = await _dbContext.PackingRecommendation
                    .FromSqlRaw("EXECUTE spViewPackingRecommendations @TravelerID, @Date", travelerIdParam, DateParam)
                    .ToListAsync();

                return packingRecommendations;
            }


         
        //Ayden Pratt InputTripDates
        public async Task<List<PackingRecommendation>> InputTripDates(DateTime Date)
        {
            var DateParam = new SqlParameter("@Date", Date);
            var packingRecommendations = await _dbContext.PackingRecommendation
                .FromSqlRaw("EXECUTE InputTripDates @Date", DateParam)
                .ToListAsync();

            return packingRecommendations;
        }

        public async Task<List<PackingRecommendation>> inputTripDates(DateTime Date)
        {
            var dateParam = new SqlParameter("@Date", Date);

            var packingRecommendations = await _dbContext.PackingRecommendation
                .FromSqlRaw("EXECUTE InputTripDates @Date", dateParam)
                .ToListAsync();

            return packingRecommendations;
        }
    }
}
