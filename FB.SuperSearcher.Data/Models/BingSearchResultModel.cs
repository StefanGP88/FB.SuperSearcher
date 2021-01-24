using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FB.SuperSearcher.Data.Models
{
    public class QueryContext
    {
        [JsonProperty("originalQuery")]
        public string OriginalQuery { get; set; }
    }

    public class DeepLink
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class License
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ContractualRule
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("targetPropertyName")]
        public string TargetPropertyName { get; set; }

        [JsonProperty("targetPropertyIndex")]
        public int TargetPropertyIndex { get; set; }

        [JsonProperty("mustBeCloseToContent")]
        public bool MustBeCloseToContent { get; set; }

        [JsonProperty("license")]
        public License License { get; set; }

        [JsonProperty("licenseNotice")]
        public string LicenseNotice { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Value
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("isFamilyFriendly")]
        public bool IsFamilyFriendly { get; set; }

        [JsonProperty("displayUrl")]
        public string DisplayUrl { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("deepLinks")]
        public List<DeepLink> DeepLinks { get; set; }

        [JsonProperty("dateLastCrawled")]
        public DateTime DateLastCrawled { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("isNavigational")]
        public bool IsNavigational { get; set; }

        [JsonProperty("contractualRules")]
        public List<ContractualRule> ContractualRules { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("webSearchUrl")]
        public string WebSearchUrl { get; set; }

        [JsonProperty("datePublished")]
        public DateTime DatePublished { get; set; }

        [JsonProperty("contentUrl")]
        public string ContentUrl { get; set; }

        [JsonProperty("hostPageUrl")]
        public string HostPageUrl { get; set; }

        [JsonProperty("contentSize")]
        public string ContentSize { get; set; }

        [JsonProperty("encodingFormat")]
        public string EncodingFormat { get; set; }

        [JsonProperty("hostPageDisplayUrl")]
        public string HostPageDisplayUrl { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("insightsMetadata")]
        public InsightsMetadata InsightsMetadata { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("about")]
        public List<About> About { get; set; }

        [JsonProperty("provider")]
        public List<Provider> Provider { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("mentions")]
        public List<Mention> Mentions { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("publisher")]
        public List<Publisher> Publisher { get; set; }

        [JsonProperty("isAccessibleForFree")]
        public bool IsAccessibleForFree { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("motionThumbnailUrl")]
        public string MotionThumbnailUrl { get; set; }

        [JsonProperty("embedHtml")]
        public string EmbedHtml { get; set; }

        [JsonProperty("allowHttpsEmbed")]
        public bool AllowHttpsEmbed { get; set; }

        [JsonProperty("viewCount")]
        public int ViewCount { get; set; }

        [JsonProperty("allowMobileEmbed")]
        public bool AllowMobileEmbed { get; set; }

        [JsonProperty("isSuperfresh")]
        public bool IsSuperfresh { get; set; }
    }

    public class WebPages
    {
        [JsonProperty("webSearchUrl")]
        public string WebSearchUrl { get; set; }

        [JsonProperty("totalEstimatedMatches")]
        public int TotalEstimatedMatches { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("contentUrl")]
        public string ContentUrl { get; set; }
    }

    public class InsightsMetadata
    {
        [JsonProperty("shoppingSourcesCount")]
        public int ShoppingSourcesCount { get; set; }

        [JsonProperty("recipeSourcesCount")]
        public int RecipeSourcesCount { get; set; }
    }

    public class Images
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("readLink")]
        public string ReadLink { get; set; }

        [JsonProperty("webSearchUrl")]
        public string WebSearchUrl { get; set; }

        [JsonProperty("isFamilyFriendly")]
        public bool IsFamilyFriendly { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }
    }

    public class Image
    {
        [JsonProperty("contentUrl")]
        public string ContentUrl { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }
    }

    public class About
    {
        [JsonProperty("readLink")]
        public string ReadLink { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Provider
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }
    }

    public class Mention
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class News
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("readLink")]
        public string ReadLink { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }
    }

    public class RelatedSearches
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }
    }

    public class Publisher
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Videos
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("readLink")]
        public string ReadLink { get; set; }

        [JsonProperty("webSearchUrl")]
        public string WebSearchUrl { get; set; }

        [JsonProperty("isFamilyFriendly")]
        public bool IsFamilyFriendly { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }

        [JsonProperty("scenario")]
        public string Scenario { get; set; }
    }

    public class Item
    {
        [JsonProperty("answerType")]
        public string AnswerType { get; set; }

        [JsonProperty("resultIndex")]
        public int ResultIndex { get; set; }

        [JsonProperty("value")]
        public Value Value { get; set; }
    }

    public class Mainline
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Sidebar
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class RankingResponse
    {
        [JsonProperty("mainline")]
        public Mainline Mainline { get; set; }

        [JsonProperty("sidebar")]
        public Sidebar Sidebar { get; set; }
    }

    public class BingSearchResultModel
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("queryContext")]
        public QueryContext QueryContext { get; set; }

        [JsonProperty("webPages")]
        public WebPages WebPages { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("news")]
        public News News { get; set; }

        [JsonProperty("relatedSearches")]
        public RelatedSearches RelatedSearches { get; set; }

        [JsonProperty("videos")]
        public Videos Videos { get; set; }

        [JsonProperty("rankingResponse")]
        public RankingResponse RankingResponse { get; set; }
    }
}
