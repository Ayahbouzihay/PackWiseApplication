﻿using System.Threading.Tasks;
using PackWiseAPI.Entities;

namespace PackWiseAPI.Repositories
{
    public interface ITripCategoryService
    {
       

        public Task<List<TripCategory>> SelectTrip(string CategoryName);
    }
}
