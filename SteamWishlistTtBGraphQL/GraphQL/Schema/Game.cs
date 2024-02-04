using SteamWishlistTtBGraphQL.Models;

namespace SteamWishlistTtBGraphQL.GraphQL.Schema
{
    public class Game
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleaseDateString { get; set; }
        public short TimeToBeat { get; set; }
        public short TimeToBeatExtra { get; set; }
        public short TimeToBeatCompletionist { get; set; }

        public Game()
        {
            Name = string.Empty;
            ReleaseDate = string.Empty;
            ReleaseDateString = string.Empty;
            TimeToBeat = short.MinValue;
            TimeToBeatExtra = short.MinValue;
            TimeToBeatCompletionist = short.MinValue;
        }

        public Game(SteamGameModel game, HLTBSearchResultModel hltbResult)
        {
            Name = game.Name;
            ReleaseDate = game.ReleaseDate;
            ReleaseDateString = game.ReleaseDateString;
            TimeToBeat = hltbResult.GameplayMain;
            TimeToBeatExtra = hltbResult.GameplayMainExtra;
            TimeToBeatCompletionist = hltbResult.GameplayCompletionist;
        }

        public static Game NonExistentGame(string? nameDescriptor = null)
        {
            return new Game
            {
                Name = nameDescriptor ?? "Not Found",
                ReleaseDate = string.Empty,
                ReleaseDateString = string.Empty,
                TimeToBeat = short.MinValue,
                TimeToBeatExtra = short.MinValue,
                TimeToBeatCompletionist = short.MinValue
            };
        }

        public static Game FromSteamGame(SteamGameModel steamGame)
        {
            return new Game
            {
                Name = steamGame.Name,
                ReleaseDate = steamGame.ReleaseDate,
                ReleaseDateString = steamGame.ReleaseDateString
            };
        }

        public void UpdateTimeData(HLTBSearchResultModel hltbResult)
        {
            TimeToBeat = hltbResult.GameplayMain;
            TimeToBeatExtra = hltbResult.GameplayMainExtra;
            TimeToBeatCompletionist = hltbResult.GameplayCompletionist;
        }
    }
}
