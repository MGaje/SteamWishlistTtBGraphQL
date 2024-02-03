using Newtonsoft.Json;
using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services
{
    public class SteamService : ISteamService
    {
        private readonly IConfigurationService _configurationService;

        private readonly HttpClient _httpClient;

        public SteamService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;

            _httpClient = new();
        }

        public async Task<List<SteamGameModel>> GetSteamGamesAsync(string userId)
        {
            var response = await _httpClient.GetAsync(_configurationService.SteamWishlistEndpoint(userId));
            var json = await response.Content.ReadAsStringAsync();
            var gameData = JsonConvert.DeserializeObject<Dictionary<string, SteamGameModel>>(json);

            if (gameData is null)
            {
                return new List<SteamGameModel>();
            }

            return gameData.Values.ToList();
        }
    }
}
