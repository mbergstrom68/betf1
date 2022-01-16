using ErgastApi.Responses.Models;

public interface IDriverService
{
    Task<IList<Driver>> GetAllDrivers();
}