using FB.SuperSearcher.Backend.Handlers;
using FB.SuperSearcher.Backend.Models;
using System.Windows;

namespace FB.SuperSearcher.Frontend
{
    /// <summary>
    /// Interaction logic for CharacterStatistecsWindow.xaml
    /// </summary>
    public partial class CharacterStatistecsWindow : Window
    {
        private readonly IStatisticsHandler _statisticsHandler;

        public CharacterStatisticViewModel ViewModel;
        public CharacterStatistecsWindow(IStatisticsHandler statisticsHandler)
        {
            InitializeComponent();
            _statisticsHandler = statisticsHandler;
            SetContext();
        }

        public void Populate(char character)
        {
            ViewModel = _statisticsHandler.GetCharacterStatistics(character, default).GetAwaiter().GetResult();
            SetContext();
        }
        private void SetContext()
        {
            CharacterTextBox.DataContext = ViewModel;
            TotalCountTextBox.DataContext = ViewModel;
            LargestCountTextBox.DataContext = ViewModel;
            SmallestCountTextBox.DataContext = ViewModel;
            LongestTermTextBox.DataContext = ViewModel;
            ShortestTermTextBox.DataContext = ViewModel;
            FirstOccurenceTextBox.DataContext = ViewModel;
            LastOccurenceTextBox.DataContext = ViewModel;
        }
    }
}
