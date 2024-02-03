using Newtonsoft.Json;
using SteamWishlistTtBGraphQL.Models;
using System.Net.Http;

namespace SteamWishlistTtBGraphQL.Services
{
    public class HLTBService : IHLTBService
    {
        private readonly IConfigurationService _configurationService;

        private readonly HttpClient _httpClient;

        public HLTBService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;

            _httpClient = new();
        }

        public async Task<List<HLTBSearchResultModel>> SearchForGameAsync(string name)
        {
            var response = await _httpClient.GetAsync(_configurationService.HowLongToBeatApiSearchEndpoint(searchQuery: name));
            var json = await response.Content.ReadAsStringAsync();

            if (json is null)
            {
                return new List<HLTBSearchResultModel>();
            }

            return JsonConvert.DeserializeObject<List<HLTBSearchResultModel>>(json)!;
        }
    }
}
