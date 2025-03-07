using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.GraphQL.Schema
{
    public class Game
    {
        public string Title { get; set; }


        public static Game FromSteamGame(SteamGameModel steamGame) => new Game
        {
            Title = steamGame.Name
        };
    }
}
