using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;


public class ProductGrowingSuggestionCategoryConfiguration : IEntityTypeConfiguration<ProductGrowingSuggestionCategory> {
    public void Configure(EntityTypeBuilder<ProductGrowingSuggestionCategory> builder) {
        builder.ToTable("ProductGrowingSuggestionCategory");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.Property(e => e.Name).HasColumnName("name");

        builder.Property(e => e.ModifiedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("modified_time");

        builder.Property(e => e.CreatedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_time")
            .HasDefaultValueSql("((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)");

        builder.Property(e => e.DeletedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("deleted_time");
    }
}
