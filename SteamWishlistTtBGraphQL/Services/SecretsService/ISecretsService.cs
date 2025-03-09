using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services
{
    public interface ISecretsService
    {
        SteamSettings GetSteamSettings();
        IGDBSettings GetIGDBSettings();
    }
}
