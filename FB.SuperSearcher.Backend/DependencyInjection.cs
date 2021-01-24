using Microsoft.Extensions.DependencyInjection;
using FB.SuperSearcher.Data;
using FB.SuperSearcher.Backend.Handlers;
using FB.SuperSearcher.Backend.Handlers.Implementations;
using Microsoft.Extensions.Configuration;

namespace FB.SuperSearcher.Backend
{
    public static class DependencyInjection
    {
        public static void ConfigureServicesBackend(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<ISearchHandler, SearchHandler>();
            services.AddSingleton<IStatisticsHandler, StatisticHandler>();
            services.ConfigureServicesData(configuration);
        }
    }
}
