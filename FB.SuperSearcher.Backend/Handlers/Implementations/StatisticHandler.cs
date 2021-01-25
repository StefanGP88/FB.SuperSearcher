using FB.SuperSearcher.Backend.Mappers;
using FB.SuperSearcher.Backend.Models;
using FB.SuperSearcher.Data;
using FB.SuperSearcher.Data.Mappers;
using FB.SuperSearcher.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Backend.Handlers.Implementations
{
    public class StatisticHandler : IStatisticsHandler
    {
        private readonly IUnitOfWork _uow;
        public StatisticHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task AddOrUpdateSearchStatistic(string searchTerm, CancellationToken cancellation)
        {
            var termStats = await _uow.StatisticRepository.FindSearchTermFrom(searchTerm, cancellation).ConfigureAwait(false);

            if (termStats == null)
                await AddNewSerchTerm(searchTerm, cancellation).ConfigureAwait(false);
            else
                await UpdateSeachTerm(termStats, cancellation).ConfigureAwait(false);

            _ = await _uow.SaveChangesAsync(cancellation).ConfigureAwait(false);
        }

        public async Task<SearchTermStatisticsViewModel> GetSerchTermStatistics(string searchTerm, CancellationToken cancellation)
        {
            var termStats = await _uow.StatisticRepository.FindSearchTermFrom(searchTerm, cancellation).ConfigureAwait(false);
            return termStats.MapToViewModel();
        }

        public async Task<CharacterStatisticViewModel> GetCharacterStatistics(char character, CancellationToken cancellation)
        {
            var characterOccurences = await _uow.StatisticRepository.GetCharacterOcurrences(character, cancellation).ConfigureAwait(false);
            if (characterOccurences.Count == 0)
            {
                return characterOccurences.MapToEmptyViewModel(character);
            }
            return characterOccurences.MapToViewModel();
        }

        private async Task AddNewSerchTerm(string searchTerm, CancellationToken cancellation)
        {
            var model = searchTerm.MapToSearchTermDbModel();
            await _uow.StatisticRepository.AddSearchTerm(model, cancellation).ConfigureAwait(false);
        }

        private async Task UpdateSeachTerm(SearchTermDbModel model, CancellationToken cancellation)
        {
            var searchDateModel = model.MapNewSearchDateDbModel();
            await _uow.StatisticRepository.AddSearchDate(searchDateModel, cancellation).ConfigureAwait(false);
        }
    }
}
