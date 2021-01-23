using FB.SuperSearcher.Data.Enums;

namespace FB.SuperSearcher.Data.Models
{
    public class SearchResultModel
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public SearchResultTypes ResultType { get; set; }
    }
}
