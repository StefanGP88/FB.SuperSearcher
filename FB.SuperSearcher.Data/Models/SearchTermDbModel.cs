using System;
using System.Collections.Generic;

namespace FB.SuperSearcher.Data.Models
{
    public class SearchTermDbModel
    {
        private string _searchTerm;
        public Guid Id { get; set; }
        public string SearchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value.ToLowerInvariant(); }
        }
        public int Length { get; set; }

        public List<SearchDateDbModel> SearchDates { get; set; }
        public List<SearchTermCharactersDbModel> Characters { get; set; }
    }
}
