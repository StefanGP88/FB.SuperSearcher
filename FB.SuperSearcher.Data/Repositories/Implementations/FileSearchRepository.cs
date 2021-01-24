using FB.SuperSearcher.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FB.SuperSearcher.Data.Mappers;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Data.Repositories.Implementations
{
    public class FileSearchRepository : IFileSearchRepository
    {
        public async Task<List<SearchResultModel>> SearchAsync(string searchTerm)
        {
            return await Task.Run(() => SearchRoutine(searchTerm)).ConfigureAwait(false);
        }

        private List<SearchResultModel> SearchRoutine(string searchTerm)
        {
            //TODO: dont hardcode result count
            const int maxCount = 5;
            var result = new List<SearchResultModel>();
            if (string.IsNullOrWhiteSpace(searchTerm)) return result;

            var paths = GetLogicalDrives();

            while (paths.TryPop(out var folder) && result.Count < maxCount - 1)
            {
                if (IsMatchingFolder(folder, searchTerm, out var directoryInfo, out var continueLoop))
                {
                    result.Add(directoryInfo.MapToModel());
                }

                if (continueLoop) continue;

                try
                {
                    var matchingFiles = Directory
                        .EnumerateFiles(folder)
                        .Where(x => IsMatchingFile(x, searchTerm))
                        .Take(maxCount - result.Count)
                        .Select(x => GetFileModel(x))
                        .ToList();

                    result.AddRange(matchingFiles);

                    var subFolders = Directory
                        .EnumerateDirectories(folder, "*", SearchOption.TopDirectoryOnly)
                        .OrderByDescending(x => x)
                        .ToList();
                    subFolders.ForEach(x => paths.Push(x));
                }
                catch
                {
                }
            }

            return result
                .OrderBy(x => x.FullPath)
                .ToList();
        }
        private Stack<string> GetLogicalDrives()
        {
            var stack = new Stack<string>();

            foreach (var item in Environment.GetLogicalDrives().OrderByDescending(x => x))
            {
                var driveInfo = new DriveInfo(item);
                if (driveInfo.IsReady)
                    stack.Push(item);
            }
            return stack;
        }
        private bool IsMatchingFolder(string path, string match, out DirectoryInfo directoryInfo, out bool continueLoop)
        {
            directoryInfo = new DirectoryInfo(path);
            continueLoop = false;

            // filter out stuff like C:\$Recycle.Bin
            if (!string.IsNullOrWhiteSpace(directoryInfo.Extension))
                continueLoop = true;

            if (continueLoop) return false;

            return directoryInfo.Name.Contains(match, StringComparison.CurrentCultureIgnoreCase);
        }
        private SearchResultModel GetFileModel(string path)
        {
            var file = new FileInfo(path);
            return file.MapToModel();
        }
        private bool IsMatchingFile(string path, string match)
        {
            var file = new FileInfo(path);
            var fileName = file.Name;
            if (!string.IsNullOrWhiteSpace(file.Extension))
            {
                fileName = file.Name.Replace(file.Extension, "");
            }

            return fileName.Contains(match, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
