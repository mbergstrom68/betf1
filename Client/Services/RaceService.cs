using ErgastApi.Client;
using ErgastApi.Requests;
using ErgastApi.Responses.Models.RaceInfo;

public class RaceService : IRaceService
{
    private IErgastClient client;
    public RaceService()
    {
        client = new ErgastClient();
    }
    public async Task<IList<Race>> GetAllRacesAsync()
    {
        var request = new RaceListRequest 
        {
            Season = "2022"            
        };

        var result = await client.GetResponseAsync(request);                
        
        return result.Races;
    }
}