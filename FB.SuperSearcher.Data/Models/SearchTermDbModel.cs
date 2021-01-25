using System;
using System.Collections.Generic;

namespace FB.SuperSearcher.Data.Models
{
    public class SearchTermDbModel
    {
        public Guid Id { get; set; }
        public string SearchTerm { get; set; }
        public int Length { get; set; }

        public List<SearchDateDbModel> SearchDates { get; set; }
        public List<SearchTermCharactersDbModel> Characters { get; set; }
    }
}
