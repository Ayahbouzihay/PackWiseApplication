using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using PackWiseAPI.Entities;
using PackWiseAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

//Ayden Pratt InputTripDates API
namespace PackWiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputTripDatesController : ControllerBase
    {
        private readonly IPackingRecommendationService packingRecommendationService2;

        public InputTripDatesController(IPackingRecommendationService packingRecommendationService)
        {
            packingRecommendationService2 = packingRecommendationService;
        }
        [HttpPost]
        public async Task<ActionResult<List<PackingRecommendation>>> inputTripDates(DateTime Date)
        {
            var DateDetails = await packingRecommendationService2.InputTripDates(Date);
            if (DateDetails == null)
            {
                return NotFound();
            }
            return DateDetails;
        }
    }

}
