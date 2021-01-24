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
        public async Task<SearchTermDbModel> FindSearchTermFrom(string Term, CancellationToken cancellation)
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

            var charss = await _dbContext.SearchTermCharacters
                .AsNoTracking()
                .Where(x => x.Character == character)
                .Select(x=>x.SearchTermId)
                .ToListAsync(cancellation)
                .ConfigureAwait(false);

            var termss = await _dbContext.SearchTerms
                .AsNoTracking()
                .Where(x=> charss.Contains(x.Id))
                .Include(x => x.SearchDates)
                .Include(x => x.Characters.Where(v=>v.Character == character))
                .ToListAsync(cancellation)
                .ConfigureAwait(false);

            return termss.SelectMany(x => x.Characters).ToList();
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
