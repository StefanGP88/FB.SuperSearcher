using FB.SuperSearcher.Data.Models;
using System.IO;

namespace FB.SuperSearcher.Data.Mappers
{
    public static class SearchResultMappers
    {
        public static FileSearchResultModel MapToModel(this DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null) return null;
            return new FileSearchResultModel
            {
                FullPath = directoryInfo.FullName,
                Name = directoryInfo.Name,
                ResultType = "Folder"
            };
        }
        public static FileSearchResultModel MapToModel(this FileInfo fileInfo)
        {
            if (fileInfo == null) return null;
            return new FileSearchResultModel
            {
                FullPath = fileInfo.FullName,
                Name = fileInfo.Name,
                ResultType = "File"
            };
        }
    }
}
