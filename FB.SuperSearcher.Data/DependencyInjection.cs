using FB.SuperSearcher.Data.Repositories;
using FB.SuperSearcher.Data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FB.SuperSearcher.Data
{
    public static class DependencyInjection
    {
        public static void ConfigureServicesData(this IServiceCollection services)
        {
            services.AddSingleton<ISearchRepository, FileSearchRepository>();
        }

    }
}
