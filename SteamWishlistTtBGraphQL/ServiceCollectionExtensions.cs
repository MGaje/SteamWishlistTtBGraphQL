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
                .AddSingletonServices()
                .AddScopedServices();
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services) 
        {
            return services
                .AddScoped<ISteamService, SteamService>()
                .AddScoped<IHLTBService, HLTBService>()
                .AddScoped<ISteamTTBService, SteamTTBService>();
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IConfigurationService, ConfigurationService>();
        }
    }
}
