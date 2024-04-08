using Microsoft.AspNetCore.Mvc;
using PackWiseAPI.Entities;
using PackWiseAPI.Repositories;
using System.Security.AccessControl;

namespace PackWiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExploreActivitiesController : Controller
    {
        private readonly ITripCategoryService tripCategoryService;
        public ExploreActivitiesController(ITripCategoryService tripCategoryService)
        {
            this.tripCategoryService = tripCategoryService;
        }
        [HttpGet("{CategoryID}")]
        public async Task<List<TripCategory>> ExploreActivities(int CategoryID)
        {
            var exploreActivities = await tripCategoryService.ExploreActivities(CategoryID);
            if (exploreActivities == null)
           { 
                //return NotFound();
            }

          return exploreActivities;



        }

    }
}
