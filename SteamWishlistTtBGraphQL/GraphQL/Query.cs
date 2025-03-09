using System.Linq;
using SteamWishlistTtBGraphQL.GraphQL.Schema;
using SteamWishlistTtBGraphQL.Models;
using SteamWishlistTtBGraphQL.Models.Responses;
using SteamWishlistTtBGraphQL.Services;

namespace SteamWishlistTtBGraphQL.GraphQL
{
    public class Query
    {
        [UseFiltering]
        public async Task<IEnumerable<MyGame>> GetGamesAsync(string userId, [Service] IQueryService queryService)
            => await queryService.GetGamesAsync(userId);

        [UseFiltering]
        public async Task<IGDBGameTimeToBeat> GetTimeToBeatAsync(string game, [Service] IQueryService queryService)
            => await queryService.GetIGDBTimeToBeatAsync(game);

        [UseFiltering]
        public async Task<IEnumerable<IGDBGameTimeToBeat>> GetSteamGamesTimeToBeatAsync(string userId, [Service] IQueryService queryService)
            => await queryService.GetSteamGamesTTBAsync(userId);
    }
}
