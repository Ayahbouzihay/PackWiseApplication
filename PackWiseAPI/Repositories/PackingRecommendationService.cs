﻿using PackWiseAPI.Data;
using PackWiseAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        //Ayah-mounina Bouzihay get Packing Recommendation
        public async Task<List<PackingRecommendation>> getPackingRecommendations(string travelerId, DateTime tripDate)
        {
            var travelerIdParam = new SqlParameter("@TravelerID", travelerId);
            var tripDateParam = new SqlParameter("@TripDate", tripDate);
            var packingRecommendations = await _dbContext.PackingRecommendation
                .FromSqlRaw("EXECUTE spViewPackingRecommendations @TravelerID, @TripDate", travelerIdParam, tripDateParam)
                .ToListAsync();
        
            return packingRecommendations;
        }

        public Task<List<PackingRecommendation>> GetPackingRecommendations(string travelerId, DateTime tripDate)
        {
            throw new NotImplementedException();
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

        public Task<List<PackingRecommendation>> inputTripDates(DateTime Date)
        {
            throw new NotImplementedException();
        }
    }
}
