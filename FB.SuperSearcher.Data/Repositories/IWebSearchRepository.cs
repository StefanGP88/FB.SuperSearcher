using FB.SuperSearcher.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Data.Repositories
{
    public interface IWebSearchRepository
    {
        Task<List<SearchResultModel>> SearchAsync(string searchTerm);
    }
}
