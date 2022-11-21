using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Entities;
using Products.Domain.Mementos;

namespace Products.Infrastructure.EntityFramework.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<ProductMemento>
{
    public void Configure(EntityTypeBuilder<ProductMemento> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired();

        builder.HasMany(p => p.Reviews).WithOne(r => r.Product).IsRequired();
    }
}