using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class YourEntityConfiguration : IEntityTypeConfiguration<YourEntity>
{
    public void Configure(EntityTypeBuilder<YourEntity> builder)
    {
        builder.ToTable("YourEntities"); // Table name in the database

        builder.HasKey(e => e.Id); // Primary key
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100); // Example property configuration
    }
}