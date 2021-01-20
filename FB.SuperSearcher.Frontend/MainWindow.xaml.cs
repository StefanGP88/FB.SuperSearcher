using FB.SuperSearcher.Backend.Handlers;
using System.Windows;

namespace FB.SuperSearcher.Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISearchHandler _searchHandler;
        public MainWindow(ISearchHandler searchHandler)
        {
            InitializeComponent();
            _searchHandler = searchHandler;
        }

        private void PerformSearch(object sender, RoutedEventArgs e)
        {
            SearchResultListView.ItemsSource = _searchHandler.Search(SearchTextbox.Text);
        }
    }
}
