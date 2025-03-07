using Newtonsoft.Json;
using SteamWishlistTtBGraphQL.Models;
using SteamWishlistTtBGraphQL.Responses.Steam;
using SteamWishlistTtBGraphQL.Services.SecretsService;

namespace SteamWishlistTtBGraphQL.Services
{
    public class SteamService(ISecretsService secretsService) : ISteamService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<List<SteamGameModel>> GetSteamGamesAsync(string userId)
        {
            var steamSettings = secretsService.GetSteamSettings();
            var response = await _httpClient.GetAsync($"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={steamSettings.ApiKey}&steamid={userId}&include_appinfo=1&format=json");
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
