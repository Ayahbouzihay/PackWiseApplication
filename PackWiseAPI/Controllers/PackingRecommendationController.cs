using Microsoft.AspNetCore.Mvc;
using PackWiseAPI.Entities;
using PackWiseAPI.Repositories;
using System.Security.AccessControl;

namespace PackWiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackingRecommendationController : Controller
    {
       private readonly IPackingRecommendationService packingRecommendationService;

        public PackingRecommendationController(IPackingRecommendationService packingRecommendationsService)
        {
            this.packingRecommendationService = packingRecommendationsService;
        }

        [HttpGet("{date}")]
        public async Task<List<PackingRecommendation>> InputTripDates(DateTime date)
        {
            var DateDetails = await packingRecommendationService.InputTripDates(date);
            if (DateDetails == null)
            {
               // return NotFound;
            }
            return DateDetails;
        }
    }


 }

   
