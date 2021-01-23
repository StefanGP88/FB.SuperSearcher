using FB.SuperSearcher.Data.Repositories;

namespace FB.SuperSearcher.Data
{
    public interface IUnitOfWork
    {
        IWebSearchRepository WebSearchRepository { get; }
        IFileSearchRepository FileSearchRepository { get; }
    }
}
