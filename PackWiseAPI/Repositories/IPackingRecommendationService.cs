using Microsoft.AspNetCore.Mvc;
using PackWiseAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PackWiseAPI.Repositories
{
    public interface IPackingRecommendationService
    {
        Task<List<PackingRecommendation>> GetPackingRecommendations(string travelerId, DateTime Date);

        Task<List<PackingRecommendation>> InputTripDates(DateTime Date);
       
    }
}
