using Newtonsoft.Json;
using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.Responses.Steam
{
    public class SteamOwnedGamesResponse
    {
        [JsonProperty("game_count")]
        public int GameCount { get; set; }

        [JsonProperty("games")]
        public List<SteamGameModel> Games { get; set; }
    }
}
