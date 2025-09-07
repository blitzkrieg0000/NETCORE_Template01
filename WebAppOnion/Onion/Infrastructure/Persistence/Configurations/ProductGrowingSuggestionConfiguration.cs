using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;


public class ProductGrowingSuggestionConfiguration : IEntityTypeConfiguration<ProductGrowingSuggestion> {
    public void Configure(EntityTypeBuilder<ProductGrowingSuggestion> builder) {
        builder.ToTable("ProductGrowingSuggestion");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.Property(e => e.Description).HasColumnName("description");

        builder.Property(e => e.Image).HasColumnName("image");

        builder.Property(e => e.ProductGrowingSuggestionCategoryId).HasColumnName("product_growing_suggestion_category_id");

        builder.Property(e => e.Title).HasColumnName("title");

        builder.HasOne(d => d.ProductGrowingSuggestionCategory)
            .WithMany(p => p.ProductGrowingSuggestions)
            .HasForeignKey(d => d.ProductGrowingSuggestionCategoryId)
            .HasConstraintName("productgrowingsuggestion_fk");

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
