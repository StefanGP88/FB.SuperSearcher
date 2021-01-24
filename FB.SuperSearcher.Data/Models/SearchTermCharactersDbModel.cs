using System;

namespace FB.SuperSearcher.Data.Models
{
    public class SearchTermCharactersDbModel
    {
        private char _character;
        public Guid Id { get; set; }
        public char Character
        {
            get { return _character; }
            set { _character = char.ToLowerInvariant(value); }
        }
        public int Count { get; set; }

        public Guid SearchTermId { get; set; }
        public SearchTermDbModel SearchTerm { get; set; }
    }
}
