using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PackWiseAPI.Entities;
using PackWiseAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackWiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PackingRecommendationController : ControllerBase
    {
        private readonly IPackingRecommendationService _packingRecommendationService;

        public PackingRecommendationController(IPackingRecommendationService packingRecommendationService)
        {
            this._packingRecommendationService = packingRecommendationService;
        }

        [HttpGet]
        //Ayah-mounina Bouzihay
        public async Task<ActionResult<List<PackingRecommendation>>> GetPackingRecommendations(int travelerId, DateTime Date)
        {
            var packingRecommendations = await _packingRecommendationService.GetPackingRecommendations(travelerId, Date);
            if (packingRecommendations == null)
            {
                //return NotFound();
            }
            return packingRecommendations;
        }
    }


}

   
