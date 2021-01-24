using FB.SuperSearcher.Backend.Models;
using FB.SuperSearcher.Data.Models;

namespace FB.SuperSearcher.Backend.Mappers
{
    public static class SearchResultMappers
    {
        public static SearchResultViewModel MapToViewModel(this SearchResultModel model)
        {
            if (model == null) return null;
            return new SearchResultViewModel
            {
                Path = model.FullPath,
                Title = model.Name,
                SearchResultType = model.ResultType
            };
        }
    }
}
