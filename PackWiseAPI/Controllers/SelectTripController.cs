using Microsoft.AspNetCore.Mvc;
using PackWiseAPI.Entities;
using PackWiseAPI.Repositories;
using System.Security.AccessControl;

namespace PackWiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectTripController : Controller
    {
        private readonly ITripCategoryService tripCategoryService;
        public SelectTripController(ITripCategoryService tripCategoryService)
        {
            this.tripCategoryService = tripCategoryService;
        }
        [HttpGet("{CategoryName}")]
        public async Task<List<TripCategory>> selectTrip(string CategoryName)
        {
            var SelectTrip = await tripCategoryService.SelectTrip(CategoryName);
            if (selectTrip == null)
           {

                //return NotFound();
           }

            return SelectTrip;



        }

    }
}
