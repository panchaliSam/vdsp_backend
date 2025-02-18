using Microsoft.EntityFrameworkCore;
using Server.Domain.Models.Entities;

// Adjust the namespace as needed

namespace Server.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    // DbSets for User and Customer entities
    public DbSet<User> User { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<Package> Package { get; set; }
    public DbSet<Staff> Staff { get; set; }

    // Override OnModelCreating if you need to add custom configurations for your models
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User-Related Configuration
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Customer-Related Configuration
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.CusId);

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();

        // Configure Foreign Key relationship
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.User)
            .WithMany()  // Assuming one user can be associated with many customers
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);  // Ensures cascading delete behavior if needed

        // Additional configurations for any other relationships or constraints can go here
    }
}