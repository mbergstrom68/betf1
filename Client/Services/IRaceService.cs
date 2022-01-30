using ErgastApi.Responses.Models.RaceInfo;

public interface IRaceService
{
    Task<IList<Race>> GetAllRacesAsync();
}