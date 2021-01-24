using FB.SuperSearcher.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Linq;
using FB.SuperSearcher.Data.Mappers;
using FB.SuperSearcher.Data.Enums;

namespace FB.SuperSearcher.Data.Repositories.Implementations
{
    public class BingSearchRepository : IWebSearchRepository
    {
        private readonly string _subscriptionKey = "ed1a652d8dfd45339aadb0fce83aec5a";
        private readonly string _baseUri = "https://api.bing.microsoft.com/v7.0/search";
        public async Task<List<SearchResultModel>> SearchAsync(string searchTerm)
        {
            const int maxCount = 5;
            var result = new List<SearchResultModel>();
            var queryResult = await QueryBing(searchTerm, maxCount).ConfigureAwait(false);

            if (queryResult?.WebPages?.Value?.Any() == true)
            {
                var webpageResults = queryResult.WebPages.Value
                    .Take(maxCount)
                    .Select(x => x.MapToModel(SearchResultTypes.WebPage))
                    .ToList();
                result.AddRange(webpageResults);
            }

            if (result.Count < maxCount && queryResult?.News?.Value?.Any() == true)
            {
                var articleResults = queryResult.News.Value
                    .Take(maxCount - result.Count)
                    .Select(x => x.MapToModel(SearchResultTypes.Article))
                    .ToList();
                result.AddRange(articleResults);
            }
            return result;
        }

        private async Task<BingSearchResultModel> QueryBing(string term, int maxCount)
        {
            try
            {
                return await _baseUri
                    .SetQueryParam("q", Uri.EscapeDataString(term))
                    .SetQueryParam("mkt", "en-us")
                    .SetQueryParam("textDecorations", bool.TrueString)
                    .SetQueryParam("count", maxCount)
                    .SetQueryParam("offset", 0)
                    .WithHeader("Ocp-Apim-Subscription-Key", _subscriptionKey)
                    .GetJsonAsync<BingSearchResultModel>()
                    .ConfigureAwait(false);
            }
            catch(FlurlHttpException e)
            {
                return null;
            }
            catch(Exception e)
            {
                return null;

            }
        }
    }
}
