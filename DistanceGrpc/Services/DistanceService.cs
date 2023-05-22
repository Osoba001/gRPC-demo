using GoogleMapInfo.GoogleServices;
using Grpc.Core;

namespace DistanceGrpc.Services
{
    public class DistanceService:DistanceInfo.DistanceInfoBase
    {
        private readonly GoogleDistance _googleDistance;
        public readonly ILogger<DistanceService> _loger;
        public DistanceService(GoogleDistance googleDistance, ILogger<DistanceService> loger)
        {
            _googleDistance = googleDistance;
            _loger = loger;
        }
        public override async Task<DistanceData> GetDistance(Cities cities, ServerCallContext context)
        {
            var totalMiles = "0";
            var distanceData = await _googleDistance.GetDistanceData(cities.
           OriginCity, cities.DestinationCirt);
            foreach (var distanceDataRow in distanceData.rows)
            {
                foreach (var element in distanceDataRow.elements)
                {
                    totalMiles = element.distance.text;
                }
            }
            return new DistanceData { Miles = totalMiles };
        }
    }

}


