using SteamWishlistTtBGraphQL.GraphQL.Schema;
using SteamWishlistTtBGraphQL.Models;
using SteamWishlistTtBGraphQL.Models.Responses;

namespace SteamWishlistTtBGraphQL.Services
{
    public class QueryService(
        ISteamService steamService,
        IIGDBService igdbService
    ) : IQueryService
    {
        /// <summary>
        /// Gets the Steam games of the specified user.
        /// </summary>
        /// <param name="userId">The Steam id of the user.</param>
        /// <returns>List of Steam games of specified user.</returns>
        public async Task<IEnumerable<MyGame>> GetGamesAsync(string userId)
        {
            var steamGames = await steamService.GetSteamGamesAsync(userId);
            return steamGames.Select(sg => MyGame.FromSteamGame(sg));
        }

        /// <summary>
        /// Gets the IGDB time to beat data of the specified game.
        /// </summary>
        /// <param name="game">The name of the game to get the time to beat of.</param>
        /// <returns>IGDB time to beat data.</returns>
        public async Task<IGDBGameTimeToBeat> GetIGDBTimeToBeatAsync(string game)
        {
            return await igdbService.GetTimeToBeatAsync(game);
        }

        /// <summary>
        /// Gets the IGDB time to beat of all Steam games of the specified user.
        /// </summary>
        /// <param name="userId">The Steam id of the user.</param>
        /// <returns>List of IGDB time to beat data of Steam games.</returns>
        public async Task<IEnumerable<IGDBGameTimeToBeat>> GetSteamGamesTTBAsync(string userId)
        {
            var steamGames = await steamService.GetSteamGamesAsync(userId);
            var ttb = await igdbService.GetTimeToBeatAsync(steamGames.Select(x => x.Name));

            return ttb;
        }
    }
}
