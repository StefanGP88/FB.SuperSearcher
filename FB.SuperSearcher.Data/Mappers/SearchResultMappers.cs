using FB.SuperSearcher.Data.Enums;
using FB.SuperSearcher.Data.Models;
using System.IO;

namespace FB.SuperSearcher.Data.Mappers
{
    public static class SearchResultMappers
    {
        public static SearchResultModel MapToModel(this DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null) return null;
            return new SearchResultModel
            {
                FullPath = directoryInfo.FullName,
                Name = directoryInfo.Name,
                ResultType = SearchResultTypes.Folder
            };
        }
        public static SearchResultModel MapToModel(this FileInfo fileInfo)
        {
            if (fileInfo == null) return null;
            return new SearchResultModel
            {
                FullPath = fileInfo.FullName,
                Name = fileInfo.Name,
                ResultType = SearchResultTypes.File
            };
        }

        public static SearchResultModel MapToModel(this Value bingResult, SearchResultTypes resultType)
        {
            if (bingResult == null) return null;
            return new SearchResultModel
            {
                FullPath = bingResult.Url,
                Name = bingResult.Name,
                ResultType = resultType
            };
        }
    }
}
