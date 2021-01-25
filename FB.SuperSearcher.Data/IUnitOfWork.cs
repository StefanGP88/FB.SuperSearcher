using FB.SuperSearcher.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Data
{
    public interface IUnitOfWork
    {
        IWebSearchRepository WebSearchRepository { get; }
        IFileSearchRepository FileSearchRepository { get; }
        IStatisticRepository StatisticRepository { get; }

        Task<int> SaveChanges(CancellationToken cancellation);
    }
}
