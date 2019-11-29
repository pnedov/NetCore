using Microsoft.EntityFrameworkCore;

namespace MoviesBox.EFModel
{
  public class DbMovieContext : DbContext
  {
    public DbMovieContext() : base() { }
    public DbMovieContext(DbContextOptions options) : base(options)
    {
      Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Data Source=BBCBROADCAST\SQLEXPRESS;Initial Catalog=MovieBox;Integrated Security=True;");

      base.OnConfiguring(optionsBuilder);
    }

    public DbSet<DbRating> Ratings { get; set; }
    public DbSet<DbMovieFullInfo> Movies { get; set; }
  }
}
