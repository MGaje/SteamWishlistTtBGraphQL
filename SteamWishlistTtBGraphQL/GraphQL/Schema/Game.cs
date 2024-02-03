using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.GraphQL.Schema
{
    public class Game
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleaseDateString { get; set; }


        public static Game FromSteamGame(SteamGameModel steamGame)
        {
            return new Game
            {
                Title = steamGame.Name,
                ReleaseDate = steamGame.ReleaseDate,
                ReleaseDateString = steamGame.ReleaseDateString
            };
        }
    }
}
