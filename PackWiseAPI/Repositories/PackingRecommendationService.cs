using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PackWiseAPI.Data;
using PackWiseAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackWiseAPI.Repositories
{
    public class PackingRecommendationService : IPackingRecommendationService
    {
        private readonly DbContextClass _dbContext;

        public PackingRecommendationService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PackingRecommendation>> GetPackingRecommendations(string travelerId, DateTime tripDate)
        {
            var travelerIdParam = new SqlParameter("@TravelerID", travelerId);
            var tripDateParam = new SqlParameter("@TripDate", tripDate);
            var packingRecommendations = await _dbContext.PackingRecommendation
                .FromSqlRaw("EXECUTE spViewPackingRecommendations @TravelerID, @TripDate", travelerIdParam, tripDateParam)
                .ToListAsync();

            return packingRecommendations;
        }
    }
}