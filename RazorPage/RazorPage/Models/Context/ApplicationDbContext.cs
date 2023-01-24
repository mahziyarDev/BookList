using Microsoft.EntityFrameworkCore;

namespace RazorPage.Models.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
    {

    }


    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }
}