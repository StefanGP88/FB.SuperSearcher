using FB.SuperSearcher.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FB.SuperSearcher.Data.Mappers;

namespace FB.SuperSearcher.Data.Repositories.Implementations
{
    public class FileSearchRepository : ISearchRepository
    {
        public List<FileSearchResultModel> Search(string searchTerm)
        {
            //TODO: dont hardcode result count
            var resultCount = 5;
            var result = new List<FileSearchResultModel>();
            var paths = GetLogicalDrives();

            while (paths.TryPeek(out _) && result.Count < resultCount - 1)
            {
                var folder = paths.Pop();
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
                .Take(resultCount)
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
        private FileSearchResultModel GetFileModel(string path)
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
                //remove file extention from name
                fileName = file.Name.Replace(file.Extension, "");
            }
            //if(file.)

            return fileName.Contains(match, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
