using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // OnModelCreating lets us tell EF Core how our domain classes
        // should be represented as database relationships.
        //
        // User has many Books.
        // WithMany() means Book does not need a User navigation property.
        //
        // EF Core creates a join table to store which User has which Book.
        modelBuilder.Entity<User>()
            .HasMany(user => user.Books)
            .WithMany();
    }
}