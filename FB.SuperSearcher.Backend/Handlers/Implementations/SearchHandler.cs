using FB.SuperSearcher.Backend.Models;
using System.Collections.Generic;

namespace FB.SuperSearcher.Backend.Handlers.Implementations
{
    public class SearchHandler : ISearchHandler
    {
        public List<SearchResultViewModel> Search(string searchTerm)
        {
            return new List<SearchResultViewModel>
            {
                new SearchResultViewModel{IsWebResult = true, Path="www.google.com"},
                new SearchResultViewModel{IsWebResult =false, Path = "C://Folder/"}
            };
        }
    }
}
