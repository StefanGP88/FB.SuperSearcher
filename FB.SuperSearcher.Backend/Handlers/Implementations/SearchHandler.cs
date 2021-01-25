using FB.SuperSearcher.Backend.Mappers;
using FB.SuperSearcher.Backend.Models;
using FB.SuperSearcher.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Backend.Handlers.Implementations
{
    public class SearchHandler : ISearchHandler
    {
        private readonly IUnitOfWork _uow;
        public SearchHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<List<SearchResultViewModel>> Search(string searchTerm, CancellationToken cancellation)
        {
            var searchTasks = new[]
            {
                _uow.FileSearchRepository.Search(searchTerm, cancellation),
                _uow.WebSearchRepository.Search(searchTerm, cancellation)
            };
            var taskComplete = await Task.WhenAll(searchTasks).ConfigureAwait(false);

            var result = taskComplete.SelectMany(x => x).ToList();
            return result.ConvertAll(x => x.MapToViewModel());
        }
    }
}
