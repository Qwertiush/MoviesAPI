using Microsoft.EntityFrameworkCore;
using tut.Entities;

namespace tut.Data;

public class MovieStoreContext(DbContextOptions<MovieStoreContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Genre>().HasData(
            new {Id = 1, Name = "Action"},
            new {Id = 2, Name = "Horror"},
            new {Id = 3, Name = "Nwm"},
            new {Id = 4, Name = "Comedy"}
        );
    }

}
