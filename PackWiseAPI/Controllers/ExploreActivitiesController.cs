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
        private readonly IExploreActivities exploreActivitiesService;
        public ExploreActivitiesController(IExploreActivities exploreActivitiesService)
        {
            this.exploreActivitiesService = exploreActivitiesService;
        }
        [HttpGet("{CategoryID}")]
        public async Task<List<Activity>> GetExploreActivities(int CategoryID)
        {
            var activities = await exploreActivitiesService.GetExploreActivities(CategoryID);
            if (activities == null)
           { 
                //return NotFound();
            }

          return activities;



        }

    }
}
