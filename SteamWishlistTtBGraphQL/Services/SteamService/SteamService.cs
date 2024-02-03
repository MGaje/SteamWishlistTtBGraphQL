using Newtonsoft.Json;
using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Services
{
    public class SteamService : ISteamService
    {
        private HttpClient _httpClient;

        public SteamService()
        {
            _httpClient = new();
        }

        public async Task<List<SteamGameModel>> GetSteamGamesAsync(string userId)
        {
            var response = await _httpClient.GetAsync($"https://store.steampowered.com/wishlist/profiles/{userId}/wishlistdata/?p=0");
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
