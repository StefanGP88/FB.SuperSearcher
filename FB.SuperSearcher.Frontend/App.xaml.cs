using FB.SuperSearcher.Backend;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace FB.SuperSearcher.Frontend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<SearchTermStatisticsWindow>();
            services.AddTransient<CharacterStatistecsWindow>();
            services.AddSingleton<IServiceProvider>(x =>
           {
               return _serviceProvider;
           });
            services.ConfigureServicesBackend();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
