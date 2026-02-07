using Microsoft.EntityFrameworkCore;
using CarGallery.Domain.Entities;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
namespace CarGallery.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Car> Cars => Set<Car>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Admin User
        var passwordHash = BCrypt.Net.BCrypt.HashPassword("12345");
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", PasswordHash = passwordHash, Role = "Admin" }
        );
    }
}
