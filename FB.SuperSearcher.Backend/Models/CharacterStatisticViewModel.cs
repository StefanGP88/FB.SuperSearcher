using System;

namespace FB.SuperSearcher.Backend.Models
{
    public class CharacterStatisticViewModel
    {
        public char Character { get; set; }
        public int TotalCount { get; set; }
        public int LargestCount { get; set; }
        public int SmallestCount { get; set; }
        public string LongestTerm { get; set; }
        public string ShortestTerm { get; set; }
        public DateTime FirstOccurence { get; set; }
        public DateTime LastOccurence { get; set; }
    }
}
