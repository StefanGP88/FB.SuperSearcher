using FB.SuperSearcher.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FB.SuperSearcher.Data.Repositories.Implementations
{
    public class StatisticEfCoreRepository : IStatisticRepository
    {
        private readonly SearchStatisticDbContext _dbContext;
        public StatisticEfCoreRepository(SearchStatisticDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<SearchTermDbModel> GetSearchTerm(string Term, CancellationToken cancellation)
        {
            return await _dbContext.SearchTerms
                .AsNoTracking()
                .Include(x => x.SearchDates)
                .Include(x => x.Characters)
                .FirstOrDefaultAsync(x => x.SearchTerm == Term.ToLower(), cancellation)
                .ConfigureAwait(false);
        }

        public async Task<List<SearchTermCharactersDbModel>> GetCharacterOcurrences(char character, CancellationToken cancellation)
        {
            if (!await _dbContext.SearchTermCharacters.AnyAsync(x => x.Character == character, cancellation).ConfigureAwait(false))
                return new List<SearchTermCharactersDbModel>();

            var termIds = _dbContext.SearchTermCharacters
                .AsNoTracking()
                .Where(x => x.Character == character)
                .Select(x => x.SearchTermId);

            var term = await _dbContext.SearchTerms
                .AsNoTracking()
                .Where(x=> termIds.Contains(x.Id))
                .Include(x => x.SearchDates)
                .Include(x => x.Characters.Where(v=>v.Character == character))
                .ToListAsync(cancellation)
                .ConfigureAwait(false);

            return term.SelectMany(x => x.Characters).ToList();
        }

        public async Task AddSearchDate(SearchDateDbModel model, CancellationToken cancellation)
        {
            await _dbContext.SearchDates.AddAsync(model, cancellation).ConfigureAwait(false);
        }

        public async Task AddSearchTerm(SearchTermDbModel model, CancellationToken cancellation)
        {
            await _dbContext.SearchTerms.AddAsync(model, cancellation).ConfigureAwait(false);
        }
    }
}
