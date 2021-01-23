using FB.SuperSearcher.Data.Repositories;

namespace FB.SuperSearcher.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IWebSearchRepository WebSearchRepository { get; }
        public IFileSearchRepository FileSearchRepository { get; }
        public UnitOfWork(IWebSearchRepository webSearchRepository, IFileSearchRepository fileSearchRepository)
        {
            WebSearchRepository = webSearchRepository;
            FileSearchRepository = fileSearchRepository;
        }
    }
}
