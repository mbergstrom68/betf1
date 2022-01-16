using ErgastApi.Client;
using ErgastApi.Requests;
using ErgastApi.Responses.Models;

public class DriverService : IDriverService
{
    private IErgastClient client;
    public DriverService(IErgastClient client)
    {
        this.client = client;
    }

    public async Task<IList<Driver>> GetAllDrivers()
    {
        var request = new DriverInfoRequest 
        {
            Season = Seasons.Current
        };

        var result = await client.GetResponseAsync(request);

        return result.Drivers;
    }
}