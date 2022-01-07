using Microsoft.EntityFrameworkCore;
using SoftwareEngineering.Entities;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public BookContext(DbContextOptions options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}