using FB.SuperSearcher.Backend.Models;
using System.Collections.Generic;

namespace FB.SuperSearcher.Backend.Handlers
{
    public interface ISearchHandler
    {
        List<SearchResultViewModel> Search(string searchTerm);
    }
}
