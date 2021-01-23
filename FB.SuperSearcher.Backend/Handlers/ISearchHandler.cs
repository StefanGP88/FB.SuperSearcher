using FB.SuperSearcher.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Backend.Handlers
{
    public interface ISearchHandler
    {
        Task<List<SearchResultViewModel>> Search(string searchTerm);
    }
}
