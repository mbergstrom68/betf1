using BlazorApp.Client.Models;

namespace BlazorApp.Client.Services
{
    public interface IBettingService
    {
        Task<IList<BetModel>> GetBetsAsync(string user, int season, int race);
        Task SaveBetsAsync(string user, int season, int race, IList<BetModel> bets);
    }
}