using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Entities;
using Products.Domain.Mementos;

namespace Products.Infrastructure.EntityFramework.Configurations;

internal sealed class ReviewConfiguration : IEntityTypeConfiguration<ReviewMemento>
{
    public void Configure(EntityTypeBuilder<ReviewMemento> builder)
    {
        builder.ToTable(nameof(Review));
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Description)
            .IsRequired();

        builder.HasOne(r => r.Product).WithMany(p => p.Reviews).IsRequired();
    }
}