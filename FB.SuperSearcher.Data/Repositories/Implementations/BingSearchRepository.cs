using FB.SuperSearcher.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Linq;
using FB.SuperSearcher.Data.Mappers;
using FB.SuperSearcher.Data.Enums;
using System.Threading;
using Microsoft.Extensions.Options;
using FB.SuperSearcher.Data.Settings;

namespace FB.SuperSearcher.Data.Repositories.Implementations
{
    public class BingSearchRepository : IWebSearchRepository
    {
        private readonly SearchSettings _settings;
        public BingSearchRepository(IOptions<SearchSettings> settings)
        {
            _settings = settings.Value;
        }
        public async Task<List<SearchResultModel>> SearchAsync(string searchTerm, CancellationToken cancellation)
        {
            var result = new List<SearchResultModel>();
            var queryResult = await QueryBing(searchTerm, _settings.MaxWebResult, cancellation).ConfigureAwait(false);

            if (queryResult?.WebPages?.Value?.Any() == true)
            {
                var webpageResults = queryResult.WebPages.Value
                    .Take(_settings.MaxWebResult)
                    .Select(x => x.MapToModel(SearchResultTypes.WebPage))
                    .ToList();
                result.AddRange(webpageResults);
            }

            if (result.Count < _settings.MaxWebResult && queryResult?.News?.Value?.Any() == true)
            {
                var articleResults = queryResult.News.Value
                    .Take(_settings.MaxWebResult - result.Count)
                    .Select(x => x.MapToModel(SearchResultTypes.Article))
                    .ToList();
                result.AddRange(articleResults);
            }
            return result;
        }

        private async Task<BingSearchResultModel> QueryBing(string term, int maxCount, CancellationToken cancellation)
        {
            try
            {
                return await _settings.BingApiUrl
                    .SetQueryParam("q", Uri.EscapeDataString(term))
                    .SetQueryParam("mkt", "en-us")
                    .SetQueryParam("textDecorations", bool.TrueString)
                    .SetQueryParam("count", maxCount)
                    .SetQueryParam("offset", 0)
                    .WithHeader("Ocp-Apim-Subscription-Key", _settings.BingSubscriptionKey)
                    .GetJsonAsync<BingSearchResultModel>(cancellation)
                    .ConfigureAwait(false);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
