using SteamWishlistTtBGraphQL.GraphQL.Schema;
using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services
{
    public class SteamTTBService : ISteamTTBService
    {
        private readonly ISteamService _steamService;
        private readonly IHLTBService _hltbService;

        public SteamTTBService(ISteamService steamService, IHLTBService hltbService)
        {
            _steamService = steamService;
            _hltbService = hltbService;
        }

        public async Task<List<Game>> GetGameDataAsync(string userId)
        {
            var steamGames = await _steamService.GetSteamGamesAsync(userId);
            var gamesWithData = new List<Game>();

            foreach (var game in steamGames)
            {
                var searchResults = await _hltbService.SearchForGameAsync(game.Name);
                if (!searchResults.Any())
                {
                    continue;
                }

                // Let's just take the top result from the search.
                gamesWithData.Add(new Game(game, searchResults[0]));
            }

            return gamesWithData;
        }
    }
}
