using SteamWishlistTtBGraphQL.GraphQL;
using SteamWishlistTtBGraphQL.Services;
using SteamWishlistTtBGraphQL.Services.SecretsService;

namespace SteamWishlistTtBGraphQL
{
    public static class ServiceCollectionExtensions
    {
        public static void SetupForSteamWishlistTtbGraphQL(this IServiceCollection services)
        {
            services
                .AddCors()
                .AddServices()
                .AddGraphQLServer()
                .AddFiltering()
                .AddQueryType<Query>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ISecretsService, SecretsService>()
                .AddScoped<ISteamService, SteamService>();
        }
    }
}
