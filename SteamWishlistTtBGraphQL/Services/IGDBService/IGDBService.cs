using IGDB;
using IGDB.Models;
using Newtonsoft.Json;
using SteamWishlistTtBGraphQL.Models;
using SteamWishlistTtBGraphQL.Models.Responses;
using SteamWishlistTtBGraphQL.Services;
using System.Text;
using System.Text.RegularExpressions;

namespace SteamWishlistTtBGraphQL.Services
{
    /// <summary>
    /// This service is responsible for interacting with IGDB via a third party wrapper.
    /// 500 limit is explicitly used in queries because 1) if left unspecified, the default is 10 and 2) 500 is the max.
    /// </summary>
    public class IGDBService : IIGDBService
    {
        private readonly IGDBSettings _settings;
        private readonly IGDB.IGDBClient _client;
        private readonly HttpClient _httpClient;

        public IGDBService(ISecretsService secretsService)
        {
            _settings = secretsService.GetIGDBSettings();
            _client = new(_settings.ClientId, _settings.ClientSecret);
            _httpClient = new();
        }

        /// <summary>
        /// Gets the time to beat of the specified game.
        /// </summary>
        /// <param name="game">The name of the game to get the time to beat of.</param>
        /// <returns>Time to beat data.</returns>
        public async Task<IGDBGameTimeToBeat> GetTimeToBeatAsync(string game)
        {
            var gameResults = await _client.QueryAsync<IGDB.Models.Game>(IGDBClient.Endpoints.Games, query: $"fields id,name; where name = \"{game}\" & version_parent = null;");
            var target = gameResults.First();

            var ttbResults = await _client.QueryAsync<IGDBGameTimeToBeat>("game_time_to_beats", query: $"fields *; where game_id = {target.Id};");
            var ttb = ttbResults.FirstOrDefault() ?? new();
            ttb.GameName = game;

            return ttb;
        }

        /// <summary>
        /// Gets the time to beat of all specified games.
        /// </summary>
        /// <param name="games">List of games to get times to beat of.</param>
        /// <returns>Times to beat data.</returns>
        public async Task<IEnumerable<IGDBGameTimeToBeat>> GetTimeToBeatAsync(IEnumerable<string> games)
        {
            // Clean up the game names. Remove symbols that might affect the results from IGDB.
            games = games.Select(g =>
            {
                Regex r = new Regex("[:,™,®,\\.]");
                string cleanName = r.Replace(g, String.Empty);
                return $"\"{cleanName}\"";
            });

            // Generate where clause for the games query. We need this query because IGDB uses ids for other query types
            // like "game_time_to_beat".
            StringBuilder sb = new();
            sb.Append("where name = (");
            sb.Append(String.Join(',', games.ToArray()));
            sb.Append(")");
            string gamesWhereClause = sb.ToString();

            var gameResults = await _client.QueryAsync<IGDB.Models.Game>(IGDBClient.Endpoints.Games, query: $"fields id,name; {gamesWhereClause}; limit 500;");

            // Generate where clause for the ttb query.
            sb.Clear();
            sb.Append("where game_id = (");
            sb.Append(String.Join(',', gameResults.Select(x => x.Id)));
            sb.Append(")");
            string ttbWhereClause = sb.ToString();

            var ttbResults = await _client.QueryAsync<IGDBGameTimeToBeat>($"game_time_to_beats", query: $"fields *; {ttbWhereClause}; limit 500;");

            // After we get the results, add the game's name to the associated ttb for more human readable results.
            foreach ( var ttbResult in ttbResults )
            {
                ttbResult.GameName = gameResults.First(x => x.Id == ttbResult.GameId).Name;
            }

            return ttbResults;
        }
    }
}
