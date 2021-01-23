using Microsoft.Extensions.DependencyInjection;
using FB.SuperSearcher.Data;
using FB.SuperSearcher.Backend.Handlers;
using FB.SuperSearcher.Backend.Handlers.Implementations;

namespace FB.SuperSearcher.Backend
{
    public static class DependencyInjection
    {
        public static void ConfigureServicesBackend(this IServiceCollection services)
        {
            services.AddSingleton<ISearchHandler, SearchHandler>();
            services.ConfigureServicesData();
        }
    }
}
