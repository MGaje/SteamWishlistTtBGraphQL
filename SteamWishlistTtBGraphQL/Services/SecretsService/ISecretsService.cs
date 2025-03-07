using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services.SecretsService
{
    public interface ISecretsService
    {
        SteamSettings GetSteamSettings();
    }
}
