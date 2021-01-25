using System;

namespace FB.SuperSearcher.Data.Models
{
    public class SearchTermCharactersDbModel
    {
        public Guid Id { get; set; }
        public char Character { get; set; }
        public int Count { get; set; }

        public Guid SearchTermId { get; set; }
        public SearchTermDbModel SearchTerm { get; set; }
    }
}
