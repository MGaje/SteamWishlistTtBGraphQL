using IGDB.Models;
using static HotChocolate.ErrorCodes;
using System.Collections.Generic;
using System.Drawing;
using System;
using Newtonsoft.Json;

namespace SteamWishlistTtBGraphQL.Models
{
    public class IGDBGameTimeToBeat
    {
        [JsonProperty("checksum")]
        public string Checksum { get; set; }

        [JsonProperty("completely")]
        public string Completely { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("game_id")]
        public int GameId { get; set; }

        [JsonProperty("hastily")]
        public int Hastily { get; set; }

        [JsonProperty("normally")]
        public int Normally { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        public string GameName { get; set; }

        private string _NormallyFormatted;
        public string NormallyFormatted 
        { 
            get 
            { 
                if (_NormallyFormatted is null)
                {
                    TimeSpan time = TimeSpan.FromSeconds(Normally);
                    _NormallyFormatted = $"{time.Hours} hours and {time.Minutes} minutes";
                }

                return _NormallyFormatted;
            } 
        }

    }
}
