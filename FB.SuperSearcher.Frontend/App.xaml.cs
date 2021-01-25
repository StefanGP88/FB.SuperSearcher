using FB.SuperSearcher.Backend;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace FB.SuperSearcher.Frontend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfigurationRoot _configurationRoot;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
            ServiceProviderTasks();
        }

        public void ServiceProviderTasks()
        {
            _serviceProvider.ServiceProviderTasksBackend(_configurationRoot);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<SearchTermStatisticsWindow>();
            services.AddTransient<CharacterStatistecsWindow>();
            services.AddSingleton(_ => _serviceProvider);
            services.ConfigureServicesBackend(_configurationRoot);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}