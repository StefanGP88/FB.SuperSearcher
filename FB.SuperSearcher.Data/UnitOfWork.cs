using FB.SuperSearcher.Data.Models;
using FB.SuperSearcher.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SearchStatisticDbContext _statisticDbContext;
        public IWebSearchRepository WebSearchRepository { get; }
        public IFileSearchRepository FileSearchRepository { get; }
        public IStatisticRepository StatisticRepository { get; }
        public UnitOfWork(IWebSearchRepository webSearchRepository, IFileSearchRepository fileSearchRepository,
            IStatisticRepository statisticRepository, SearchStatisticDbContext searchStatisticDbContext)
        {
            WebSearchRepository = webSearchRepository;
            FileSearchRepository = fileSearchRepository;
            StatisticRepository = statisticRepository;
            _statisticDbContext = searchStatisticDbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellation)
        {
            return await _statisticDbContext.SaveChangesAsync(cancellation).ConfigureAwait(false);
        }
    }
}
