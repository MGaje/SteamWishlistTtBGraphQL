using Newtonsoft.Json;
using SteamWishlistTtBGraphQL.Models;
using SteamWishlistTtBGraphQL.Models.Responses;

namespace SteamWishlistTtBGraphQL.Services
{
    public class SteamService(ISecretsService secretsService) : ISteamService
    {
        private readonly HttpClient _httpClient = new();
        private readonly static string BASE_STEAM_API_URI = "http://api.steampowered.com";

        /// <summary>
        /// Gets the Steam games data of the specified user.
        /// </summary>
        /// <param name="userId">The Steam id of the user to get games data for.</param>
        /// <returns>List of specified user's Steam game data.</returns>
        public async Task<IEnumerable<SteamGameModel>> GetSteamGamesAsync(string userId)
        {
            var steamSettings = secretsService.GetSteamSettings();
            var response = await _httpClient.GetAsync($"{BASE_STEAM_API_URI}/IPlayerService/GetOwnedGames/v0001/?key={steamSettings.ApiKey}&steamid={userId}&include_appinfo=1&format=json");
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();

            var steamGameDataResponse = JsonConvert.DeserializeObject<Dictionary<string, SteamOwnedGamesResponse>>(json);
            if (steamGameDataResponse is null || steamGameDataResponse["response"] is null)
            {
                return new List<SteamGameModel>();
            }

            return steamGameDataResponse["response"].Games;
        }
    }
}
