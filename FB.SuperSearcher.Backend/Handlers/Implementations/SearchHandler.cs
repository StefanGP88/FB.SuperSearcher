using FB.SuperSearcher.Backend.Mappers;
using FB.SuperSearcher.Backend.Models;
using FB.SuperSearcher.Data.Repositories;
using System.Collections.Generic;

namespace FB.SuperSearcher.Backend.Handlers.Implementations
{
    public class SearchHandler : ISearchHandler
    {
        private readonly ISearchRepository _repository;
        public SearchHandler(ISearchRepository searchRepository)
        {
            _repository = searchRepository;
        }
        public List<SearchResultViewModel> Search(string searchTerm)
        {
            var result = _repository.Search(searchTerm);
            return result.ConvertAll(x => x.MapToViewModel());
        }
    }
}
