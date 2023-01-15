using Microsoft.EntityFrameworkCore;
using PrincessChoicer.lab4.db.entity;

namespace PrincessChoicer.lab4.db.conf;

public sealed class EnvironmentContext : DbContext
{
    public DbSet<SearchTry> SearchTries { get; set; }

    public EnvironmentContext(DbContextOptions<EnvironmentContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SearchTry>()
            .HasMany(searchTry => searchTry.Challengers)
            .WithOne(contender => contender.SearchTry);

        modelBuilder.Entity<SearchTry>()
            .HasIndex(searchLoveTry => searchLoveTry.Name)
            .IsUnique();
    }
}