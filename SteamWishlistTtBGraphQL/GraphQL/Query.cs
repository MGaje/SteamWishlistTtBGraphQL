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
    }
}
