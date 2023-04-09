using Microsoft.EntityFrameworkCore;
using MoneyHunter.Entities.Entities.Implementations;

namespace MoneyHunter.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<UserEntity> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MoneyHunter;Trusted_Connection=True;");
    }
}
