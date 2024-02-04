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
            if (!steamGames.Any())
            {
                return new List<Game>();
            }

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

        public async Task<Game> GetSingleGameAsync(string userId, string gameName)
        {
            var steamGames = await _steamService.GetSteamGamesAsync(userId);
            if (!steamGames.Any())
            {
                return Game.NonExistentGame();
            }

            var targetGame = steamGames.FirstOrDefault(game => game.Name == gameName);
            if (targetGame is null)
            {
                return Game.NonExistentGame("Target Game Not Found in Wishlist");
            }

            var searchResults = await _hltbService.SearchForGameAsync(gameName);
            return new Game(targetGame, searchResults[0]);
        }
    }
}
