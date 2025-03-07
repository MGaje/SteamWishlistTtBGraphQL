using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services.SecretsService
{
    public class SecretsService(IConfiguration config) : ISecretsService
    {
        public SteamSettings GetSteamSettings() => config.GetSection("Steam").Get<SteamSettings>() ?? new();
    }
}
