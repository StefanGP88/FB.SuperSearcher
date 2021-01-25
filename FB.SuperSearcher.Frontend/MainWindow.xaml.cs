using FB.SuperSearcher.Backend.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace FB.SuperSearcher.Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISearchHandler _searchHandler;
        private readonly IStatisticsHandler _statisticsHandler;
        private readonly IServiceProvider _serviceProvider;
        public MainWindow(ISearchHandler searchHandler, IStatisticsHandler statisticsHandler,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _searchHandler = searchHandler;
            _statisticsHandler = statisticsHandler;
            _serviceProvider = serviceProvider;
        }

        private string GetSearchTerm()
        {
            return SearchTextbox.Text.ToLowerInvariant();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = GetSearchTerm();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("please enter a search term");
            }
            else
            {
                SearchResultListView.ItemsSource = _searchHandler.Search(searchTerm, default).GetAwaiter().GetResult();
                _statisticsHandler.AddOrUpdateSearchStatistic(searchTerm, default);
            }
        }

        private void StatisticButton_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = GetSearchTerm();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("please enter a search term");
            }
            else
            {
                var window = _serviceProvider.GetRequiredService<SearchTermStatisticsWindow>();
                window.Populate(searchTerm);
                window.Show();
            }
        }

        private void CharStatsButton_Click(object sender, RoutedEventArgs e)
        {
            var character = GetSearchTerm();
            if (string.IsNullOrWhiteSpace(character))
            {
                MessageBox.Show("please enter a character");
            }
            else if(character.Length != 1)
            {
                MessageBox.Show("please only enter 1 character");
            }
            else
            {
                var window = _serviceProvider.GetRequiredService<CharacterStatistecsWindow>();
                window.Populate(char.Parse(character));
                window.Show();
            }
        }
    }
}
