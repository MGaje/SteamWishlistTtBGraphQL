using SteamWishlistTtBGraphQL.Models;
using SteamWishlistTtBGraphQL.Models.Responses;

namespace SteamWishlistTtBGraphQL.Services
{
    public interface IIGDBService
    {
        Task<IGDBGameTimeToBeat> GetTimeToBeatAsync(string game);
        Task<IEnumerable<IGDBGameTimeToBeat>> GetTimeToBeatAsync(IEnumerable<string> games);
    }
}
