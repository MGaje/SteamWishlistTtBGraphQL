using Newtonsoft.Json;

namespace SteamWishlistTtBGraphQL.Models
{
    public class SteamGameModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("release_string")]
        public string ReleaseDateString { get; set; }
    }
}
