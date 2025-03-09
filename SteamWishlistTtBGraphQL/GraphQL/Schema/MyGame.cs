using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.GraphQL.Schema
{
    public class MyGame
    {
        public string Title { get; set; }

        public static MyGame FromSteamGame(SteamGameModel steamGame) => new MyGame
        {
            Title = steamGame.Name
        };
    }
}
