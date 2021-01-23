using FB.SuperSearcher.Data.Models;
using System.Collections.Generic;

namespace FB.SuperSearcher.Data.Repositories
{
    public interface ISearchRepository
    {
        List<FileSearchResultModel> Search(string term);
    }
}
