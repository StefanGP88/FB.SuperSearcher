using Microsoft.EntityFrameworkCore;

namespace FB.SuperSearcher.Data.Models
{
    public class SearchStatisticDbContext : DbContext
    {
        private const string connectionString = "Data Source=localhost;Initial Catalog=SearcherDb;Integrated Security=true;MultipleActiveResultSets=True;";
        public SearchStatisticDbContext() : base() { }
        public SearchStatisticDbContext(DbContextOptions<SearchStatisticDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<SearchTermDbModel> SearchTerms { get; set; }
        public DbSet<SearchTermCharactersDbModel> SearchTermCharacters { get; set; }
        public DbSet<SearchDateDbModel> SearchDates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchTermDbModel>().HasKey(x => x.Id);
            modelBuilder.Entity<SearchTermDbModel>().HasAlternateKey(x => x.SearchTerm);
            modelBuilder.Entity<SearchTermDbModel>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<SearchTermDbModel>().Property(x => x.SearchTerm).IsRequired();
            modelBuilder.Entity<SearchTermDbModel>().Property(x => x.Length).IsRequired();
            modelBuilder.Entity<SearchTermDbModel>().HasMany(x => x.Characters).WithOne(x => x.SearchTerm).HasForeignKey(x => x.SearchTermId);
            modelBuilder.Entity<SearchTermDbModel>().HasMany(x => x.SearchDates).WithOne(x => x.SearchTerm).HasForeignKey(x => x.SearchTermId);

            modelBuilder.Entity<SearchDateDbModel>().HasKey(x => x.Id);
            modelBuilder.Entity<SearchDateDbModel>().Property(x => x.SearchDate).IsRequired();
            modelBuilder.Entity<SearchDateDbModel>().Property(x => x.SearchTermId).IsRequired();

            modelBuilder.Entity<SearchTermCharactersDbModel>().HasKey(x => x.Id);
            modelBuilder.Entity<SearchTermCharactersDbModel>().Property(x => x.Count).IsRequired();
            modelBuilder.Entity<SearchTermCharactersDbModel>().Property(x => x.Character).IsRequired();
            modelBuilder.Entity<SearchTermCharactersDbModel>().Property(x => x.SearchTermId).IsRequired();
        }
    }
}
