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
    public class InputTripDates : ControllerBase
    {
        private readonly IPackingRecommendationService packingRecommendationService2;

        public InputTripDates(IPackingRecommendationService packingRecommendationService)
        {
            packingRecommendationService2 = packingRecommendationService;
        }
        [HttpGet]

        public async Task<ActionResult<List<PackingRecommendation>>> inputTripDates(string Date)
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
