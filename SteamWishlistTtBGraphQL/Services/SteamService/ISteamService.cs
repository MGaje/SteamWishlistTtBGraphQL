using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services
{
    public interface ISteamService
    {
        Task<IEnumerable<SteamGameModel>> GetSteamGamesAsync(string userId);
    }
}
