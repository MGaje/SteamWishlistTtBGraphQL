using SteamWishlistTtBGraphQL.GraphQL.Schema;
using SteamWishlistTtBGraphQL.Models;
using SteamWishlistTtBGraphQL.Models.Responses;

namespace SteamWishlistTtBGraphQL.Services
{
    public interface IQueryService
    {
        Task<IEnumerable<MyGame>> GetGamesAsync(string userId);
        Task<IGDBGameTimeToBeat> GetIGDBTimeToBeatAsync(string game);
        Task<IEnumerable<IGDBGameTimeToBeat>> GetSteamGamesTTBAsync(string userId);
    }
}
