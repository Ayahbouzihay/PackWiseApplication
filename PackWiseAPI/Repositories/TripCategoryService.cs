﻿using PackWiseAPI.Data;
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