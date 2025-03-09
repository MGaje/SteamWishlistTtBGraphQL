using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services
{
    public class SecretsService(IConfiguration config) : ISecretsService
    {
        /// <summary>
        /// Gets the Steam settings from application config.
        /// </summary>
        /// <returns>The Steam settings.</returns>
        public SteamSettings GetSteamSettings() => config.GetSection("Steam").Get<SteamSettings>() ?? new();

        /// <summary>
        /// Gets the IGDB settings from the application config.
        /// </summary>
        /// <returns>The IGDB settings.</returns>
        public IGDBSettings GetIGDBSettings() => config.GetSection("IGDB").Get<IGDBSettings>() ?? new();
    }
}
