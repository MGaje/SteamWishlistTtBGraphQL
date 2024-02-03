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
                .AddQueryType<Query>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingletonServices()
                .AddScopedServices();
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services) 
        {
            return services
                .AddScoped<ISteamService, SteamService>();
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IConfigurationService, ConfigurationService>();
        }
    }
}
