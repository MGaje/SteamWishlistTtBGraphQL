using Newtonsoft.Json;

namespace SteamWishlistTtBGraphQL.Models.Responses
{
    public class IGDBTokenResponseModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
