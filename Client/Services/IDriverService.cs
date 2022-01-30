using ErgastApi.Responses.Models;
using ErgastApi.Responses.Models.Standings;

public interface IDriverService
{
    Task<IList<Driver>> GetAllDrivers();
    Task<IList<DriverStandingsList>> GetCurrentDriverStandings();
}