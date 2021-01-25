using FB.SuperSearcher.Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Data.Repositories
{
    public interface IFileSearchRepository
    {
        Task<List<SearchResultModel>> Search(string searchTerm, CancellationToken cancellation);
    }
}
