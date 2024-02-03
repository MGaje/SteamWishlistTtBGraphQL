using Newtonsoft.Json;

namespace SteamWishlistTtBGraphQL.Models
{
    public class HLTBSearchResultModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("gameplayMain")]
        public short GameplayMain { get; set; }

        [JsonProperty("gameplayMainExtra")]
        public short GameplayMainExtra { get; set; }

        [JsonProperty("gameplayCompletionist")]
        public short GameplayCompletionist { get; set; }
    }
}
