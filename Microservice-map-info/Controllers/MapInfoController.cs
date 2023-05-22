using GoogleMapInfo.GoogleServices;
using GoogleMapInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice_map_info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapInfoController : ControllerBase
    {
        private readonly GoogleDistance _googleDistance;

        public MapInfoController(GoogleDistance googleDistance)
        {
            _googleDistance = googleDistance;
        }
        [HttpGet]
        public async Task<GoogleDistanceData> GetDistance()
        {
            return await _googleDistance.GetDistanceData();
        } 


    }
}
