using FB.SuperSearcher.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FB.SuperSearcher.Data.Mappers
{
    public static class StatisticMappers
    {
        public static SearchTermDbModel MapToSearchTermDbModel(this string term)
        {
            if (string.IsNullOrWhiteSpace(term)) return null;
            var model = new SearchTermDbModel
            {
                Id = Guid.NewGuid(),
                Length = term.Length,
                SearchTerm = term,
                SearchDates = new List<SearchDateDbModel>()
            };
            model.MapNewSearchCharacterDbModelList();
            model.SearchDates.Add(model.MapNewSearchDateDbModel());
            return model;
        }

        public static SearchDateDbModel MapNewSearchDateDbModel(this SearchTermDbModel searchTermDbModel)
        {
            if (string.IsNullOrWhiteSpace(searchTermDbModel.SearchTerm)) return null;
            return new SearchDateDbModel
            {
                Id = Guid.NewGuid(),
                SearchTermId = searchTermDbModel.Id,
                SearchDate = DateTime.UtcNow
            };
        }
        private static void MapNewSearchCharacterDbModelList(this SearchTermDbModel searchTermDbModel)
        {
            var characters = searchTermDbModel.SearchTerm.Distinct().ToList();
            searchTermDbModel.Characters = characters.ConvertAll(x => new SearchTermCharactersDbModel
            {
                Id = Guid.NewGuid(),
                Character = x,
                Count = searchTermDbModel.SearchTerm.Count(y => y == x)
            });
        }
    }
}
