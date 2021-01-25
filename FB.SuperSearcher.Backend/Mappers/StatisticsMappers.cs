using FB.SuperSearcher.Backend.Models;
using FB.SuperSearcher.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FB.SuperSearcher.Backend.Mappers
{
    public static class StatisticsMappers
    {
        public static SearchTermStatisticsViewModel MapToViewModel(this SearchTermDbModel dbModel)
        {
            if (dbModel == null) return null;
            return new SearchTermStatisticsViewModel
            {
                Term = dbModel.SearchTerm,
                Length = dbModel.Length,
                TotalOcurrences = dbModel.SearchDates.Count,
                Characters = dbModel.Characters.ConvertAll(x => x.MapToViewModel()),
                FirstOccurence = dbModel.SearchDates.Min(x => x.SearchDate),
                LastOccurence = dbModel.SearchDates.Max(x => x.SearchDate)
            };
        }

        public static CharacterCountViewModel MapToViewModel(this SearchTermCharactersDbModel dbModel)
        {
            if (dbModel == null) return null;
            return new CharacterCountViewModel
            {
                Character = dbModel.Character,
                Count = dbModel.Count
            };
        }

        public static CharacterStatisticViewModel MapToEmptyViewModel(this List<SearchTermCharactersDbModel> list, char character)
        {
            if (list == null) return null;

            return new CharacterStatisticViewModel
            {
                Character = character
            };
        }

        public static CharacterStatisticViewModel MapToViewModel(this List<SearchTermCharactersDbModel> list)
        {
            if (list == null) return null;

            var viewModel = new CharacterStatisticViewModel
            {
                Character = list[0].Character,
                TotalCount = list.Sum(x => x.SearchTerm.SearchDates.Count * x.Count),
                FirstOccurence = list.SelectMany(x => x.SearchTerm.SearchDates).Min(x => x.SearchDate),
                LastOccurence = list.SelectMany(x => x.SearchTerm.SearchDates).Max(x => x.SearchDate),
                LargestCount = list.Max(x => x.Count),
                SmallestCount = list.Min(x => x.Count),
                LongestTerm = list.Aggregate(string.Empty, (longest, current) => longest.Length > current.SearchTerm.Length ? longest : current.SearchTerm.SearchTerm)
            };
            viewModel.ShortestTerm = list.Aggregate(viewModel.LongestTerm, (shortest, current) => shortest.Length < current.SearchTerm.Length ? shortest : current.SearchTerm.SearchTerm);
            return viewModel;
        }
    }
}
