using FB.SuperSearcher.Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Data.Repositories
{
    public interface IStatisticRepository
    {
        Task<SearchTermDbModel> FindSearchTermFrom(string Term, CancellationToken cancellation);
        Task<List<SearchTermCharactersDbModel>> GetCharacterOcurrences(char character, CancellationToken cancellation);
        Task AddSearchTerm(SearchTermDbModel model, CancellationToken cancellation);
        Task AddSearchDate(SearchDateDbModel model, CancellationToken cancellation);
    }
}
