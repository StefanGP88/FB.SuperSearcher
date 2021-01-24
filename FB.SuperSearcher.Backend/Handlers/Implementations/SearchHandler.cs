using FB.SuperSearcher.Backend.Mappers;
using FB.SuperSearcher.Backend.Models;
using FB.SuperSearcher.Data;
using System.Collections.Generic;
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
            var result = new List<SearchResultViewModel>();

            var fileResults = await _uow.FileSearchRepository.SearchAsync(searchTerm, cancellation).ConfigureAwait(false);
            var webResult = await _uow.WebSearchRepository.SearchAsync(searchTerm, cancellation).ConfigureAwait(false);

            result.AddRange(fileResults.ConvertAll(x => x.MapToViewModel()));
            result.AddRange(webResult.ConvertAll(x => x.MapToViewModel()));

            return result;
        }
    }
}
