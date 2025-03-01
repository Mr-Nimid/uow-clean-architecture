using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace Test;

public class RepositoryTests
{
    private readonly AppDbContext _context;
    private readonly IRepository<YourEntity, int> _repository;

    public RepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestInMemoryDb") // Use an in-memory database for testing
            .Options;

        _context = new AppDbContext(options);
        _repository = new Repository<YourEntity, int>(_context);

        // Optionally, initialize the database with some test data
        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task TestAddEntity()
    {
        // Arrange
        var entity = new YourEntity { Id = 1, Name = "Test Entity" };

        // Act
        await _repository.AddAsync(entity);
        await _context.SaveChangesAsync();

        // Assert
        var result = await _repository.GetByIdAsync(entity.Id);
        Assert.NotNull(result);
        Assert.Equal("Test Entity", result.Name);
    }
}