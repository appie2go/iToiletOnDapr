using System.Net;
using Dapr.Client;

namespace iToiletOnDapr.Rating.Location;

public class LocationService : ILocationService
{
    public LocationService()
    {
        
    }
    
    public async Task<bool> Exists(Guid locationId)
    {
        using var client = new DaprClientBuilder()
            .Build();
      
        var result = client.CreateInvokeMethodRequest(HttpMethod.Get, "location", $"toilet/{locationId}");
        var response = await client.InvokeMethodWithResponseAsync(result);
        
        switch (response.StatusCode)
        {
            case HttpStatusCode.NotFound: return false;
            case HttpStatusCode.OK: return true;
            default:
                var body = await response.Content.ReadAsStringAsync();
                throw new ApplicationException("Unable to execute service-to-service request", new Exception(body));
        }
    }
}