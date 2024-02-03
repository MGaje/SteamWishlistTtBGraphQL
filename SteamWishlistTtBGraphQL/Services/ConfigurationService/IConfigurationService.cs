namespace SteamWishlistTtBGraphQL.Services
{ 
    public interface IConfigurationService
    {
        string SteamWishlistEndpoint(string userId);
        string HowLongToBeatApiSearchEndpoint();
    }
}
