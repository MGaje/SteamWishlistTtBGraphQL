using SteamWishlistTtBGraphQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.SetupForSteamWishlistTtbGraphQL();

var app = builder.Build();
app.RunSteamWishlistTtbGraphQL();
