using SteamWishlistTtBGraphQL.GraphQL;
using SteamWishlistTtBGraphQL.Services;

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
                .AddScoped<IIGDBService, IGDBService>()
                .AddScoped<IQueryService, QueryService>()
                .AddScoped<ISteamService, SteamService>();
        }
    }
}
