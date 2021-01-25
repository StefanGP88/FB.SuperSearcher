using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FB.SuperSearcher.Data.Models
{
    public class SearchStatisticDbContextDesign : IDesignTimeDbContextFactory<SearchStatisticDbContext>
    {
        public SearchStatisticDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SearchStatisticDbContext>();
            builder.UseSqlServer("Cannot be emty for migrations");
            return new SearchStatisticDbContext(builder.Options);
        }
    }
}
