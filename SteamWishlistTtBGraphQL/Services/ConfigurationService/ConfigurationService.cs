namespace SteamWishlistTtBGraphQL.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string SteamWishlistEndpoint(string userId) => _configuration.GetValue<string>("Endpoints:SteamWishlist")!.Replace("{{USER_ID}}", userId);
        public string HowLongToBeatApiSearchEndpoint(string searchQuery) => _configuration.GetValue<string>("Endpoints:HLTBApiSearch")!.Replace("{{SEARCH_QUERY}}", searchQuery);
    }
}
