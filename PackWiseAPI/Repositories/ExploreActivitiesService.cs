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
    public class ExploreActivitiesService : IExploreActivities
    {
        private readonly DbContextClass _dbContext;

        public ExploreActivitiesService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Activity>> GetExploreActivities(int CategoryID)
        {
            var categoryIDParam = new SqlParameter("@CategoryID", CategoryID);
            var activities = await _dbContext.Activity
                .FromSqlRaw("EXECUTE spExploreActivities @CategoryID", categoryIDParam)
                
                .ToListAsync();

            return activities;
        }
    }



 
}
        

