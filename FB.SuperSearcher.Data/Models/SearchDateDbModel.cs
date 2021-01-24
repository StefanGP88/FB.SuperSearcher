using System;

namespace FB.SuperSearcher.Data.Models
{
    public class SearchDateDbModel
    {
        public Guid Id { get; set; }
        public DateTime SearchDate { get; set; }

        public Guid SearchTermId { get; set; }
        public SearchTermDbModel SearchTerm { get; set; }
    }
}
