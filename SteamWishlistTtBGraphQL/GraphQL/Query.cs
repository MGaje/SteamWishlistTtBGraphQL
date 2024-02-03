using System.Linq;
using SteamWishlistTtBGraphQL.GraphQL.Schema;
using SteamWishlistTtBGraphQL.Services;

namespace SteamWishlistTtBGraphQL.GraphQL
{
    public class Query
    {
        public async Task<List<Game>> GetGamesAsync(string userId, [Service] ISteamService steamService) 
            => (await steamService.GetSteamGamesAsync(userId))
                .Select(x => Game.FromSteamGame(x)).ToList();
    }
}
