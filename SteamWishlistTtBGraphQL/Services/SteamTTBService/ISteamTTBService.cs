using SteamWishlistTtBGraphQL.GraphQL.Schema;

namespace SteamWishlistTtBGraphQL.Services
{
    public interface ISteamTTBService
    {
        Task<List<Game>> GetGameDataAsync(string userId);
        Task<Game> GetSingleGameAsync(string userId, string gameName);
    }
}
