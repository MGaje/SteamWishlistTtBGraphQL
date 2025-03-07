using Newtonsoft.Json;

namespace SteamWishlistTtBGraphQL.Models
{
    public class SteamGameModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

    }
}
