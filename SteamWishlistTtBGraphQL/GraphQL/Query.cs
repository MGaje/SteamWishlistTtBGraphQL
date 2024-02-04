using System.Linq;
using SteamWishlistTtBGraphQL.GraphQL.Schema;
using SteamWishlistTtBGraphQL.Services;

namespace SteamWishlistTtBGraphQL.GraphQL
{
    public class Query
    {
        [UseFiltering]
        public async Task<List<Game>> GetGamesAsync(string userId, [Service] ISteamTTBService steamTTBService)
            => await steamTTBService.GetGameDataAsync(userId);

        public async Task<Game> GetGameAsync(string userId, string gameName, [Service] ISteamTTBService steamTTBService)
            => await steamTTBService.GetSingleGameAsync(userId, gameName);
    }
}
