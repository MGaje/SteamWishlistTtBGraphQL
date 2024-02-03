using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services
{
    public interface IHLTBService
    {
        Task<List<HLTBSearchResultModel>> SearchForGameAsync(string name);
    }
}
