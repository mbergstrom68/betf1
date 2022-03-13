using BlazorApp.Client.Models;
using Blazored.LocalStorage;

namespace BlazorApp.Client.Services
{
    public class BettingService : IBettingService
    {
        private readonly ILocalStorageService localStore;

        public BettingService(ILocalStorageService localStore)
        {
            this.localStore = localStore;
        }

        public async Task<IList<BetModel>> GetBetsAsync(string user, int season, int round)
        {
            var bets = await localStore.GetItemAsync<IList<BetModel>>(GetStorageKey(user, season, round));
            return bets;
        }

        public async Task SaveBetsAsync(string user, int season, int round, IList<BetModel> bets)
        {            
            await localStore.SetItemAsync<IList<BetModel>>(GetStorageKey(user, season, round), bets);
        }

        private static string GetStorageKey(string user, int season, int race)
        {
            return $"bets:{user}-{season}-{race}";
        }

    }
}
