using System;
using System.Collections.Generic;

namespace FB.SuperSearcher.Backend.Models
{
    public class SearchTermStatisticsViewModel
    {
        public string Term { get; set; }
        public int Length { get; set; }
        public DateTime FirstOccurence { get; set; }
        public DateTime LastOccurence { get; set; }
        public int TotalOcurrences { get; set; }
        public List<CharacterCountViewModel> Characters { get; set; }
    }
}
