using FB.SuperSearcher.Backend.Handlers;
using FB.SuperSearcher.Backend.Models;
using System.Windows;

namespace FB.SuperSearcher.Frontend
{
    /// <summary>
    /// Interaction logic for SearchTermStatisticsWindow.xaml
    /// </summary>
    public partial class SearchTermStatisticsWindow : Window
    {
        private readonly IStatisticsHandler _statisticsHandler;

        public SearchTermStatisticsViewModel ViewModel;
        public SearchTermStatisticsWindow(IStatisticsHandler statisticsHandler)
        {
            InitializeComponent();
            _statisticsHandler = statisticsHandler;
            SetContext();
        }

        public void Populate(string searchTerm)
        {
            ViewModel = _statisticsHandler.GetSerchTermStatistics(searchTerm, default).GetAwaiter().GetResult();
            SetContext();
        }
        private void SetContext()
        {
            SearchTermTextBox.DataContext = ViewModel;
            SearchLengthTextBox.DataContext = ViewModel;
            FirstTimeTextBox.DataContext = ViewModel;
            LastTimeTextBox.DataContext = ViewModel;
            TotalTimesTextBox.DataContext = ViewModel;
            CharacterListView.ItemsSource = ViewModel?.Characters;
        }
    }
}
