using FB.SuperSearcher.Backend.Models;
using System.Threading;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Backend.Handlers
{
    public interface IStatisticsHandler
    {
        Task AddOrUpdateSearchStatistic(string searchTerm, CancellationToken cancellation);
        Task<SearchTermStatisticsViewModel> GetSerchTermStatistics(string searchTerm, CancellationToken cancellation);
        Task<CharacterStatisticViewModel> GetCharacterStatistics(char character, CancellationToken cancellation);
    }
}
