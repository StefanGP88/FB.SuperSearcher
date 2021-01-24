using FB.SuperSearcher.Data.Models;
using FB.SuperSearcher.Data.Repositories;
using FB.SuperSearcher.Data.Repositories.Implementations;
using FB.SuperSearcher.Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FB.SuperSearcher.Data
{
    public static class DependencyInjection
    {
        public static void ConfigureServicesData(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IFileSearchRepository, FileSearchRepository>();
            services.AddSingleton<IWebSearchRepository, BingSearchRepository>();
            services.AddSingleton<IStatisticRepository, StatisticEfCoreRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<SearchStatisticDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")), ServiceLifetime.Singleton);

            services.Configure<SearchSettings>(x =>
            {
                x.BingApiUrl = configuration.GetSection("SearchSettings:BingApiUrl").Value;
                x.BingSubscriptionKey = configuration.GetSection("SearchSettings:BingSubscriptionKey").Value;
                x.MaxFileAndFolderResults = int.Parse(configuration.GetSection("SearchSettings:MaxFileAndFolderResults").Value);
                x.MaxWebResult = int.Parse(configuration.GetSection("SearchSettings:MaxWebResult").Value);
            });

            if (bool.Parse(configuration.GetSection("RunMigrationOnAppStart").Value))
            {
                var build = services.BuildServiceProvider();
                var dbContext = build.GetService<SearchStatisticDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
