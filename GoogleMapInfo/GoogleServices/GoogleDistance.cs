using GoogleMapInfo.Models;

namespace GoogleMapInfo.GoogleServices
{
    public class GoogleDistance
    {

        public async Task<GoogleDistanceData> GetDistanceData(string originCity = "Woji, Port Harcourt", string destinationCity = "Uromi, Edo State")
        {

            await Task.Delay(1000);
            var duration = new Duration() { text = "20 hours 52 mins", value = 72841 };
            var distance = new Distance() { text = "2,311 km", value = 64527 };
            var element = new Element() { distance = distance, duration = duration, status = "Ok" };
            var row = new Row() { elements = new Element[] { element } };
            return new GoogleDistanceData()
            {
                destination_addresses = new[] { destinationCity },
                origin_addresses = new[] { originCity },
                status = "OK",
                rows = new[] { row }
            };
        }
    }
}
