using FB.SuperSearcher.Data.Enums;

namespace FB.SuperSearcher.Backend.Models
{
    public class SearchResultViewModel
    {
        public SearchResultTypes SearchResultType { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
    }
}
