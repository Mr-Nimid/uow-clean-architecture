using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations from the assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Automatically register all DbSets dynamically based on entity types in the assembly
        var entityTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Entity<>)));

        foreach (var entityType in entityTypes)
        {
            // This ensures each entity gets registered as a DbSet dynamically
            modelBuilder.Entity(entityType);
        }
    }
}