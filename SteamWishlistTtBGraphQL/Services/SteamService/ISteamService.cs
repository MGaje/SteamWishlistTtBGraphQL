using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services
{
    public interface ISteamService
    {
        Task<List<SteamGameModel>> GetSteamGamesAsync(string userId);
    }
}
