using SteamWishlistTtBGraphQL.Services;

namespace SteamWishlistTtBGraphQL
{
    public static class WebApplicationExtensions
    {
        public static void RunSteamWishlistTtbGraphQL(this WebApplication app)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.MapGraphQL();
            app.Run();
        }
    }
}
